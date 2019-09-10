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
        public int Score { get; private set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }

        public override string ToString()
        {
            return $"Nu spelar: {Nickname}";
        }
    }
}
