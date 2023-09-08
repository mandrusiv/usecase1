using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using UseCase1.Models;
using UseCase1.Services;

namespace UseCase1.Tests;

[TestFixture]
public class ExternalCountriesUtilsTests
{

    [TestCase(null)]
    [TestCase("")]
    public void FilterByName_CountryNameIsNullEmpty_ShouldReturnWholeList(string name)
    {
        // Arrange
        var list = GetCountries();

        // Act
        var result = list.FilterByName(name).ToList();

        // Asset
        result.Count.Should().Be(3);
    }

    [TestCase("UK")]
    [TestCase("Uk")]
    [TestCase("uk")]
    [TestCase("uK")]
    public void FilterByName_CountryNameIsDefined_ShouldReturnFilteredList(string name)
    {
        // Arrange
        var list = GetCountries();

        // Act
        var result = list.FilterByName(name).ToList();

        // Asset
        result.Count.Should().Be(1);
    }


    [Test]
    public void FilterByPopulation_PopulationIsNull_ShouldReturnWholeList()
    {
        // Arrange
        var list = GetCountries();

        // Act
        var result = list.FilterByPopulation(null).ToList();

        // Asset
        result.Count.Should().Be(3);
    }

    [Test]
    public void FilterByPopulation_PopulationIsDefined_ShouldReturnTwoOfThree()
    {
        // Arrange
        var list = GetCountries();

        // Act
        var result = list.FilterByPopulation(40000000).ToList();

        // Asset
        result.Count.Should().Be(2);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("desc")]
    [TestCase("asc")]
    [TestCase("d")]
    [TestCase("a")]
    public void SortByName_InvalidOrderIsDefined_ShouldReturnNotSortedList(string order)
    {
        // Arrange
        var list = GetCountries();


        // Act
        var result = list.SortByName(order).ToList();

        // Asset
        result.First().Name.Common.Should().Be(list.First().Name.Common);
        result.First().Population.Should().Be(list.First().Population);
        result.Last().Name.Common.Should().Be(list.Last().Name.Common);
        result.Last().Population.Should().Be(list.Last().Population);
    }

    [Test]
    public void SortByName_Ascend_ShouldReturnNotSortedList()
    {
        // Arrange
        var list = GetCountries();

        // Act
        var result = list.SortByName("ascend").ToList();

        // Asset
        result[0].Name.Common.Should().Be("Belgium");
        result[1].Name.Common.Should().Be("Poland");
        result[2].Name.Common.Should().Be("Ukraine");
    }

    [Test]
    public void SortByName_Descend_ShouldReturnNotSortedList()
    {
        // Arrange
        var list = GetCountries();

        // Act
        var result = list.SortByName("descend").ToList();

        // Asset
        result[2].Name.Common.Should().Be("Belgium");
        result[1].Name.Common.Should().Be("Poland");
        result[0].Name.Common.Should().Be("Ukraine");
    }

    [Test]
    public void GetPagedData_PageSizeIsNotDefined_ShouldReturnWholeList()
    {
        // Arrange
        var list = GetCountries();

        // Act
        var result = list.GetPagedData(null).ToList();

        // Asset
        result.Count.Should().Be(3);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void GetPagedData_PageSizeIsDefined_ShouldReturn(int count)
    {
        // Arrange
        var list = GetCountries();

        // Act
        var result = list.GetPagedData(count).ToList();

        // Asset
        result.Count.Should().Be(count);
    }


    private List<ExternalCountry> GetCountries()
    {
        return new List<ExternalCountry>
        {
            new()
            {
                Name = new CountryName
                {
                    Common = "Ukraine"
                },

                Population = 36744634,
            },
            new()
            {
                Name = new CountryName
                {
                    Common = "Belgium"
                },

                Population = 11686140,
            },
            new()
            {
                Name = new CountryName
                {
                    Common = "Poland"
                },

                Population = 41026067,
            }
        };
    }
}
