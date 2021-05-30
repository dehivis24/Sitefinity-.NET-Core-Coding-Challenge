using System;

namespace Renderer.Dto
{
    public class GalleryItem
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Name { get; set; }
        public Image[] Image { get; set; }
        public string LocationType { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        /// <summary>
        /// The image view model.
        /// </summary>
    }
    public class Image
    {
        /// <summary>
        /// Gets or sets the thumbnail url.
        /// </summary>
        public string ThumbnailUrl { get; set; }
        public Thumbnail[] Thumbnails { get; set; }
    }

    public class Thumbnail
    {
        /// <summary>
        /// Gets or sets the thumbnail url.
        /// </summary>
        public string Url { get; set; }
        public string Title { get; set; }
    }
}