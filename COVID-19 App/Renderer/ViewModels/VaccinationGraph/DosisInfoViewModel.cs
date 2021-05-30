using System;
using System.Text.Json.Serialization;

namespace Renderer.ViewModels.VaccinationGraph
{
    public class DosisInfoViewModel
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("total_vaccinations")]
        public decimal TotalVaccinations { get; set; }
        [JsonPropertyName("people_vaccinated")]
        public decimal PeopleVaccinated { get; set; }
        [JsonPropertyName("total_vaccinations_per_hundred")]
        public decimal TotalVaccinationsPerHundred { get; set; }
        [JsonPropertyName("people_vaccinated_per_hundred")]
        public decimal PeopleVaccinatedPerHundred { get; set; }
        [JsonPropertyName("daily_vaccinations")]
        public decimal DailyVaccinations { get; set; }
        [JsonPropertyName("daily_vaccinations_per_million")]
        public decimal DailyVaccinationsPerMillion { get; set; }
    }
}
