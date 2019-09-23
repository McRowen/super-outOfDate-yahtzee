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
            

            Label testLabel = new Label();
            testLabel.Name = "lblTest";
            testLabel.Text = "Label test.";
            testLabel.BorderStyle = BorderStyle.FixedSingle;

            Label test2 = new Label(); ;
            test2.Location = new Point(100, 0);
            test2.Name = "lblTest";
            test2.Text = "Label test.";
            test2.BorderStyle = BorderStyle.FixedSingle;
            //testList.Add(testLabel);
            //testList.Add(test2);
            //Controls.Add(testList[0]);
            //Controls.Add(testList[1]);
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
                    /*if(o == 0)
                    {
                        int t = extraSpace.Length + fontSize;

                        cellLabel.Location = new Point((edgeDif + t) + (o * xDif), edgeDif + (i * yDif));
                    }
                    else
                    {
                        cellLabel.Location = new Point(edgeDif + (o * xDif), edgeDif + (i * yDif));
                    }
                    */
                    cellLabel.Location = new Point(edgeDif + (o * xDif), edgeDif + (i * yDif));

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
            testList[1].Text = "Yey";
        }
    }
}
