using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatzyGrupp2.Gamelogic
{
    class Gamelogic
    {
        //public int[] Dices { get; set; }
        ////public Random Roll { get; set; }

        ///*public Gamelogic1(int r1, int r2, int r3, int r4, int r5, int r6)
        //{

        //}*/
        //public Gamelogic()
        //{
        //    Dices = new int[] {1, 2, 3, 4, 5, 6 };
        //}

        public int Round { get; set; }

        public int[] GetRandomDice()
        {
            int[] num = new int[5];
            Random rnd = new Random();
            for(int i = 0; i < 5; i++)
            {
                int dice = rnd.Next(1, 7);
                num[i] = dice;
            }
            return num;
        }

        public bool TurnOver()
        {
            if (Round == 3)
                return true;
            else
                return false;
        }

        public void IncrementRound()
        {
            if(Round > 3 || Round < 1)
            {
                Round = 1;
            }
            else
            {
                Round++;
            }
        }
    }
}
