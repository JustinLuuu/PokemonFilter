using backend.Models;
using Newtonsoft.Json;


namespace backend.Methods
{
    public class GetPokemonHelper
    {
        public string content { get; set; } = "";
        private HttpResponseMessage response { get; set; } = new HttpResponseMessage();
        private HttpClient httpRequest { get; set; } = new HttpClient();
        private const string urlTemplate = "https://pokeapi.co/api/v2/pokemon";

        public async Task<Tuple<int, List<PokemonResult>>> GetAllPokemons()
        {
            response = await httpRequest.GetAsync(urlTemplate + "?limit=3000000");
            content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<PokemonListResult>(content)?.PokemonResults;
            results.ForEach(x => x.id = Convert.ToInt32(x.urlData.ToString().Split("/")[^2]));
            return Tuple.Create((int)response.StatusCode, results);
        }

        public async Task<Tuple<int, Pokemon>> GetPokemonById(int pokemonId)
        {
            response = await httpRequest.GetAsync(urlTemplate + $"/{pokemonId}");
            content = await response.Content.ReadAsStringAsync();
            var pokemon = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Pokemon>(content) :null;           
            return Tuple.Create((int)response.StatusCode, pokemon);
        }

    }
}
