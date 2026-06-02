using Bissness;
using firstTrying.Global;
using firstTrying.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bissness.clsPerson;

namespace firstTrying
{
    public partial class frmAddUpdatePerson : Form
    {
        
        enum Mode { Add=0, Update=1 };
        Mode mode = Mode.Add;
        clsPerson _Person;
        public int SelectedPersonID { get; private set; } = -1;

        enum Gendor { Male=0, Female=1 };
        public frmAddUpdatePerson()
        {
           
            InitializeComponent();
            _FillCountriesInComboBox();
            _RefreshDataGrid();


        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            //_Person = clsPerson.Find(PersonID);
            mode = Mode.Update;
            // _Person._Mode = clsPerson.enMode.Update;

            //_FillPersonInfo(PersonID);
            _LoadPersonInfo(PersonID);
            _RefreshDataGrid();
        }
        public void _RefreshDataGrid()
        {
            _FillCountriesInComboBox();
            llRemoveImage.Visible = false;
            cbCountry.SelectedValue = cbCountry.FindString("Syria")+1;
        }

       
        private void _FillCountriesInComboBox()
        {
       
            DataTable dtCountries = clsCountry.GetAllCountries();

            
            cbCountry.DataSource = dtCountries;

           
            cbCountry.DisplayMember = "CountryName";

           
            cbCountry.ValueMember = "CountryID";
            
        }
        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true; // منع الخروج من الحقل
                                 // تأكدي أن الأداة هي txtNationalNo والرسالة منطقية
                errorProvider1.SetError(txtNationalNo, "National Number is required!");
                return; // الخروج من الدالة لأننا وجدنا خطأ
            }
            else
            {
                // إخفاء الخطأ إذا كتب المستخدم شيئاً
                errorProvider1.SetError(txtNationalNo, "");
            }

            if (clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This National Number is already used by another person!");
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, "");
            }
        }

        private bool txtNationalNo_Validating()
        {
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text.Trim()))
            {
                MessageBox.Show("National Number is required!");
                return false;

            }
            if (clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                MessageBox.Show("National Number is Exist!");
                return false;
            }
            return true;
        }


        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (txtEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
            ;

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
          
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                MessageBox.Show("Email is not valid!, Validation Error");
                return;
            }

            if(mode == Mode.Add)
                _FillPersonInfo(-1);
            else
                _FillPersonInfo(_Person.PersonID);
            _Person.Save();
            this.SelectedPersonID = _Person.PersonID;
            this.Close();
            _RefreshDataGrid();
            



        }

        private void _LoadPersonInfo(int PersonID)
        {
             _Person=clsPerson.Find(PersonID);
            _Person.PersonID = PersonID;
            txtFirstName.Text=_Person.FirstName;
            txtLastName.Text= _Person.LastName;
            txtThirdName.Text= _Person.ThirdName;
            txtSecondName.Text= _Person.SecondName;
            txtEmail.Text= _Person.Email;
            txtAddress.Text= _Person.Address;
            txtEmail.Text = _Person.Email;
            txtPhone.Text= _Person.Phone;
            txtNationalNo.Text= _Person.NationalNo;
            if (_Person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            
            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }
            else
            {
                
                pbPersonImage.Image = (_Person.Gendor == 0) ?
                    Image.FromFile(@"C:\Users\hanan\source\repos\firstTrying\resources\Male 512.png") : Image.FromFile(@"C:\Users\hanan\source\repos\firstTrying\resources\Female 512.png");
            }

        }
        private void _FillPersonInfo(int PersonID)
        {
            if(PersonID==-1)
            {
                _Person=new clsPerson();
            }
            else
            {
                _Person=clsPerson.Find(PersonID);
            }
            _Person.PersonID = PersonID;
            _Person.FirstName = txtFirstName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.Email = txtEmail.Text;
            _Person.Address = txtAddress.Text;
            _Person.Phone = txtPhone.Text;
            _Person.NationalNo = txtNationalNo.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.NationalityCountryID = cbCountry.SelectedIndex + 1;
            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            if (rbMale.Checked)
            {
                _Person.Gendor = 0;
            }
            if (rbFemale.Checked)
            {
                _Person.Gendor = 1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _RefreshDataGrid();
            this.Close();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)

                pbPersonImage.Image = Image.FromFile(@"C:\Users\hanan\source\repos\firstTrying\resources\Female 512.png");

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)

                pbPersonImage.Image = Image.FromFile(@"C:\Users\hanan\source\repos\firstTrying\resources\Male 512.png");

        }
        private bool _HandlePersonImage()
        {
            //Create folder;
            //copy image distination 
            //make copy in my folder
            //
            if (pbPersonImage.ImageLocation == null)
                return true;

            string FolderPath = @"C:\Users\hanan\source\repos\firstTrying\people_images";
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            //copy pbpersonImage to the Directory
            
            string SelectedFileName = pbPersonImage.ImageLocation;
            FileInfo file = new FileInfo(SelectedFileName);
            string FileName = Guid.NewGuid().ToString() + file.Extension; // اسم عشوائي + الامتداد (.jpg)

            string DestinationPath = FolderPath +"\\"+ FileName;

            try
            {
               
                File.Copy(SelectedFileName, DestinationPath, true);

                // 5. تحديث مسار الصورة في الكائن ليتم حفظه في قاعدة البيانات
                // person.ImagePath = DestinationPath; 
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying image: " + ex.Message);
                return false;
            }

            return false;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                _HandlePersonImage();
                llRemoveImage.Visible = true;
                // ...
            }
        }

        private void pbPersonImage_Click(object sender, EventArgs e)
        {

        }
    }
}
