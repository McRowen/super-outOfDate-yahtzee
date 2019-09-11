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

        public void AddPlayerTest(string first, string last, string nick)
        {
            using (var conn = new
                            NpgsqlConnection(ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO player(firstname, lastname, nickname) VALUES(@firstname, @lastname, @nickname)";
                    cmd.Parameters.AddWithValue("firstname", first);
                    cmd.Parameters.AddWithValue("lastname", last);
                    cmd.Parameters.AddWithValue("nickname", nick);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

        }
        // Metod för att få upp alla spelare
        public List<Player.Player> GetAllPlayers(Player.Player p)
        {
            
            List<Player.Player> players = new List<Player.Player>();
            using (var conn = new
             NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT player.player_id, player.firstname, player.lastname, player.nickname FROM player";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p = new Player.Player()
                            {
                                Player_id = reader.GetInt32(0),
                                Firstname = reader.GetString(1),
                                Lastname = reader.GetString(2),
                                Nickname = reader.GetString(3)
                            };
                            players.Add(p);
                        }
                    }
                    conn.Close();
                }
                return players;
            }
        }

        //  Metod för att se highscore
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
                    cmd.CommandText = "SELECT player.player_id, player.nickname, player.firstname, player.lastname, game_player.score FROM game_player INNER JOIN player ON player.player_id = game_player.player_id ORDER BY game_player.score DESC";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pe = new Player.Player()
                            {
                                Player_id = reader.GetInt32(0),
                                Firstname = reader.GetString(1),
                                Lastname = reader.GetString(2),
                                Nickname = reader.GetString(3),
                                Score = reader.GetInt32(4)
                            };
                            gamers.Add(pe);
                        }
                    }
                }
                conn.Close();
            }
            return gamers;
        }
    }
}

