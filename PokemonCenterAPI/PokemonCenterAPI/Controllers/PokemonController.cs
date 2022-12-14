using Microsoft.AspNetCore.Mvc;
using PokemonCenterAPI.DTO;
using PokemonCenterAPI.Services;

namespace PokemonCenterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : BaseController<PokemonController>
    {

        private IPokemonService pokemonService;

        public PokemonController(IPokemonService pokemonService) { 
            this.pokemonService = pokemonService;
        }

        [HttpGet("ById")]
        public List<PokemonDTO> GetById([FromQuery] int id)
        {
            Logger.LogInformation("Get by ID called.");
            return pokemonService.GetById(id);
        }

        [HttpGet("GetAllByTypes")]
        public List<PokemonDTO> GetAllByTypes([FromQuery] List<string> types){
            Logger.LogInformation("Get all by types called.");
            return pokemonService.GetAllByTypes(types);
        }

        [HttpGet("GetAllPaginated")]
        public List<PokemonDTO> GetAllPaginated([FromQuery] int page, [FromQuery] int pageSize){
            Logger.LogInformation("Get all paginated called.");
            return pokemonService.GetAllPaginated(page, pageSize);
        }

        [HttpGet("SearchByName")]
        public List<PokemonDTO> SearchByName(string name){
            Logger.LogInformation("Search by name called.");
            return pokemonService.SearchByName(name);
        }

        [HttpGet("GetAll")]
        public List<PokemonDTO> GetAll(){
            Logger.LogInformation("Get all called.");
            return pokemonService.GetAll();
        }

        [HttpPost]
        public int Create([FromBody] PokemonDTO pokemon){
            Logger.LogInformation("Create called.");
            return pokemonService.Create(pokemon);
        }

        [HttpPut]
        public bool Update([FromBody] PokemonDTO pokemon){
            Logger.LogInformation("Update called.");
            return pokemonService.Update(pokemon);
        }

        [HttpDelete]
        public void Delete([FromQuery] int id){
            Logger.LogInformation("Delete called.");
            pokemonService.Delete(id);
        }


    }
}
