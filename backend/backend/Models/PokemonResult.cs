using Newtonsoft.Json;

namespace backend.Models
{
    public class PokemonResult
    {   
        public int id {get;set;}
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("url")]
        public Uri urlData { get; set; }
    }
}
