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
        NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString);

        Player.Player p = new Player.Player();

        public Player.Player AddPlayer(string first, string last, string nick)
        {
            //int id = 0;
            //id++;
            string stmt = "INSERT INTO player(firstname, lastname, nickname) " +
                          "VALUES(" /*+ p.Player_id + ","*/ + p.Firstname + "," + p.Lastname + "," + p.Nickname + ")";

            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
                    cmd.Parameters.AddWithValue("firstname", p.Firstname);
                    cmd.Parameters.AddWithValue("lastname", p.Lastname);

                    using (var reader = cmd.ExecuteReader())
                    {
                        //while (reader.Read())
                        //{
                            p = new Player.Player()
                            {
                                Firstname = first,
                                Lastname = last,
                                Nickname = nick
                            };
                        //}
                        return p;
                    }
                }
            }
        }

        //  Denna blir en error när man försöker gå in på highscore sidan. om man kommenterar bort den fungerar knapparna.
        public List<Player.Player> GetHighScore()
        {
            Player.Player pe;
            List<Player.Player> gamers = new List<Player.Player>();
            using (var conn = new
               NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT player.nickname, player.firstname, player.lastname, game_player.score FROM game_player INNER JOIN player ON player.player_id = game_player.player_id ORDER BY game_player.score DESC";
                    using (var reader = cmd.ExecuteReader())
                    {
                        pe = new Player.Player()
                        {
                            Firstname = reader.GetString(0),
                            Lastname = reader.GetString(1),
                            Nickname = reader.GetString(2),
                            Score = reader.GetInt32(3)
                        };
                        gamers.Add(pe);
                    }
                }
                conn.Close();
            }
            return gamers;
        }
    }
}

