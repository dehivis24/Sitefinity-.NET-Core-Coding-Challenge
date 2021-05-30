using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Renderer.ViewModels.VaccinationAppointment
{
    public class AppointmentDataViewModel
    {
        public List<SelectListItem> Regions { get; set; }
        public string Region { get; set; }

        public List<SelectListItem> Cities { get; set; }
        public string City { get; set; }

        public List<SelectListItem> Sites { get; set; }
        public string Site { get; set; }
    }
}
