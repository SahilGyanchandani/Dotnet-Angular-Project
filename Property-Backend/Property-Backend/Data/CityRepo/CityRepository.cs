using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Property_Backend.Model;
using Property_Backend.Model.Dto.CityDto;

namespace Property_Backend.Data.CityRepo
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CityRepository(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddCitiesAsync(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCitiesAsync(City city)
        {
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

        public async Task<List<cityResponseDto>> GetCitiesAsync()
        {
            var cities = await _context.Cities.ToListAsync();
            //var selectedField = cities.Select(c => new cityResponseDto {cityId= c.cityId,cityName= c.cityName }).ToList();

            return _mapper.Map<List<cityResponseDto>>(cities);
        }

        public async Task<City> GetCityIdAsync(int cityId)
        {
            var getCity = await _context.Cities.FindAsync(cityId);
            return getCity;
        }

        public async Task UpdateCityAsync(City city)
        {
            _context.Cities.Update(city);
            await _context.SaveChangesAsync();
        }
    }
}
