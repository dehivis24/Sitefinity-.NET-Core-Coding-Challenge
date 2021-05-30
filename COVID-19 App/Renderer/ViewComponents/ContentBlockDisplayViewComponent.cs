using Microsoft.AspNetCore.Mvc;
using Progress.Sitefinity.AspNetCore.ViewComponents;
using Renderer.Entities.ContentBlockDisplay;
using Renderer.Models.ContentBlockDisplay;
using Renderer.ViewModels.ContentBlockDisplay;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Renderer.ViewComponents
{
    [SitefinityWidget(Title = "Content Block Display")]
    public class ContentBlockDisplayViewComponent : ViewComponent
    {
        private IContentBlockDisplayModel _contentBlockModel;

        public ContentBlockDisplayViewComponent(IContentBlockDisplayModel contentBlockModel)
        {
            this._contentBlockModel = contentBlockModel;
        }
        public async Task<IViewComponentResult> InvokeAsync(IViewComponentContext<ContentBlockDisplayEntity> context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            ContentBlockDisplayViewModel model = new();

            if (context.Entity.ContentBlock != null && context.Entity.ContentBlock.ItemIdsOrdered != null && context.Entity.ContentBlock.ItemIdsOrdered.Any()) 
            {
                var contentBlockId = context.Entity.ContentBlock.ItemIdsOrdered[0];
                model = await _contentBlockModel.GetViewModel(contentBlockId);
            }

            return View("Default", model);
        }
    }
}
