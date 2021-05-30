using System.Collections.Generic;
using static Renderer.Entities.VaccinationGraph.VaccinationGraphEntity;

namespace Renderer.VaccinationGraph.ViewModels
{
    public class VaccinationDataViewModel
    {
        public List<decimal> DosisPerMonth { get; set; }
        public List<KeyValuePair<string, string>> CountryList { get; set; }
        public List<KeyValuePair<decimal, string>> MonthList { get; set; }
        public string SelectedCountry { get; set; }
        public string GraphType { get; set; }
    }
}
