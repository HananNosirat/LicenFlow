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
    public partial class frmShowPersonInfo : Form
    {
        clsPerson _Person;
        public frmShowPersonInfo()
        {
            InitializeComponent();
        }

        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            this.clsPersonCard1.loadPersonCard(PersonID);

        }

        private void _FillForm(int PersonID)
        {
            //_Person = clsPerson.Find(PersonID);
            this.clsPersonCard1.loadPersonCard(PersonID);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void clsPersonCard1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
