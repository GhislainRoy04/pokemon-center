using System.Data;
using MySqlConnector;

namespace PokemonCenterAPI.Connector{

    public class DataConnector : IDataConnector{

        protected readonly IConfiguration  configuration;

        public DataConnector(IConfiguration configuration){
            this.configuration = configuration;
        }

        public MySqlConnection GetConnectionString(){
            return new MySqlConnection(GetCnnString());
        }

        public void TestConnection(){
            using (MySqlConnection connection = new MySqlConnection(GetCnnString())){
                connection.Open();
            }
        }

        private string GetCnnString(){
            return this.configuration.GetValue<string>("ConnectionString:Default");
        }


    }


}