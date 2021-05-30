using Renderer.Entities.VaccinationSiteSearch;
using Renderer.Models.VaccinationSiteSearch;
using Microsoft.AspNetCore.Mvc;
using Progress.Sitefinity.AspNetCore.ViewComponents;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Renderer.ViewComponents
{
    [SitefinityWidget]
    public class VaccinationSiteSearchViewComponent : ViewComponent
    {
        private IVaccinationSiteSearchModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="VaccinationSiteSearchViewComponent"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public VaccinationSiteSearchViewComponent(IVaccinationSiteSearchModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Invokes the view component.
        /// </summary>
        /// <param name="context">The view component context.</param>
        /// <returns>The view component result.</returns>
        public async Task<IViewComponentResult> InvokeAsync(IViewComponentContext<VaccinationSiteSearchEntity> context)
        {
            var viewModels = await this.model.GetViewModels(context.Entity);    
            return this.View(viewModels);
        }
    }
}
