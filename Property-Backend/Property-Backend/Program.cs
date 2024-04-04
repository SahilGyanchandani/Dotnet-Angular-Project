
using Amazon.Extensions.NETCore.Setup;
using Amazon.SimpleSystemsManagement;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Property_Backend.Data;
using Property_Backend.Data.CityRepo;
using Property_Backend.Helper;
using Property_Backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

});

// Add services to the container.
builder.Host.ConfigureAppConfiguration((context, config) =>
{
    var settings = config.Build();
    var keyVaultURL = settings["KeyVaultConfiguration:KeyVaultURL"];
    var keyVaultClientId = settings["KeyVaultConfiguration:ClientId"];
    var tenantId = settings["KeyVaultConfiguration:TenantId"];
    var keyVaultClientSecret = settings["KeyVaultConfiguration:ClientSecret"];

    var credential =new ClientSecretCredential(tenantId,keyVaultClientId, keyVaultClientSecret);
    var client = new SecretClient(new Uri(keyVaultURL),credential);
    config.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());
});

builder.Configuration.AddSystemsManager(options=>
{
    options.Path = "/Production/";
    options.ReloadAfter= TimeSpan.FromMinutes(5);
});

//builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
//builder.Services.AddAWSService<IAmazonSimpleSystemsManagement>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMappingProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IMapProtocol, MapProtocol>();    

var app = builder.Build();

app.UseCors(policy =>
{
    policy.WithOrigins("http://localhost:4200") // Allow requests from this origin
          .AllowAnyMethod()                     // Allow any HTTP method
          .AllowAnyHeader();                    // Allow any HTTP headers
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseCors();

app.MapControllers();

app.Run();
