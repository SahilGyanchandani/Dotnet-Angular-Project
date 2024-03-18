using Property_Backend.Model;
using Property_Backend.Model.Dto.CityDto;

namespace Property_Backend.Data.CityRepo
{
    public interface ICityRepository
    {
        Task<List<cityResponseDto>> GetCitiesAsync();
        Task DeleteCitiesAsync(City city);
        Task AddCitiesAsync(City city);
        Task<City> GetCityIdAsync(int cityId);
        Task UpdateCityAsync(City city);
    }
}
