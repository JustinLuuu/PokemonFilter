using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Methods;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/pokemons")]
    public class PokemonsController : ControllerBase
    {        
        GetPokemonHelper pokeMethods = new GetPokemonHelper();

        [HttpGet("GetMatches/{characterString}")]
        public async Task<ActionResult<List<PokemonResult>>> Get(string characterString)
        {
            if (!ValidateStringParams.Validate(characterString))
            {
                return BadRequest("the request got invalid parameters!");
            }

            (var statusCode, var allPokemons) = await pokeMethods.GetAllPokemons();

            if (statusCode == 200)
            {               
                var pokemonsFiltered = allPokemons?.Where(x => x.name.Contains(characterString.ToLower())).ToList();

                if (pokemonsFiltered?.Count > 0)
                {
                    return Ok(pokemonsFiltered);
                }

                return NotFound("no matches found with pokemon names!");
            }
            return BadRequest();
        }


        [HttpGet("GetPokemon/{pokemonId:int}")]
        public async Task<ActionResult<Pokemon>> Get(int pokemonId)
        {
            if(pokemonId == default(int)) // check if integer is null or has the default value: 0
            {
                return BadRequest("forgot the id in the url !");
            }

            (var statusCode, var pokemon) = await pokeMethods.GetPokemonById(pokemonId);

            switch (statusCode)
            {
                case 200:
                    return Ok(pokemon);
                case 404:
                    return NotFound();
                default:
                    return BadRequest();
            }            
        }
    }
}