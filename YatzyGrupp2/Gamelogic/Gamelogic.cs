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

            if (dice != null)
            {
                num = dice;
            }

            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                if (randInarray[i] == false)
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
            if (Round > 3 || Round < 1)
            {
                Round = 1;
            }
            else
            {
                Round++;
            }
        }

        public int Points(int[] d, bool[] dt, int number)
        {
            int points = 0;

            if (dt[0] == true && d[0] == number)
            {
                points += d[0];
            }
            if (dt[1] == true && d[1] == number)
            {
                points += d[1];
            }
            if (dt[2] == true && d[2] == number)
            {
                points += d[2];
            }
            if (dt[3] == true && d[3] == number)
            {
                points += d[3];
            }
            if (dt[4] == true && d[4] == number)
            {
                points += d[4];
            }


            return points;
        }
        public int FullHouseOnTheTable(int[] d, bool[] dt)
        {
            int points = 0;
            if (FullHouse(d, dt))
            {
                points = d[0] + d[1] + d[2] + d[3] + d[4];
            }
            return points;
        }

        public int SmallLargeStraight(int[] d, bool[] dt)
        {
            int points = 0;
            if (CalcLargeStraight(d, dt))
            {
                points = d[0] + d[1] + d[2] + d[3] + d[4];
            }
            return points;
        }

        public int Chans(int[] d, bool[] dt)
        {
            int points = 0;
            points = d[0] + d[1] + d[2] + d[3] + d[4];
            return points;
        }
        public int PointsExtra(int[] d, bool[] dt) //Vi kommer nog få ändra ordningen på if statserna så att de med mer poäng kommer först
        {                                          //och inte de med mindre poäng för att det är möjöligt att ett true värde på tex tvåpar när man
            int points = 0;                        //ska ha fyrtal
            
            if (ParTest(d, dt))
            {                
                int temp = 0;
                for(int i = 0; i < dt.Length; i++)
                {
                    if(dt[i] == true)
                    {
                        temp = d[i];
                    }
                }
                points = temp * 2;
            }
            if (Triss(d, dt))
            {
                
                int temp = 0;
                for (int i = 0; i < dt.Length; i++)
                {
                    if (dt[i] != false)
                    {
                        temp = d[i];
                    }
                }
                points = temp * 3;
            }

            if(Tvapar(d, dt))
            {
                Array.Sort(d);
                if (d[0] == d[1] && d[2] == d[3])
                {
                    points = d[0] * 2 + d[2] * 2;
                }
                else if (d[1] == d[2] && d[3] == d[4])
                {
                    points = d[1] * 2 + d[3] * 2;
                }
            }

            if (Fyrtal(d, dt))
            {
                Array.Sort(d);
                if (d[0] == d[1] && d[2] == d[3] && d[0] == d[3])
                {
                    points = d[0] * 4;
                }
                else if (d[1] == d[2] && d[3] == d[4] && d[1] == d[4])
                {
                    points = d[1] * 4;
                }
            }

            if(yatzy(d, dt))
            {
                points = 50;
            }
            return points;
            
        }
        public bool CalcLargeStraight(int[] d, bool[] dt)
        {
            Array.Sort(d);

            if (((d[0] == 1) && (d[1] == 2) && (d[2] == 3) && (d[3] == 4) && (d[4] == 5)) || ((d[0] == 2) && (d[1] == 3) && (d[2] == 4) && (d[3] == 5) && (d[4] == 6)))
            {
                return true;
            }
            return false;
        }
        public bool FullHouse(int[] d, bool[] dt)
        {           
            Array.Sort(d);

            if ((((d[0] == d[1]) && (d[1] == d[2])) && (d[3] == d[4]) && (d[2] != d[3])) || ((d[0] == d[1]) && ((d[2] == d[3]) && (d[3] == d[4])) && (d[1] != d[2])))
            {              
                return true;
            }
            return false;
        }
        //public bool Par(int[] d)
        //{
        //    d = new int[5];
        //    bool par = false;

        //    for (int i = 0; i < d.Length; i++)
        //    {
        //        for (int j = 0; j < d.Length; j++)
        //        {
        //            if (d[i] == d[j])
        //            {
        //                par = true;
        //            }
        //        }                
        //    }
        //    return par;
        //}
        //public bool SmallLadder(int[] d)
        //{
        //    int[] smallLadder = new int[] { 1, 2, 3, 4, 5 };
        //    d = new int[5];
        //    bool ladder = false;
        //    int temp = 0;

        //    for (int i = 0; i < smallLadder.Length; i++)
        //    {
        //        for (int j = 0; j < smallLadder.Length - 1; j++)
        //        {
        //            if (smallLadder[j] > smallLadder[j] + 1)
        //            {
        //                temp = smallLadder[j + 1];
        //                smallLadder[j + 1] = smallLadder[j];
        //                smallLadder[j] = temp;
        //            }
        //            if (d[i] == smallLadder[j])
        //            {
        //                ladder = true;
        //            }
        //        }
        //    }
        //    return ladder;
        //}
        //public bool BigLadder(int[] d)
        //{
        //    int[] bigLadder = new int[] { 2, 3, 4, 5, 6 };
        //    d = new int[5];
        //    bool ladder = false;
        //    int temp = 0;

        //    for (int i = 0; i < bigLadder.Length; i++)
        //    {
        //        for (int j = 0; j < bigLadder.Length - 1; j++)
        //        {
        //            if (bigLadder[j] > bigLadder[j] + 1)
        //            {
        //                temp = bigLadder[j + 1];
        //                bigLadder[j + 1] = bigLadder[j];
        //                bigLadder[j] = temp;
        //            }
        //            if (d[i] == bigLadder[j])
        //            {
        //                ladder = true;
        //            }
        //        }
        //    }
        //    return ladder;
        //}

        public bool ParTest(int[] d, bool[] dt)
        {
            //int temp = 0;
            for(int i = 0; i < d.Length; i++)
            {
                for(int l = i; l < d.Length-1; l++)
                {
                    if(d[i] == d[l] && dt[i] == true && dt[l] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Triss(int[] d, bool[] dt)
        {
            int temp = 0;
            

            Array.Sort(d);
            if (d[0] == d[1] && d[1] == d[2])
            {
                return true;
            }
            else if(d[1] == d[2] && d[2] == d[3])
            {
                return true;
            }
            else if (d[2] == d[3] && d[3] == d[4])
            {
                return true;
            }


            return false;
        }

        public bool Tvapar(int[] d, bool[] dt)
        {
            Array.Sort(d);
            if (d[0] == d[1] && d[2] == d[3])
            {
                return true;
            }
            else if(d[1] == d[2] && d[3] == d[4])
            {
                return true;
            }
            return false;
        }
        public bool Fyrtal(int[] d, bool[] dt)
        {
            Array.Sort(d);
            if (d[0] == d[1] && d[2] == d[3] && d[0] == d[3]) // 0=3 så att vi inte får ett falskt positivt med tvåpar
            {
                return true;
            }
            else if (d[1] == d[2] && d[3] == d[4] && d[1] == d[4])
            {
                return true;
            }


            return false;
        }

        public bool yatzy(int[] d, bool[] dt)
        {
            int temp = d[0];
            for(int i = 0; i < d.Length; i++)
            {
                if(d[i] != temp)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
