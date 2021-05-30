using Microsoft.AspNetCore.Mvc;
using Renderer.Entities.VaccinationGraph;
using Renderer.Models.VaccinationGraph;
using Renderer.VaccinationGraph.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Renderer.Entities.VaccinationGraph.VaccinationGraphEntity;

namespace Renderer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaccinationGraphController : ControllerBase
    {
        private IVaccinationGraphModel _graphModel;

        public VaccinationGraphController(IVaccinationGraphModel graphModel)
        {
            this._graphModel = graphModel;
        }

        [HttpGet]
        public async Task<ActionResult<List<decimal>>> GetGraphUpdatedData([FromQuery]string countryCode) 
        {
            if (string.IsNullOrEmpty(countryCode)) return BadRequest("Country Code is invalid");

            if (Enum.TryParse<CountryList>(countryCode, out CountryList defaultCountry)) 
            {
                VaccinationDataViewModel model = await _graphModel.GetViewModel(new VaccinationGraphEntity { DefaultCountry = defaultCountry });

                if (model != null)
                    return Ok(model.DosisPerMonth);
            }

            return BadRequest("Update data failed");
        }
    }
}
