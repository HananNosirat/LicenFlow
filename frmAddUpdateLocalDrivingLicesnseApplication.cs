using Bissness;
using firstTrying.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstTrying
{
    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {

        public enum enMode { AddNew=0,Update=1 };
        private enMode _Mode=enMode.AddNew;

        private int _LocalDrivingLicenseApplicationID=-1;
        private int _SelectedPersonID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;


        public frmAddUpdateLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
            _ResetDefualtValues();
            _FillComboBox();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicesnseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
           // this.ctrPersonCardWithFilter1.gbFilters.Visible = false;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _FillComboBox();
            _Mode = enMode.Update;
            _ResetDefualtValues();

           
                _LoadData();
            

        }

        private void _ResetDefualtValues()
        {
            _FillComboBox();
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "New Local Driving License";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                cbLicenseClass.SelectedIndex = 2;
                lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;

            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;


            }
        }
        private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }

        }
        private void _LoadData()
        {
            ctrPersonCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // this.Close();

                return;
            }

            ctrPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = clsFormat.DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedByUser.Text = clsUser.Find(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;
        }

        private void _Refresh()
        {
            _FillComboBox();
            //_LoadData();
        }

        private void _FillComboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            cbLicenseClass.DataSource = dtLicenseClasses;
            cbLicenseClass.DisplayMember = "ClassName";  
            cbLicenseClass.ValueMember = "LicenseClassID";
        }

      
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblCreatedByUser_Click(object sender, EventArgs e)
        {

        }

        private void lblFees_Click(object sender, EventArgs e)
        {

        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbLicenseClass.SelectedIndex == -1)
                return;

            // هاد هو "الأمان" لأن الـ ComboBox لما نربطه بـ DataTable بيخزن عناصر كـ DataRowView
            DataRowView selectedRow = (DataRowView)cbLicenseClass.SelectedItem;

            // 3. نسحب الـ ID من العمود اللي بدنا ياه (تأكدي من اسم العمود في قاعدة البيانات عندك)
            int LicenseClassID = Convert.ToInt32(selectedRow["LicenseClassID"]);

            // 4. الآن كودك صار بالسليم
            int PersonID = _SelectedPersonID;

          
        }

        private void lblApplicationDate_Click(object sender, EventArgs e)
        {

        }

        private void lblLocalDrivingLicebseApplicationID_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnApplicationInfoNext_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(this.ctrPersonCardWithFilter1.ctrPersonCard1.lblPersonID.Text, out _SelectedPersonID))
            {
                _SelectedPersonID = -1;
            }
            if (_SelectedPersonID == -1)
            {
                MessageBox.Show("This person is not valid","select a person",MessageBoxButtons.OK);
                return;
            }

            btnSave.Enabled = true;
            tpApplicationInfo.Enabled = true;
           // tpPersonalInfo.Enabled = false;
            tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];

        }

        private void tpApplicationInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            int LicenseClassID = (int)cbLicenseClass.SelectedValue;

          
            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (_Mode == enMode.AddNew && ActiveApplicationID != -1)
            {
                MessageBox.Show("This person already has an active application with ID = " + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.AddNew && clsLicense.IsLicenseExistByPersonID(_SelectedPersonID, LicenseClassID))
            {
                MessageBox.Show("Person already has a license for this class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_Mode == enMode.AddNew)
            {
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
            }

            _LocalDrivingLicenseApplication.ApplicantPersonID = _SelectedPersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewDrivingLicense;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            // الطيقة الأكثر أماناً عشان نضمن إن البرنامج ما يوقف
            // في زر الحفظ (btnSave_Click)
            float Fees = 0;
            // نستخدم Trim() لإزالة أي فراغات قد تسبب فشل التحويل
            if (float.TryParse(lblFees.Text.Trim(), out Fees))
            {
                _LocalDrivingLicenseApplication.PaidFees = Fees;
            }
            else
            {
                // بدلاً من وضعه صفر، يمكننا جلب السعر مباشرة من قاعدة البيانات كخيار أمان (Backup)
                _LocalDrivingLicenseApplication.PaidFees = clsApplicationType.Find(1).Fees;
             
               
            }
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;

            if (_LocalDrivingLicenseApplication.Save())
            {
                _Mode = enMode.Update; 
                lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToString();
                lblCreatedByUser.Text = clsUser.Find(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;
                lblFees.Text= _LocalDrivingLicenseApplication.PaidFees.ToString();

                lblTitle.Text = "Update Local Driving License Application";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
