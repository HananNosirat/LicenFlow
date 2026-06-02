using Bissness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstTrying
{
    public partial class frmAddUpdateUser : Form
    {
        public enum enMode {AddNew=0,Updete=1};
        private enMode _Mode = enMode.AddNew;
        clsUser User;
        int personID;
        public frmAddUpdateUser()
        {
            InitializeComponent();
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            User = clsUser.Find(UserID);
            personID = User.PersonID;
            _Mode = enMode.Updete;
            ctrPersonCardWithFilter1.gbFilters.Visible = false;
            ctrPersonCardWithFilter1.ctrPersonCard1.loadPersonCard(User.PersonID);
            //tpLoginInfo
            FillTbLoginInfo();
        }

        private void FillTbLoginInfo()
        {
            lblUserID.Text = User.UserID.ToString();
            txtUserName.Text = User.UserName.ToString();
            txtPassword.Text = User.Password.ToString();
            txtConfirmPassword.Text = User.Password.ToString();
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {

        }

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {

            int.TryParse(ctrPersonCardWithFilter1.ctrPersonCard1.lblPersonID.Text, out  personID);
            if (!clsPerson.IsPersonExist(personID))
            {
                MessageBox.Show("Selected a Person ", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsUser.isUserExistForPersonID(personID))
            {

                MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // ctrPersonCardWithFilter1.FilterFocus();
                return;
            }
            btnSave.Enabled = true;
            tpLoginInfo.Enabled = true;
            tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            { 
                    User = new clsUser();
                    User.UserName = txtUserName.Text;
                    User.Password = txtPassword.Text;
                    User.PersonID = personID;
                    User.IsActive = chkIsActive.Checked;
                    User.PersonInfo = clsPerson.Find(personID);
            }
            if(_Mode==enMode.Updete)
            {
                User=new clsUser(User.UserID,personID, txtUserName.Text, txtPassword.Text, chkIsActive.Checked);
            }
            if(User.save())
            MessageBox.Show("Saved successfully.");
            else
            {
                MessageBox.Show("Something Wrong .please try again.");
            }
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void ctrPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void tpLoginInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
