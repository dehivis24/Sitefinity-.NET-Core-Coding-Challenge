using Renderer.ViewModels.ContentBlockDisplay;
using System;
using System.Threading.Tasks;

namespace Renderer.Models.ContentBlockDisplay
{
    public interface IContentBlockDisplayModel
    {
        Task<ContentBlockDisplayViewModel> GetViewModel(string contentBlockId);
    }
}
