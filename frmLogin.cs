using Bissness;
using firstTrying.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace firstTrying
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {

            string userName = "",password="";
            clsGlobal.GetStoredCredential(ref userName,ref password);
            clsUser user=Bissness.clsUser.FindByUsernameAndPassword(userName,password);
            btnLogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 15, 15));


            if (user != null)
            {
                txtUserName.Text =userName;
                txtPassword.Text = password;
                chkRememberMe.Checked = user.IsActive;
            }
            else
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
                chkRememberMe.Checked = false;
            }
                
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user= clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if (chkRememberMe.Checked)
            {
                //store username and password
                clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            }
            else
            {
                //store empty username and password
                clsGlobal.RememberUsernameAndPassword("", "");

            }

            if (user != null)
            {
                if (user.IsActive)
                {
                    clsGlobal.CurrentUser = user;
                    this.Hide();
                    Form1 frm = new Form1(this);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
