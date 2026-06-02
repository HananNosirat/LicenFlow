using Bissness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstTrying
{
    public partial class frmListPeople : Form
    {

        private DataTable _dtAllPeople;//= clsPerson.GetAllPeople();

        //only select the columns that you want to show in the grid
        private DataTable _dtPeople;//= _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                    //     "FirstName", "SecondName", "ThirdName", "LastName",
                                                    //     "GendorCaption", "DateOfBirth", "CountryName",
                                                     //    "Phone", "Email");

        public frmListPeople()
        {
            InitializeComponent();
           _Refrish_GridView();
        }


        public void _Refrish_GridView()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                           "FirstName", "SecondName", "ThirdName", "LastName",
                           "GendorCaption", "DateOfBirth", "CountryName",
                          "Phone", "Email");

            dgvPeople.DataSource = _dtPeople;
            label2.Text=_dtAllPeople.Rows.Count.ToString();
            txtFilterValue.Visible = false;
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0) {
                txtFilterValue.Visible=false;
            }
            else 
                {
                txtFilterValue.Visible = true;
                }
        }

        private void pbPersonImage_Click(object sender, EventArgs e)
        {

        }

        private void frmListPeople_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           // _dtAllPeople.Rows();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            String FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                label2.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}]={1}",FilterColumn,txtFilterValue.Text.Trim());

            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}]LIKE '{1}%'", FilterColumn, txtFilterValue.Text);

            }
            label2.Text = dgvPeople.Rows.Count.ToString();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson =new frmAddUpdatePerson();
            frmAddUpdatePerson.ShowDialog();
            _Refrish_GridView();
            _Refrish_GridView();

        }

        private void dgvPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // int NationalNo = (int)dgvPeople.CurrentRow.Cells[0].Value;
            
            int PersonID = (int)dgvPeople.CurrentRow.Cells["PersonID"].Value;
            frmShowPersonInfo frmShowPersonInfo = new frmShowPersonInfo(PersonID);
            frmShowPersonInfo.ShowDialog();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson =new frmAddUpdatePerson();
            frmAddUpdatePerson.ShowDialog();
            _Refrish_GridView();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells["PersonID"].Value;
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson(PersonID);
            frmAddUpdatePerson.ShowDialog();
            _Refrish_GridView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells["PersonID"].Value;
            clsPerson.DeletePerson(PersonID);
            _Refrish_GridView();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this section is for Send Email");
        }
    }
}
