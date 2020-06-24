using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AccelaTest
{
    public partial class Menu : Form
    {
        PersonEntity entity;
        Controller control;
        string errormessage;
        public Menu(PersonEntity entity)
        {
            InitializeComponent();
            this.entity = entity;
            control=new Controller(entity);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            PersonForm pf = new PersonForm("Add", control);
            if (pf.ShowDialog() == DialogResult.OK)
                RefreshData();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            SelectId si = new SelectId();
            if (si.ShowDialog() == DialogResult.OK)
            {
                PersonForm pf = new PersonForm("Modify", control, si.ReturnId);
                if (pf.ShowDialog() == DialogResult.OK)
                    RefreshData();
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            SelectId si = new SelectId();
            if (si.ShowDialog() == DialogResult.OK)
            {
                PersonForm pf = new PersonForm("Delete", control, si.ReturnId);
                if (pf.ShowDialog() == DialogResult.OK)
                    RefreshData();
            }
        }

        private void bNumber_Click(object sender, EventArgs e)
        {
            MessageBox.Show(control.CountNumberPerson().ToString(), "Number of Person");
        }

        private void BExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = false;
            if(op.ShowDialog()==DialogResult.OK)
            {
                AuxFiles.InsertfromFile(op.FileName, control,out errormessage);
                if (errormessage!="")
                    MessageBox.Show(errormessage);
            }
        }

        private void RefreshData()
        {
            dataGridView1.DataSource = (from a in entity.Persons select a).ToList();
            dataGridView1.Refresh();
        }
    }
}
