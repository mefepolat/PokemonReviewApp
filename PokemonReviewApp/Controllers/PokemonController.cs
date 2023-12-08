using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
       
        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonController>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _pokemonRepository.GetPokemons();
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokemons);
        }
    }

}
