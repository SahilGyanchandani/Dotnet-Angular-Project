using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Property_Backend.Data;
using Property_Backend.Data.CityRepo;
using Property_Backend.Model;

namespace Property_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly ApplicationDbContext _context;
        public CityController(ApplicationDbContext context , ICityRepository cityRepository)
        {
            _context = context;
            _cityRepository = cityRepository;
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
                    cityName = cityName
                };

               await _cityRepository.AddCitiesAsync(city);  

                return Ok("City added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error while adding the city:{ex.Message}");
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

        
    }
}
