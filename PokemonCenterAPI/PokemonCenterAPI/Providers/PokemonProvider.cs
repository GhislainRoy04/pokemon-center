using System.Data;
using PokemonCenterAPI.DTO;
using PokemonCenterAPI.Connector;
using PokemonCenterAPI.Utils;

namespace PokemonCenterAPI.Providers{

    class PokemonProvider : IPokemonProvider{

        IDataConnector connector;

        public PokemonProvider(IDataConnector connector){
            this.connector = connector;
        }

        public List<PokemonDTO> GetAll(){
            string cmd = $"SELECT *,IF(Legendary = 'True', 1, 0) as LegendaryBool FROM pokemon;";
            DataTable dt = DAL.GetDataTable(cmd, connector.GetConnectionString());
            List<PokemonDTO> pokemons = new List<PokemonDTO>();

            foreach(DataRow row in dt.Rows){
                pokemons.Add(PokemonMapper(row));
            }

            return pokemons;
        }

        public List<PokemonDTO> GetAllByTypes(List<string> types){
            string cmd = $"SELECT *,IF(Legendary = 'True', 1, 0) as LegendaryBool FROM pokemon WHERE Type1 IN ({types}) OR Type2 IN ({types});";
        
            DataTable dt = DAL.GetDataTable(cmd, connector.GetConnectionString());
            List<PokemonDTO> pokemons = new List<PokemonDTO>();

            foreach(DataRow row in dt.Rows){
                pokemons.Add(PokemonMapper(row));
            }

            return pokemons;
        }

        public List<PokemonDTO> SearchByName(string name){
            string cmd = $"SELECT *,IF(Legendary = 'True', 1, 0) as LegendaryBool FROM pokemon WHERE Name LIKE '%{name}%';";
        
            DataTable dt = DAL.GetDataTable(cmd, connector.GetConnectionString());
            List<PokemonDTO> pokemons = new List<PokemonDTO>();

            foreach(DataRow row in dt.Rows){
                pokemons.Add(PokemonMapper(row));
            }

            return pokemons;
        }

        public List<PokemonDTO> GetById(int id){
            string cmd = $"SELECT *,IF(Legendary = 'True', 1, 0) as LegendaryBool FROM pokemon WHERE Id = {id};";
        
            DataTable dt = DAL.GetDataTable(cmd, connector.GetConnectionString());
            List<PokemonDTO> pokemons = new List<PokemonDTO>();

            foreach(DataRow row in dt.Rows){
                pokemons.Add(PokemonMapper(row));
            }

            return pokemons;
        }

        public List<PokemonDTO> GetAllPaginated(int page, int pageSize){
            string cmd = $"SELECT * FROM ( SELECT *, IF(Legendary = 'True', 1, 0) as LegendaryBool, row_number() OVER (ORDER BY Id) as paginationNumber FROM pokemon) paginationTable WHERE paginationNumber >= {page*pageSize} AND paginationNumber <= {(page*pageSize)+pageSize};";
            DataTable dt = DAL.GetDataTable(cmd, connector.GetConnectionString());
            List<PokemonDTO> pokemons = new List<PokemonDTO>();

            foreach(DataRow row in dt.Rows){
                pokemons.Add(PokemonMapper(row));
            }

            return pokemons;
        }

        public int Create(PokemonDTO pokemon){
            string cmd = $"INSERT INTO pokemon (Id, Name, Type1, Type2, Total, HP, Attack, Defense, SpecialAttack, SpecialDefense, Speed, Generation, Legendary) VALUES ({pokemon.Id}, '{pokemon.Name}', '{pokemon.Type1}', '{pokemon.Type2}', {pokemon.GetTotal()}, {pokemon.Hp}, {pokemon.Attack}, {pokemon.Defense}, {pokemon.SpecialAttack}, {pokemon.SpecialDefense}, {pokemon.Speed}, {pokemon.Generation}, {pokemon.Legendary}); SELECT LAST_INSERT_ID();";
            return DAL.Create(cmd, connector.GetConnectionString());
        }

        public bool Update(PokemonDTO pokemon){
            string cmd = $"UPDATE pokemon SET Name = '{pokemon.Name}', Type1 = '{pokemon.Type1}', Type2 = '{pokemon.Type2}', HP = {pokemon.Hp}, Attack = {pokemon.Attack}, Defense = {pokemon.Defense}, SpecialAttack = {pokemon.SpecialAttack}, SpecialDefense = {pokemon.SpecialDefense}, Speed = {pokemon.Speed} WHERE Id = {pokemon.Id}";
            return DAL.Update(cmd, connector.GetConnectionString());
        }

        public void Delete(int id){
            string cmd = $"DELETE FROM pokemon WHERE Id = {id};";
            DAL.Delete(cmd, connector.GetConnectionString());
        }

        private PokemonDTO PokemonMapper(DataRow row){
            PokemonDTO pokemon = new PokemonDTO();
            pokemon.Id = Convert.ToInt32(row["Id"]);
            pokemon.Name = Convert.ToString(row["Name"]);
            pokemon.Type1 = Convert.ToString(row["Type1"]);
            if(row["Type2"] != DBNull.Value) pokemon.Type2 = Convert.ToString(row["Type2"]);
            pokemon.Hp = Convert.ToInt32(row["HP"]);
            pokemon.Attack = Convert.ToInt32(row["Attack"]);
            pokemon.Defense = Convert.ToInt32(row["Defense"]);
            pokemon.SpecialAttack = Convert.ToInt32(row["SpecialAttack"]);
            pokemon.SpecialDefense = Convert.ToInt32(row["SpecialDefense"]);
            pokemon.Speed = Convert.ToInt32(row["Speed"]);
            pokemon.Generation = Convert.ToInt32(row["Generation"]);
            pokemon.Legendary = Convert.ToBoolean(row["LegendaryBool"]);

            return pokemon;
        }

    }


}