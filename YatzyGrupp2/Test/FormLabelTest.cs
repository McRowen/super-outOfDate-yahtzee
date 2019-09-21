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
            testList.Add(testLabel);
            testList.Add(test2);
            Controls.Add(testList[0]);
            Controls.Add(testList[1]);
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            testList[1].Text = "Yey";
        }
    }
}
