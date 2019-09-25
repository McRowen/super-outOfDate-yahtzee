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
        Game.Game g = new Game.Game();
        GamePlayer.GamePlayer gp = new GamePlayer.GamePlayer();

        public GamePlayer.GamePlayer StartNewGamePlayer(Game.Game g, List<Player.Player> selectedPlayer)
        {
            string stmt = "INSERT INTO game_player (game_id, player_id) VALUES game_id, player_id";

            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        for (int i = 0; i < selectedPlayer.Count; i++)
                        {
                            gp = new GamePlayer.GamePlayer()
                            {
                                Game_id = g.Game_id,
                                Player_id = selectedPlayer[i].Player_id
                            };
                        }
                        return gp;
                    }
                }
            }
        }
        public DateTime StartNewGame()
        {
           // string stmt = "INSERT INTO game (game_id, started_at, gametype_id) VALUES(@game_id, CURRENT_TIMESTAMP, 1)";
            Game.Game game = new Game.Game();
            DateTime date = DateTime.Now;
            int gametyp = 1;

            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {

                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO game(started_at, gametype_id) VALUES(@started_at, @gametype_id)";
                   // cmd.Parameters.AddWithValue("game_id", g.Game_id);
                    cmd.Parameters.AddWithValue("started_at", date);
                    cmd.Parameters.AddWithValue("gametype_id", gametyp);
                    cmd.ExecuteNonQuery();
                    //using (var reader = cmd.ExecuteReader())
                    //{
                    //cmd.Parameters.AddWithValue("game_id", g.Game_id);
                    //    g = new Game.Game()
                    //    {
                    //        Game_id = reader.GetInt32(0),
                    //        Started_at = reader.GetDateTime(1),
                    //        Gametype_id = reader.GetInt32(2)
                    //    };
                    //    return g;
                    //}
                }
                conn.Close();
            }
            return date;
        }
        public void AddPlayerTest(string first, string last, string nick)
        {
            using (var conn = new
                            NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
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
        public List<Player.highscoreplayer> GetHighScore()
        {
            List<Player.highscoreplayer> gamers = new List<Player.highscoreplayer>();
            Player.highscoreplayer pe = new Player.highscoreplayer();
            using (var conn = new
               NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "WITH rankscoreamount AS(SELECT player.nickname, player.firstname, player.lastname, SUM(game_player.score) FROM game_player " +
                        "JOIN player ON player.player_id = game_player.player_id JOIN game ON game.game_id = game_player.game_id " +
                        "WHERE game.started_at BETWEEN CURRENT_DATE -INTERVAL '7 days' AND CURRENT_DATE +INTERVAL '1 day' " +
                        "GROUP BY player.nickname, player.firstname, player.lastname ORDER BY SUM DESC) SELECT* FROM rankscoreamount";
                    using (var reader = cmd.ExecuteReader())
                    {
                        int rank = 1;
                        while (reader.Read())
                        {
                            try
                            {
                                pe = new Player.highscoreplayer()
                                {
                                    Rank = rank,
                                    Nickname = reader.GetString(0),
                                    Firstname = reader.GetString(1),
                                    Lastname = reader.GetString(2),
                                    Score = reader.GetInt32(3)
                                };
                                rank++;
                                gamers.Add(pe);
                            }
                            catch (PostgresException ex)
                            {
                                System.Windows.MessageBox.Show(ex.Message);                              
                            }
                        }
                    }
                }
                conn.Close();
            }
            return gamers;
        }
        public List<Player.highscoreplayer> GetMostWins()
        {
                         List<Player.highscoreplayer> wins = new List<Player.highscoreplayer>();
            Player.highscoreplayer pe = new Player.highscoreplayer();
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
                        int rank = 1;

                        while (reader.Read())
                        {

                            pe = new Player.highscoreplayer()
                            {
                                Rank = rank,
                                Nickname = reader.GetString(0),
                                Firstname = reader.GetString(1),
                                Lastname = reader.GetString(2),
                                Count = reader.GetInt32(3)
                              
                            };
                        rank++;
                            wins.Add(pe);
                        }
                    }
                }
                conn.Close();
            }
            return wins;
        }
    }
}

