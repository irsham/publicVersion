using Paymentsense.Coding.Challenge.Api.Common;
using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountryListService : ICountryListService
    {
        private readonly IHttpClientFactory _clientFactory;
        public CountryListService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Gets the countries asynchronous.
        /// </summary>
        /// <returns>
        /// Country list
        /// </returns>
        public async Task<List<Country>> GetCountriesAsync()
        {
            List<Country> countries = new List<Country>();
            var request = new HttpRequestMessage(HttpMethod.Get, GenerateURI("all"));
            var client = _clientFactory.CreateClient("restcountries");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                countries = await JsonSerializer.DeserializeAsync
                        <List<Country>>(responseStream, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
            }

            return countries;
        }

        /// <summary>
        /// Generates the URI.
        /// </summary>
        /// <param name="uriPart">The URI part.</param>
        /// <returns>URI string</returns>
        private string GenerateURI(string uriPart) => $"{CommonConstants.restCountriesBaseUrl}{uriPart}";
    }
}
