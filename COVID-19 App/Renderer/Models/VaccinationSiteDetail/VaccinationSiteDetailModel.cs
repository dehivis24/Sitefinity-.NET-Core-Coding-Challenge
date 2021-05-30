using Microsoft.AspNetCore.Http;
using Progress.Sitefinity.AspNetCore.SitefinityApi;
using Progress.Sitefinity.AspNetCore.SitefinityApi.Filters;
using Progress.Sitefinity.Renderer.Entities.Content;
using Renderer.Dto;
using Renderer.Entities.VaccinationSiteDetail;
using Renderer.ViewModels.VaccinationSiteDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace Renderer.Models.VaccinationSiteDetail
{
    /// <summary>
    /// The model class.
    /// </summary>
    public class VaccinationSiteDetailModel : IVaccinationSiteDetailModel
    {
        private readonly IRestClient service;
        /// <summary>
        /// Initializes a new instance of the <see cref="VaccinationSiteDetailViewComponent"/> class.
        /// </summary>
        /// <param name="service">The rest service.</param>
        public VaccinationSiteDetailModel(IRestClient service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets the view models.
        /// </summary>
        /// <param name="entity">The entity object.</param>
        /// <returns>The generated view models.</returns>
        public async Task<SiteDetailViewModel> GetViewModels(VaccinationSiteDetailEntity entity, HttpRequest request)
        {
            var provider = "OpenAccessProvider";

            // when using the OData client, the url is automatically prefixed with the value of web the service and the sitefinity instance url
            // we use an expand the get the related image
            var getAllArgs = new GetAllArgs
            {
                // required parameter, specifies the items to work with
                Type = "vaccinationsites"
            };

            getAllArgs.Fields = new List<string>() { "Id", "Name", "Region", "LocationType", "SiteType", "Accesibility", "AgeGroup", "VaccineType", "EmailAddress", "PhoneNumber",
                                                    "Country", "State", "City", "Latitude", "Longitude", "FirstDose", "SecondDose", "TotalDose", "Hypertension", "Diabetes", "HeartDisease",
                                                    "ChronicRespiratoryDiseases", "ChronicKidneyDisease", "ObesityGrade3", "MorbidObesity", "Cancer", "HIVAIDS", "Transplant", "Image",
                                                    "Schedule"};

            //Get site name from query string
            string siteName = request.Query["Name"].FirstOrDefault();
            siteName = HttpUtility.HtmlDecode(siteName);

            getAllArgs.Filter = new FilterClause()
            {
                FieldName = "Name",
                //If access by URL set a default value
                FieldValue = siteName == null ? "GRECIA HOSPITAL" : siteName,
                Operator = FilterClause.Operators.Equal
            };

            getAllArgs.Provider = provider;
            
            var response = await service.GetItems<SiteDetail>(getAllArgs);
            var viewModel = response.Items.Select(x => this.GetItemViewModel(x)).FirstOrDefault();
            viewModel.DisplayRiskFactors = entity.DisplayRiskFactors;
            viewModel.VaccinactionInstructions = entity.VaccinationInstructions;


            string pageURL = "";
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
                viewModel.AppointmentUrl = !string.IsNullOrEmpty(pageURL) ? pageURL : null;
            }
            return viewModel;
        }

        private SiteDetailViewModel GetItemViewModel(SiteDetail siteDetail)
        {
            var viewModel = new SiteDetailViewModel()
            {
                Name = siteDetail.Name,
                Region = siteDetail.Region,
                Accesibility = siteDetail.Accesibility,
                VaccineType = siteDetail.VaccineType,
                EmailAddress = siteDetail.EmailAddress,
                PhoneNumber = siteDetail.PhoneNumber,
                Country = siteDetail.Country,
                State = siteDetail.State,
                City = siteDetail.City,
                MapDirectionsUrl = "https://www.google.com/maps/dir/Current+Location/" + siteDetail.Latitude + "," + siteDetail.Longitude,
                FirstDose = siteDetail.FirstDose,
                SecondDose = siteDetail.SecondDose,
                TotalDose = siteDetail.TotalDose,                
                Hypertension = siteDetail.Hypertension,
                Diabetes = siteDetail.Diabetes,
                HeartDisease = siteDetail.HeartDisease,
                ChronicRespiratoryDiseases = siteDetail.ChronicRespiratoryDiseases,
                ChronicKidneyDisease = siteDetail.ChronicKidneyDisease,
                ObesityGrade3 = siteDetail.ObesityGrade3,
                MorbidObesity = siteDetail.MorbidObesity,
                Cancer = siteDetail.Cancer,
                HIVAIDS = siteDetail.HIVAIDS,
                Transplant = siteDetail.Transplant
            };

            viewModel.LocationType = GetDescription((LocationType)siteDetail.LocationType);
            viewModel.SiteType = GetDescription((SiteType)siteDetail.SiteType);
            viewModel.AgeGroup = GetDescription((AgeGroup)siteDetail.AgeGroup);

            List<Thumbnail> result = siteDetail.Image.Any() ? siteDetail.Image[0].Thumbnails.Where(x => x.Title == "0").ToList() : null;
            viewModel.Image = result.Any() ? result[0].Url : null;

            viewModel.Schedule = new ScheduleDtoViewModel();
            if (siteDetail.Schedule != null)
            {
                viewModel.Schedule.Title = siteDetail.Schedule.FirstOrDefault().Title;
                viewModel.Schedule.Schedule = siteDetail.Schedule.FirstOrDefault().Schedule;
            }

            return viewModel;
        }


        public string GetDescription(Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }
    }
}
