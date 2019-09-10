using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatzyGrupp2.Test
{
    class DataTest
    {
        public string Spelare { get; set; }
        public int Test1 { get; set; }
        public int Test2 { get; set; }
        public int Test3 { get; set; }
        public int Test4 { get; set; }

        public DataTest(string spelare, int test1, int test2, int test3, int test4)
        {
            Spelare = spelare;
            Test1 = test1;
            Test2 = test2;
            Test3 = test3;
            Test4 = test4;
        }



        public void SystemLinkChildSchedule(int schedule_id, int child_id)
        {
            using (var conn = new
                            NpgsqlConnection(ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO child_schedule(child_id ,schedule_id, startdate) VALUES(@child_id, @schedule_id, NOW())";
                    cmd.Parameters.AddWithValue("child_id", child_id);
                    cmd.Parameters.AddWithValue("schedule_id", schedule_id);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
}
