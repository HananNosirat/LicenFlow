using Bissness;
using firstTrying.Controls;
using firstTrying.Global;
using System;
using System.Windows.Forms;

namespace firstTrying
{
    public partial class frmRenewLocalDrivingLicenseApplication : Form
    {
        private int _NewLicenseID = -1;

        public frmRenewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmRenewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected;
            // التركيز على الفلتر مرة واحدة عند تحميل الشاشة
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

            // تعبئة البيانات الثابتة للطلب
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = "???";
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;

            // تعطيل رابط الرخصة الجديدة حتى تتم عملية التجديد بنجاح
            llShowLicenseInfo.Enabled = false;
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblOldLicenseID.Text = SelectedLicenseID.ToString();

            // التحقق من فحص اختيار رخصة صحيحة
            if (SelectedLicenseID == -1)
            {
                llShowLicenseHistory.Enabled = false;
                btnRenewLicense.Enabled = false;
                ResetApplicationFields();
                return;
            }

            llShowLicenseHistory.Enabled = true;

            // -----------------------------------------------------------------
            // أولاً: التحقق من الشروط (Validation) قبل عرض أي بيانات
            // -----------------------------------------------------------------

            // 1. التحقق من أن الرخصة منتهية الصلاحية فعلاً
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expired, it will expire on: " + clsFormat.DateToShort(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate),
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                ResetApplicationFields();
                return;
            }

            // 2. التحقق من أن الرخصة نشطة وليست محظورة أو ملغية
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license.",
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                ResetApplicationFields();
                return;
            }

            // -----------------------------------------------------------------
            // ثانياً: تعبئة البيانات فقط إذا اجتازت الرخصة الشروط السابقة
            // -----------------------------------------------------------------
            int DefaultValidityLength = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassIfo.DefaultValidityLength;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(DefaultValidityLength));
            lblLicenseFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassIfo.ClassFees.ToString();

            // حساب إجمالي الرسوم بشكل آمن
            float appFees = Convert.ToSingle(lblApplicationFees.Text);
            float licenseFees = Convert.ToSingle(lblLicenseFees.Text);
            lblTotalFees.Text = (appFees + licenseFees).ToString();

            txtNotes.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;
            btnRenewLicense.Enabled = true;
        }

        // دالة مساعدة لتفريغ الحقول في حال كانت الرخصة المحددة غير صالحة
        private void ResetApplicationFields()
        {
            lblExpirationDate.Text = "???";
            lblLicenseFees.Text = "0";
            lblTotalFees.Text = lblApplicationFees.Text;
            txtNotes.Text = "";
            llShowLicenseInfo.Enabled = false;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenewLicense_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew this License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // استدعاء دالة التجديد من البزنس لإنشاء طلب ورخصة جديدة
            // استدعاء دالة التجديد (Renew) وتمرير نص الملاحظات والمستخدم الحالي
            clsLicense NewLicense = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(this.txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);
            if (NewLicense == null)
            {
                MessageBox.Show("Failed to Renew this License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // عرض البيانات الناتجة بعد نجاح عملية التجديد في الـ Labels
            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblRenewedLicenseID.Text = _NewLicenseID.ToString();

            MessageBox.Show("License Renewed Successfully with ID = " + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // قفل عناصر التحكم لمنع التكرار وتفعيل رابط الشاشة الجديدة
            btnRenewLicense.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void llShowLicenseInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
        }
    }
}