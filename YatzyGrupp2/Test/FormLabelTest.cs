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
        static int players = 4;
        List<Label>  testList = new List<Label>();
        LabelTest cellLabelArray = new LabelTest();
        int tempPos = 0;
        int xDif = 97;
        int yDif = 30;
        int edgeDif = 20;
        int fontSize = 12;
        string fontType = "Arial";
        string extraSpace = "";
        private void FormLabelTest_Load(object sender, EventArgs e)
        {
            int temp = 0;
            
            for(int i = 0; i < 19; i++)
            {
                
                for (int o = 0; o < 5; o++)
                {
                    Label cellLabel = new Label();

                    if(i < 9)
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
                    cellLabel.Size = new Size(xDif+1, yDif+1);
                    cellLabel.Location = new Point(edgeDif + (o * xDif), edgeDif + (i * yDif));
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

      




        private void Button1_Click(object sender, EventArgs e)
        {
            
            if(testList[1].Name == "lbl1")
            {
                testList[1].Text = "Yey";
            }
        }


        public void SetColorLabel()
        {

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
                            testList[i- temp2 + k].BackColor = Color.Red;

                        }

                        testList[i].BackColor = Color.Gray;


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
                         if(tempPos == i-1 || tempPos == i + 1 || tempPos == i)
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
                                testList[i - temp2 + k].BackColor = Color.Red;

                            }

                            testList[i].BackColor = Color.Gray;
                            tempPos = i;
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
                            tempPos = i;
                        }
                        




                    }
                }

            }
        }
    }
}
