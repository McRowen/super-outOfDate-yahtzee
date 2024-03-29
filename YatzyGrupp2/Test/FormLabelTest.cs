﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YatzyGrupp2.View;

namespace YatzyGrupp2.Test
{
    public partial class FormLabelTest : Form 
    {
        //Alla listor som behövs
        List<Label> testList = new List<Label>();
        LabelTest cellLabelArray = new LabelTest();
        List<Player.Player> gamePlayers = new List<Player.Player>();
        List<Game.Game> GetGames = new List<Game.Game>();
        Gamelogic.Gamelogic gl = new Gamelogic.Gamelogic();
        SQLCommands.SQLCommands sql = new SQLCommands.SQLCommands();

        public FormLabelTest()
        {
            //Lite sql och annat som behöver hända i start
            InitializeComponent();
            gamePlayers = StartView.players;
            GetGames = SQLCommands.SQLCommands.GetGames;
            lblSpelare.Text = "Nu spelar " + gamePlayers[0].Nickname;
            this.BackgroundImage = Properties.Resources.velourgreen;
            Dice1.Image = side1;
            Dice2.Image = side2;
            Dice3.Image = side3;
            Dice4.Image = side4;
            Dice5.Image = side5;
        }
        //Variablar som används för att kontrollera labels och annat samt en del som används för att kolla olika saker i kåden
        bool valt = false; //Om man har valt ett resultat
        int[] dice = new int[5]; //Vad blev resultatet av tärningskastet
        bool[] diceThrow = new bool[] { false, false, false, false, false }; //Vilka tärningar som är vald
        int turn = 0; //Väms tur är det
        int throws = 0; //Hur många kast är kvar
        int sum = 0;  //Hur mycket påäng
        int players; //Hur många spelare
        int tempPos = 0; //Håller koll på vad musen var över för label tidigare
        int xDif = 100; //Bestämmer hur stor labeln är samt vart den ska vara i X
        int yDif = 23; //Bestämmer hur stor labeln är samt vart den ska vara i X
        int edgexDif = 20; //Hur långt ifrån kanten alla labels ska vara
        int edgeyDif = 100; //Hur långt ifrån kanten alla labels ska vara
        int fontSize = 12; //Hur stort typsnitt i labels
        string fontType = "Times New Roman"; //Vad för typsnitt
        bool styrdYatzy = false; //Om det är styrt eller inte
        int[] playerRound; //Har med vad som ska väljas i styrtyatzy
        static string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\"); //Används för att hämta bilder
        static int remove1 = path.IndexOf("\\b"); //Tar bort onödigt i path till bilder
        static int remove2 = path.IndexOf("g\\"); //Tar bort onödigt i path till bilder
        static string result = PathText(remove1, remove2, path); //Tar bort onödigt i path till bilder
        static Image side1 = Image.FromFile(result + "Dice1.bmp");//---------|----------          
        static Image side2 = Image.FromFile(result + "Dice2.bmp");//---------|---------- 
        static Image side3 = Image.FromFile(result + "Dice3.bmp");//   Path till bilder 
        static Image side4 = Image.FromFile(result + "Dice4.bmp");//---------|---------- 
        static Image side5 = Image.FromFile(result + "Dice5.bmp");//---------|---------- 
        static Image side6 = Image.FromFile(result + "Dice6.bmp");//---------|---------- 

        public void ThrowTheDices() //Används för att flytta tärnings bilderna
        {
            if (Dice1.BackColor != Color.Red)
            {
                this.Dice1.Location = new Point(707, 385);
                this.Dice1.Location = new Point(648, 307);
                this.Dice1.Location = new Point(626, 236);
            }
            if (Dice2.BackColor != Color.Red)
            {
                this.Dice2.Location = new Point(847, 387);
                this.Dice2.Location = new Point(831, 229);
                this.Dice2.Location = new Point(781, 193);
            }
            if (Dice3.BackColor != Color.Red)
            {
                this.Dice3.Location = new Point(916, 381);
                this.Dice3.Location = new Point(838, 298);
                this.Dice3.Location = new Point(737, 263);
            }
            if (Dice4.BackColor != Color.Red)
            {
                this.Dice4.Location = new Point(959, 378);
                this.Dice4.Location = new Point(898, 263);
                this.Dice4.Location = new Point(845, 202);
            }
            if (Dice5.BackColor != Color.Red)
            {
                this.Dice5.Location = new Point(898, 364);
                this.Dice5.Location = new Point(907, 286);
                this.Dice5.Location = new Point(948, 167);
            }
        }

        static public string PathText(int r1, int r2, string path)
        {
            string result = "";

            if (r1 != r2 && r1 >= 0)
            {

                result = path.Remove(r1 + 1, r2 - r1);

            }
            return result;
        } //Används för att ta bort ondädigt ifrån sökvägen

        public void ResetDice()
        {
            Dice1.Text = null;
            Dice2.Text = null;
            Dice3.Text = null;
            Dice4.Text = null;
            Dice5.Text = null;

            Dice1.BackColor = Color.White;
            Dice2.BackColor = Color.White;
            Dice3.BackColor = Color.White;
            Dice4.BackColor = Color.White;
            Dice5.BackColor = Color.White;
        } //Återställer tärningarna

        private void FormLabelTest_Load(object sender, EventArgs e) //Sätter ut och fyller alla labels med data. Ladda också in lite data
        {
            int temp = 0;
            gamePlayers = View.StartView.players;
            styrdYatzy = View.StartView.styrdYatzy;
            players = gamePlayers.Count;
            playerRound = new int[players];
            playerRound = Enumerable.Repeat<int>(1, players).ToArray(); //Sätter allt i arrayen till 1
            lblRound.Text = "";
            for (int i = 0; i < 19; i++)
            {
                
                for (int o = 0; o < players + 1; o++)
                {
                    Label cellLabel = new Label();

                    if(i <= 9)
                    {
                        cellLabel.Name = "lblX" + Convert.ToString(o) + "Y0" + Convert.ToString(i);
                    }
                    else
                    {
                        cellLabel.Name = "lblX" + Convert.ToString(o) + "Y" + Convert.ToString(i);
                    }
                    
                    cellLabel.Text = "lbl------" + Convert.ToString(temp);
                    cellLabel.Font = new System.Drawing.Font(fontType, fontSize, FontStyle.Bold);
                    cellLabel.BorderStyle = BorderStyle.FixedSingle;
                    cellLabel.Size = new Size(xDif, yDif);
                    cellLabel.Location = new Point(edgexDif + (o * xDif), edgeyDif + (i * yDif));
                    cellLabel.Click += new System.EventHandler(ctrlClick);
                    cellLabel.BackColor = System.Drawing.Color.White;
                    cellLabel.MouseEnter += new System.EventHandler(label_Enter);
                    cellLabel.MouseLeave += new System.EventHandler(label_Leave);
                    temp++;
                    testList.Add(cellLabel);
                }               
            }
            for(int q = 0; q < testList.Count; q++)
            {
               Controls.Add(testList[q]);
            }
            PlayersActive();

            lblSpelare.Text = "Spelare: " + gamePlayers[turn].Nickname;
        }

        public void ChangeLabelText(string labelName, string labelText) //Ändrar texten i en label
        {
            for(int i = 0; i < testList.Count; i++)
            {
                if(testList[i].Name == labelName)
                {
                    testList[i].Text = labelText;
                }
            }
        }

        public void ChangeLabelColor() // Ändrar färgen i labels
        {
            int[] rows = new int[] { 0, 1, 2, 3, 4 };
            int[] columnUpper = new int[] { 1, 2, 3, 4, 5, 6, 9 };
            int[] columnLower = new int[] { 10, 11, 12, 13, 14, 15, 16, 17 };


            for (int i = 0; i < testList.Count; i++)
            {
                for (int a = 0; a < rows.Length; a++)
                {
                    if (testList[i].Name == "lblX" + rows[a] + "Y00")
                    {
                        testList[i].BackColor = System.Drawing.Color.Orange;
                    }
                    if (testList[i].Name == "lblX" + rows[a] + "Y07") 
                    {
                        testList[i].BackColor = System.Drawing.Color.Orange;
                    }
                    if (testList[i].Name == "lblX" + rows[a] + "Y08")
                    {
                        testList[i].BackColor = System.Drawing.Color.Orange;
                    }
                    if (testList[i].Name == "lblX" + rows[a] + "Y18")
                    {
                        testList[i].BackColor = System.Drawing.Color.Orange;
                    }
                }
                for (int b = 0; b < columnUpper.Length; b++)
                {
                    if (testList[i].Name == "lblX0Y0" + columnUpper[b])
                    {
                        testList[i].BackColor = System.Drawing.Color.LightYellow;
                    }
                }
                for (int c = 0; c < columnLower.Length; c++)
                {
                    if (testList[i].Name == "lblX0Y" + columnLower[c])
                    {
                        testList[i].BackColor = System.Drawing.Color.LightYellow;
                    }
                }

            }

            
        }

        public void SetLabelTextEmpty() //Sätter texten i en label till tom/0
        {
            for(int i = 0; i < testList.Count; i++)
            {
                testList[i].Text = "0";
            }
        }

        private void PlayersActive() //Laddar in all viktigt text
        {
            SetLabelTextEmpty();
            ChangeLabelText("lblX0Y00", "Spelare");
            ChangeLabelText("lblX0Y01", "Ettor");
            ChangeLabelText("lblX0Y02", "Tvåor");
            ChangeLabelText("lblX0Y03", "Treor");
            ChangeLabelText("lblX0Y04", "Fyror");
            ChangeLabelText("lblX0Y05", "Femmor");
            ChangeLabelText("lblX0Y06", "Sexor");
            ChangeLabelText("lblX0Y07", "Summa");
            ChangeLabelText("lblX0Y08", "Bonus");
            ChangeLabelText("lblX0Y09", "Par");
            ChangeLabelText("lblX0Y10", "Två Par");
            ChangeLabelText("lblX0Y11", "Tretal");
            ChangeLabelText("lblX0Y12", "Fyrtal");
            ChangeLabelText("lblX0Y13", "Liten Stege");
            ChangeLabelText("lblX0Y14", "Stor Stege");
            ChangeLabelText("lblX0Y15", "Kåk");
            ChangeLabelText("lblX0Y16", "Chans");
            ChangeLabelText("lblX0Y17", "Yatzy");
            ChangeLabelText("lblX0Y18", "Total");
            for (int i = 0; i < gamePlayers.Count; i++)
            {
                ChangeLabelText("lblX" + Convert.ToString(i + 1) + "Y00", gamePlayers[i].Nickname);
            }

            ChangeLabelColor();

        }

        private void Button1_Click(object sender, EventArgs e) //Används inte
        {
            SetLabelTextEmpty();
            ChangeLabelText("lblX0Y00", "Spelare:");
            ChangeLabelText("lblX0Y01", "Ettor");
            ChangeLabelText("lblX0Y02", "Tvåor");
            ChangeLabelText("lblX0Y03", "Treor");
            ChangeLabelText("lblX0Y04", "Fyror");
            ChangeLabelText("lblX0Y05", "Femmor");
            ChangeLabelText("lblX0Y06", "Sexor");
            ChangeLabelText("lblX0Y07", "Summa");
            ChangeLabelText("lblX0Y08", "Bonus");
            ChangeLabelText("lblX0Y09", "Par");
            ChangeLabelText("lblX0Y10", "Två Par");
            ChangeLabelText("lblX0Y11", "Tretal");
            ChangeLabelText("lblX0Y12", "Fyrtal");
            ChangeLabelText("lblX0Y13", "Liten Stege");
            ChangeLabelText("lblX0Y14", "Stor Stege");
            ChangeLabelText("lblX0Y15", "Kåk");
            ChangeLabelText("lblX0Y16", "Chans");
            ChangeLabelText("lblX0Y17", "Yatzy");
            ChangeLabelText("lblX0Y18", "Total");
            for(int i = 0; i < gamePlayers.Count; i++)
            {
                ChangeLabelText("lblX" + Convert.ToString(i + 1) + "Y00", gamePlayers[i].Nickname);
            }
        }
        
        private void label_Click(object sender, MouseEventArgs e) //Används inte
        {
            Control test = (Control)sender;
            string test2 = Convert.ToString(test);
            
        }
       
        private void ctrlClick(System.Object sender, EventArgs e) //Eventhandler för label om man klickar på dem. Den används också för att fixa påäng
        {
            Control ctrl = (Control)sender;

            if (valt == false)
            {
                for (int i = 0; i < testList.Count; i++)
                {
                    if (ctrl.Name == testList[i].Name)
                    {
                        int temp = GetYValue(ctrl.Name);
                        if (GetXValue(ctrl.Name) - 1 == turn && styrdYatzy == false)
                        {
                            if (temp < 7 && temp > 0)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.Points(dice, diceThrow, temp)));
                                sum += gl.Points(dice, diceThrow, temp);
                            }
                            else if (GetYValue(ctrl.Name) == 9) //Par
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.Pair(dice, diceThrow)));
                                sum += gl.Pair(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 10)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.TwoPair(dice, diceThrow)));
                                sum += gl.TwoPair(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 11)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.ThreeOfAKind(dice, diceThrow)));
                                sum += gl.ThreeOfAKind(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 12)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.FourOfAKind(dice, diceThrow)));
                                sum += gl.FourOfAKind(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 13)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.SmallLargeStraight(dice, diceThrow)));
                                sum += gl.SmallLargeStraight(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 14)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.SmallLargeStraight(dice, diceThrow)));
                                sum += gl.SmallLargeStraight(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 15)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.FullHouseOnTheTable(dice, diceThrow)));
                                sum += gl.FullHouseOnTheTable(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 16)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.Chans(dice, diceThrow)));
                                sum += gl.Chans(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 17)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.Yatzyz(dice, diceThrow)));
                                sum += gl.Yatzyz(dice, diceThrow);
                            }
                        }
                        else if (GetXValue(ctrl.Name) - 1 == turn && styrdYatzy == true)
                        {
                            if (temp < 7 && temp > 0 && GetYValue(ctrl.Name) == playerRound[turn])
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.Points(dice, diceThrow, temp)));
                                sum += gl.Points(dice, diceThrow, temp);
                            }
                            else if (GetYValue(ctrl.Name) == 9 && GetYValue(ctrl.Name) == playerRound[turn] + 2) //Par
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.Pair(dice, diceThrow)));
                                sum += gl.Pair(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 10 && GetYValue(ctrl.Name) == playerRound[turn] + 2)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.TwoPair(dice, diceThrow)));
                                sum += gl.TwoPair(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 11 && GetYValue(ctrl.Name) == playerRound[turn] + 2)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.ThreeOfAKind(dice, diceThrow)));
                                sum += gl.ThreeOfAKind(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 12 && GetYValue(ctrl.Name) == playerRound[turn] + 2)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.FourOfAKind(dice, diceThrow)));
                                sum += gl.FourOfAKind(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 13 && GetYValue(ctrl.Name) == playerRound[turn] + 2)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.SmallLargeStraight(dice, diceThrow)));
                                sum += gl.SmallLargeStraight(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 14 && GetYValue(ctrl.Name) == playerRound[turn] + 2)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.SmallLargeStraight(dice, diceThrow)));
                                sum += gl.SmallLargeStraight(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 15 && GetYValue(ctrl.Name) == playerRound[turn] + 2)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.FullHouseOnTheTable(dice, diceThrow)));
                                sum += gl.FullHouseOnTheTable(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 16 && GetYValue(ctrl.Name) == playerRound[turn] + 2)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.Chans(dice, diceThrow)));
                                sum += gl.Chans(dice, diceThrow);
                            }
                            else if (GetYValue(ctrl.Name) == 17 && GetYValue(ctrl.Name) == playerRound[turn] + 2)
                            {
                                ChangeLabelText(ctrl.Name, Convert.ToString(gl.Yatzyz(dice, diceThrow)));
                                sum += gl.Yatzyz(dice, diceThrow);
                            }
                        }
                    }

                }
                valt = true;
            }
            
        }

        public int GetYValue(string name) //Får Y värdet ifrån en label namn
        {
            int temp = 0;
            for(int i = 0; i < testList.Count; i++)
            {
                if(name == testList[i].Name)
                {
                    temp = int.Parse(Convert.ToString(testList[i].Name[6]) + Convert.ToString(testList[i].Name[7]));

                }
            }
            return temp;
        }

        public int GetXValue(string name) //Får X värdet ifrån en label namn
        {
            int temp = 0;
            temp = int.Parse(Convert.ToString(name[4]));

            
            return temp;
        }

        public void SumScore() //Lägger ut påängen i labels
        {
            int temp;
            for (int n = 0; n < players; n++)
            {
                temp = 0;
                for (int i = 1; i < 7; i++)
                {
                    for (int k = 0; k < testList.Count; k++)
                    {
                        if (testList[k].Name == "lblX" + Convert.ToString(turn + 1) + "Y0" + Convert.ToString(i))
                        {
                            temp += Convert.ToInt32(testList[k].Text);
                            //temp = temp + int.Parse(testList[k].Text);

                        }
                        else if (testList[k].Name == "lblX" + Convert.ToString(turn + 1) + "Y" + Convert.ToString(i))
                        {
                            temp += Convert.ToInt32(testList[k].Text);
                            //temp = temp + int.Parse(testList[k].Text);

                        }

                    }
                    for (int a = 0; a < testList.Count; a++)
                    {
                        if (testList[a].Name == "lblX" + Convert.ToString(turn + 1) + "Y07")
                        {
                            testList[a].Text = Convert.ToString(temp);


                        }

                    }
                    for (int a = 0; a < testList.Count; a++)
                    {
                        if (testList[a].Name == "lblX" + Convert.ToString(turn + 1) + "Y08")
                        {
                            if (temp >= 63)
                            {
                                int bonus = 50;
                                testList[a].Text = Convert.ToString(bonus);
                            }



                        }

                    }
                }

                //gamePlayers[n].Score = temp;
            }




        }

        public void TotalScore() //Lägger ut påängen i labels total
        {
            int temp;
            for (int n = 0; n < players; n++)
            {
                temp = 0;
                for (int i = 7; i < 18; i++)
                {
                    for (int k = 0; k < testList.Count; k++)
                    {
                        if (testList[k].Name == "lblX" + Convert.ToString(turn + 1) + "Y0" + Convert.ToString(i))
                        {
                            temp += Convert.ToInt32(testList[k].Text);
                            //temp = temp + int.Parse(testList[k].Text);

                        }
                        else if (testList[k].Name == "lblX" + Convert.ToString(turn + 1) + "Y" + Convert.ToString(i))
                        {
                            temp += Convert.ToInt32(testList[k].Text);
                            //temp = temp + int.Parse(testList[k].Text);

                        }

                    }
                    for (int a = 0; a < testList.Count; a++)
                    {
                        if (testList[a].Name == "lblX" + Convert.ToString(turn + 1) + "Y18")
                        {
                            testList[a].Text = Convert.ToString(temp);
                        }
                        SetScore(testList);
                    }
                }
            }
        }

        public void SetScore(List<Label> label) //Lägger in påängen i databas
        {

            for (int i = 0; i < label.Count; i++)
            {
                if (label[i].Name == "lblX" + Convert.ToString(1) + "Y18")
                {
                    gamePlayers[0].Score = int.Parse(label[i].Text);
                }
                if (label[i].Name == "lblX" + Convert.ToString(2) + "Y18")
                {
                    gamePlayers[1].Score = int.Parse(label[i].Text);
                }
                if (label[i].Name == "lblX" + Convert.ToString(3) + "Y18")
                {
                    gamePlayers[2].Score = int.Parse(label[i].Text);
                }
                if (label[i].Name == "lblX" + Convert.ToString(4) + "Y18")
                {
                    gamePlayers[3].Score = int.Parse(label[i].Text);
                }
            }
        }

        private void label_Enter(object sender, EventArgs e) //Om musen går över en label
        {
            Control ctrl = (Control)sender;
            for (int i = 0; i < testList.Count; i++)
            {
                for (int a = 0; a < players; a++)
                {
                    if (testList[i].Name == ctrl.Name)
                    {
                        int temp = int.Parse(testList[i].Name[6].ToString());
                        if (temp == 0)
                        {
                            temp = int.Parse(Convert.ToString(testList[i].Name[6]) + Convert.ToString(testList[i].Name[7]));
                        }

                        int temp2 = int.Parse(testList[i].Name[4].ToString());
                        for (int k = 0; k <= players; k++)
                        {
                            string xTemp = Convert.ToString(k);
                            string yTemp = Convert.ToString(temp);
                            string nameTemp = "lblX" + xTemp + "Y" + yTemp;
                            testList[i- temp2 + k].BackColor = Color.LightGray;
                            ChangeLabelColor();

                        }

                        testList[i].BackColor = Color.Gray;
                        ChangeLabelColor();
                        tempPos = i;

                    }
                }

            }
        }

        private void label_Leave(object sender, EventArgs e) //Om musen går ut ur en label
        {
            Control ctrl = (Control)sender;
            for (int i = 0; i < testList.Count; i++)
            {
                for (int a = 0; a < players; a++)
                {
                    if (testList[i].Name == ctrl.Name)
                    {
                        if(tempPos == i-1 || tempPos == i + 1)
                        {
                            int temp = int.Parse(testList[i].Name[6].ToString());
                            if (temp == 0)
                            {
                                temp = int.Parse(Convert.ToString(testList[i].Name[6]) + Convert.ToString(testList[i].Name[7]));
                            }

                            int temp2 = int.Parse(testList[i].Name[4].ToString());
                            for (int k = 0; k <= players; k++)
                            {
                                string xTemp = Convert.ToString(k);
                                string yTemp = Convert.ToString(temp);
                                string nameTemp = "lblX" + xTemp + "Y" + yTemp;
                                testList[i - temp2 + k].BackColor = Color.LightGray;
                                ChangeLabelColor();

                            }

                            testList[i].BackColor = Color.Gray;
                            ChangeLabelColor();
                            //tempPos = i;
                        }
                        
                        else
                        {
                            int temp = int.Parse(testList[i].Name[6].ToString());
                            if (temp == 0)
                            {
                                temp = int.Parse(Convert.ToString(testList[i].Name[6]) + Convert.ToString(testList[i].Name[7]));
                            }

                            int temp2 = int.Parse(testList[i].Name[4].ToString());
                            for (int k = 0; k <= players; k++)
                            {
                                string xTemp = Convert.ToString(k);
                                string yTemp = Convert.ToString(temp);
                                string nameTemp = "lblX" + xTemp + "Y" + yTemp;
                                testList[i - temp2 + k].BackColor = Color.White;
                                ChangeLabelColor();

                            }
                            //tempPos = i;
                        }
                        




                    }
                }

            }
        }

        private void ThrowDices_Click(object sender, EventArgs e) //Om man klickar på kasta tärning
        {
            throws++;
            if (throws == 4)
            {
                throws = 0 + 1 ;
            }
            lblThrows.Text = "Kast nr: " + throws;
            lblThrows.BackColor = Color.Transparent;
            lblThrows.Font = new System.Drawing.Font(fontType, fontSize, FontStyle.Bold);

            ThrowTheDices();

            dice = gl.GetRandomDice(diceThrow, dice);
            if (diceThrow[0] != true)
            {
                Dice1.Text = Convert.ToString(dice[0]);
                if (Dice1.Text == "1")
                {
                    Dice1.Text = "";
                    Dice1.Image = side1;
                }
                if (Dice1.Text == "2")
                {
                    Dice1.Text = "";
                    Dice1.Image = side2;
                }
                if (Dice1.Text == "3")
                {
                    Dice1.Text = "";
                    Dice1.Image = side3;
                }
                if (Dice1.Text == "4")
                {
                    Dice1.Text = "";
                    Dice1.Image = side4;
                }
                if (Dice1.Text == "5")
                {
                    Dice1.Text = "";
                    Dice1.Image = side5;
                }
                if (Dice1.Text == "6")
                {
                    Dice1.Text = "";
                    Dice1.Image = side6;
                }
            }
            if (diceThrow[1] != true)
            {
                Dice2.Text = Convert.ToString(dice[1]);
                if (Dice2.Text == "1")
                {
                    Dice2.Text = "";
                    Dice2.Image = side1;
                }
                if (Dice2.Text == "2")
                {
                    Dice2.Text = "";
                    Dice2.Image = side2;
                }
                if (Dice2.Text == "3")
                {
                    Dice2.Text = "";
                    Dice2.Image = side3;
                }
                if (Dice2.Text == "4")
                {
                    Dice2.Text = "";
                    Dice2.Image = side4;
                }
                if (Dice2.Text == "5")
                {
                    Dice2.Text = "";
                    Dice2.Image = side5;
                }
                if (Dice2.Text == "6")
                {
                    Dice2.Text = "";
                    Dice2.Image = side6;
                }
            }
            if (diceThrow[2] != true)
            {
                Dice3.Text = Convert.ToString(dice[2]);
                if (Dice3.Text == "1")
                {
                    Dice3.Text = "";
                    Dice3.Image = side1;
                }
                if (Dice3.Text == "2")
                {
                    Dice3.Text = "";
                    Dice3.Image = side2;
                }
                if (Dice3.Text == "3")
                {
                    Dice3.Text = "";
                    Dice3.Image = side3;
                }
                if (Dice3.Text == "4")
                {
                    Dice3.Text = "";
                    Dice3.Image = side4;
                }
                if (Dice3.Text == "5")
                {
                    Dice3.Text = "";
                    Dice3.Image = side5;
                }
                if (Dice3.Text == "6")
                {
                    Dice3.Text = "";
                    Dice3.Image = side6;
                }
            }
            if (diceThrow[3] != true)
            {
                Dice4.Text = Convert.ToString(dice[3]);
                if (Dice4.Text == "1")
                {
                    Dice4.Text = "";
                    Dice4.Image = side1;
                }
                if (Dice4.Text == "2")
                {
                    Dice4.Text = "";
                    Dice4.Image = side2;
                }
                if (Dice4.Text == "3")
                {
                    Dice4.Text = "";
                    Dice4.Image = side3;
                }
                if (Dice4.Text == "4")
                {
                    Dice4.Text = "";
                    Dice4.Image = side4;
                }
                if (Dice4.Text == "5")
                {
                    Dice4.Text = "";
                    Dice4.Image = side5;
                }
                if (Dice4.Text == "6")
                {
                    Dice4.Text = "";
                    Dice4.Image = side6;
                }
            }
            if (diceThrow[4] != true)
            {
                Dice5.Text = Convert.ToString(dice[4]);
                if (Dice5.Text == "1")
                {
                    Dice5.Text = "";
                    Dice5.Image = side1;
                }
                if (Dice5.Text == "2")
                {
                    Dice5.Text = "";
                    Dice5.Image = side2;
                }
                if (Dice5.Text == "3")
                {
                    Dice5.Text = "";
                    Dice5.Image = side3;
                }
                if (Dice5.Text == "4")
                {
                    Dice5.Text = "";
                    Dice5.Image = side4;
                }
                if (Dice5.Text == "5")
                {
                    Dice5.Text = "";
                    Dice5.Image = side5;
                }
                if (Dice5.Text == "6")
                {
                    Dice5.Text = "";
                    Dice5.Image = side6;
                }
            }
           

            gl.IncrementRound();

            if (gl.TurnOver())
            {
                ThrowDices.Enabled = false;
            }
            else
            {
                ThrowDices.Enabled = true;
            }
        }

        private void EndGame_Click(object sender, EventArgs e) //Om man trycker på avsluta
        {
            SumScore();
            TotalScore();
            sql.EndTime(GetGames);
            sql.GetScore(gamePlayers);

            this.Close();
            View.StartView startView = new View.StartView();
            gamePlayers.Clear();
            startView.listViewChosenPlayers.ItemsSource = null;
         

        }

        private void Dice1_MouseDown(object sender, MouseEventArgs e) //Om man klickar på tärningar
        {
            this.Dice1.Location = new Point(793, 522);

            int i = 0;

            if (diceThrow[i] != true)
            {
                diceThrow[i] = true;
                Dice1.BackColor = Color.Red;
            }
            else
            {
                diceThrow[i] = false;
                Dice1.BackColor = Color.White;
            }
        }

        private void Dice2_MouseDown(object sender, MouseEventArgs e)
        {
            this.Dice2.Location = new Point(855, 522);

            int i = 1;

            if (diceThrow[i] != true)
            {
                diceThrow[i] = true;
                Dice2.BackColor = Color.Red;
            }
            else
            {
                diceThrow[i] = false;
                Dice2.BackColor = Color.White;
            }
        }

        private void Dice3_MouseDown(object sender, MouseEventArgs e)
        {
            this.Dice3.Location = new Point(917, 522);
            int i = 2;

            if (diceThrow[i] != true)
            {
                diceThrow[i] = true;
                Dice3.BackColor = Color.Red;
            }
            else
            {
                diceThrow[i] = false;
                Dice3.BackColor = Color.White;
            }
        }

        private void Dice4_MouseDown(object sender, MouseEventArgs e)
        {
            this.Dice4.Location = new Point(979, 522);

            int i = 3;

            if (diceThrow[i] != true)
            {
                diceThrow[i] = true;
                Dice4.BackColor = Color.Red;
            }
            else
            {
                diceThrow[i] = false;
                Dice4.BackColor = Color.White;
            }
        }

        private void Dice5_MouseDown(object sender, MouseEventArgs e)
        {
            this.Dice5.Location = new Point(1041, 522);

            int i = 4;

            if (diceThrow[i] != true)
            {
                diceThrow[i] = true;
                Dice5.BackColor = Color.Red;
            }
            else
            {
                diceThrow[i] = false;
                Dice5.BackColor = Color.White;
            }
        }

        private void BtnNextPlayer_Click(object sender, EventArgs e) //Klickar på nästa spelare
        {
            this.Dice1.Location = new Point(793, 522);
            this.Dice2.Location = new Point(855, 522);
            this.Dice3.Location = new Point(917, 522);
            this.Dice4.Location = new Point(979, 522);
            this.Dice5.Location = new Point(1041, 522);

            Dice1.Image = side1;
            Dice2.Image = side2;
            Dice3.Image = side3;
            Dice4.Image = side4;
            Dice5.Image = side5;

            throws = 0;
            lblThrows.Text = "";
            SumScore();
            TotalScore();
            playerRound[turn]++;
            bool tempTurn = false;
            
            if (styrdYatzy == true)
            {
                if (playerRound[turn] < 7)
                {
                    lblRound.Text = "Få " + Convert.ToString(playerRound[turn]);
                }
                else
                {
                    for (int i = 0; i < testList.Count; i++)
                    {
                        if (testList[i].Name == "lblX0Y0" + Convert.ToString(playerRound[turn] + 2))
                        {
                            lblRound.Text = "Få " + testList[i].Text;
                            tempTurn = true;
                        }
                        if (testList[i].Name == "lblX0Y" + Convert.ToString(playerRound[turn] + 2) && testList[i].Text != "Total")
                        {
                            lblRound.Text = "Få " + testList[i].Text;
                            tempTurn = true;
                        }
                    }
                }
            }
           
            if (turn < gamePlayers.Count)
            {
                turn++;
            }
            if (turn == gamePlayers.Count)
            {
                turn = 0;
            }
            
            lblSpelare.Text = "Nu spelar: " + gamePlayers[turn].Nickname;
            gl.Round = 0; //Den här byter runda inte turn. Kolla i gamelogic för runda.
            ThrowDices.Enabled = true;
            diceThrow = Enumerable.Repeat<bool>(false, 5).ToArray(); // Gör alla värden i en array till false
            
            ResetDice();
            valt = false;
        }

        private void button1_Click_1(object sender, EventArgs e) //Klickar på hjälp kanppen
        {
            View.GameViewHelp gameViewHelp = new View.GameViewHelp();
            gameViewHelp.Show();
        }

        private void FormLabelTest_FormClosing(object sender, FormClosingEventArgs e) //Klickar på stäng av kanppen
        {
            View.StartView startView = new View.StartView();
            startView.Show();           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            List<Player.Player> selectedPlayer = new List<Player.Player>();
            sql.DeleteGameFromDb(selectedPlayer);
            sql.DeleteGameIdFromDb();
            this.Close();
            View.StartView startView = new View.StartView();
            gamePlayers.Clear();
            startView.listViewChosenPlayers.ItemsSource = null;
        }
    }        
}
