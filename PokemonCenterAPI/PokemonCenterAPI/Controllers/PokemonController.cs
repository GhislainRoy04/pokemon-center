using Microsoft.AspNetCore.Mvc;
using PokemonCenterAPI.DTO;

namespace PokemonCenterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {

        public PokemonController() { 
        
        }

        [HttpGet("ById")]
        public PokemonDTO GetById([FromQuery] int id)
        {
            return new PokemonDTO();
        }

    }
}
