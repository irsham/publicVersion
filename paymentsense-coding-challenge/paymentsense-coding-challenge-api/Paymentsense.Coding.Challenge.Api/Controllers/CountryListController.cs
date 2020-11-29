using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Paymentsense.Coding.Challenge.Api.Common;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryListController : ControllerBase
    {
        private IMemoryCache _cache;
        private ICountryListService _countryListService;

        public CountryListController(IMemoryCache memoryCache, ICountryListService countryListService)
        {
            _cache = memoryCache;
            _countryListService = countryListService;
        }

        // GET: api/CountryList
        [HttpGet]
        public async Task<List<Country>> Get()
        {
            List<Country> countries;

            // Gets the value from cache or else updates it.
            if (!_cache.TryGetValue(CommonConstants.countryListCacheKey, out countries))
            {
                countries = await _countryListService.GetCountriesAsync();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(1));
                _cache.Set(CommonConstants.countryListCacheKey, countries, cacheEntryOptions);
            }
            return countries;
        }
    }
}
