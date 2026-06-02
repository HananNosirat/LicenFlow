using Bissness;
using firstTrying.Global;
using System;
using System.Windows.Forms;
using static Bissness.clsLicense;

namespace firstTrying
{
    public partial class frmReplaceLostOrDamagedLicenseApplication : Form
    {
        private int _NewLicenseID = -1;

        public frmReplaceLostOrDamagedLicenseApplication()
        {
            InitializeComponent();
        }

        private int _GetApplicationTypeID()
        {
            if (rbDamagedLicense.Checked)
                return (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            else
                return (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
        }

        private enIssueReason _GetIssueReason()
        {
            if (rbDamagedLicense.Checked)
                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
        }

        private void frmReplaceLostOrDamagedLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected;
            // تعبئة البيانات الأساسية للطلب عند التحميل
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;

            // تحديد الاختيار الافتراضي (تالف) وتحديث الرسوم بناءً عليه
            rbDamagedLicense.Checked = true;
            UpdateApplicationFees();

            // إخفاء روابط شاشة الرخصة الجديدة حتى تتم العملية
            llShowLicenseInfo.Enabled = false;
            btnIssueReplacement.Enabled = false;
        }

        private void UpdateApplicationFees()
        {
            lblApplicationFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).Fees.ToString();
        }

       
      

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                btnIssueReplacement.Enabled = false;
                return;
            }

            // التحقق من الشروط أولاً: يجب أن تكون الرخصة نشطة للاستبدال
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license.",
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }

            // تحديث بيانات الطلب في الأسفل لكي تظهر للمستخدم بدلاً من [???]
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            UpdateApplicationFees();

            // تفعيل زر الاستبدال الآن لأن الرخصة مطابقة للشروط
            btnIssueReplacement.Enabled = true;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
           
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssueReplacement_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense NewLicense = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Replace(_GetIssueReason(), clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Failed to Issue a replacement for this License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // عرض البيانات الجديدة بعد نجاح العملية
            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblRreplacedLicenseID.Text = _NewLicenseID.ToString();

            MessageBox.Show("License Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // تعطيل عناصر التحكم لمنع التكرار وتفعيل رابط الشاشة الجديدة
            btnIssueReplacement.Enabled = false;
            gbReplacementFor.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void rbDamagedLicense_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbDamagedLicense.Checked)
            {
                lblTitle.Text = "Replacement for Damaged License";
                this.Text = lblTitle.Text;
                UpdateApplicationFees();
            }
        }

        private void rbLostLicense_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbLostLicense.Checked)
            {
                lblTitle.Text = "Replacement for Lost License";
                this.Text = lblTitle.Text;
                UpdateApplicationFees();
            }
        }

        private void lblApplicationID_Click(object sender, EventArgs e)
        {

        }

        private void llShowLicenseInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
        }
    }
}