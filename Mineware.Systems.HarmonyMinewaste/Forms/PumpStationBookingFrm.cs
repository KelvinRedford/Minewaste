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
    public partial class PumpStationBookingFrm : DevExpress.XtraEditors.XtraForm
    {
        public DataTable dtProb;
        public string _theConnection;
        public PumpStationBookingFrm()
        {
            InitializeComponent();
        }

        private void CloseBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gcProblems.Focus();
            if (IDLbl.Text == "N")
            {
                string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DatePumpEdit.EditValue.ToString()));

                MWDataManager.clsDataAccess _dbManSaveBudget = new MWDataManager.clsDataAccess();
                _dbManSaveBudget.ConnectionString = _theConnection;
                _dbManSaveBudget.SqlStatement = "";

                //D/Shift
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  [tbl_BookingsDailyPumpStation] values ( '" + dt + "', \r\n";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " '" + SecPumpEdit.EditValue.ToString() + "', '" + TimeEdit.EditValue + "', \r\n";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " '" + DensityEdit.EditValue.ToString() + "' ) \r\n ";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";

                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_BookingsDailyPumpStation set \r\n";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Time = '" + TimeEdit.EditValue + "', \r\n";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Density = " + DensityEdit.EditValue + " \r\n";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Calendardate = '" + dt + "' \r\n ";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + SecPumpEdit.EditValue.ToString() + "'   \r\n";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Time = '" + TimeEdit.EditValue + "'  \r\n";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";
                _dbManSaveBudget.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManSaveBudget.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManSaveBudget.ExecuteInstruction();
            }
            else
            {
                string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DatePumpEdit.EditValue.ToString()));

                MWDataManager.clsDataAccess _dbManSaveBudget = new MWDataManager.clsDataAccess();
                _dbManSaveBudget.ConnectionString = _theConnection;
                _dbManSaveBudget.SqlStatement = "";

                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " update tbl_BookingsDailyPumpStation set \r\n";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Time = '" + TimeEdit.EditValue + "', \r\n";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Density = " + DensityEdit.EditValue + " \r\n";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Calendardate = '" + dt + "' \r\n ";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + SecPumpEdit.EditValue.ToString() + "'   \r\n";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Time = '" + TimeEdit.EditValue + "'  \r\n";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " --and BookID =  '" + IDLbl.Text + "' \r\n";
                _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " \r\n";
                _dbManSaveBudget.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManSaveBudget.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManSaveBudget.ExecuteInstruction();
            }

            
            this.Close();
        }

        void LoadProblems()
        {
           // string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DatePumpEdit.EditValue.ToString()));


           // ///LoadProblems
           // ///
           // MWDataManager.clsDataAccess _Bookings = new MWDataManager.clsDataAccess();
           // _Bookings.ConnectionString = _theConnection
           // _Bookings.SqlStatement = "select a.*, b.Problem ProbDesc, a.ProbID+':'+b.Problem ProbDesc2 from ( \r\n" +
           //                          " select * from [tbl_BookingsDailyProblemsPump] where calendardate = '" + dt + "' and Section = '" + SecPumpEdit.EditValue.ToString() + "' \r\n" +
           //                          " )a \r\n" +
           //                          "left outer join ( select * from tbl_ProblemsPumpStation)b \r\n" +
           //                          " on a.ProbID = b.ProbCode";
           // _Bookings.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
           // _Bookings.queryReturnType = MWDataManager.ReturnType.DataTable;
           // _Bookings.ExecuteInstruction();
           //// gcProblems.DataSource = null;
           // if (_Bookings.ResultsDataTable.Rows.Count > 0)
           // {

           //     dtProb = _Bookings.ResultsDataTable;
           //     DataSet ds = new DataSet();
           //     if (ds.Tables.Count > 0)
           //         ds.Tables.Clear();
           //     ds.Tables.Add(dtProb);
           //     //Grd3Mnth.Visible = true;
           //     gcProblems.DataSource = ds.Tables[0];
           //     gcID.FieldName = "ID";
           //     gcProb.FieldName = "ProbDesc2";
           //     gcStart.FieldName = "StartTime";
           //     gcEnd.FieldName = "EndTime";

           // }
        }

        private void PumpStationBookingFrm_Load(object sender, EventArgs e)
        {
            LoadProblems();       
            

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            //string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DatePumpEdit.EditValue.ToString()));

            ProblemBookingPumpStationFrm ProbFrm = new ProblemBookingPumpStationFrm();
            ProbFrm.SectionLbl.Text = SecPumpEdit.EditValue.ToString();
            ProbFrm.DateLbl.Text = DatePumpEdit.EditValue.ToString();
            ProbFrm.ShowDialog(this);
            LoadProblems();
        }

        string ID = "";

        private void gvProblems_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //DeleteBtn.Enabled = true;
            //ID = gvProblems.GetRowCellValue(e.RowHandle, gvProblems.Columns["ID"]).ToString();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            MWDataManager.clsDataAccess _Bookings = new MWDataManager.clsDataAccess();
            _Bookings.ConnectionString = _theConnection;
            _Bookings.SqlStatement = " delete from [tbl_BookingsDailyProblemsPump] \r\n" +
                                     "  where id = "+ ID + "  \r\n" +
                                     "  \r\n" +
                                     " \r\n" +
                                     " ";
            _Bookings.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings.ExecuteInstruction();
            LoadProblems();
        }
    }
}
