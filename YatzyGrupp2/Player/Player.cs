using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatzyGrupp2.Player
{
    class Player
    {
        public int Player_id { get; private set; }
        public int Score { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }

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
