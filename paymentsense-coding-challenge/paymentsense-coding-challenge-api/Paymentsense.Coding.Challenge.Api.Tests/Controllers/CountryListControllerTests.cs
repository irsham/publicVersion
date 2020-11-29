using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Paymentsense.Coding.Challenge.Api.Common;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using System.Collections.Generic;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class CountryListControllerTests
    {
        private readonly CountryListController controller;
        private readonly Mock<ICountryListService> _countryListService;
        private readonly IMemoryCache _cache;

        private Country country = new Country()
        {
            Alpha3Code = "Alpha3Code",
            Borders = new List<string>() { "Borders" },
            Capital = "Capital",
            Currencies = new List<Currency>() { new Currency() { Code = "curCode", Name = "curName", Symbol = "curSym" } },
            Flag = "flag",
            Name = "Name",
            Population = 1234,
            Languages = new List<Language>() { new Language() { Name = "langName", Iso639_1 = "Iso639_1", Iso639_2 = "Iso639_2", NativeName = "NativeName" } },
            Timezones = new List<string>() { "tz" }
        };

        private List<Country> countries;

        public CountryListControllerTests()
        {
            this._countryListService = new Mock<ICountryListService>();
            this._cache = new MemoryCache(new MemoryCacheOptions());
            this.controller = new CountryListController(this._cache, this._countryListService.Object);
            this.countries = new List<Country>() { country };
        }

        [Fact]
        public void Get_ReturnsNullCountryListFromCache()
        {
            _cache.Set(CommonConstants.countryListCacheKey, countries);
            var result = controller.Get().Result;

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(countries);
        }

        [Fact]
        public void Get_ReturnsCountryListFromService()
        {
            object expectedValue = countries;
            _cache.Remove(CommonConstants.countryListCacheKey);
            this._countryListService.Setup(x => x.GetCountriesAsync()).ReturnsAsync(countries);
            var result = controller.Get().Result;

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(countries);
        }
    }
}
