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
        List<Label> testList = new List<Label>();
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
                for(int o = 0; o < 5; o++)
                {
                    Label cellLabel = new Label();
                    cellLabel.Name = "lbl" + Convert.ToString(temp);
                    if(i <= 1)
                        cellLabel.Text = "lbl------"+ extraSpace + "0" + Convert.ToString(temp);
                    else
                        cellLabel.Text = "lbl------" + Convert.ToString(temp);
                    cellLabel.Font = new System.Drawing.Font(fontType, fontSize, FontStyle.Bold);
                    cellLabel.BorderStyle = BorderStyle.FixedSingle;
                    cellLabel.Size = new Size(cellLabel.PreferredWidth, cellLabel.PreferredHeight);
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
                if(testList[i].Name == ctrl.Name)
                {
                    
                    int temp = int.Parse(testList[i].Name[3].ToString());
                    if (temp <= 9 && testList[i].Name[4] == null)
                    {
                        
                        for(int o = temp; o <= 4; o++)
                        {
                            testList[o].BackColor = Color.Red;
                        }
                        for (int o = temp; o >= 0; o--)
                        {
                            testList[o].BackColor = Color.Red;
                        }
                        testList[i].BackColor = Color.Gray;
                    }
                    else
                    {
                        string stringTest = Convert.ToString(testList[i].Name[3]) + Convert.ToString(testList[i].Name[4]);
                        int temp2 = Convert.ToInt32(stringTest);
                        for (int o = temp2; o/10 < 4; o++)
                        {
                            testList[o].BackColor = Color.Red;
                        }
                        for (int o = temp2; o/10 > 0; o--)
                        {
                            testList[o].BackColor = Color.Red;
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
                if (testList[i].Name == ctrl.Name)
                {
                    testList[i].BackColor = Color.White;
                }
                
            }
        }
    }
}
