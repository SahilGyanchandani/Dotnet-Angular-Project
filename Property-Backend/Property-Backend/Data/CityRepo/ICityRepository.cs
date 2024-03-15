using Property_Backend.Model;

namespace Property_Backend.Data.CityRepo
{
    public interface ICityRepository
    {
        Task<List<City>> GetCitiesAsync();
        Task DeleteCitiesAsync(City city);
        Task AddCitiesAsync(City city);
    }
}
