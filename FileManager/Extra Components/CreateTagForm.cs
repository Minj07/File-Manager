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
            roundedButton1.BackColor = color;
            roundedButton1.ForeColor = this.ForeColor;
            roundedButton1.BorderColor = this.ForeColor;
            label1.ForeColor = this.BackColor;
            label1.BackColor = this.ForeColor;

        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog=new ColorDialog())
            {
                DialogResult result = colorDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    color = colorDialog.Color;
                    roundedButton1.BackColor = color;
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
