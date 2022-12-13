using MySqlConnector;

namespace PokemonCenterAPI.Connector{
    public interface IDataConnector{

        MySqlConnection GetConnectionString();
        void TestConnection();

    }
}