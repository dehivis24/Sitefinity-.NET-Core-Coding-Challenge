using Progress.Sitefinity.Renderer.Entities.Content;
using Progress.Sitefinity.Renderer.Designers.Attributes;

namespace Renderer.Models.VaccinationGallery
{
    /// <summary>
    /// The entity class.
    /// </summary>
    public class VaccinationGalleryEntity
    {
        [Content(Type = KnownContentTypes.Pages)]
        [DescriptionExtended(InstructionalNotes = "Select Vaccination Detail Page")]
        public MixedContentContext Page { get; set; }
    }
}