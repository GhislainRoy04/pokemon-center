using Microsoft.AspNetCore.Mvc;
using PokemonCenterAPI.DTO;
using PokemonCenterAPI.Providers;
using System.Data;

namespace PokemonCenterAPI.Services{

    public class PokemonService: IPokemonService{

        private IPokemonProvider provider;

        public PokemonService(IPokemonProvider provider){
            this.provider = provider;
        }

        public List<PokemonDTO> GetAll(){
            return this.provider.GetAll();
        }

        public List<PokemonDTO> GetAllByTypes(List<string> types){
            return this.provider.GetAllByTypes(types);
        }

        public List<PokemonDTO> GetAllPaginated(int page, int pageSize){
            return this.provider.GetAllPaginated(page, pageSize);
        }

        public List<PokemonDTO> SearchByName(string name){
            return this.provider.SearchByName(name);
        }

        public List<PokemonDTO> GetById(int id){
            return this.provider.GetById(id);
        }

        public int Create(PokemonDTO pokemon){
            return this.provider.Create(pokemon);
        }

        public bool Update(PokemonDTO pokemon){
            return this.provider.Update(pokemon);
        }

        public void Delete(int id){
            this.provider.Delete(id);
        }




    }

}