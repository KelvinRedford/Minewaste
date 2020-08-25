using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;



namespace Mineware.Systems.Minewaste
{
    public partial class PropFrm : DevExpress.XtraEditors.XtraForm
    {
        BindingSource bs = new BindingSource();
        public string _theConnection;
        //public MainScreenFrm MainScreen2;

        // public string editLbl = "N";

        public PropFrm()
        {
            InitializeComponent();
            //MainScreen2 = _MainScreen;
        }

        //public SysFrm SysFrm;

      
        private void PropFrm_Load(object sender, EventArgs e)
        {
            //this.Icon = Mineware.Systems.Minewaste.Properties.Resources.button_teal;
            LoadAccessRights();

        }

        public void LoadAccessRights()
        {
            /// populate SystemRightsLB
            MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();
            _dbMan3.ConnectionString = _theConnection;
            _dbMan3.SqlStatement =  " select distinct([Activity]) Activity from tbl_User_Access "+
                                    " where activity not in (select[Activity] from tbl_User_Access where USERid = '" + UserIDTxt.Text.ToString() + "') " +
                                    " order by Activity ";
            _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan3.ExecuteInstruction();

            DataTable Neil = _dbMan3.ResultsDataTable;

            bs.DataSource = Neil;

            foreach (DataRow dr in Neil.Rows)
            {
                SystemRightsLB.Items.Add(dr["Activity"].ToString());

            }

            MWDataManager.clsDataAccess _dbMan4 = new MWDataManager.clsDataAccess();
            _dbMan4.ConnectionString = _theConnection;
            _dbMan4.SqlStatement = " select distinct([Activity]) Activity from tbl_User_Access where  USERid = '" + UserIDTxt.Text.ToString() + "' order by Activity ";
            _dbMan4.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan4.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan4.ExecuteInstruction();

            DataTable Neil1 = _dbMan4.ResultsDataTable;

            bs.DataSource = Neil;

            foreach (DataRow dr in Neil1.Rows)
            {
                SystemRightsDropLB.Items.Add(dr["Activity"].ToString());

            }

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
                //if (UserIDTxt.Text == "")
                //{
                //    MessageBox.Show("Please enter the Company Name", "Insufficient information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                if (UserNameTxt.Text == "")
                {
                    MessageBox.Show("Please enter the users name.", "Insufficient information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (PasswordTxt.Text == "")
                {
                    MessageBox.Show("Please enter a password", "Insufficient information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
               


                string Admin = "N";

                if (AdminCheckBox.Checked == true)
                    Admin = "Y";

                MWDataManager.clsDataAccess _dbManDelete = new MWDataManager.clsDataAccess();
            _dbManDelete.ConnectionString = _theConnection;

                _dbManDelete.SqlStatement = " delete from tbl_Users where userid = '" + UserIDTxt.Text.ToString() + "' \r\n";
                _dbManDelete.SqlStatement = _dbManDelete.SqlStatement + "  delete from tbl_User_Access where userid =  '" + UserIDTxt.Text.ToString() + "' ";
                _dbManDelete.SqlStatement = _dbManDelete.SqlStatement + "  ";

                _dbManDelete.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManDelete.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManDelete.ExecuteInstruction();

                MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = _theConnection;

                _dbMan.SqlStatement = " insert into tbl_Users (UserID, UserName, Password, ConfirmPassword, PracticeNo, AccessCode, SysAdmin) ";
                _dbMan.SqlStatement = _dbMan.SqlStatement + " VALUES ( '" + UserIDTxt.Text.ToString() + "', '" + UserNameTxt.Text.ToString() + "', '" + PasswordTxt.Text.ToString() + "', '" + PasswordConfTxt.Text.ToString() + "', '" + PracticeTxt.Text.ToString() + "', ";
                _dbMan.SqlStatement = _dbMan.SqlStatement + " '" + AccessCodeTxt.Text.ToString() + "', '" + Admin + "' ) ";
                for (int i = 0; i < SystemRightsDropLB.Items.Count; i++)
                {
                    _dbMan.SqlStatement = _dbMan.SqlStatement + " insert into tbl_User_Access values('" + UserIDTxt.Text.ToString() + "', '" + SystemRightsDropLB.Items[i].ToString() + "','Y') ";
                }

                _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan.ExecuteInstruction();
            

            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
            Close();

            //main

        }

        private void SystemRightsLB_MouseDown(object sender, MouseEventArgs e)
        {
            if (SystemRightsLB.Items.Count == 0)
                return;

            int index = SystemRightsLB.IndexFromPoint(e.X, e.Y);
            string s = SystemRightsLB.Items[index].ToString();
            DragDropEffects dde1 = DoDragDrop(s,
                DragDropEffects.All);

            if (dde1 == DragDropEffects.All)
            {
                SystemRightsLB.Items.RemoveAt(SystemRightsLB.IndexFromPoint(e.X, e.Y));
            }
        }

        private void SystemRightsLB_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string str = (string)e.Data.GetData(
                    DataFormats.StringFormat);

                SystemRightsLB.Items.Add(str);
            }
        }

        private void SystemRightsLB_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void SystemRightsDropLB_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string str = (string)e.Data.GetData(
                    DataFormats.StringFormat);

                SystemRightsDropLB.Items.Add(str);
            }
        }

        private void SystemRightsDropLB_MouseDown(object sender, MouseEventArgs e)
        {
            if (SystemRightsDropLB.Items.Count == 0)
                return;



            int index = SystemRightsDropLB.IndexFromPoint(e.X, e.Y);
            if (index == -1)
                return;
            string s = SystemRightsDropLB.Items[index].ToString();
            DragDropEffects dde1 = DoDragDrop(s,
                DragDropEffects.All);

            if (dde1 == DragDropEffects.All)
            {
                SystemRightsDropLB.Items.RemoveAt(SystemRightsDropLB.IndexFromPoint(e.X, e.Y));
            }
        }

        private void SystemRightsDropLB_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
