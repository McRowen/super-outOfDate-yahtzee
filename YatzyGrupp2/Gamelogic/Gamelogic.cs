using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatzyGrupp2.Gamelogic
{
    class Gamelogic
    {

        public int Round { get; set; }
        public List<int> DiceValue { get; set; }
        int temp;
        public int ShowPointsAvailable(int[] d, bool[] dt)
        {            
            if (Points(d, dt, 1) > 0 && Points(d, dt, 1) < 6)
            {
                temp = Points(d, dt, 1);
            }
            else if (Points(d, dt, 2) > 0 && Points(d, dt, 2) < 11)
            {
                temp = Points(d, dt, 2);
            }
            else if (Points(d, dt, 3) > 0 && Points(d, dt, 3) < 16)
            {
                temp = Points(d, dt, 3);
            }
            else if (Points(d, dt, 4) > 0 && Points(d, dt, 4) < 21)
            {
                temp = Points(d, dt, 4);
            }
            else if (Points(d, dt, 5) > 0 && Points(d, dt, 5) < 26)
            {
                temp = Points(d, dt, 5);
            }
            else if (Points(d, dt, 6) > 0 && Points(d, dt, 6) < 31)
            {
                temp = Points(d, dt, 6);
            }
            else if (PointsExtra(d, dt) > 4)
            {
                temp = PointsExtra(d, dt);
            }
            else if (PointsExtra(d, dt ) > 3)
            {
                temp = PointsExtra(d, dt);
            }
            else if (PointsExtra(d, dt) > 5)
            {
                temp = PointsExtra(d, dt);
            }
            else if (PointsExtra(d, dt) > 2)
            {
                temp = PointsExtra(d, dt);
            }
            else if (PointsExtra(d, dt) > 1)
            {
                temp = PointsExtra(d, dt);
            }
            else if (FullHouseOnTheTable(d, dt) > 6)
            {
                temp = FullHouseOnTheTable(d, dt);
            }
            else if (SmallLargeStraight(d, dt) > 14)
            {
                temp = SmallLargeStraight(d, dt);
            }
            else if (SmallLargeStraight(d, dt) > 19)
            {
                temp = SmallLargeStraight(d, dt);
            }
            return temp;
        }
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

            if (Yatzy(d, dt))
            {
                points = 50;
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
            if (Tvapar(d, dt))
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
        public bool Yatzy(int[] d, bool[] dt)
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
