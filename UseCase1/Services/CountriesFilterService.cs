using UseCase1.ExternalApis;
using UseCase1.Models;

namespace UseCase1.Services;

public class CountriesFilterService: ICountriesFilterService
{
    public IEnumerable<Country> FilterByName(string countryName, List<Country> sourceCountries)
    {
        return sourceCountries.Where(a => a.Name.Common.Contains(countryName, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Country> FilterByPopulation(int population, List<Country> sourceCountries)
    {
        return sourceCountries.Where(a => a.Population < population);
    }
}
