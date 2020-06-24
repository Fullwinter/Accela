using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccelaTest
{
    public partial class DBConnection : Form
    {
        string errormessage;
        public DBConnection()
        {
            InitializeComponent();
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            Conection connection = new Conection(tbDB.Text, tbIP.Text, "PersonEntity", cBWindowsCredentials.Checked, tbUsername.Text, tbPassword.Text);
            if (Validator.Validate(connection, out errormessage))
            {
                PersonEntity entityPerson = new PersonEntity();
                entityPerson.ChangeDatabase(connection);
                if (entityPerson.Database.Exists())
                {
                    Menu formMenu = new Menu(entityPerson);
                    this.Hide();
                    //All okay show the DBconnection again
                    if (DialogResult.OK == formMenu.ShowDialog())
                        this.Show();
                    else
                        this.Close();
                }
                else
                    MessageBox.Show("There is no Db with this connection paramaters");
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cBWindowsCredentials_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
                unfold();
            else display();
        }

        private void DBConnection_Load(object sender, EventArgs e)
        {
            unfold();
            
            //just for make faster for me access the db
            string defaultip = ConfigurationSettings.AppSettings.Get("ipdefault");
            string defaultdb = ConfigurationSettings.AppSettings.Get("Dbdefault");
            string defaultcheck = ConfigurationSettings.AppSettings.Get("credentialCheck");
            string defaultauto = ConfigurationSettings.AppSettings.Get("AcceptAuto");

            if (defaultip != null)
                tbIP.Text = defaultip;
            if (defaultdb != null)
                tbDB.Text = defaultdb;
            if (!defaultcheck.Equals("yes"))
                cBWindowsCredentials.Checked = false;
            else cBWindowsCredentials.Checked = true;
            if (defaultauto.Equals("yes"))
                bAccept_Click(bAccept, e);
            
        }

        //Just for display or not the User and password
        private void unfold()
        {
            tbUsername.Enabled = false;
            tbPassword.Enabled = false;
            tbUsername.Visible = false;
            tbPassword.Visible = false;
            lpass.Visible = false;
            luser.Visible = false;
            bAccept.Location = new Point(12, 81);
            bCancel.Location = new Point(122, 81);
            this.Size = new Size(225, 148);
        }

        private void display()
        {
            tbUsername.Enabled = true;
            tbPassword.Enabled = true;
            tbUsername.Visible = true;
            tbPassword.Visible = true;
            lpass.Visible = true;
            luser.Visible = true;
            bAccept.Location = new Point(12, 137);
            bCancel.Location = new Point(122, 137);
            this.Size = new Size(225, 209);
        }
    }
}
