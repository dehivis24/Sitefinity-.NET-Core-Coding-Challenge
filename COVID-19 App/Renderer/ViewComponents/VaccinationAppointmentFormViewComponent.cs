using Microsoft.AspNetCore.Mvc;
using Progress.Sitefinity.AspNetCore.ViewComponents;
using Renderer.Models.Appointment;
using Renderer.ViewModels.VaccinationAppointment;
using System;
using System.Threading.Tasks;

namespace Renderer.ViewComponents
{
    [SitefinityWidget(Title = "Vaccination Appointment")]
    public class VaccinationAppointmentFormViewComponent: ViewComponent
    {
        private IVaccinationAppointmentModel _appointmentModel;

        public VaccinationAppointmentFormViewComponent(IVaccinationAppointmentModel appointmentModel)
        {
            this._appointmentModel = appointmentModel;
        }

        public async Task<IViewComponentResult> InvokeAsync(IViewComponentContext<AppointmentDataViewModel> context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            AppointmentViewModel model = await _appointmentModel.GetViewModel(context.Entity);

            return View("Default", model);
        }

    }
}