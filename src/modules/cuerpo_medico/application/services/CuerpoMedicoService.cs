using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs;

public class CuerpoMedicoService : ICuerpoMedicoService
{
private readonly ICityRepository _cityRepository;

  public CityService(ICityRepository countryRepository)
  {
      _cityRepository = countryRepository;
  }
  public async Task AddCityAsync(City city)
  {
      _cityRepository.Add(city);
      await _cityRepository.SaveAsync();
  }

  public async Task<IEnumerable<City?>> GetAllCities()
  {
      return await _cityRepository.GetAllAsync();
  }

  public async Task<City?> GetCityById(int id)
  {
      return await _cityRepository.GetByIdAsync(id);
  }

  public async Task RemoveCityAsync(int id)
  {
      var city = await _cityRepository.GetByIdAsync(id);
      if (city != null)
      {
          _cityRepository.Remove(city);
          await _cityRepository.SaveAsync();
      }
  }

  public async Task UpdateCityAsync(int id, City country)
  {
      var existingCity = await _cityRepository.GetByIdAsync(id);
      if (existingCity != null)
      {
          existingCity.Name = country.Name;
          existingCity.RegionId = country.RegionId;
          _cityRepository.Update(existingCity);
          await _cityRepository.SaveAsync();
      }
  }
}
