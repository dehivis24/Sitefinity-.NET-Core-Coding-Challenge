using Progress.Sitefinity.Renderer.Designers.Attributes;
using Progress.Sitefinity.Renderer.Entities.Content;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Renderer.Entities.ContentBlockDisplay
{
    public class ContentBlockDisplayEntity
    {
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Content Block")]
        [DescriptionExtended(InstructionalNotes = "Select content block to display")]
        [Content(Type = "Telerik.Sitefinity.GenericContent.Model.ContentItem", AllowMultipleItemsSelection = false)]
        public MixedContentContext ContentBlock { get; set; }
    }
}
