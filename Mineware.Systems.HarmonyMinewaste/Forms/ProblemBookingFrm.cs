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
    public partial class ProblemBookingFrm : DevExpress.XtraEditors.XtraForm
    {
        BindingSource bs = new BindingSource();
        BindingSource bs2 = new BindingSource();
        BindingSource bs3 = new BindingSource();
        BindingSource bs4 = new BindingSource();
        BindingSource bs5 = new BindingSource();
        BindingSource bs6 = new BindingSource();
        BindingSource bs7 = new BindingSource();
        BindingSource bs8 = new BindingSource();
        BindingSource bs9 = new BindingSource();
        public string _theConnection;
        public ProblemBookingFrm()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ProblemBookingFrm_Load(object sender, EventArgs e)
        {
            //Breakdowns
            MWDataManager.clsDataAccess _Bookings = new MWDataManager.clsDataAccess();
            _Bookings.ConnectionString = _theConnection;
            _Bookings.SqlStatement = " select *, ProbCode+':'+Problem ProbDesc from tbl_Problems  " +
                                     " where probCatID = 1 \r\n";
            _Bookings.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings.ExecuteInstruction();

            DataTable Neil = _Bookings.ResultsDataTable;

            bs.DataSource = Neil;

            foreach (DataRow dr in Neil.Rows)
            {
                LB1.Items.Add(dr["ProbDesc"].ToString());

            }

            
            MWDataManager.clsDataAccess _Bookings2 = new MWDataManager.clsDataAccess();
            _Bookings2.ConnectionString = _theConnection;
            _Bookings2.SqlStatement = " select *, ProbCode+':'+Problem ProbDesc from tbl_Problems  " +
                                     " where probCatID = 2 \r\n";
            _Bookings2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings2.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings2.ExecuteInstruction();

            DataTable Neil2 = _Bookings2.ResultsDataTable;

            bs2.DataSource = Neil2;

            foreach (DataRow dr2 in Neil2.Rows)
            {
                LB2.Items.Add(dr2["ProbDesc"].ToString());

            }


            MWDataManager.clsDataAccess _Bookings3 = new MWDataManager.clsDataAccess();
            _Bookings3.ConnectionString = _theConnection;
            _Bookings3.SqlStatement = " select *, ProbCode+':'+Problem ProbDesc from tbl_Problems  " +
                                     " where probCatID = 3 \r\n";
            _Bookings3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings3.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings3.ExecuteInstruction();

            DataTable Neil3 = _Bookings3.ResultsDataTable;

            bs3.DataSource = Neil3;

            foreach (DataRow dr3 in Neil3.Rows)
            {
                LB3.Items.Add(dr3["ProbDesc"].ToString());

            }


            MWDataManager.clsDataAccess _Bookings4 = new MWDataManager.clsDataAccess();
            _Bookings4.ConnectionString = _theConnection;
            _Bookings4.SqlStatement = " select *, ProbCode+':'+Problem ProbDesc from tbl_Problems  " +
                                     " where probCatID = 4 \r\n";
            _Bookings4.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings4.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings4.ExecuteInstruction();

            DataTable Neil4 = _Bookings4.ResultsDataTable;

            bs4.DataSource = Neil4;

            foreach (DataRow dr4 in Neil4.Rows)
            {
                LB4.Items.Add(dr4["ProbDesc"].ToString());

            }


            MWDataManager.clsDataAccess _Bookings5 = new MWDataManager.clsDataAccess();
            _Bookings5.ConnectionString = _theConnection ;
            _Bookings5.SqlStatement = " select *, ProbCode+':'+Problem ProbDesc from tbl_Problems  " +
                                     " where probCatID = 5 \r\n";
            _Bookings5.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings5.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings5.ExecuteInstruction();

            DataTable Neil5 = _Bookings5.ResultsDataTable;

            bs5.DataSource = Neil5;

            foreach (DataRow dr5 in Neil5.Rows)
            {
                LB5.Items.Add(dr5["ProbDesc"].ToString());

            }


            MWDataManager.clsDataAccess _Bookings6 = new MWDataManager.clsDataAccess();
            _Bookings6.ConnectionString = _theConnection;
            _Bookings6.SqlStatement = " select *, ProbCode+':'+Problem ProbDesc from tbl_Problems  " +
                                     " where probCatID = 6 \r\n";
            _Bookings6.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings6.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings6.ExecuteInstruction();

            DataTable Neil6 = _Bookings6.ResultsDataTable;

            bs6.DataSource = Neil6;

            foreach (DataRow dr6 in Neil6.Rows)
            {
                LB6.Items.Add(dr6["ProbDesc"].ToString());

            }



            MWDataManager.clsDataAccess _Bookings7 = new MWDataManager.clsDataAccess();
            _Bookings7.ConnectionString = _theConnection;
            _Bookings7.SqlStatement = " select *, ProbCode+':'+Problem ProbDesc from tbl_Problems  " +
                                     " where probCatID = 7 \r\n";
            _Bookings7.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings7.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings7.ExecuteInstruction();

            DataTable Neil7 = _Bookings7.ResultsDataTable;

            bs7.DataSource = Neil7;

            foreach (DataRow dr7 in Neil7.Rows)
            {
                LB7.Items.Add(dr7["ProbDesc"].ToString());

            }


            MWDataManager.clsDataAccess _Bookings8 = new MWDataManager.clsDataAccess();
            _Bookings8.ConnectionString = _theConnection;
            _Bookings8.SqlStatement = " select *, ProbCode+':'+Problem ProbDesc from tbl_Problems  " +
                                     " where probCatID = 8 \r\n";
            _Bookings8.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings8.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings8.ExecuteInstruction();

            DataTable Neil8 = _Bookings8.ResultsDataTable;

            bs8.DataSource = Neil8;

            foreach (DataRow dr8 in Neil8.Rows)
            {
                LB8.Items.Add(dr8["ProbDesc"].ToString());

            }


            MWDataManager.clsDataAccess _Bookings9 = new MWDataManager.clsDataAccess();
            _Bookings9.ConnectionString = _theConnection;
            _Bookings9.SqlStatement = " select *, ProbCode+':'+Problem ProbDesc from tbl_Problems  " +
                                     " where probCatID = 9 \r\n";
            _Bookings9.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings9.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings9.ExecuteInstruction();

            DataTable Neil9 = _Bookings9.ResultsDataTable;

            bs9.DataSource = Neil9;

            foreach (DataRow dr9 in Neil9.Rows)
            {
                LB9.Items.Add(dr9["ProbDesc"].ToString());

            }


            LB1.SelectedIndex = -1;
            LB2.SelectedIndex = -1;
            LB3.SelectedIndex = -1;
            LB4.SelectedIndex = -1;
            LB5.SelectedIndex = -1;
            LB6.SelectedIndex = -1;
            LB7.SelectedIndex = -1;
            LB8.SelectedIndex = -1;
            LB9.SelectedIndex = -1;
            
        }

        public string ExtractBeforeColon(string TheString)
        {
            if (TheString != "")
            {
                string BeforeColon;

                int index = TheString.IndexOf(":");

                BeforeColon = TheString.Substring(0, index);

                return BeforeColon;
            }
            else
            {
                return "";
            }
        }


        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LB1.Focus();

            MWDataManager.clsDataAccess _dbManSaveBudget = new MWDataManager.clsDataAccess();
            _dbManSaveBudget.ConnectionString = _theConnection;
            _dbManSaveBudget.SqlStatement = "";

            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  tbl_BookingsDailyProblems values ( '" + DateLbl.Text + "', \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " '" + SecLbl.Text + "', '" + GunLbl.Text + "', \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " '" + DamLbl.Text + "','" + BenchLbl.Text + "', '" + ExtractBeforeColon(ProbLbl.Text) + "', '" + StartTime.EditValue.ToString() + "', '" + EndTime.EditValue.ToString() + "', '" + CommentsTxt.Text + "' ) \r\n ";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";

            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_BookingsDailyProblems set \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  ProbID = '" + ExtractBeforeColon(ProbLbl.Text) + "', \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  StartTime = '" + StartTime.EditValue.ToString() + "', \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  EndTime = '" + EndTime.EditValue.ToString() + "' \r\n,";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Comments = '" + CommentsTxt.Text + "' \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Calendardate = '" + DateLbl.Text + "' \r\n ";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + SecLbl.Text + "'   \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and gun = '" + GunLbl.Text + "'  \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and dam = '" + DamLbl.Text + "' and bench = '" + BenchLbl.Text + "' \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";

            _dbManSaveBudget.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbManSaveBudget.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbManSaveBudget.ExecuteInstruction();

            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);

            this.Close();
        }

        private void LB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB1.SelectedIndex != -1)
            {
                ProbLbl.Text = LB1.SelectedItem.ToString();
                LB2.SelectedIndex = -1;
                LB3.SelectedIndex = -1;
                LB4.SelectedIndex = -1;
                LB5.SelectedIndex = -1;
                LB6.SelectedIndex = -1;
                LB7.SelectedIndex = -1;
                LB8.SelectedIndex = -1;
                LB9.SelectedIndex = -1;
            }

        }

        private void LB2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB2.SelectedIndex != -1)
            {
                ProbLbl.Text = LB2.SelectedItem.ToString();
                LB1.SelectedIndex = -1;
                LB3.SelectedIndex = -1;
                LB4.SelectedIndex = -1;
                LB5.SelectedIndex = -1;
                LB6.SelectedIndex = -1;
                LB7.SelectedIndex = -1;
                LB8.SelectedIndex = -1;
                LB9.SelectedIndex = -1;
            }
        }

        private void LB3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB3.SelectedIndex != -1)
            {
                ProbLbl.Text = LB3.SelectedItem.ToString();
                LB1.SelectedIndex = -1;
                LB2.SelectedIndex = -1;
                LB4.SelectedIndex = -1;
                LB5.SelectedIndex = -1;
                LB6.SelectedIndex = -1;
                LB7.SelectedIndex = -1;
                LB8.SelectedIndex = -1;
                LB9.SelectedIndex = -1;
            }
        }

        private void LB4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB4.SelectedIndex != -1)
            {
                ProbLbl.Text = LB4.SelectedItem.ToString();
                LB1.SelectedIndex = -1;
                LB2.SelectedIndex = -1;
                LB3.SelectedIndex = -1;
                LB5.SelectedIndex = -1;
                LB6.SelectedIndex = -1;
                LB7.SelectedIndex = -1;
                LB8.SelectedIndex = -1;
                LB9.SelectedIndex = -1;
            }
        }

        private void LB5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB5.SelectedIndex != -1)
            {
                ProbLbl.Text = LB5.SelectedItem.ToString();
                LB1.SelectedIndex = -1;
                LB2.SelectedIndex = -1;
                LB3.SelectedIndex = -1;
                LB4.SelectedIndex = -1;
                LB6.SelectedIndex = -1;
                LB7.SelectedIndex = -1;
                LB8.SelectedIndex = -1;
                LB9.SelectedIndex = -1;
            }
        }

        private void LB6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB6.SelectedIndex != -1)
            {
                ProbLbl.Text = LB6.SelectedItem.ToString();
                LB1.SelectedIndex = -1;
                LB2.SelectedIndex = -1;
                LB3.SelectedIndex = -1;
                LB4.SelectedIndex = -1;
                LB5.SelectedIndex = -1;
                LB7.SelectedIndex = -1;
                LB8.SelectedIndex = -1;
                LB9.SelectedIndex = -1;
            }
        }

        private void LB7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB7.SelectedIndex != -1)
            {
                ProbLbl.Text = LB7.SelectedItem.ToString();
                LB1.SelectedIndex = -1;
                LB2.SelectedIndex = -1;
                LB3.SelectedIndex = -1;
                LB4.SelectedIndex = -1;
                LB5.SelectedIndex = -1;
                LB6.SelectedIndex = -1;
                LB8.SelectedIndex = -1;
                LB9.SelectedIndex = -1;
            }
        }

        private void LB8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB8.SelectedIndex != -1)
            {
                ProbLbl.Text = LB8.SelectedItem.ToString();
                LB1.SelectedIndex = -1;
                LB2.SelectedIndex = -1;
                LB3.SelectedIndex = -1;
                LB4.SelectedIndex = -1;
                LB5.SelectedIndex = -1;
                LB6.SelectedIndex = -1;
                LB7.SelectedIndex = -1;
                LB9.SelectedIndex = -1;
            }
        }

        private void LB9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB9.SelectedIndex != -1)
            {
                ProbLbl.Text = LB9.SelectedItem.ToString();
                LB1.SelectedIndex = -1;
                LB2.SelectedIndex = -1;
                LB3.SelectedIndex = -1;
                LB4.SelectedIndex = -1;
                LB5.SelectedIndex = -1;
                LB6.SelectedIndex = -1;
                LB7.SelectedIndex = -1;
                LB8.SelectedIndex = -1;
            }
        }

        private void LB1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
