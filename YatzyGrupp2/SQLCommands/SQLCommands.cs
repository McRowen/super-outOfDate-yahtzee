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

        public Player.Player AddPlayer(string first, string last, string nick) // Metod som inte fungerade...
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
        public Player.Player GetChosenPlayer(Player.Player player_Id) //Metod för att lägga till spelare i spelet.
        {
            //List<Player.Player> ChosenPlayers = new List<Player.Player>();
            Player.Player ChosenPlayers = new Player.Player();
            using (var conn = new
                            NpgsqlConnection(ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select nickname from player where player_Id = @player_Id";
                    cmd.Parameters.AddWithValue("player_Id", player_Id.Player_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p = new Player.Player()
                            {
                                Nickname = reader.GetString(0)
                            };
                            ChosenPlayers = p;
                        }
                    }
                }
                conn.Close();
            }
            return ChosenPlayers;
        }
        // Metod för att få upp alla spelare
        public List<Player.Player> GetAllPlayers()
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
            List<Player.Player> gamers = new List<Player.Player>();
            using (var conn = new
               NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    //cmd.CommandText = "SELECT player.player_id, player.nickname, player.firstname, player.lastname," +
                    //    " game_player.score FROM game_player INNER JOIN player ON player.player_id = game_player.player_id ORDER BY game_player.score DESC";
                    cmd.CommandText = "WITH rankscoreamount AS(SELECT player.nickname, player.firstname, player.lastname, SUM(game_player.score) FROM game_player " +
                        "JOIN player ON player.player_id = game_player.player_id JOIN game ON game.game_id = game_player.game_id " +
                        "WHERE game.started_at BETWEEN CURRENT_DATE -INTERVAL '7 days' AND CURRENT_DATE +INTERVAL '1 day' " +
                        "GROUP BY player.nickname, player.firstname, player.lastname ORDER BY SUM DESC) SELECT* FROM rankscoreamount";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p = new Player.Player()
                            {
                                Nickname = reader.GetString(0),
                                Firstname = reader.GetString(1),
                                Lastname = reader.GetString(2),
                                Score = reader.GetInt32(3)
                            };
                            gamers.Add(p);
                        }
                    }
                }
                conn.Close();
            }
            return gamers;
        }
        public List<Player.Player> GetMostWins(){
                         List<Player.Player> wins = new List<Player.Player>();
            using (var conn = new
               NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "WITH mostgames AS (SELECT player.nickname, player.firstname, player.lastname, COUNT(game.ended_at) FROM" +
                        " player JOIN game_player ON player.player_id" +
                        " = game_player.player_id JOIN game ON game.game_id = game_player.game_id GROUP BY player.nickname, player.firstname," +
                        " player.lastname ORDER BY COUNT DESC) SELECT * FROM mostgames";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p = new Player.Player()
                            {
                                Nickname = reader.GetString(0),
                                Firstname = reader.GetString(1),
                                Lastname = reader.GetString(2),
                                Ended_At = reader.GetInt32(3)
                            };
                            wins.Add(p);
                        }
                    }
                }
                conn.Close();
            }
            return wins;
                }
    }
}

