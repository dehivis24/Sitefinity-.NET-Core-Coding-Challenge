using Renderer.ViewModels.VaccinationAppointment;
using System.Threading.Tasks;

namespace Renderer.Models.Appointment
{
    public interface IVaccinationAppointmentModel
    {
        Task<AppointmentViewModel> GetViewModel(AppointmentDataViewModel appointmentDataViewModel);

        Task<bool> AddAppointmentResponse(AppointmentViewModel appointmentViewModel);
    }
}
