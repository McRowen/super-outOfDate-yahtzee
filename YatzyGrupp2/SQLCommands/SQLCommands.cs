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
        public static List<Game.Game> GetGames = new List<Game.Game>();


        //Metod för att lägga till player_id av dom spelarna som är valda + game_id i game_player i databsen.
        public void StartNewGamePlayer(List<Player.Player> selectedPlayer)
        {
            //  string stmt = "INSERT INTO game_player (game_id, player_id) VALUES @game_id, @player_id";

            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                //int a = GameID();
                for (int i = 0; i < selectedPlayer.Count; i++)
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;

                        //cmd.Parameters.AddWithValue("player_id", selectedPlayer[i].Player_id);

                        int temp = selectedPlayer[i].Player_id;

                        cmd.Parameters.AddWithValue("game_id", GetGames[0].Game_id);
                        cmd.Parameters.AddWithValue("player_id", temp);
                        cmd.CommandText = "INSERT INTO game_player (game_id, player_id) VALUES (@game_id, @player_id)";

                        //gp = new GamePlayer.GamePlayer()
                        //{
                        //    Game_id = a,
                        //    Player_id = temp
                        //};

                        //cmd.ExecuteNonQuery();
                        cmd.ExecuteReader();



                    }
                    conn.Close();
                }

            }
        }
        //Metod för att lägga till spel i databsen + att returna game_id
        public int GameID()
        {
            string stmt = "INSERT INTO game (started_at, gametype_id) VALUES(CURRENT_TIMESTAMP, 1) RETURNING Game_id";


            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
                    cmd.Connection = conn;
                    int game_id = (Int32)cmd.ExecuteScalar();
                    return game_id;
                }

            }

        }
        //public int PlayerID(List<Player.Player> SelectedPlayers)
        //{
        //    string stmt = "SELECT player_ID FROM player WHERE nickname = " +SelectedPlayers.


        //}


        //public DateTime StartNewGame()
        //{
        //   // string stmt = "INSERT INTO game (game_id, started_at, gametype_id) VALUES(@game_id, CURRENT_TIMESTAMP, 1)";
        //    Game.Game game = new Game.Game();
        //    DateTime date = DateTime.Now;
        //    int gametyp = 1;

        //    using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
        //    {
        //        conn.Open();
        //        using (var cmd = new NpgsqlCommand())
        //        {

        //            cmd.Connection = conn;
        //            cmd.CommandText = "INSERT INTO game(started_at, gametype_id) VALUES(@started_at, @gametype_id)";
        //           // cmd.Parameters.AddWithValue("game_id", g.Game_id);
        //            cmd.Parameters.AddWithValue("started_at", date);
        //            cmd.Parameters.AddWithValue("gametype_id", gametyp);
        //            cmd.ExecuteNonQuery();
        //            //using (var reader = cmd.ExecuteReader())
        //            //{
        //            //cmd.Parameters.AddWithValue("game_id", g.Game_id);
        //            //    g = new Game.Game()
        //            //    {
        //            //        Game_id = reader.GetInt32(0),
        //            //        Started_at = reader.GetDateTime(1),
        //            //        Gametype_id = reader.GetInt32(2)
        //            //    };
        //            //    return g;
        //            //}
        //        }
        //        conn.Close();
        //    }
        //    return date;
        //}
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
                    cmd.CommandText = "select player_id, nickname from player where player_Id = @player_Id";
                    cmd.Parameters.AddWithValue("player_Id", player_Id.Player_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p = new Player.Player()
                            {
                                Player_id = reader.GetInt32(0),
                                Nickname = reader.GetString(1)
                            };
                            ChosenPlayers = p;
                        }
                    }
                }
                conn.Close();
            }
            return ChosenPlayers;
        }
        //Metod för att lägga till Game i lista, kan behövas för att hitta game_id senare.
        public List<Game.Game> GetGame()
        {

            Game.Game Ggame = new Game.Game();
            int a = GameID();
            DateTime CurrentDate;
            CurrentDate = DateTime.Now;

            using (var conn = new
                            NpgsqlConnection(ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT game_id, started_at, gametype_id FROM game where game_id = @game_id";
                    cmd.Parameters.AddWithValue("game_id", a);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ggame = new Game.Game()
                            {
                                Game_id = a,
                                Started_at = CurrentDate,
                                Gametype_id = 1,
                            };
                            GetGames.Add(Ggame);
                        }
                    }
                }
                conn.Close();

            }
            return GetGames;

        }
        // Sätter eneded_at på det spelet som är igång.
        public void EndTime(List<Game.Game> GetGames)
        {

            using (var conn = new
                NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE GAME SET ended_at = CURRENT_TIMESTAMP WHERE game_id = @game_id";
                    cmd.Parameters.AddWithValue("game_id", GetGames[0].Game_id);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

        }

        public void GetScore(List<Player.Player> selectedPlayer)
        {
            using (var conn = new
                NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                for (int i = 0; i < selectedPlayer.Count; i++)
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "UPDATE GAME_PLAYER SET score = @score WHERE game_id = @game_id AND player_ID = @player_id";
                        cmd.Parameters.AddWithValue("game_id", GetGames[0].Game_id);
                        cmd.Parameters.AddWithValue("player_id", selectedPlayer[i].Player_id);
                        cmd.Parameters.AddWithValue("score", selectedPlayer[i].Score);


                        cmd.ExecuteReader();
                    }
                    conn.Close();

                }

            }
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
        public List<Player.Player> Getgameplayers(int gameId)
        {
            string stmt = "SELECT game_player.game_id, game_player.player_id, player.firstname, player.Nickname, player.Lastname, game_player.score, game.ended_at FROM game_player INNER JOIN player on player.player_id = game_player.player_id JOIN game ON game.game_id = game_player.game_id WHERE game.game_id = @gameId";
            List<Player.Player> players = new List<Player.Player>();
            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
                    cmd.Parameters.AddWithValue("gameId", gameId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(5))
                            {
                                Player.Player p = new Player.Player()
                                {
                                    Player_id = reader.GetInt32(1),
                                    Firstname = reader.GetString(2),
                                    Lastname = reader.GetString(4),
                                    Nickname = reader.GetString(3),
                                    Score = reader.GetInt32(5)
                                };
                                players.Add(p);
                            }
                        }
                    }
                }

            }
            return players;
        }
        public List<Player.winstreak> GetWinsCount()
        {
            List<Player.winstreak> games = new List<Player.winstreak>();
            string stmt = "SELECT game_id, ended_at FROM game WHERE ended_at IS NOT NULL";
            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Player.winstreak wp = new Player.winstreak();
                            wp.Gamez = new Game.Game();
                            wp.Gamez.Ended_at = reader.GetDateTime(1);
                            wp.Gamez.Game_id = reader.GetInt32(0);
                            wp.Players = Getgameplayers(wp.Gamez.Game_id);
                            games.Add(wp);
                        }
                    }
                }
            }
            return games;
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

        //    public List<Player.Player> GetWinstreak()
        //    {
        //        List<Player.winstreak> winstreaks = new List<Player.winstreak>();

        //        List<Player.Player> PlayerWinner = new List<Player.Player>();
        //        int rank = 0;

        //        foreach (Player.winstreak item in collection)
        //        {

        //        }

        //        using (var conn = new
        //           NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
        //        {
        //            conn.Open();
        //            using (var cmd = new NpgsqlCommand())
        //            {
        //                cmd.Connection = conn;
        //                cmd.CommandText = "WITH winstreak AS (SELECT player.nickname, player.firstname, player.lastname, COUNT(game.ended_at) FROM" +
        //                    " player JOIN game_player ON player.player_id" +
        //                    " = game_player.player_id JOIN game ON game.game_id = game_player.game_id GROUP BY player.nickname, player.firstname," +
        //                    " player.lastname ORDER BY COUNT DESC) SELECT * FROM winstreak";
        //                using (var reader = cmd.ExecuteReader())
        //                {

        //                    }
        //                }
        //            }
        //            conn.Close();
        //        }

        //    }
        //}
    }
}

