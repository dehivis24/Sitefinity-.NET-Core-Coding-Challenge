using Microsoft.AspNetCore.Http;
using Renderer.Entities.VaccinationSiteSearch;
using Renderer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renderer.Models.VaccinationSiteSearch
{
    /// <summary>
    /// The model interface.
    /// </summary>
    public interface IVaccinationSiteSearchModel
    {
        /// <summary>
        /// Gets the view models.
        /// </summary>
        /// <param name="entity">The entity object.</param>
        /// <returns>The generated view models.</returns>
        Task<VaccinationSiteViewModel> GetViewModels(VaccinationSiteSearchEntity entity);

        Task<List<VaccinationSiteViewModel>> GetListSiteViewModels();
    }
}
