using Progress.Sitefinity.AspNetCore.SitefinityApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renderer.Dto
{
    public class SiteDetail : ISdkItem
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        public string Region { get; set; }

        public int LocationType { get; set; }

        public int SiteType { get; set; }

        public string Accesibility { get; set; }

        public int AgeGroup { get; set; }

        public string VaccineType { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int FirstDose { get; set; }

        public int SecondDose { get; set; }

        public int TotalDose { get; set; }

        public ScheduleDto[] Schedule { get; set; }

        public int Hypertension { get; set; }

        public int Diabetes { get; set; }

        public int HeartDisease { get; set; }

        public int ChronicRespiratoryDiseases { get; set; }

        public int ChronicKidneyDisease { get; set; }

        public int ObesityGrade3 { get; set; }

        public int MorbidObesity { get; set; }

        public int Cancer { get; set; }

        public int HIVAIDS { get; set; }

        public int Transplant { get; set; }

        public Image[] Image { get; set; }
    }

}
