using UseCase1.Models;

namespace UseCase1.Services;

public static class ExternalCountriesUtils
{
    private const string AscendingOrder = "ascend";
    private const string DescendingOrder = "descend";

    public static IEnumerable<ExternalCountry> FilterByName(this IEnumerable<ExternalCountry> sourceCountries, string? countryName)
    {
        return string.IsNullOrEmpty(countryName) ? sourceCountries : sourceCountries.Where(a => a.Name.Common.Contains(countryName, StringComparison.OrdinalIgnoreCase));
    }

    public static IEnumerable<ExternalCountry> FilterByPopulation(this IEnumerable<ExternalCountry> sourceCountries, int? population)
    {
        return population == null ? sourceCountries : sourceCountries.Where(a => a.Population < population);
    }

    public static IEnumerable<ExternalCountry> SortByName(this IEnumerable<ExternalCountry> sourceCountries, string? order)
    {
        return order == DescendingOrder
            ? sourceCountries.OrderByDescending(a => a.Name.Common)
            : order == AscendingOrder
                ? sourceCountries.OrderBy(a => a.Name.Common)
                : sourceCountries;
    }

    public static IEnumerable<ExternalCountry> GetPagedData(this IEnumerable<ExternalCountry> sourceCountries, int? pageSize)
    {
        return pageSize.HasValue ? sourceCountries.Take(pageSize.Value) : sourceCountries;
    }
}
