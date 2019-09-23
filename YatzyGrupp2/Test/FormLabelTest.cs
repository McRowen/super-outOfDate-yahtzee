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
            Control test = (Control)sender;
            string test2 = Convert.ToString(test.Name);
            if(test2 == "lbl0")
            {
                MessageBox.Show("Yes");
            }
        }
    }
}
