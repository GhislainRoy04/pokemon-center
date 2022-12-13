using Microsoft.AspNetCore.Mvc;
using PokemonCenterAPI.DTO;
using PokemonCenterAPI.Services;

namespace PokemonCenterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {

        private IPokemonService pokemonService;

        public PokemonController(IPokemonService pokemonService) { 
            this.pokemonService = pokemonService;
        }

        [HttpGet("ById")]
        public List<PokemonDTO> GetById([FromQuery] int id)
        {
            return pokemonService.GetById(id);
        }

        [HttpGet("GetAllByTypes")]
        public List<PokemonDTO> GetAllByTypes([FromQuery] List<string> types){
            return pokemonService.GetAllByTypes(types);
        }

        [HttpGet("GetAllPaginated")]
        public List<PokemonDTO> GetAllPaginated([FromQuery] int page, [FromQuery] int pageSize){
            return pokemonService.GetAllPaginated(page, pageSize);
        }

        [HttpGet("SearchByName")]
        public List<PokemonDTO> SearchByName(string name){
            return pokemonService.SearchByName(name);
        }

        [HttpGet("GetAll")]
        public List<PokemonDTO> GetAll(){
            return pokemonService.GetAll();
        }

        [HttpPost]
        public int Create([FromBody] PokemonDTO pokemon){
            return pokemonService.Create(pokemon);
        }

        [HttpPut]
        public bool Update([FromBody] PokemonDTO pokemon){
            return pokemonService.Update(pokemon);
        }

        [HttpDelete]
        public void Delete([FromQuery] int id){
            pokemonService.Delete(id);
        }


    }
}
