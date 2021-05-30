using Progress.Sitefinity.Renderer.Designers.Attributes;
using Progress.Sitefinity.Renderer.Entities.Content;
using System.ComponentModel;

namespace Renderer.Entities.VaccinationSiteSearch
{
    /// <summary>
    /// The entity class.
    /// </summary>
    public class VaccinationSiteSearchEntity
    {
        [Content(Type = KnownContentTypes.Pages)]
        [DescriptionExtended(InstructionalNotes = "Select Vaccination Detail Page")]
        public MixedContentContext Page { get; set; }

    }
}