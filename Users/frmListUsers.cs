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
    public partial class frmListUsers : Form
    {
        static DataTable _dtAllUsers;
        public frmListUsers()
        {
            InitializeComponent();
            _RefreshDataGridView();
        }
        private void _RefreshDataGridView()
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtAllUsers;
            label2.Text= _dtAllUsers.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex != -1)
            {
                txtFilterValue.Visible = true;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                cbIsActive.Visible = false;
                txtFilterValue.Visible= false;
            }
            if (cbFilterBy.SelectedIndex == 5)
            {
                cbIsActive.Visible = true;
                txtFilterValue.Visible = false;
            }
            if(cbFilterBy.SelectedIndex>0&&cbFilterBy.SelectedIndex<5)
            {
                txtFilterValue.Visible = true;
                cbIsActive.Visible = false;
            }
            
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAdd = new frmAddUpdateUser();
            
            frmAdd.ShowDialog();
            _RefreshDataGridView();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            // 1. خريطة لربط اختيار الكومبوبوكس بأسماء الأعمدة الحقيقية في قاعدة البيانات
            switch (cbFilterBy.Text)
            {
                case "User ID": FilterColumn = "UserID"; break;
                case "UserName": FilterColumn = "UserName"; break;
                case "Person ID": FilterColumn = "PersonID"; break;
                case "Full Name": FilterColumn = "FullName"; break;
                default: FilterColumn = "None"; break;
            }

            // 2. إذا كان الحقل فارغاً أو الفلتر "None"، نمسح الفلترة ونعرض كل البيانات
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                ((DataTable)dgvUsers.DataSource).DefaultView.RowFilter = "";
                //lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

            string FilterValue = txtFilterValue.Text.Trim();
            string RowFilter = "";

            // 3. بناء جملة الفلترة حسب نوع العمود (رقمي أم نصي)
            if (FilterColumn == "UserID" || FilterColumn == "PersonID")
            {
                // الفلترة بالأرقام لا تحتاج علامات تنصيص ' '
                RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            else
            {
                // الفلترة بالنصوص تحتاج علامات تنصيص واستخدام LIKE للبحث الجزئي
                RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterValue);
            }

            // 4. تطبيق الفلترة وتحديث عدد السجلات
            try
            {
                ((DataTable)dgvUsers.DataSource).DefaultView.RowFilter = RowFilter;
                //lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                // في حال أدخل المستخدم حروفاً في حقل رقمي بالخطأ
                ((DataTable)dgvUsers.DataSource).DefaultView.RowFilter = "";
            }
        }

        private void cbIsActive_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive"; // اسم العمود في قاعدة البيانات
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    // مسح الفلتر لعرض الجميع
                    ((DataTable)dgvUsers.DataSource).DefaultView.RowFilter = "";
                    break;

                case "Yes":
                    // فلترة المستخدمين النشطين (True أو 1)
                    ((DataTable)dgvUsers.DataSource).DefaultView.RowFilter = string.Format("[{0}] = 1", FilterColumn);
                    break;

                case "No":
                    // فلترة المستخدمين غير النشطين (False أو 0)
                    ((DataTable)dgvUsers.DataSource).DefaultView.RowFilter = string.Format("[{0}] = 0", FilterColumn);
                    break;
            }

            // تحديث عدد السجلات بعد الفلترة
            //lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }

        private int _GetUserIdByCurrentRow()
        {
            return (int)dgvUsers.CurrentRow.Cells["UserID"].Value;
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = _GetUserIdByCurrentRow();
            frmAddUpdateUser frmAddUpdateUser = new frmAddUpdateUser(UserID);

            frmAddUpdateUser.lblTitle.Text = "Update";

            frmAddUpdateUser.ShowDialog();
            this._RefreshDataGridView();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = _GetUserIdByCurrentRow();
            frmShowUserInfo frmShowUserInfo = new frmShowUserInfo(UserID);
            frmShowUserInfo.ShowDialog();
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = _GetUserIdByCurrentRow();
            clsUser.Delete(UserID);
            _RefreshDataGridView();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID= _GetUserIdByCurrentRow();
            frmChangePassword frmChangePassword = new frmChangePassword(userID);
            frmChangePassword.ShowDialog();
        }
    }
}
