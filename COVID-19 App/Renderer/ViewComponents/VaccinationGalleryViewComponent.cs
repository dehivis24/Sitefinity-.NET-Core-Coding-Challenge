using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Progress.Sitefinity.AspNetCore.ViewComponents;
using Renderer.Models.VaccinationGallery;

namespace Renderer.ViewComponents
{
    /// <summary>
    /// The view component for accessing Sitefinity data.
    /// </summary>
    [SitefinityWidget]
    public class VaccinationGalleryViewComponent : ViewComponent
    {
        private IVaccinationGalleryModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="VaccinationGalleryViewComponent"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public VaccinationGalleryViewComponent(IVaccinationGalleryModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Invokes the view component.
        /// </summary>
        /// <param name="context">The view component context.</param>
        /// <returns>The view component result.</returns>
        public async Task<IViewComponentResult> InvokeAsync(IViewComponentContext<VaccinationGalleryEntity> context)
        {
            var viewModels = await this.model.GetViewModels(context.Entity);
            return this.View(viewModels);
        }
    }
}


