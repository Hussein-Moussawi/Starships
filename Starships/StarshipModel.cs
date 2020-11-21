using Newtonsoft.Json;
namespace Starships
{
    public class StarshipModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("consumables")]
        public string Consumables { get; set; }

        [JsonProperty("MGLT")]
        public string MaxDistanceByHour { get; set; }
    }
}
