using PokemonCenterAPI.DTO;

namespace PokemonCenterAPI.Providers{

    public interface IPokemonProvider{

        List<PokemonDTO> GetAll();
        List<PokemonDTO> GetAllByTypes(List<string> types);
        List<PokemonDTO> GetAllPaginated(int page, int pageSize);
        List<PokemonDTO> SearchByName(string name);
        List<PokemonDTO> GetById(int id);
        int Create(PokemonDTO pokemon);
        bool Update(PokemonDTO pokemon);
        void Delete(int id);
    }

}