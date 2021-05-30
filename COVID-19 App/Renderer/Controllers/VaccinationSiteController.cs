using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Progress.Sitefinity.AspNetCore.ViewComponents;
using Renderer.Entities.VaccinationSiteSearch;
using Renderer.Models.VaccinationSiteSearch;
using Renderer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renderer.Controllers
{
    [ApiController]
    [Route("api/[controller]/{action}")]
    public class VaccinationSiteController : ControllerBase
    {
        private IVaccinationSiteSearchModel _vaccinationSiteSearchModel;

        public VaccinationSiteController(IVaccinationSiteSearchModel vaccinationSiteSearchModel)
        {
            this._vaccinationSiteSearchModel = vaccinationSiteSearchModel;
        }

        [HttpGet]
        public async Task<ActionResult<List<SelectListItem>>> FilterSite([FromQuery] double distance, [FromQuery] double positionLat, [FromQuery] double positionLng)
        {
            List<VaccinationSiteViewModel> siteList = await _vaccinationSiteSearchModel.GetListSiteViewModels();

            foreach (var site in siteList)
            {
                site.Distance = Math.Round(GetHaversineDistance(Convert.ToDouble(site.Latitude), Convert.ToDouble(site.Longitude), positionLat, positionLng), 2);
            }

            var filteredList = new List<VaccinationSiteViewModel>();

            if (siteList != null && siteList.Any())
            {
                filteredList = siteList.Where(s => s.Distance <= distance).OrderBy(s => s.Distance).ToList();
            }

            if (filteredList != null)
                return Ok(filteredList);

            return BadRequest("Update data failed");
        }

        [NonAction]
        internal double GetHaversineDistance(double lat1, double lon1, double lat2, double lon2)
        {
            int earthRadius = 6371;

            var dLat = ConvertToRadians(lat2 - lat1);
            var dLon = ConvertToRadians(lon2 - lon1);
            lat1 = ConvertToRadians(lat1);
            lat2 = ConvertToRadians(lat2);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            return earthRadius * 2 * Math.Asin(Math.Sqrt(a));
        }

        [NonAction]
        private static double ConvertToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
