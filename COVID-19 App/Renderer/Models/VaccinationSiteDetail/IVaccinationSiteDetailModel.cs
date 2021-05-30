using Microsoft.AspNetCore.Http;
using Renderer.Entities.VaccinationSiteDetail;
using Renderer.ViewModels.VaccinationSiteDetail;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renderer.Models.VaccinationSiteDetail
{
    /// <summary>
    /// The model interface.
    /// </summary>
    public interface IVaccinationSiteDetailModel
    {
        /// <summary>
        /// Gets the view models.
        /// </summary>
        /// <param name="entity">The entity object.</param>
        /// <returns>The generated view models.</returns>
        Task<SiteDetailViewModel> GetViewModels(VaccinationSiteDetailEntity entity, HttpRequest request);
    }
}
