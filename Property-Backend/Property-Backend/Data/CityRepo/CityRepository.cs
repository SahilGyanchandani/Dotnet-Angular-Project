using Microsoft.EntityFrameworkCore;
using Property_Backend.Model;

namespace Property_Backend.Data.CityRepo
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;
        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
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

        public async Task<List<City>> GetCitiesAsync()
        {
            var cities = await _context.Cities.ToListAsync();

            return cities;
        }
    }
}
