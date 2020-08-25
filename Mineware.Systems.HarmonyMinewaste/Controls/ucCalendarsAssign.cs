using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;
using Mineware.Systems.Global;
using Mineware.Systems.GlobalConnect;

namespace Mineware.Systems.Minewaste.Controls
{
    public partial class ucCalndarsAssign : ucBaseUserControl
    {
        public ucCalndarsAssign()
        {
            InitializeComponent();
        }

        Mineware.Systems.Minewaste.GlobalItems procs = new Mineware.Systems.Minewaste.GlobalItems();
        
        private void ucCalndarsAssign_Load(object sender, EventArgs e)
        {
            PM1Txt.Value = (DateTime.Now.Year * 100) + DateTime.Now.Month;
            procs.ProdMonthVis(Convert.ToInt32(PM1Txt.Text));
            PMTxt.Text = procs.Prod2;


            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

            _dbMan.SqlStatement = "select * from tbl_Calendar_Code where active = 'Y' order by calendarcode " +
                                      " ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();
            //DataTable SubA = _dbMan.ResultsDataTable;


            DataTable dt = _dbMan.ResultsDataTable;

            foreach (DataRow dr in dt.Rows)
            {
                CalTypelst.Items.Add(dr["calendarcode"].ToString());
            }
        }

        private void PM1Txt_Click(object sender, EventArgs e)
        {
            procs.ProdMonthCalc(Convert.ToInt32(PM1Txt.Text));
            PM1Txt.Text = procs.Prod.ToString();
            procs.ProdMonthVis(Convert.ToInt32(PM1Txt.Text));
            PMTxt.Text = procs.Prod2;
        }

        private void LoadGrid()
        {
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _dbMan.SqlStatement = "  select  a.*, b.calendarcode, CONVERT(varchar(15),  b.begindate, 106) bb, CONVERT(varchar(15),  b.enddate, 106) cc, totalshifts from ( " +
                                    "select a.* from tbl_Section a left outer join [tbl_Section_Duration] b " +
                                    "on a.prodmonth = b.prodmonth and a.sectionid = b.sectionid where a.prodmonth = '" + PM1Txt.Text + "' and hierid in " +
                                    "(select hierid from dbo.tbl_Section_Hier where seccal = 'Y') " +
                                    ") a " +
                                    "left outer join " +
                                     "(select * from tbl_Calendar_SecCal where prodmonth = '" + PM1Txt.Text + "') b " +
                                    " on a.sectionid = b.sectionid " +
                                     "order by a.sectionid ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            DataTable dt = _dbMan.ResultsDataTable;

            CalTypeGrd.DataSource = dt;
            colSection.FieldName = "SectionID";
            colSecName.FieldName = "Name";
            ColCalType.FieldName = "calendarcode";
            colSDate.FieldName = "bb";
            colEDate.FieldName = "cc";
            ColDur.FieldName = "totalshifts";
        }

        private void PMTxt_TextChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void bandedGridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            Callbl.Text = bandedGridView2.GetRowCellValue(e.RowHandle, bandedGridView2.Columns[1]).ToString();
            Seclbl.Text = bandedGridView2.GetRowCellValue(e.RowHandle, bandedGridView2.Columns[0]).ToString();

            // getinfo
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _dbMan.SqlStatement = " select * from tbl_Calendar_SecCal where prodmonth = '" + PM1Txt.Value.ToString() + "' and sectionid = '" + Seclbl.Text + "' ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();



            CalChangeBtn.Enabled = true;
        }

        private void CalChangeBtn_Click(object sender, EventArgs e)
        {
            if (CalTypelst.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a valid calendar.", "Insufficient information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

          


            MWDataManager.clsDataAccess _dbManDelete = new MWDataManager.clsDataAccess();
            _dbManDelete.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

            _dbManDelete.SqlStatement = " delete from tbl_Calendar_SecCal where prodmonth = '" + PM1Txt.Value.ToString() + "' and sectionid = '" + Seclbl.Text + "' \r\n";          

            _dbManDelete.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbManDelete.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbManDelete.ExecuteInstruction();

            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

            _dbMan.SqlStatement = " insert into tbl_Calendar_SecCal  ";
            _dbMan.SqlStatement = _dbMan.SqlStatement + " VALUES ( '" + PM1Txt.Value.ToString() + "', '" + Seclbl.Text + "', '" + CalTypelst.SelectedItem + "' ";
            _dbMan.SqlStatement = _dbMan.SqlStatement + ", '" + String.Format("{0:yyyy-MM-dd}", FromDate.Value) + "', '" + String.Format("{0:yyyy-MM-dd}", ToDate.Value) + "', '" + DurTxt.Text + "' ) ";            
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();


            MWDataManager.clsDataAccess _dbManDelete2 = new MWDataManager.clsDataAccess();
            _dbManDelete2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

            _dbManDelete2.SqlStatement = " delete from tbl_Calendar_Days where prodmonth = '" + PM1Txt.Value.ToString() + "'\r\n" +
                                        "exec sp_Calendar_Days  '" + PM1Txt.Value.ToString() + "'";

            _dbManDelete2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbManDelete2.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbManDelete2.ExecuteInstruction();

            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
            LoadGrid();

        }


        private void LoadDuration()
        {
            if (CalTypelst.SelectedIndex == -1)
            {               
                return;
            }

            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _dbMan.SqlStatement = " select COUNT(workingday)num from dbo.tbl_Calendar_WorkingDays " +
                                    "where calendarcode = '" + CalTypelst.SelectedItem + "' " +
                                    "and calendardate >= '" + String.Format("{0:yyyy-MM-dd}",FromDate.Value) + "' " +
                                    "and calendardate <= '" + String.Format("{0:yyyy-MM-dd}", ToDate.Value) + "' and workingday = 'Y' ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            DataTable dt = _dbMan.ResultsDataTable;

            DurTxt.Text = dt.Rows[0]["num"].ToString();
        }

        private void CalTypelst_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDuration();
        }

        private void FromDate_CloseUp(object sender, EventArgs e)
        {
            LoadDuration();
        }

        private void ToDate_CloseUp(object sender, EventArgs e)
        {
            LoadDuration();
        }
    }
}
