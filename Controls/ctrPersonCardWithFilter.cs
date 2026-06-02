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
    public partial class ctrPersonCardWithFilter : UserControl
    {
        public ctrPersonCardWithFilter()
        {
            InitializeComponent();
        }
        private int _PersonID = -1;

        public int PersonID
        {
            get { return this._PersonID; }
        }

        private void FindNow()
        {
            
            switch(cbFilterBy.Text)
            {
                case "Person ID":
                    
                    if (int.TryParse(txtFilterValue.Text, out int PersonID))
                    { 
                       
                        this.ctrPersonCard1.loadPersonCard(PersonID);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid Numeric ID.");
                    }
                    break;
                case "National No.":
                    this.ctrPersonCard1.loadPersonCard(txtFilterValue.Text);
                    
                    break;

                 default:
                    break;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide! put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson();
            frmAddUpdatePerson.ShowDialog();
            int PersonID=frmAddUpdatePerson.SelectedPersonID;
            ctrPersonCard1.loadPersonCard(PersonID);
        }

        public void LoadPersonInfo(int PersonID)
        {

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            FindNow();

        }
    }
}
