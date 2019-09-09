using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Npgsql;

namespace YatzyGrupp2.SQLCommands
{
    class SQLCommands
    {
        //Player.Player player = new Player.Player();

        public List<Player.Player> GetAllPlayer()
        {
            Player.Player p;
            List<Player.Player> player = new List<Player.Player>();
            string stmt = "SELECT * FROM game_player";
            var conn = new
                NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString);
            conn.Open();
            var cmd = new NpgsqlCommand(stmt, conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                p = new Player.Player()
                {
                    Firstname = reader.GetString(1),
                    Lastname = reader.GetString(2),
                    Nickname = reader.GetString(3)
                };
                player.Add(p);
            }
            conn.Close(); 
            return player; 
        }

    }
}
