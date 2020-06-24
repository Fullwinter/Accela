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
    public partial class PersonForm : Form
    {
        string action;
        Controller control;
        string errormessage;
        int id;
        public PersonForm(string action, Controller control, int id = -1)
        {
            InitializeComponent();
            this.action = action;
            this.control = control;
            this.id = id;
        }

        private void PersonForm_Load(object sender, EventArgs e)
        {
            LoadPerson(id);
            if (action.Equals("Delete"))
            {
                tbFirstName.Enabled=false;
                tbLastName.Enabled=false;
            }
        }

        private void bAccept_Click(object sender, EventArgs e)
        {

            if (Validator.ValidatePersonData(tbId.Text, tbFirstName.Text, tbLastName.Text, out errormessage))
            {
                Person p = new Person{ firstName = tbFirstName.Text, lastName = tbLastName.Text };
                
                if (action.Equals("Add"))
                    control.AddPerson(p);
                else if (action.Equals("Modify"))
                    control.EditPerson(p);
                else if (action.Equals("Delete"))
                    control.DeletePerson(Convert.ToInt32(tbId.Text));
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else MessageBox.Show(errormessage, "Error");
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        //Load the fields in case we have an Id
        private void LoadPerson(int id)
        {
            if (!action.Equals("Add"))
            {
                Person p = control.GetPersonById(id);
                if (p != null)
                {
                    tbId.Text = p.id.ToString();
                    tbFirstName.Text = p.firstName;
                    tbLastName.Text = p.lastName;
                }
                else
                {
                    MessageBox.Show("ID User doesn't exists", "Error");
                    this.DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
        }
    }
}
