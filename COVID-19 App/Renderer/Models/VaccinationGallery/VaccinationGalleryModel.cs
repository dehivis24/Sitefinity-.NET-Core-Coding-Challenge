using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Progress.Sitefinity.AspNetCore.SitefinityApi;
using Progress.Sitefinity.Renderer.Entities.Content;
using Renderer.Dto;
using Renderer.ViewModels.VaccinationGallery;

namespace Renderer.Models.VaccinationGallery
{
    /// <summary>
    /// The model class.
    /// </summary>
    public class VaccinationGalleryModel : IVaccinationGalleryModel
    {
        private readonly IRestClient service;
        /// <summary>
        /// Initializes a new instance of the <see cref="VaccinationGalleryViewComponent"/> class.
        /// </summary>
        /// <param name="service">The rest service.</param>
        public VaccinationGalleryModel(IRestClient service)
        {
            this.service = service;
        }


        /// <summary>
        /// Gets the view models.
        /// </summary>
        /// <param name="entity">The entity object.</param>
        /// <returns>The generated view models.</returns>
        public async Task<IList<VaccinationInfoModel>> GetViewModels(VaccinationGalleryEntity entity)
        {
            // when using the OData client, the url is automatically prefixed with the value of web the service and the sitefinity instance url
            // we use an expand the get the related image

            var getAllArgs = new GetAllArgs
            {
                Type = "Telerik.Sitefinity.DynamicTypes.Model.VaccinationData.VaccinationSite"
            };

            getAllArgs.Fields.Add(nameof(GalleryItem.Name));
            getAllArgs.Fields.Add(nameof(GalleryItem.Image));
            getAllArgs.Fields.Add(nameof(GalleryItem.LocationType));
            getAllArgs.Fields.Add(nameof(GalleryItem.Country));
            getAllArgs.Fields.Add(nameof(GalleryItem.State));
            getAllArgs.Fields.Add(nameof(GalleryItem.City));

            var response = await this.service.GetItems<GalleryItem>(getAllArgs);

            string pageURL = "";
            if (entity.Page.Content[0].Variations != null && entity.Page.Content[0].Variations.Length > 0)
            {
                var pageId = entity.Page.Content[0].Variations[0].Filter.Value;

                var getAllArgsPage = new GetItemArgs()
                {
                    Id = pageId,
                    Type = KnownContentTypes.Pages
                };

                getAllArgsPage.Fields.Add(nameof(Page.ViewUrl));
                var responsePage = await this.service.GetItem<Page>(getAllArgsPage);
                pageURL = !string.IsNullOrEmpty(responsePage.ViewUrl) ? responsePage.ViewUrl : "";
            }

            var viewModels = response.Items.Select(x => this.GetItemViewModel(x, pageURL)).ToList();
            return viewModels;
        }

        private VaccinationInfoModel GetItemViewModel(GalleryItem item, string page)
        {
            List<Thumbnail> result = item.Image.Any() ? item.Image[0].Thumbnails.Where(x => x.Title == "0").ToList() : null;

            var viewModel = new VaccinationInfoModel()
            {
                Name = item.Name,
                Image = result.Any() ? result[0].Url : null,
                LocationType = item.LocationType,
                City = item.City,
                Country = item.Country,
                State = item.State,
                Page = !string.IsNullOrEmpty(page) ? page + "?Name=" + HttpUtility.UrlEncode(item.Name) : null
            };

            return viewModel;
        }
    }
}