using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraNavBar;

using System.Configuration;
using System.Data.SqlClient;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using Mineware.Systems.Global;
using Mineware.Systems.GlobalConnect;

namespace Mineware.Systems.Minewaste.Controls
{
    public partial class ucSetupUsers : ucBaseUserControl
    {
        public ucSetupUsers()
        {
            InitializeComponent();
        }

        private void ucSetupUsers_Load(object sender, EventArgs e)
        {
            LoadUsers();

        }

        public void LoadUsers()
        {
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

            _dbMan.SqlStatement = "select * from tbl_Users " +
                                      " ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();
            //DataTable SubA = _dbMan.ResultsDataTable;


            DataTable dt = _dbMan.ResultsDataTable;
            DataSet ds = new DataSet();
            if (ds.Tables.Count > 0)
                ds.Tables.Clear();
            ds.Tables.Add(dt);
            //Grd3Mnth.Visible = true;
            UsersGrid.DataSource = ds.Tables[0];
            gcUserID.FieldName = "UserID";
            gcUserName.FieldName = "UserName";
            gcPracticeNo.FieldName = "PracticeNo";
            gcPassword.FieldName = "Password";
            gcAccessCode.FieldName = "AccessCode";
            gcSysAdmin.FieldName = "SysAdmin";
            //gcLastName.FieldName = "surname";
        }

        private void UsersGV_RowCellClick(object sender, RowCellClickEventArgs e)
        {

        }

        private void ActivityGV_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }

        private void ActivityGV_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

        }

        private void ActivityGV_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {

        }

        private void ActivityGV_RowCellDefaultAlignment(object sender, DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
        {

        }

        private void ActivityGrid_Click(object sender, EventArgs e)
        {

        }

        private void UsersGV_RowCellClick_1(object sender, RowCellClickEventArgs e)
        {
            UserRightsPnl.Width = panel1.Width / 4;
            //layoutControl10.Visible = true;
            ///Load Users Rights
            ///
            layoutControlGroup12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

            _dbMan.SqlStatement = " " +
                            " select a.Activity,  " +
                        " case when rights is null then 'N' else 'Y' end as Rights  " +
                         " from(" +
                        "  select distinct(Activity) Activity from tbl_User_Access)a " +
                        "  left outer join (" +
                         " select Rights, Activity from tbl_User_Access where userid = '" + UsersGV.GetFocusedDataRow()["USERID"].ToString() + "')b " +
                         " on a.Activity = b.Activity  order by a.Activity ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            DataTable dt = _dbMan.ResultsDataTable;
            DataSet ds = new DataSet();
            if (ds.Tables.Count > 0)
                ds.Tables.Clear();
            ds.Tables.Add(dt);
            //Grd3Mnth.Visible = true;
            gridControl1.DataSource = ds.Tables[0];
            gridColumn1.FieldName = "Activity";
            gridColumn2.FieldName = "Rights";
        }

        private void EditBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PropFrm UsersFrm = new PropFrm();
            UsersFrm._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            UsersFrm.Edit.Text = "Y";

            UsersFrm.UserIDTxt.Text = UsersGV.GetFocusedDataRow()["USERID"].ToString();
            UsersFrm.UserNameTxt.Text = UsersGV.GetFocusedDataRow()["USERNAME"].ToString();
            UsersFrm.PracticeTxt.Text = UsersGV.GetFocusedDataRow()["PracticeNo"].ToString();
            UsersFrm.PasswordTxt.Text = UsersGV.GetFocusedDataRow()["Password"].ToString();
            UsersFrm.PasswordConfTxt.Text = UsersGV.GetFocusedDataRow()["Password"].ToString();
            UsersFrm.AccessCodeTxt.Text = UsersGV.GetFocusedDataRow()["AccessCode"].ToString();

            //UsersFrm.UserNameTxt.Text = SysGrid.CurrentRow.Cells[1].Value.ToString();
            //UsersFrm.PasswordTxt.Text = SysGrid.CurrentRow.Cells[2].Value.ToString();
            //UsersFrm.PasswordConfTxt.Text = SysGrid.CurrentRow.Cells[3].Value.ToString();
            //UsersFrm.PracticeTxt.Text = SysGrid.CurrentRow.Cells[4].Value.ToString();
            //UsersFrm.AccessCodeTxt.Text = SysGrid.CurrentRow.Cells[5].Value.ToString();
            // UsersFrm.ConnectionString = ConnectionString;
            UsersFrm.ShowDialog();

            LoadUsers();
        }

        private void DeleteBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

            _dbMan.SqlStatement = "delete from tbl_User2 " +
                                      " where userid = '" + UsersGV.GetFocusedDataRow()["USERID"].ToString() + "' ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            MWDataManager.clsDataAccess _dbMan2 = new MWDataManager.clsDataAccess();
            _dbMan2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

            _dbMan2.SqlStatement = "delete from tbl_Users " +
                                      " where userid = '" + UsersGV.GetFocusedDataRow()["USERID"].ToString() + "' ";
            _dbMan2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan2.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan2.ExecuteInstruction();

            LoadUsers();

        }


        private void AddBtn_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PropFrm UsersFrm = new PropFrm();
            UsersFrm._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            UsersFrm.ShowDialog();
            LoadUsers();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
