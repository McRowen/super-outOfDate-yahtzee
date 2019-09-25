using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YatzyGrupp2.Test
{
    public partial class FormLabelTest : Form
    {
        public FormLabelTest()
        {
            InitializeComponent();
            
        }
        
        List<Label>  testList = new List<Label>();
        LabelTest cellLabelArray = new LabelTest();
        List<Player.Player> gamePlayers = new List<Player.Player>();

        int players;
        int tempPos = 0;
        int xDif = 100;
        int yDif = 28;
        int edgexDif = 20;
        int edgeyDif = 75;
        int fontSize = 12;
        string fontType = "Arial";
        string extraSpace = "";
        private void FormLabelTest_Load(object sender, EventArgs e)
        {
            int temp = 0;
            gamePlayers = View.StartView.players;
            players = gamePlayers.Count;
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

            
        }

        public void ChangeLabelText(string labelName, string labelText)
        {
            for(int i = 0; i < testList.Count; i++)
            {
                if(testList[i].Name == labelName)
                {
                    testList[i].Text = labelText;
                }
            }
        }

        public void SetLabelTextEmpty()
        {
            for(int i = 0; i < testList.Count; i++)
            {
                testList[i].Text = "";
            }
        }


        private void Button1_Click(object sender, EventArgs e)
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


        

        private void label_Click(object sender, MouseEventArgs e)
        {
            Control test = (Control)sender;
            string test2 = Convert.ToString(test);
            
        }

        private void ctrlClick(System.Object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            MessageBox.Show("You clicked: " + ctrl.Name);
        }

        private void label_Enter(object sender, EventArgs e)
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

                        }

                        testList[i].BackColor = Color.Gray;
                        tempPos = i;

                    }
                }

            }
        }

        private void label_Leave(object sender, EventArgs e)
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

                            }

                            testList[i].BackColor = Color.Gray;
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

                            }
                            //tempPos = i;
                        }
                        




                    }
                }

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
