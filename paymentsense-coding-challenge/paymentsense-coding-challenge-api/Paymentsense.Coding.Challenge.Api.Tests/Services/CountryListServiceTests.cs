using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Moq.Protected;
using Paymentsense.Coding.Challenge.Api.Common;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class CountryListServiceTests
    {
        private readonly CountryListService service;
        private readonly Mock<IHttpClientFactory> _clientFactory;

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

        private List<Country> expectedCountries;

        public CountryListServiceTests()
        {
            this._clientFactory = new Mock<IHttpClientFactory>();
            this.service = new CountryListService(this._clientFactory.Object);
            this.expectedCountries = new List<Country>() { country };
        }

        [Fact]
        public void Get_ReturnsCountryList()
        {
            HttpClient client = MockHttpClientFactory();
            _clientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);


            var result = service.GetCountriesAsync().Result;

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedCountries);
        }

        private static HttpClient MockHttpClientFactory()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("[{\"name\":\"Name\",\"alpha3Code\":\"Alpha3Code\",\"flag\":\"flag\",\"population\":1234,\"timezones\":[\"tz\"],\"currencies\":[{\"code\":\"curCode\",\"name\":\"curName\",\"symbol\":\"curSym\"}],\"capital\":\"Capital\",\"languages\":[{\"iso639_1\":\"Iso639_1\",\"iso639_2\":\"Iso639_2\",\"name\":\"langName\",\"nativeName\":\"NativeName\"}],\"borders\":[\"Borders\"]}]"),
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            return client;
        }
    }
}
