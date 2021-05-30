using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Renderer.ViewModels.VaccinationGraph
{
    public class VaccinationInfoViewModel
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("iso_code")]
        public string IsoCode { get; set; }
        [JsonPropertyName("data")]
        public IEnumerable<DosisInfoViewModel> Data { get; set; }
    }
}
