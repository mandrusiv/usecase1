using Microsoft.AspNetCore.Mvc;
using UseCase1.Models;
using UseCase1.Services;

namespace UseCase1.Controllers;
[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ILogger<CountriesController> _logger;
    private readonly ICountriesFilterService _countriesFilterService;

    public CountriesController(ILogger<CountriesController> logger, ICountriesFilterService countriesFilterService)
    {
        _logger = logger;
        _countriesFilterService = countriesFilterService;
    }

    [HttpGet(Name = "Countries")]
    [ProducesResponseType(typeof(IEnumerable<Country>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(string? countryName, int? population, string? nameSortOrder, int? pageSize)
    {
        var data = await _countriesFilterService.GetPreparedCountries(countryName, population, nameSortOrder, pageSize);

        return Ok(data);
    }
}
