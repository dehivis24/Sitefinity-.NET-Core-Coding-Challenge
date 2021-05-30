using System.Collections.Generic;
using System.Threading.Tasks;
using Renderer.ViewModels.VaccinationGallery;

namespace Renderer.Models.VaccinationGallery
{
    /// <summary>
    /// The model interface.
    /// </summary>
    public interface IVaccinationGalleryModel
    {
        /// <summary>
        /// Gets the view models.
        /// </summary>
        /// <param name="entity">The entity object.</param>
        /// <returns>The generated view models.</returns>
        Task<IList<VaccinationInfoModel>> GetViewModels(VaccinationGalleryEntity entity);
    }
}