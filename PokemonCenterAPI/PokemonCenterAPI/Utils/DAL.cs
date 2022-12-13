using System.Data;
using MySqlConnector;

namespace PokemonCenterAPI.Utils{

    public static class DAL{

        internal static DataTable GetDataTable(string sql, MySqlConnection connection){
            DataTable dt = new DataTable();

            using(connection){
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 1000;
                adapter.SelectCommand = cmd;
                connection.Open();
                adapter.Fill(dt);
            }

            return dt;
        }

        internal static int Create(string sql, MySqlConnection connection){
            using(connection){
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 1000;
                connection.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        internal static bool Update(string sql, MySqlConnection connection){
            using(connection){
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 1000;
                connection.Open();
                return (bool)cmd.ExecuteScalar();
            }
        }

        internal static void Delete(string sql, MySqlConnection connection){
            using(connection){
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 1000;
                connection.Open();
                cmd.ExecuteScalar();
            }
        }

    }

}