using UseCase1.Models;

namespace UseCase1.Services;

public interface ICountriesFilterService
{
    Task<IEnumerable<Country>> GetPreparedCountries(string? countryName, int? population, string? nameSortOrder,
        int? pageSize);
}
