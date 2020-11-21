using Newtonsoft.Json;
using System.Collections.Generic;

namespace Starships
{
    public class StarshipsResponseModel
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string NextPageUrl { get; set; }

        [JsonProperty("previous")]
        public string PrevPageUrl { get; set; }

        [JsonProperty("results")]
        public List<StarshipModel> StarshipModels { get; set; }
    }
}
