using Progress.Sitefinity.AspNetCore.SitefinityApi.Dto;
using Renderer.ViewModels;
using System.Collections.Generic;

namespace Renderer.Dto
{
    public class VaccinationSite : ISdkItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string AgeGroup { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public decimal FirstDosis { get; set; }
        public decimal SecondDosis { get; set; }

        public decimal TotalDosis { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public List<ScheduleViewModel> Schedule { get; set; }
    }
}
