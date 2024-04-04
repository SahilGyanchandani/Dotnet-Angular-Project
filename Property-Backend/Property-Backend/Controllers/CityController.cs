using MailKit.Net.Imap;
using MailKit.Security;
using MailKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Property_Backend.Data;
using Property_Backend.Data.CityRepo;
using Property_Backend.Model;
using Property_Backend.Model.Dto.CityDto;
using System.Net.Mail;
using MimeKit;
using MailKit.Search;
using Property_Backend.Services;

namespace Property_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapProtocol _imap;
        

        public CityController(ApplicationDbContext context ,IConfiguration configuration, ICityRepository cityRepository, IMapProtocol imap)
        {
            _context = context;
            _configuration = configuration;
            _cityRepository = cityRepository;
            _imap = imap;
        }
        [HttpGet("GetCities")]
        public async Task<IActionResult> GetAllCities()
        {
            var cities= await _cityRepository.GetCitiesAsync();

            return Ok(cities);
        }

        [HttpPost("AddCity")]
        public async Task<IActionResult> AddCity(string cityName)
        {
            try
            {
                var city = new City
                {
                    cityName = cityName,
                    createdDate = DateTime.UtcNow,
                    updatedDate = DateTime.UtcNow,
                    isDeleted = false
                };

               await _cityRepository.AddCitiesAsync(city);  

                return Ok("City added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }

        }

        [HttpDelete("DeleteCity")]
        public async Task<IActionResult> DeleteCity(int cityId)
        {
            try
            {
                var city= await _context.Cities.FindAsync(cityId);
                if (city != null)
                {
                    await _cityRepository.DeleteCitiesAsync(city);
                    return Ok("City deleted Successfully.");
                }
                else
                {
                    return NotFound("City not found");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"An error while deleting the city:{ex.Message}");
            }

        }

        [HttpPut("updateCity")]
        public async Task<IActionResult> UpdateCity([FromBody] cityUpdateDto cityUpdate)
        {
            try
            {
                var existingCity = await _cityRepository.GetCityIdAsync(cityUpdate.cityId);
                if (existingCity == null)
                {
                    return NotFound("City not found");
                }
                else
                {
                    existingCity.cityName = cityUpdate.cityName;
                    existingCity.updatedDate = DateTime.UtcNow;

                    await _cityRepository.UpdateCityAsync(existingCity);
                    return Ok("City updated successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet("AwsParameter")]
        public IActionResult GetString()
        {
            var jwtKey = _configuration["Jwt:Key"];

            return Ok(new { jwtKey });   
        }

        [HttpGet("AzureKeyVault")]
        public IActionResult GetParameter()
        {
            var jwtKey = _configuration["JwtKey"];

            return Ok(new { jwtKey });
        }

        [HttpGet("FetchEmail")]
        public IActionResult GetEmails()
        {
            // Call the service method to fetch emails
            var emails = _imap.FetchEmails("imap.example.com", 993, "", "");
            return Ok(emails);
        }



    }
}
