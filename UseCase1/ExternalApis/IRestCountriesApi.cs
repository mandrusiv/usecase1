using RestEase;
using UseCase1.Models;

namespace UseCase1.ExternalApis;

[BasePath("https://restcountries.com/v3.1/")]
public interface IRestCountriesApi
{
    [Get("all")]
    Task<Country[]> GetAll();
}
