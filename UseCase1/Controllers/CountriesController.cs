using Microsoft.AspNetCore.Mvc;
using UseCase1.Models;

namespace UseCase1.Controllers;
[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{

    private readonly ILogger<CountriesController> _logger;

    public CountriesController(ILogger<CountriesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Countries")]
    public IEnumerable<Country> Get(string? countryName = null, int? population = null)
    {
        return new List<Country>();
    }
}
