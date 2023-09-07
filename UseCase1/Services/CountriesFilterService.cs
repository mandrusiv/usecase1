using UseCase1.ExternalApis;
using UseCase1.Models;

namespace UseCase1.Services;

public class CountriesFilterService: ICountriesFilterService
{
    private readonly ILogger<CountriesFilterService> _logger;
    private readonly IRestCountriesApi _api;

    public CountriesFilterService(ILogger<CountriesFilterService> logger, IRestCountriesApi api)
    {
        _logger = logger;
        _api = api;
    }

    public async Task<IEnumerable<Country>> GetPreparedCountries(string? countryName, int? population, string? nameSortOrder,
        int? pageSize)
    {
        var countries = await TryGetDataFromExternalApi();

        return countries.ToList().FilterByName(countryName).FilterByPopulation(population)
            .SortByName(nameSortOrder).GetPagedData(pageSize).Select(MapToModel);
    }

    private Country MapToModel(ExternalCountry externalCountry)
    {
        return new Country
        {
            Name = externalCountry.Name.Common,
            Population = externalCountry.Population
        };
    }

    private async Task<IEnumerable<ExternalCountry>> TryGetDataFromExternalApi()
    {
        try
        {
            _logger.LogTrace("Getting data from external API");

            var countries = await _api.GetAll();

            return countries;
        }
        catch (Exception e)
        {
            _logger.LogError("Error while getting data from external API", e);
            throw;
        }
    }
}
