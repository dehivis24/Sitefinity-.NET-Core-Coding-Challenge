using Microsoft.Extensions.Caching.Memory;
using Renderer.Entities.VaccinationGraph;
using Renderer.VaccinationGraph.ViewModels;
using Renderer.ViewModels.VaccinationGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Renderer.Models.VaccinationGraph
{
    public class VaccinationGraphModel : IVaccinationGraphModel
    {
        private const string CacheKey = "_VaccinationData_Key";
        private const string DataSourceRepository = "https://raw.githubusercontent.com/owid/covid-19-data/master/public/data/vaccinations/vaccinations.json";
        private const string DefaultCountry = "CRI";

        private IHttpClientFactory _clientFactory;
        private IMemoryCache _cache;

        public VaccinationGraphModel(IHttpClientFactory clientFactory, IMemoryCache cache)
        {
            _clientFactory = clientFactory;
            _cache = cache;
        }

        public async Task<VaccinationDataViewModel> GetViewModel(VaccinationGraphEntity entity) 
        {
            VaccinationDataViewModel model = new();
            IEnumerable<VaccinationInfoViewModel> vaccinationFullData = await GetVaccinationData();

            model.MonthList = new List<KeyValuePair<decimal, string>>();
            var fullMonthList = new[] {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}
                .Take(DateTime.Today.Month).ToList();

            for (int i = 0; i < fullMonthList.Count; ++i)
                model.MonthList.Add(new KeyValuePair<decimal, string>(i, fullMonthList[i]));

            if (vaccinationFullData != null)
            {
                model.CountryList = vaccinationFullData.Select(c => new KeyValuePair<string, string>(c.IsoCode, c.Country)).Distinct().ToList();
                model.DosisPerMonth = new List<decimal>();
                model.SelectedCountry = !string.IsNullOrEmpty(entity.DefaultCountry.ToString()) ? entity.DefaultCountry.ToString() : DefaultCountry;
                model.GraphType = entity.GraphTypeValue.ToString();
                VaccinationInfoViewModel vaccinationInfo = vaccinationFullData.Where(v => v.IsoCode == entity.DefaultCountry.ToString()).FirstOrDefault();

                if (vaccinationInfo != null) 
                {
                    foreach (var month in model.MonthList)
                    {
                        decimal totalDosisByMonth = vaccinationInfo.Data.Where(vd => vd.Date.Month == month.Key).Sum(v => v.DailyVaccinations);
                        model.DosisPerMonth.Add(totalDosisByMonth);
                    }
                }
            }

            return model;
        }

        public async Task<IEnumerable<VaccinationInfoViewModel>> GetVaccinationData()
        {
            IEnumerable<VaccinationInfoViewModel> cacheEntry;

            // Look for cache key.
            if (!_cache.TryGetValue(CacheKey, out cacheEntry))
            {
                var request = new HttpRequestMessage(HttpMethod.Get, DataSourceRepository);

                var client = _clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    cacheEntry = await JsonSerializer.DeserializeAsync<IEnumerable<VaccinationInfoViewModel>>(responseStream);

                    // Set cache options.
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        // Keep in cache for this time, reset time if accessed.
                        .SetSlidingExpiration(TimeSpan.FromMinutes(10));

                    // Save data in cache.
                    _cache.Set(CacheKey, cacheEntry, cacheEntryOptions);
                }
            }

            return cacheEntry;
        }
    }
}
