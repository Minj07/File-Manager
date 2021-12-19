using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class CreateTagForm : Form
    {
        public Color color { get; set; } = Color.Red;

        public CreateTagForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Abort;
            BtnColor.BackColor = color;
            BtnColor.ForeColor = this.ForeColor;
            BtnColor.BorderColor = this.ForeColor;
            LblName.ForeColor = this.ForeColor;
            TxtBoxName.BackColor = this.BackColor;

        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog=new ColorDialog())
            {
                DialogResult result = colorDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    color = colorDialog.Color;
                    BtnColor.BackColor = color;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
