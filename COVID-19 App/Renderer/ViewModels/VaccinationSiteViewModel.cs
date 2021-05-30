using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renderer.ViewModels
{
    public class VaccinationSiteViewModel
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string AgeGroup { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public decimal TotalDosis { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public List<ScheduleViewModel> Schedule { get; set; }
        public double Distance { get; set; }
        public string DetailPage { get; set; }       

    }
}
