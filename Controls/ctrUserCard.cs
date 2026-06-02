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
    public partial class ctrUserCard : UserControl
    {
        clsUser User;
        public ctrUserCard()
        {
            InitializeComponent();
        }
       
        private void _FillUserInfo(int UserID)
        {
            //User = new clsUser();
            User=clsUser.Find(UserID);
            User.UserID = UserID;
            User.UserName=User.UserName.Trim();
            User.IsActive= User.IsActive;
        }
        public void _LoadUserInfo(int UserID)
        {
            _FillUserInfo(UserID);
            this.lblUserID.Text = User.UserID.ToString();
            this.lblUserName.Text = User.UserName;
            
            lblIsActive.Text = (User.IsActive) ? "Yes" : "No";

        }

        private void lblUserID_Click(object sender, EventArgs e)
        {

        }

        private void ctrPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
