using UseCase1.ExternalApis;
using UseCase1.Models;

namespace UseCase1.Services;

public class CountriesFilterService: ICountriesFilterService
{
    private const string AscendingOrder = "ascend";
    private const string DescendingOrder = "descend";
    public IEnumerable<Country> FilterByName(List<Country> sourceCountries, string countryName)
    {
        return sourceCountries.Where(a => a.Name.Common.Contains(countryName, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Country> FilterByPopulation(List<Country> sourceCountries, int population)
    {
        return sourceCountries.Where(a => a.Population < population);
    }

    public IEnumerable<Country> SortByName(List<Country> sourceCountries, string order = AscendingOrder)
    {
        return order == DescendingOrder
            ? sourceCountries.OrderByDescending(a => a.Name.Common)
            : sourceCountries.OrderBy(a => a.Name.Common);
    }

    public IEnumerable<Country> GetPagedData(List<Country> sourceCountries, int pageSize, int pageIndex = 0)
    {
        return sourceCountries.GetRange(pageIndex, pageSize);
    }
}
