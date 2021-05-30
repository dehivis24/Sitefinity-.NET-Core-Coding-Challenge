using Progress.Sitefinity.Renderer.Designers.Attributes;
using Progress.Sitefinity.Renderer.Entities.Content;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Renderer.Entities.VaccinationSiteDetail
{
    /// <summary>
    /// The entity class.
    /// </summary>
    public class VaccinationSiteDetailEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether to display the population risk factors.
        /// </summary>
        [DisplayName("Display Risk Factors")]
        public bool DisplayRiskFactors { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the vaccination instructions.
        /// </summary>
        [DisplayName("Vaccination Instructions")]
        [MaxLength(500, ErrorMessage = "The message must be less than {1} symbols.")]
        public string VaccinationInstructions { get; set; }

        [Content(Type = KnownContentTypes.Pages)]
        [DescriptionExtended(InstructionalNotes = "Select Vaccination Appointment Page")]
        public MixedContentContext Page { get; set; }
    }
}
