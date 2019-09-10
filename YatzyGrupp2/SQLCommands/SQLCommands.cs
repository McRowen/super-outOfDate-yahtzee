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
                using(var cmd = new NpgsqlCommand(stmt, conn))
                {
                    cmd.Parameters.AddWithValue("player_Id", p.Player_id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p = new Player.Player()
                            {
                                Firstname = first,
                                Lastname = last,
                                Nickname = nick
                            };
                        }
                        return p;
                    }
                }
            }
        }
    }
}
