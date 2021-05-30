using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Renderer.Models.Appointment;
using Renderer.ViewModels.VaccinationAppointment;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renderer.Controllers
{
    [ApiController]
    [Route("api/[controller]/{action}")]
    public class VaccinationAppointmentController : ControllerBase
    {
        private IVaccinationAppointmentModel _appointmentModel;

        public VaccinationAppointmentController(IVaccinationAppointmentModel appointmentModel)
        {
            this._appointmentModel = appointmentModel;
        }

        [HttpGet]
        public async Task<ActionResult<List<SelectListItem>>> UpdateData([FromQuery] string region, [FromQuery] string city)
        {
            if (string.IsNullOrEmpty(region) && string.IsNullOrEmpty(city)) return BadRequest("Region or City are invalid");

            AppointmentDataViewModel model = await _appointmentModel.GetViewModel(new AppointmentDataViewModel { Region = region, City = city });

            if (model != null)
                return Ok(model);

            return BadRequest("Update data failed");
        }


        [HttpPost]
        public async Task<ActionResult<List<SelectListItem>>> SendResponse([FromBody] AppointmentViewModel model)
        {
            if (model == null) return BadRequest("Invalid");

            if (model.Regions != null && model.Regions.Any())
            {
                model.Region = model.Regions[0].Value;
            }

            if (model.Cities != null && model.Cities.Any())
            {
                model.City = model.Cities[0].Value;
            }

            bool created = await _appointmentModel.AddAppointmentResponse(model);

            if (created)
                return Ok(model);

            return BadRequest("Update data failed");
        }
    }
}
