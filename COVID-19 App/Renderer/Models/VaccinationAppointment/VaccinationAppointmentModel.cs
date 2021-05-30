using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Net.Http.Headers;
using Progress.Sitefinity.AspNetCore.SitefinityApi;
using Progress.Sitefinity.AspNetCore.SitefinityApi.Exceptions;
using Renderer.Dto;
using Renderer.ViewModels;
using Renderer.ViewModels.VaccinationAppointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Renderer.Models.Appointment
{
    public class VaccinationAppointmentModel : IVaccinationAppointmentModel
    {
        private const string CacheKey = "_VaccinationSiteData_Key";

        private IMemoryCache _cache;
        private readonly IRestClient _service;

        private static TokenClient tokenClient;


        public static readonly Dictionary<string, string> AdditionalParameters = new Dictionary<string, string>()
        {
            { "membershipProvider", "Default" }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="SitefinityDataViewComponent"/> class.
        /// </summary>
        /// <param name="service">The rest service.</param>
        public VaccinationAppointmentModel(IRestClient service, IMemoryCache cache)
        {
            _service = service;
            _cache = cache;
        }

        public async Task<AppointmentViewModel> GetViewModel(AppointmentDataViewModel appointmentDataViewModel)
        {

            AppointmentViewModel model = new();
            IList<VaccinationSiteViewModel> vaccinationFullSites = await GetVaccinationSites();

            if (vaccinationFullSites != null)
            {
                if (string.IsNullOrEmpty(appointmentDataViewModel.Region))
                {
                    model.Region = vaccinationFullSites[0].Region;
                    model.City = vaccinationFullSites[0].City;
                }
                else
                {
                    model.Region = appointmentDataViewModel.Region;
                }

                var regions = vaccinationFullSites
                            .Select(a => new SelectListItem()
                            {
                                Value = a.Region,
                                Text = a.Region
                            }).Distinct();

                model.Regions = new List<SelectListItem>();
                foreach (var item in regions)
                {
                    var region = model.Regions.FirstOrDefault(c => c.Text == item.Text);
                    if (region == null)
                    {
                        model.Regions.Add(item);
                    }
                }

                model.Cities = vaccinationFullSites
                          .Where(i => i.Region == model.Region)
                          .Select(a => new SelectListItem()
                          {
                              Value = a.City,
                              Text = a.City
                          }).Distinct()
                          .ToList();

                if (!string.IsNullOrEmpty(appointmentDataViewModel.City))
                    model.City = appointmentDataViewModel.City;
                else if (model.Cities != null || model.Cities.Any())
                    model.City = model.Cities[0].Value;
                else
                    model.City = vaccinationFullSites[0].City;

                model.Sites = vaccinationFullSites
                         .Where(i => i.City == model.City)
                         .Select(a => new SelectListItem()
                         {
                             Value = a.Name,
                             Text = a.Name
                         }).Distinct()
                         .ToList();


                model.Site = model.Sites[0].Value;
            }
            model.Birthday = DateTime.Today;
            model.AppointmentDate = DateTime.Today;
            return model;
        }


        public async Task<IList<VaccinationSiteViewModel>> GetVaccinationSites()
        {
            IList<VaccinationSiteViewModel> cacheEntry;

            // Look for cache key.
            if (!_cache.TryGetValue(CacheKey, out cacheEntry))
            {
                // when using the OData client, the URL is automatically prefixed with the value of web the service and the sitefinity instance URL
                // we use an expand the get the related image

                var getAllArgs = new GetAllArgs
                {
                    // required parameter, specifies the items to work with
                    Type = "Telerik.Sitefinity.DynamicTypes.Model.VaccinationData.VaccinationSite"
                };

                var response = await this._service.GetItems<VaccinationSite>(getAllArgs);
                var viewModels = response.Items.Select(x => this.GetItemViewModel(x)).ToList();

                if (viewModels != null)
                {
                    cacheEntry = viewModels;

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

        private VaccinationSiteViewModel GetItemViewModel(VaccinationSite site)
        {
            var viewModel = new VaccinationSiteViewModel()
            {
                Name = site.Name,
                Region = site.Region,
                AgeGroup = site.AgeGroup,
                EmailAddress = site.EmailAddress,
                PhoneNumber = site.PhoneNumber,
                Country = site.Country,
                City = site.City,
                TotalDosis = site.TotalDosis

            };

            return viewModel;
        }


        public async Task<bool> AddAppointmentResponse(AppointmentViewModel model)
        {
            bool isAdded = false;
            var provider = "OpenAccessProvider";
            var itemType = "Telerik.Sitefinity.DynamicTypes.Model.VaccinationData.Vaccinationresponse";

            var createItemArgs = new CreateArgs()
            {
                Type = itemType,

                Data = new AppointementResponse()
                {
                    Identifier = model.Identifier,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Birthday = model.Birthday.ToUniversalTime(),
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    AppointmentDate = model.AppointmentDate.ToUniversalTime(),
                    AppointmentTime = model.AppointmentTime.ToUniversalTime(),
                    AppointmentDetails = model.AppointmentDetails,
                    Site = model.Site,
                    UrlName = model.FirstName + "-" + Guid.NewGuid().ToString(),
                },

                Provider = provider
            };

            try
            {
                #region Get Token
                var client = new HttpClient();

                TokenClientOptions tokenClientOptions = new TokenClientOptions();
                tokenClientOptions.ClientId = "testApp";
                tokenClientOptions.ClientSecret = "secret";
                tokenClientOptions.Address = "https://localhost:5001/Sitefinity/Authenticate/OpenID/connect/token";

                tokenClient = new TokenClient(client, tokenClientOptions);
                TokenResponse tokenResponse = RequestToken();
                string accessToken = "Bearer " + tokenResponse.AccessToken;

                #endregion

                createItemArgs.AdditionalHeaders.Add(HeaderNames.Authorization, accessToken);

                var createResponse = await this._service.CreateItem<AppointementResponse>(createItemArgs);
                isAdded = true;
            }
            catch (ErrorCodeException error)
            {
                isAdded = false;

                if (error != null)
                {
                   throw new ApplicationException("Cannot create items. Actual error is " + error.Message);
                }
            }
            return isAdded;
        }

        /// <summary>
        /// Request the token
        /// </summary>
        /// <returns></returns>
        private static TokenResponse RequestToken()
        {
            //This is call to the token endpoint with the parameters that are set
            TokenResponse tokenResponse = tokenClient.RequestPasswordTokenAsync("admin@sitefinity.com", "admin1234", "openid offline_access", null).Result;

            if (tokenResponse.IsError)
            {
                throw new ApplicationException("Couldn't get access token. Error: " + tokenResponse.Error);
            }

            return tokenResponse;
        }

    }
}