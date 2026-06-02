using Bissness;
using firstTrying.Properties;
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
    public partial class ctrPersonCard : UserControl
    {
        private clsPerson _Person;


        public ctrPersonCard()
        {
            InitializeComponent();
            llEditPersonInfo.LinkClicked += llEditPersonInfo_LinkClicked;
        }

        public void loadPersonCard(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            
            if (_Person == null)
            {
                MessageBox.Show("No Person with Person ID. = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; ;
            }
            _FillPersonInfo();

        }

        public void loadPersonCard(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; ;
            }
            _FillPersonInfo();


        }
        public void _LoadPersonImage()
        {
            if (_Person.ImagePath == null || _Person.ImagePath.Length == 0)
            {
                if(_Person.Gendor==0)
                {
                      pbPersonImage.ImageLocation = @"C:\Users\hanan\source\repos\firstTrying\resources\Male 512.png";
                }else
                    pbPersonImage.ImageLocation = @"C:\Users\hanan\source\repos\firstTrying\resources\Female 512.png";

            }
            else
            {
                pbPersonImage.ImageLocation= _Person.ImagePath;
            }
        }
        public void _FillPersonInfo()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblAddress.Text = _Person.Address.ToString();
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblEmail.Text = _Person.Email;
            lblFullName.Text = _Person.FullName;
            lblGendor.Text = (_Person.Gendor == 0) ? "Male" : "Female";
            lblPhone.Text = _Person.Phone;
            _LoadPersonImage();
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_Person.PersonID);
            frm.ShowDialog();

            //refresh
            loadPersonCard(_Person.PersonID);
        }

        private void lblPersonID_Click(object sender, EventArgs e)
        {

        }

        private void pbPersonImage_Click(object sender, EventArgs e)
        {

        }

        private void lblCountry_Click(object sender, EventArgs e)
        {

        }

        private void ctrPersonCard_Load(object sender, EventArgs e)
        {

        }
    }
}
