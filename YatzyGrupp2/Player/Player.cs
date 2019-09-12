using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatzyGrupp2.Player
{
    public class Player
    {
        public int Player_id { get;  set; }
        public int Score { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public int Ended_At { get; set; }

        public Player()
        {
            int id = 0;
            id++;
            Player_id = id;
        }
        public override string ToString()
        {
            return $"Nu spelar: {Nickname}";
        }
    }
}
