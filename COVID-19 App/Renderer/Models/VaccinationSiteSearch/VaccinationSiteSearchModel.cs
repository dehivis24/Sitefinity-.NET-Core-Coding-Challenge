using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Progress.Sitefinity.AspNetCore.SitefinityApi;
using Progress.Sitefinity.AspNetCore.SitefinityApi.Filters;
using Progress.Sitefinity.Renderer.Entities.Content;
using Renderer.Dto;
using Renderer.Entities.VaccinationSiteSearch;
using Renderer.Models.VaccinationSiteSearch;
using Renderer.ViewModels;

namespace Renderer.Models.VaccinationSiteSearch
{
    public class VaccinationSiteSearchModel : IVaccinationSiteSearchModel
    {
        private readonly IRestClient service;

        /// <summary>
        /// Initializes a new instance of the <see cref="SitefinityDataViewComponent"/> class.
        /// </summary>
        /// <param name="service">The rest service.</param>
        public VaccinationSiteSearchModel(IRestClient service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets the view models.
        /// </summary>
        /// <param name="entity">The entity object.</param>
        /// <returns>The generated view models.</returns>
        public async Task<VaccinationSiteViewModel> GetViewModels(VaccinationSiteSearchEntity entity)
        {
            var viewModel = new VaccinationSiteViewModel();
            var provider = "OpenAccessProvider";

            // when using the OData client, the url is automatically prefixed with the value of web the service and the sitefinity instance url
            // we use an expand the get the related image
            var getAllArgs = new GetAllArgs
            {
                // required parameter, specifies the items to work with
                Type = "Telerik.Sitefinity.DynamicTypes.Model.VaccinationData.VaccinationSite"
            };

            // optional parameter, specifies the fields to be returned, if not specified
            // the default service response fields will be returned
            getAllArgs.Fields = new List<string>() { "Id", "Name", "Region", "AgeGroup", "EmailAddress", "PhoneNumber",  "FirstDose", "SecondDose", "TotalDose",
                                                    "Country", "State", "City", "Latitude", "Longitude", "Schedule"};

            getAllArgs.Provider = provider;

            var response = await service.GetItems<VaccinationSite>(getAllArgs);

            string pageURL = string.Empty;
            if (entity.Page.Content[0].Variations != null && entity.Page.Content[0].Variations.Length > 0)
            {
                var pageId = entity.Page.Content[0].Variations[0].Filter.Value;

                var getAllArgsPage = new GetItemArgs()
                {
                    Id = pageId,
                    Type = KnownContentTypes.Pages
                };

                getAllArgsPage.Fields.Add(nameof(Page.ViewUrl));
                var responsePage = await this.service.GetItem<Page>(getAllArgsPage);
                pageURL = !string.IsNullOrEmpty(responsePage.ViewUrl) ? responsePage.ViewUrl : "";
            }

            viewModel = response.Items.Select(x => this.GetItemViewModel(x, pageURL)).FirstOrDefault();

            return viewModel;
        }

        public async Task<List<VaccinationSiteViewModel>> GetListSiteViewModels()       
        {
            // when using the OData client, the URL is automatically prefixed with the value of web the service and the sitefinity instance URL
            // we use an expand the get the related image
            var provider = "OpenAccessProvider";

            var getAllArgs = new GetAllArgs
            {
                // required parameter, specifies the items to work with
                Type = "Telerik.Sitefinity.DynamicTypes.Model.VaccinationData.VaccinationSite"
            };

            // optional parameter, specifies the fields to be returned, if not specified
            // the default service response fields will be returned
            getAllArgs.Fields = new List<string>() { "Id", "Name", "Region", "AgeGroup", "EmailAddress", "PhoneNumber",  "FirstDose", "SecondDose", "TotalDose",
                                                    "Country", "State", "City", "Latitude", "Longitude", "Schedule"};

            getAllArgs.Provider = provider;

            var response = await this.service.GetItems<VaccinationSite>(getAllArgs);

            string pageURL = string.Empty;     

            var viewModels = response.Items.Select(x => this.GetItemViewModel(x, pageURL)).ToList();

            return viewModels;
        }

        private VaccinationSiteViewModel GetItemViewModel(VaccinationSite item, string page)
        {
            var viewModel = new VaccinationSiteViewModel()
            {
                Name = item.Name,
                Region = item.Region,
                City = item.City,
                Country = item.Country,
                Latitude = item.Latitude,
                Longitude = item.Longitude,
                EmailAddress = item.EmailAddress,
                PhoneNumber = item.PhoneNumber,
                DetailPage = !string.IsNullOrEmpty(page) ? page : null      
            };

            return viewModel;
        }


    }
}
