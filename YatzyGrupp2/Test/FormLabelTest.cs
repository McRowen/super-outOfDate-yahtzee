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
        List<LabelTest>  testList = new List<LabelTest>();
        LabelTest cellLabelArray = new LabelTest();
        Label[] cellLabel = new Label[players];
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
                for(int o = 0; o < players; o++)
                {
                    Label testsak = new Label();


                    testsak.Name = "lbl" + Convert.ToString(temp);
                    if(i <= 1)
                        testsak.Text = "lbl------"+ extraSpace + "0" + Convert.ToString(temp);
                    else
                        testsak.Text = "lbl------" + Convert.ToString(temp);
                    testsak.Font = new System.Drawing.Font(fontType, fontSize, FontStyle.Bold);
                    testsak.BorderStyle = BorderStyle.FixedSingle;
                    testsak.Size = new Size(testsak.PreferredWidth, testsak.PreferredHeight);
                    testsak.Location = new Point(edgeDif + (o * xDif), edgeDif + (i * yDif));
                    testsak.Click += new System.EventHandler(ctrlClick);
                    testsak.MouseEnter += new System.EventHandler(label_Enter);
                    testsak.MouseLeave += new System.EventHandler(label_Leave);
                    temp++;
                    cellLabel[o] = testsak;
                    
                }
                cellLabelArray.CellLabel = cellLabel;
                testList.Add(cellLabelArray);
            }
            for(int q = 0; q < testList.Count; q++)
            {
                for(int a = 0; a < players; a++)
                {
                    Controls.Add(testList[q].CellLabel[a]);
                }
            }
            
        }

      




        private void Button1_Click(object sender, EventArgs e)
        {
            
            if(testList[1].CellLabel[1].Name == "lbl1")
            {
                testList[1].CellLabel[1].Text = "Yey";
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
                    if (testList[i].CellLabel[a].Name == ctrl.Name)
                    {

                        int temp = int.Parse(testList[i].CellLabel[a].Name[3].ToString());
                        

                            for (int o = temp; o <= 4; o++)
                            {
                                testList[o].CellLabel[a].BackColor = Color.Red;
                            }
                            for (int o = temp; o >= 0; o--)
                            {
                                testList[o].CellLabel[a].BackColor = Color.Red;
                            }
                            testList[i].CellLabel[a].BackColor = Color.Gray;
                        
                        
                    }
                }
                
            }
        }

        private void label_Leave(object sender, EventArgs e)
        {
            //Control ctrl = (Control)sender;
            //for (int i = 0; i < testList.Count; i++)
            //{
            //    if (testList[i].CellLabel[i].Name == ctrl.Name)
            //    {
            //        testList[i].CellLabel[i].BackColor = Color.White;
            //    }
                
            //}
        }
    }
}
