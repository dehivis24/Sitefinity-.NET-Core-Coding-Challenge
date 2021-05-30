namespace Renderer.ViewModels.VaccinationGallery
{
    /// <summary>
    /// The view model.
    /// </summary>
    public class VaccinationInfoModel
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail.
        /// </summary>
        public string Image { get; set; }

        public string LocationType { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Page { get; set; }
    }
}
