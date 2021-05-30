using Microsoft.AspNetCore.Mvc;
using Progress.Sitefinity.AspNetCore.ViewComponents;
using Renderer.Entities.VaccinationGraph;
using Renderer.Models.VaccinationGraph;
using Renderer.VaccinationGraph.ViewModels;
using System;
using System.Threading.Tasks;

namespace Renderer.ViewComponents
{
    [SitefinityWidget(Title = "Vaccination Graph")]
    public class VaccinationGraphViewComponent : ViewComponent
    {
        private IVaccinationGraphModel _graphModel;

        public VaccinationGraphViewComponent(IVaccinationGraphModel graphModel)
        {
            this._graphModel = graphModel;
        }

        public async Task<IViewComponentResult> InvokeAsync(IViewComponentContext<VaccinationGraphEntity> context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            VaccinationDataViewModel model = await _graphModel.GetViewModel(context.Entity);
            return View("Default", model);
        }
    }
}
