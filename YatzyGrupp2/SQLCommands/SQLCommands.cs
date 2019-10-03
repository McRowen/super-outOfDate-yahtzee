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
            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {                
                for (int i = 0; i < selectedPlayer.Count; i++)
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        int temp = selectedPlayer[i].Player_id;

                        cmd.Parameters.AddWithValue("game_id", GetGames[0].Game_id);
                        cmd.Parameters.AddWithValue("player_id", temp);
                        cmd.CommandText = "INSERT INTO game_player (game_id, player_id) VALUES (@game_id, @player_id)";

                        cmd.ExecuteReader();
                    }
                    conn.Close();
                }

            }
        }

        public void DeleteGameFromDb(List<Player.Player> selectedPlayer)
        {
            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                for (int i = 0; i < selectedPlayer.Count; i++)
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        int temp = selectedPlayer[i].Player_id;

                        cmd.CommandText = "DELETE FROM game_player WHERE game_id = @game_id, player_id = @ player_id";
                        cmd.Parameters.AddWithValue("game_id", g.Game_id);
                        cmd.Parameters.AddWithValue("player_id", temp);

                        cmd.ExecuteReader();
                    }
                    conn.Close();
                }

            }
        }
    
        public void DeleteGameIdFromDb()
        {
            string stmt = "DELETE FROM game where game_id = @game_id";

            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("game_id", g.Game_id);
                    cmd.ExecuteReader();
                }
                conn.Close();
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
        
        //Metod för att lägga till styrt spel i databasen + returna game_id
        public int GameIDStyrt()
        {
            string stmt = "INSERT INTO game (started_at, gametype_id) VALUES(CURRENT_TIMESTAMP, 2) RETURNING Game_id";

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

        //Metod för att lägga till spelare i databasen
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

        //Metod för att lägga till valda spelare i spelet.
        public Player.Player GetChosenPlayer(Player.Player player_Id)
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

        //Samma metod som den över fast för sytrt yatzy. Så skillnad är att gametype_id är 2.
        public List<Game.Game> GetStyrtGame()
        {
            Game.Game Ggame = new Game.Game();
            int a = GameIDStyrt();
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
                                Gametype_id = 2,
                            };
                            GetGames.Add(Ggame);
                        }
                    }
                }
                conn.Close();
            }
            return GetGames;
        }

        //Sätter ended_at på spelet som spelas när man avslutar.
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

        //Sätter poäng på spelarna i spelet när man avslutar.
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

        //Metod för att få upp alla tillgängliga registrerade användare i startview.
        public List<Player.Player> GetAllPlayers()
        {
            List<Player.Player> players = new List<Player.Player>();
            using (var conn = new
             NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    try
                    {
                        cmd.Connection = conn;
                        //Fick lägga till DISTINCT i denna SQL fråga då den annars visade flera av samma. Detta kan bero på SQL frågan själv eller databasen.
                        cmd.CommandText = "SELECT DISTINCT player.nickname, player.player_id, player.firstname, player.lastname FROM player " +
                            "INNER JOIN game_player ON game_player.player_ID = player.player_id " +
                            "INNER JOIN game ON game.game_id = game_player.game_id " +
                            "WHERE game.ended_at IS NOT NULL  OR game.started_At IS NULL AND game.ended_At IS NULL";

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                p = new Player.Player()
                                {
                                    Nickname = reader.GetString(0),
                                    Player_id = reader.GetInt32(1),
                                    Firstname = reader.GetString(2),
                                    Lastname = reader.GetString(3)
                                    
                                };
                                players.Add(p);
                            }
                        }                                            
                    }
                    catch (PostgresException ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message);
                    }
                    conn.Close();
                }
                return players;
            }
        }

        //Metod för att få upp alla registrerade användare som redan är i ett spel.
        public List<Player.Player> PlayersInGame()
        {
            List<Player.Player> players = new List<Player.Player>();
            using (var conn = new
             NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT player.player_id, player.firstname, player.lastname, player.nickname FROM player " +
                            "INNER JOIN game_player ON game_player.player_ID = player.player_id " +
                            "INNER JOIN game ON game.game_id = game_player.game_id " +
                            "WHERE game.started_at IS NOT NULL AND game.ended_at IS NULL";

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
                    }
                    catch (PostgresException ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message);
                    }
                    conn.Close();
                }
                return players;
            }
        }

        //Metod för att få upp highscore
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
                        "GROUP BY player.nickname, player.firstname, player.lastname ORDER BY SUM DESC) SELECT* FROM rankscoreamount WHERE SUM IS NOT NULL";
                    using (var reader = cmd.ExecuteReader())
                    {
                        int rank = 1;
                        while (reader.Read())
                        {
                            try
                            {
                                
                                pe = new Player.highscoreplayer();
                                if (rank > 0)
                                {
                                pe.Rank = rank;

                                }
                                pe.Nickname = reader.GetString(0);
                                pe.Firstname = reader.GetString(1);
                                pe.Lastname = reader.GetString(2);
                                if (!reader.IsDBNull(3))
                                {
                                    pe.Score = reader.GetInt32(3);
                                }
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

        //Metod för att få upp vilken spelare som spelat mest matcher.
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

        //Metod för att få upp matcher som är avslutade.
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
                        " player.lastname ORDER BY COUNT DESC) SELECT * FROM mostgames WHERE COUNT > 0";
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
        //Metod för att få fram vem som i databasen som vunnit flest matcher.
        public List<Player.highscoreplayer> GetMostWinsGames()
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
                    cmd.CommandText = "SELECT player.firstname, player.lastname, player.nickname, COUNT(player.nickname) as WINS FROM game " +
                                    "INNER JOIN game_player ON game_player.game_id = game.game_id " +
                                    "INNER JOIN player on player.player_id = game_player.player_id " +
                                    "WHERE game.ended_at IS NOT NULL " +
                                    "GROUP BY player.firstname, player.lastname, player.nickname " +
                                    "ORDER BY WINS DESC";
                    using (var reader = cmd.ExecuteReader())
                    {
                        int rank = 1;

                        while (reader.Read())
                        {

                            pe = new Player.highscoreplayer()
                            {
                                Rank = rank,
                                Firstname = reader.GetString(0),
                                Lastname = reader.GetString(1),
                                Nickname = reader.GetString(2),
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

