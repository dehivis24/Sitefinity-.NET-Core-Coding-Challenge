using Renderer.Entities.VaccinationGraph;
using Renderer.VaccinationGraph.ViewModels;
using System.Threading.Tasks;

namespace Renderer.Models.VaccinationGraph
{
    public interface IVaccinationGraphModel
    {
        Task<VaccinationDataViewModel> GetViewModel(VaccinationGraphEntity entity);
    }
}
