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



    //    public List<GamePlayer.GamePlayer> GetHighScore()
    //    {
    //        Player.Player p;
    //        List<GamePlayer.GamePlayer> gamers = new List<GamePlayer.GamePlayer>();
    //        using (var conn = new
    //           NpgsqlConnection(ConfigurationManager.ConnectionStrings["Dbconn"].ConnectionString))
    //        {
    //            conn.Open();
    //            using (var cmd = new NpgsqlCommand())
    //            {
    //                cmd.Connection = conn;
    //                cmd.CommandText = "SELECT player.nickname, player.firstname, player.lastname, game_player.score FROM game_player INNER JOIN player ON player.player_id = game_player.player_id ORDER BY game_player.score DESC";
    //                using (var reader = cmd.ExecuteReader())
    //                {
    //                    p = new Player.Player()
    //                    {
    //                       Firstname = reader.GetString(0),
    //                       Lastname = reader.GetString(1),
    //                       Nickname = reader.GetString(2),
    //                    };
    //                    gamers.Add(p);
    //                }
    //            }
    //            conn.Close();
    //        }
    //        return gamers;
    //    }
    }
}
