using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mineware.Systems.Global;

using System.Configuration;
using System.Data.SqlClient;

using DevExpress.XtraGrid.Views.Grid;
using Mineware.Systems.GlobalConnect;

namespace Mineware.Systems.Minewaste.Controls
{
    public partial class ucBookings : ucBaseUserControl
    {
        public DataTable dt;
        public DataTable dt2;

        public ucBookings()
        {
            InitializeComponent();
        }

        string resetselection = "N";

        void LoadSections()
        {
            resetselection = "N";
            string dt2 = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(editDate.EditValue));
            //Load Sections
            MWDataManager.clsDataAccess _getSec = new MWDataManager.clsDataAccess();
            _getSec.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _getSec.SqlStatement = " select distinct Section from tbl_Calendar_days where calendardate = '"+dt2+"'  " +
                                     "  \r\n";
            _getSec.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _getSec.queryReturnType = MWDataManager.ReturnType.DataTable;
            _getSec.ExecuteInstruction();

            DataTable dt = _getSec.ResultsDataTable;

            DataSet ds = new DataSet();
            if (ds.Tables.Count > 0)
                ds.Tables.Clear();
            ds.Tables.Add(dt);

            LookUpEditSection.DataSource = ds.Tables[0];
            LookUpEditSection.DisplayMember = "Section";
            LookUpEditSection.ValueMember = "Section";
            resetselection = "Y";
        }

        public DataTable DTStopingWorkplaces;
        private MWDataManager.clsDataAccess TheData = new MWDataManager.clsDataAccess();

        private void ucBookings_Load(object sender, EventArgs e)
        {            
            EditBtn.Visible = false;
            DeleteBtn.Visible = false;
            editDate.EditValue = DateTime.Now.AddDays(-1);            
            LoadSections();
        }



        void LoadBookings()
        {
            MWDataManager.clsDataAccess _Bookings = new MWDataManager.clsDataAccess();
            _Bookings.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _Bookings.SqlStatement = " exec sp_BookingsDaily '" + editSection.EditValue + "', '" + Convert.ToDateTime(editDate.EditValue).ToShortDateString() + "' " +
                                     " \r\n";
            _Bookings.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings.ExecuteInstruction();

            if (_Bookings.ResultsDataTable.Rows.Count > 0)
            {
                dt = _Bookings.ResultsDataTable;
                DataSet ds = new DataSet();
                if (ds.Tables.Count > 0)
                    ds.Tables.Clear();
                ds.Tables.Add(dt);

                gcBooking.DataSource = ds.Tables[0];
                gcGun.FieldName = "gun";
                gcDam.FieldName = "dam";
                gcBench.FieldName = "bench";
                gcPlanTonnes.FieldName = "PlanTonnes";
                gcHoursBooked.FieldName = "hoursbooked";
                gcPlanHours.FieldName = "PlanHrs";
                gcHoursVar.FieldName = "HoursVar";
                gcBookTonnes.FieldName = "BookTonnes";
                gcTonnesVar.FieldName = "TonnesVar";

                gcBench.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                gcBench.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            }
            else
            {      
                if (BookingsTab.SelectedTabPageIndex == 0)
                    MessageBox.Show("No Planning Found.", "Insufficient information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                
            }
        }


        void LoadBookingsPump()
        {
            string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(editDate.EditValue));

            MWDataManager.clsDataAccess _BookingsPump = new MWDataManager.clsDataAccess();
            _BookingsPump.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _BookingsPump.SqlStatement = " \r\n" +
                                     " select BookID, Calendardate, Section, substring(Time,0,4)+substring(Time,4,2) Time, convert(Decimal(18,3),Density)Density from tbl_BookingsDailyPumpStation where calendardate = '" + dt + "' and Section = '" + editSection.EditValue + "'  \r\n" +
                                     "  \r\n" +
                                     " ";
            _BookingsPump.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _BookingsPump.queryReturnType = MWDataManager.ReturnType.DataTable;
            _BookingsPump.ExecuteInstruction();

            gcPump.DataSource = null;
            if (_BookingsPump.ResultsDataTable.Rows.Count > 0)
            {
                dt2 = _BookingsPump.ResultsDataTable;
                DataSet ds2 = new DataSet();
                if (ds2.Tables.Count > 0)
                    ds2.Tables.Clear();
                ds2.Tables.Add(dt2);
                gcPump.DataSource = ds2.Tables[0];
                gcID.FieldName = "BookID";
                gcTime.FieldName = "Time";
                gcDensity.FieldName = "Density";

                gcDensity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                gcDensity.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            }
        }

        void LoadBookingsTonnes()
        {
            MWDataManager.clsDataAccess _Bookings = new MWDataManager.clsDataAccess();
            _Bookings.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _Bookings.SqlStatement = " exec sp_BookingsDailyTonnes '" + editSection.EditValue + "', '" + Convert.ToDateTime(editDate.EditValue).ToShortDateString() + "' " +
                                     " \r\n";
            _Bookings.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings.ExecuteInstruction();

            gcBooking2.DataSource = null; 
              
            dt = _Bookings.ResultsDataTable;
            DataSet ds = new DataSet();
            if (ds.Tables.Count > 0)
                ds.Tables.Clear();
            ds.Tables.Add(dt);
            gcBooking2.DataSource = ds.Tables[0];
            gcPlanTonnes2.FieldName = "PlanTonnes";
            gcBookTonnes2.FieldName = "BookTonnes";
            gcVariance2.FieldName = "Variance";



        }

        private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gcBooking.Visible = true;
            LoadBookings();
            gcPump.Visible = true;
            EditBtn.Enabled = false;
            DeleteBtn.Enabled = false;
            gvPump.ClearSelection();
            LoadBookingsPump();
            LoadProblems();
            LoadBookingsTonnes();
        }

        private void SecCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            gcBooking.Visible = false;
        }



        private void gvBookings_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //var gun = gvBookings.GetRowCellValue(gvBookings.FocusedRowHandle, gvBookings.Columns["Gun"]);
            //string gun2 = Convert.ToString(gun);

            //var dam = gvBookings.GetRowCellValue(gvBookings.FocusedRowHandle, gvBookings.Columns["dam"]);
            //string dam2 = Convert.ToString(dam);

            //gvBookings.OptionsEditForm.CustomEditFormLayout = new ucBookingEdit();
            //SetBoundFieldName(memoEdit1, "Comments");

            //gvBookings.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.False;


            //var priority = gvStoping.GetRowCellValue(gvStoping.FocusedRowHandle, gvStoping.Columns["PRIORITY"]);
            //string PRIORITY = Convert.ToString(priority);

            //((ucBookingEdit)gvBookings.OptionsEditForm.CustomEditFormLayout).DateLbl.Text = BookDTP.EditValue.ToString();
            //((ucBookingEdit)gvBookings.OptionsEditForm.CustomEditFormLayout).SecLbl.Text = SecCmb.Text.ToString();
            //((ucBookingEdit)gvBookings.OptionsEditForm.CustomEditFormLayout).DamLbl.Text = dam.ToString();
        }


        string gun = "";
        string bench = "";
        string dam = "";

        private void gvBookings_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                btnEdit.Enabled = true;
                gun = gvBookings.GetRowCellValue(e.RowHandle, gvBookings.Columns["gun"]).ToString();
                //bench = gvBookings.GetRowCellValue(e.RowHandle, gvBookings.Columns["bench"]).ToString();
                dam = gvBookings.GetRowCellValue(e.RowHandle, gvBookings.Columns["dam"]).ToString();
            }
            catch
            {
                return;
            }          

           
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(editDate.EditValue));
            PumpStationBookingFrm PumpBookFrm = new PumpStationBookingFrm();
            PumpBookFrm._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            PumpBookFrm.DatePumpEdit.EditValue = dt;
            PumpBookFrm.SecPumpEdit.EditValue = editSection.EditValue;
            PumpBookFrm.ShowDialog(this);
            LoadBookingsPump();
        }

        string Time = "";
        string Density = "";
        string ID = "";

        private void gvPump_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (gvPump.SelectedRowsCount > 0)
            {
                EditBtn.Visible = true;
                EditBtn.Enabled = true;
                DeleteBtn.Visible = true;
                DeleteBtn.Enabled = true;
                Time = gvPump.GetRowCellValue(e.RowHandle, gvPump.Columns["Time"]).ToString();
                Density = gvPump.GetRowCellValue(e.RowHandle, gvPump.Columns["Density"]).ToString();
                ID = gvPump.GetRowCellValue(e.RowHandle, gvPump.Columns["BookID"]).ToString();
            }
        }

        private void EditBtn_Click_1(object sender, EventArgs e)
        {
            string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(editDate.EditValue));
            PumpStationBookingFrm PumpBookFrm = new PumpStationBookingFrm();
            PumpBookFrm._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            PumpBookFrm.DatePumpEdit.EditValue = dt;
            PumpBookFrm.SecPumpEdit.EditValue = editSection.EditValue;
            PumpBookFrm.TimeEdit.EditValue = Time;
            PumpBookFrm.DensityEdit.EditValue = Density;
            PumpBookFrm.IDLbl.Text = ID;
            PumpBookFrm.ShowDialog(this);
            LoadBookingsPump();
        }


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            MWDataManager.clsDataAccess _BookingsPump = new MWDataManager.clsDataAccess();
            _BookingsPump.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _BookingsPump.SqlStatement = " delete from tbl_BookingsDailyPumpStation where bookid = '" + ID + "' \r\n";
            _BookingsPump.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _BookingsPump.queryReturnType = MWDataManager.ReturnType.DataTable;
            _BookingsPump.ExecuteInstruction();
            LoadBookingsPump();
            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(editDate.EditValue));
            ProblemBookingPumpStationFrm ProbFrm = new ProblemBookingPumpStationFrm();
            ProbFrm._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            ProbFrm.SectionLbl.Text = editSection.EditValue.ToString();
            ProbFrm.DateLbl.Text = dt;
            ProbFrm.ShowDialog(this);
            LoadProblems();
        }
        public DataTable dtProb;

        void LoadProblems()
        {
            string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(editDate.EditValue));
            ///LoadProblems
            MWDataManager.clsDataAccess _Bookings = new MWDataManager.clsDataAccess();
            _Bookings.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _Bookings.SqlStatement = "select a.*, b.Problem ProbDesc, a.ProbID+':'+b.Problem ProbDesc2 from ( \r\n" +
                                     " select * from [tbl_BookingsDailyProblemsPump] where calendardate = '" + dt + "' and Section = '" + editSection.EditValue + "' \r\n" +
                                     " )a \r\n" +
                                     "left outer join ( select * from tbl_ProblemsPumpStation)b \r\n" +
                                     " on a.ProbID = b.ProbCode";
            _Bookings.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings.ExecuteInstruction();
            gcProblems.DataSource = null;
            if (_Bookings.ResultsDataTable.Rows.Count > 0)
            {

                dtProb = _Bookings.ResultsDataTable;
                DataSet ds = new DataSet();
                if (ds.Tables.Count > 0)
                    ds.Tables.Clear();
                ds.Tables.Add(dtProb);
                //Grd3Mnth.Visible = true;
                gcProblems.DataSource = ds.Tables[0];
                gcID2.FieldName = "ID";
                gcProb.FieldName = "ProbDesc2";
                gcStart.FieldName = "StartTime";
                gcEnd.FieldName = "EndTime";

            }
        }

        string ID2 = "";
        private void gvProblems_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (gvProblems.SelectedRowsCount>0)
            {
                simpleButton5.Enabled = true;
                simpleButton4.Enabled = true;
                ID2 = gvProblems.GetRowCellValue(e.RowHandle, gvProblems.Columns["ID"]).ToString();
            }
        }


        private void gvBookings2_ShownEditor(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                gvBookings2.ActiveEditor.SelectAll();
            }));

        }

      

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            MWDataManager.clsDataAccess _Bookings = new MWDataManager.clsDataAccess();
            _Bookings.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _Bookings.SqlStatement = " delete from [tbl_BookingsDailyProblemsPump] \r\n" +
                                     "  where id = " + ID2 + "  \r\n";                                  
            _Bookings.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings.ExecuteInstruction();
            LoadProblems();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(editDate.EditValue));
            ProblemBookingPumpStationFrm ProbFrm = new ProblemBookingPumpStationFrm();
            ProbFrm._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            ProbFrm.SectionLbl.Text = editSection.EditValue.ToString();
            ProbFrm.DateLbl.Text = dt;
            ProbFrm.EditLbl.Text = ID2;
            ProbFrm.ShowDialog(this);
            LoadProblems();
        }


        private void btnEditProdHrs_Click(object sender, EventArgs e)
        {
            string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(editDate.EditValue));
            BookingEditFrm BookFrm = new BookingEditFrm();
            BookFrm._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            BookFrm.DateEditItem.EditValue = dt;
            BookFrm.SecEditItem.EditValue = editSection.EditValue.ToString();
            //string gun = gvBookings.GetRowCellValue(e.RowHandle, gvBookings.Columns["gun"]).ToString();
            //string bench = gvBookings.GetRowCellValue(e.RowHandle, gvBookings.Columns["bench"]).ToString();
            //string dam = gvBookings.GetRowCellValue(e.RowHandle, gvBookings.Columns["dam"]).ToString();
            BookFrm.GunEditItem.EditValue = gun;
            BookFrm.BenchEditItem.EditValue = bench;
            BookFrm.DamEditItem.EditValue = dam;
            BookFrm.ShowDialog(this);
            LoadBookings();
        }

        private void btnSaveTons_Click(object sender, EventArgs e)
        {
            string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(editDate.EditValue));
            string Section = editSection.EditValue.ToString();
           
            MWDataManager.clsDataAccess _dbManSave = new MWDataManager.clsDataAccess();
            _dbManSave.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _dbManSave.SqlStatement = "";
            for (int row = 0; row < gvBookings2.RowCount; row++)
            {                
                decimal TonnesDaily = 0;                
                TonnesDaily = Convert.ToDecimal(gvBookings2.GetRowCellValue(row, gvBookings2.Columns["BookTonnes"]).ToString());

                _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  BEGIN TRY insert into  tbl_BookingsDailyTonnes values ( \r\n";
                _dbManSave.SqlStatement = _dbManSave.SqlStatement + " '" + dt + "', '" + Section + "', \r\n";
                _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  '" + TonnesDaily + "' \r\n ";
                _dbManSave.SqlStatement = _dbManSave.SqlStatement + " ) END TRY \r\n";
                _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  BEGIN CATCH update tbl_BookingsDailyTonnes set \r\n";
                _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  BookTonnes = '" + TonnesDaily + "' \r\n";
                _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  \r\n";
                _dbManSave.SqlStatement = _dbManSave.SqlStatement + " where Calendardate = '" + dt + "' \r\n ";
                _dbManSave.SqlStatement = _dbManSave.SqlStatement + " and Section = '" + Section + "'  \r\n";
                _dbManSave.SqlStatement = _dbManSave.SqlStatement + " END CATCH\r\n";

            }
            _dbManSave.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbManSave.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbManSave.ExecuteInstruction();

            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
        }

        private void editDate_EditValueChanged(object sender, EventArgs e)
        {
            LoadSections();
        }

        private void editSection_EditValueChanged(object sender, EventArgs e)
        {
            if (resetselection == "Y")
                lblSectIndex.Text = editSection.EditValue.ToString();
        }
    }
}
