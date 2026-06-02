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
    public partial class frmChangePassword : Form
    {
        //public frmChangePassword()
        //{
        //    InitializeComponent();

        //}
        clsUser _User;
        private int _UserID;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("User not found!");
                this.Close();
                return;
            }

            ctrUserCard1._LoadUserInfo(_UserID);
            ctrUserCard1.ctrPersonCard1.loadPersonCard(_User.PersonID);
        }
      
       
        private void ctrUserCard1_Load(object sender, EventArgs e)
        {

        }
        private void _ResetDefualtValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }

        private bool _IsDataValid()
        {
            if (txtCurrentPassword.Text != _User.Password) return false;
            if (string.IsNullOrEmpty(txtNewPassword.Text)) return false;
            if (txtNewPassword.Text != txtConfirmPassword.Text) return false;

            return true;
        }


        private void txtCurrentPassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {

        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match New Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
            ;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren() || !_IsDataValid())
            {
                MessageBox.Show("Please correct the errors first!");
                return;
            }

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = txtNewPassword.Text;

            if (_User.save())
            {
                MessageBox.Show("Password Changed Successfully.",
                   "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefualtValues();
            }
            else
            {
                MessageBox.Show("An Erro Occured, Password did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
