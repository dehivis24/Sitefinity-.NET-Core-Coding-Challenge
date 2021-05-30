using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Renderer.ViewModels.VaccinationSiteDetail
{
    /// <summary>
    /// The view model.
    /// </summary>
    public class SiteDetailViewModel
    {
        public string Name { get; set; }

        public string Region { get; set; }

        public string LocationType { get; set; }

        public string SiteType { get; set; }

        public string Accesibility { get; set; }

        public string AgeGroup { get; set; }

        public string VaccineType { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string MapDirectionsUrl { get; set; }

        public int FirstDose { get; set; }

        public int SecondDose { get; set; }

        public int TotalDose { get; set; }

        public ScheduleDtoViewModel Schedule { get; set; }

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

        public bool DisplayRiskFactors { get; set; }

        public string VaccinactionInstructions { get; set; }

        public string Image { get; set; }

        public string AppointmentUrl { get; set; }
    }

    public enum LocationType
    {
        [Description("Hospital")]
        Hospital = 1,
        [Description("Health Area")]
        HealthArea = 2,
        [Description("EBAIS")]
        Ebais = 3,
        [Description("Medical Clinic")]
        MedicalClinic = 4,
        [Description("Other")]
        Other = 5
    }

    public enum SiteType
    {
        [Description("Indoor Site")]
        IndoorSite = 1,
        [Description("Drive Through Site")]
        DriveThroughSite = 2
    }

    public enum AgeGroup
    {
        [Description("From 16 to 57 years")]
        Group1 = 0,
        [Description("From 58 to 64 years")]
        Group2 = 1,
        [Description("From 65 to 69 years")]
        Group3 = 2,
        [Description("From 70 to 74 years")]
        Group4 = 3,
        [Description("From 75 to 80 years")]
        Group5 = 4,
        [Description("More than 80 years")]
        Group6 = 5,
    }
}
