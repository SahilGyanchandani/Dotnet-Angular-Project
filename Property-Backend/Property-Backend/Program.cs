
using Microsoft.EntityFrameworkCore;
using Property_Backend.Data;
using Property_Backend.Data.CityRepo;
using Property_Backend.Helper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMappingProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICityRepository, CityRepository>();

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
