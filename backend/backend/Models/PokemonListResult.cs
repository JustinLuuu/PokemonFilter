using Newtonsoft.Json;

namespace backend.Models
{
    public class PokemonListResult
    {
        [JsonProperty("results")]
        public List<PokemonResult> PokemonResults { get; set; }
    }
}
