using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccelaTest
{
    public partial class SelectId : Form
    {
        public int ReturnId { get; set; }
        public SelectId()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(textBox1.Text, out id) && id>=0)
            {
                ReturnId = id;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Error id", "Please introduce a numeric value i>=0");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
