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
        public List<int> DiceValue { get; set; }

        public int[] GetRandomDice(bool[] randInarray, int[] dice)
        {
            int[] num = new int[5];

            if(dice != null)
            {
                num = dice;
            }

            Random rnd = new Random();
            for(int i = 0; i < 5; i++)
            {
                if(randInarray[i] == false)
                {
                    int randValue = rnd.Next(1, 7);
                    num[i] = randValue;
                }
                
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

        public bool Par()
        {
            int[] d = new int[5];
            bool par = false;

            for (int i = 0; i < d.Length; i++)
            {
                for (int j = 0; j < d.Length; j++)
                {
                    if (d[i] == d[j])
                    {
                        par = true;
                    }
                }
                return par;
            }
        }

        public bool SmallLadder()
        {
            int[] smallLadder = new int { 1, 2, 3, 4, 5 };
            int[] d = new int[5];
            bool ladder = false;

            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] == smallLadder)
                {
                    ladder = true;
                }
                else
                {
                    ladder = false;
                }
            }
            return ladder;
        }
    }
}
