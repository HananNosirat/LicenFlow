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
    public partial class frmShowUserInfo : Form
    {
        int UserID;
        public frmShowUserInfo()
        {
            InitializeComponent();
        }
        public frmShowUserInfo(int UserID)
        {
            this.UserID = UserID;
            InitializeComponent();
            FillUserCard(UserID);

        }
        public void FillUserCard(int UserID)
        {
            clsUser user=clsUser.Find(UserID);
            //clsPerson person=clsPerson.Find(user.PersonID);
            this.ctrUserCard1.ctrPersonCard1.loadPersonCard(user.PersonID);
            this.ctrUserCard1._LoadUserInfo(UserID);
        }
        private void ctrUserCard1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
