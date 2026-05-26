using System.Text.Json.Serialization;

namespace Services.FunctionCalling.Models
{
    public class WeatherDetails
    {
        [JsonPropertyName("weather")]
        public List<WeatherData> Weather { get; set; }
    }

    public class WeatherData
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("main")]
        public string Main { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
}
