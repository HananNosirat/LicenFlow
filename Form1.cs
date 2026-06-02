using Bissness;
//using DVLD.Login;
using firstTrying;
using firstTrying.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstTrying
{
    public partial class Form1 : Form
    {

        public enum enGendor { Male = 0, Female = 1 };

        frmLogin _frmLogin;
        /*public Form1()
        {
            InitializeComponent();
        }*/

        public Form1(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;

        }
        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void retakeTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void manageLocalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ManageInternationaDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void ManageDetainedLicensestoolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      
        private void manageTestTypesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();
            frm.ShowDialog();
            //Console.WriteLine("Your message here:  "+dt.Rows);

        }

        private void peopleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmListPeople frmListPeople = new frmListPeople();
            frmListPeople.ShowDialog();

        }

        private void signOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void employeesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmListUsers frmListUsers = new frmListUsers();
            frmListUsers.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmShowUserInfo frmShowUserInfo = new frmShowUserInfo(clsGlobal.CurrentUser.UserID);//clsGlobal.CurrentUser.UserID);
            frmShowUserInfo.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void localLicenseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicesnseApplication frm = new frmAddUpdateLocalDrivingLicesnseApplication();
            frm.ShowDialog();
        }

        private void manageLocalDrivingLicenseApplicationsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmListLocalDrivingLicesnseApplications frmListLocalDrivingLicesnseApplications = new frmListLocalDrivingLicesnseApplications();
            frmListLocalDrivingLicesnseApplications.ShowDialog();
        }

        private void ManageInternationaDrivingLicenseToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmListInternationalLicesnseApplications frm = new frmListInternationalLicesnseApplications();
            frm.ShowDialog();
        }

        private void ManageDetainedLicensestoolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageApplicationTypesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicenseApplication frm = new frmRenewLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication frm = new frmReplaceLostOrDamagedLicenseApplication();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm =new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmListLocalDrivingLicesnseApplications frm = new frmListLocalDrivingLicesnseApplications();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmListDrivers frm = new frmListDrivers();
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();

        }
    }
}
