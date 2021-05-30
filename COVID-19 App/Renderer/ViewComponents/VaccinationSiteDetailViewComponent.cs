using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Progress.Sitefinity.AspNetCore.ViewComponents;
using Renderer.Entities.VaccinationSiteDetail;
using Renderer.Models.VaccinationSiteDetail;
using System.Threading.Tasks;

namespace Renderer.ViewComponents
{
    /// <summary>
    /// The view component for accessing Sitefinity data.
    /// </summary>
    [SitefinityWidget]
    public class VaccinationSiteDetailViewComponent : ViewComponent
    {
        private IVaccinationSiteDetailModel model;
        private HttpRequest request;

        /// <summary>
        /// Initializes a new instance of the <see cref="VaccinationSiteDetailViewComponent"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public VaccinationSiteDetailViewComponent(IVaccinationSiteDetailModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Invokes the view component.
        /// </summary>
        /// <param name="context">The view component context.</param>
        /// <returns>The view component result.</returns>
        public async Task<IViewComponentResult> InvokeAsync(IViewComponentContext<VaccinationSiteDetailEntity> context)
        {
            request = this.HttpContext.Request;
            var viewModels = await this.model.GetViewModels(context.Entity, request);
            return this.View(viewModels);
        }
    }
}
