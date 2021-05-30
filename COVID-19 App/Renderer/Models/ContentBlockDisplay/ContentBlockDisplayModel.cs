using Progress.Sitefinity.AspNetCore.SitefinityApi;
using Renderer.ViewModels.ContentBlockDisplay;
using System.Threading.Tasks;

namespace Renderer.Models.ContentBlockDisplay
{
    public class ContentBlockDisplayModel : IContentBlockDisplayModel
    {
        private readonly IRestClient _service;

        public ContentBlockDisplayModel(IRestClient service)
        {
            this._service = service;
        }

        public async Task<ContentBlockDisplayViewModel> GetViewModel(string contentBlockId)
        {
            ContentBlockDisplayViewModel model = new();
            if (!string.IsNullOrEmpty(contentBlockId)) 
            {
                var getSingleArgs = new GetItemArgs()
                {
                    // required parameter, specifies the id of the item to retrieve
                    Id = contentBlockId,

                    // required parameter, specifies the items to work with
                    Type = "Telerik.Sitefinity.GenericContent.Model.ContentItem",

                    // optional parameter, if nothing is specified, the default for the site will be used
                    Provider = "OpenAccessDataProvider"
                };

                //Retrieve content block from Sitefinity
                var getSingleResponse = await this._service.GetItem<ContentBlockDisplayViewModel>(getSingleArgs);

                if (getSingleResponse != null) 
                    return getSingleResponse;
            }

            return model;
        }
    }
}
