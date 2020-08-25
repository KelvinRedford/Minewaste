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

using System.Diagnostics;
using System.IO;

namespace Mineware.Systems.Minewaste
{
    public partial class BookingEditFrm : DevExpress.XtraEditors.XtraForm
    {
        public DataTable dtProb;
        public DataTable dtBook;
        public string _theConnection;
        public BookingEditFrm()
        {
            InitializeComponent();
        }

        private void ProbBtn2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void CloseBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gcProblems.Focus();
            string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateEditItem.EditValue.ToString()));

           // DShiftHrs.Clo;

            MWDataManager.clsDataAccess _dbManSaveBudget = new MWDataManager.clsDataAccess();
            _dbManSaveBudget.ConnectionString = _theConnection;
            _dbManSaveBudget.SqlStatement = "";

            //D/Shift
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  [tbl_BookingsDaily] values ( '" + dt + "', \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " '" + SecEditItem.EditValue.ToString() + "', '" + GunEditItem.EditValue.ToString() + "', \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " 'DS', '" + DamEditItem.EditValue.ToString() + "','" + BenchEditItem.EditValue.ToString() + "', '" + DShiftHrs.EditValue + "', '0' ) \r\n ";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";

            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_BookingsDaily set \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BookHours = '" + DShiftHrs.EditValue + "' \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Calendardate = '" + dt + "' \r\n ";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + SecEditItem.EditValue.ToString() + "' and shift = 'DS'  \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and gun = '" + GunEditItem.EditValue.ToString() + "'  \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and dam = '"+ DamEditItem.EditValue.ToString() + "' and bench = '" + BenchEditItem.EditValue.ToString() + "' \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";


            //A/Shift
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  [tbl_BookingsDaily] values ( '" + dt + "', \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " '" + SecEditItem.EditValue.ToString() + "', '" + GunEditItem.EditValue.ToString() + "', \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " 'AS', '" + DamEditItem.EditValue.ToString() + "','" + BenchEditItem.EditValue.ToString() + "', '" + AShiftHrs.EditValue + "', '0'  ) \r\n ";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";

            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_BookingsDaily set \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BookHours = '" + AShiftHrs.EditValue + "' \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "   \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Calendardate = '" + dt + "' \r\n ";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + SecEditItem.EditValue.ToString() + "' and shift = 'AS' \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and gun = '" + GunEditItem.EditValue.ToString() + "'  \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  and dam = '" + DamEditItem.EditValue.ToString() + "' and bench = '" + BenchEditItem.EditValue.ToString() + "' \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";

            //N/Shift
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  [tbl_BookingsDaily] values ( '" + dt + "', \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " '" + SecEditItem.EditValue.ToString() + "', '" + GunEditItem.EditValue.ToString() + "', \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " 'NS', '" + DamEditItem.EditValue.ToString() + "','" + BenchEditItem.EditValue.ToString() + "', '" + NShiftHrs.EditValue + "', '0' ) \r\n ";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";

            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_BookingsDaily set \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BookHours = '" + NShiftHrs.EditValue + "' \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Calendardate = '" + dt + "' \r\n ";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + SecEditItem.EditValue.ToString() + "' and shift = 'NS'  \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and gun = '" + GunEditItem.EditValue.ToString() + "'  \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and dam = '" + DamEditItem.EditValue.ToString() + "' and bench = '" + BenchEditItem.EditValue.ToString() + "' \r\n";
            _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";


            _dbManSaveBudget.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbManSaveBudget.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbManSaveBudget.ExecuteInstruction();

            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
            this.Close();
        }

        void LoadProblems()
        {
            string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateEditItem.EditValue.ToString()));

          
            ///LoadProblems
            ///
            MWDataManager.clsDataAccess _Bookings = new MWDataManager.clsDataAccess();
            _Bookings.ConnectionString = _theConnection;
            _Bookings.SqlStatement = "select a.*, b.Problem ProbDesc, a.ProbID+':'+b.Problem ProbDesc2 from ( \r\n" +
                                     " select * from tbl_BookingsDailyProblems where calendardate = '" + dt + "' and Section = '" + SecEditItem.EditValue.ToString() + "' and gun = '" + GunEditItem.EditValue.ToString() + "' \r\n" +
                                     " and dam = '" + DamEditItem.EditValue.ToString() + "' and bench = '" + BenchEditItem.EditValue.ToString() + "')a \r\n" +
                                     "left outer join ( select * from tbl_Problems)b \r\n" +
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
                gcProb.FieldName = "ProbDesc2";
                gcStart.FieldName = "StartTime";
                gcEnd.FieldName = "EndTime";
                gcID.FieldName = "ID";

            }
        }


        void LoadBookings()
        {
            string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateEditItem.EditValue.ToString()));

            MWDataManager.clsDataAccess _Bookings = new MWDataManager.clsDataAccess();
            _Bookings.ConnectionString = _theConnection;
            _Bookings.SqlStatement = " \r\n" +
                                     " select *, convert(Decimal(18,0),BookTonnes) BookTonnes2, 1 orderby from tbl_BookingsDaily where calendardate = '" + dt + "' and Section = '" + SecEditItem.EditValue.ToString() + "' and gun = '" + GunEditItem.EditValue.ToString() + "' \r\n" +
                                     " and dam = '" + DamEditItem.EditValue.ToString() + "' and bench = '" + BenchEditItem.EditValue.ToString() + "' and shift = 'DS' \r\n" +
                                     " union\r\n" +
                                      " select *, convert(Decimal(18,0),BookTonnes) BookTonnes2, 2 orderby from tbl_BookingsDaily where calendardate = '" + dt + "' and Section = '" + SecEditItem.EditValue.ToString() + "' and gun = '" + GunEditItem.EditValue.ToString() + "' \r\n" +
                                     " and dam = '" + DamEditItem.EditValue.ToString() + "' and bench = '" + BenchEditItem.EditValue.ToString() + "' and shift = 'AS' \r\n" +
                                        " union\r\n" +
                                      " select *, convert(Decimal(18,0),BookTonnes) BookTonnes2, 3 orderby from tbl_BookingsDaily where calendardate = '" + dt + "' and Section = '" + SecEditItem.EditValue.ToString() + "' and gun = '" + GunEditItem.EditValue.ToString() + "' \r\n" +
                                     " and dam = '" + DamEditItem.EditValue.ToString() + "' and bench = '" + BenchEditItem.EditValue.ToString() + "' and shift = 'NS' \r\n" +
                                     " order by orderby ";
            _Bookings.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings.ExecuteInstruction();

            if (_Bookings.ResultsDataTable.Rows.Count > 0)
            {
                DShiftHrs.EditValue = _Bookings.ResultsDataTable.Rows[0][6].ToString();
                AShiftHrs.EditValue = _Bookings.ResultsDataTable.Rows[1][6].ToString();
                NShiftHrs.EditValue = _Bookings.ResultsDataTable.Rows[2][6].ToString();

                TonnesDS.EditValue = _Bookings.ResultsDataTable.Rows[0][8].ToString();
                TonnesAS.EditValue = _Bookings.ResultsDataTable.Rows[1][8].ToString();
                TonnesNS.EditValue = _Bookings.ResultsDataTable.Rows[2][8].ToString();
            }
        }

        private void BookingEditFrm_Load(object sender, EventArgs e)
        {
            LoadBookings();
            LoadProblems();
            


        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateEditItem.EditValue.ToString()));

            ProblemBookingFrm ProbFrm = new ProblemBookingFrm();
            ProbFrm._theConnection = _theConnection;
            ProbFrm.SecLbl.Text = SecEditItem.EditValue.ToString();
            ProbFrm.DateLbl.Text = dt;
            ProbFrm.GunLbl.Text = GunEditItem.EditValue.ToString();
            ProbFrm.BenchLbl.Text = BenchEditItem.EditValue.ToString();
            ProbFrm.DamLbl.Text = DamEditItem.EditValue.ToString();
            ProbFrm.ShowDialog(this);
            LoadProblems();
        }

        string ID = "";

        private void gvProblems_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            DeleteBtn.Enabled = true;
            ID = gvProblems.GetRowCellValue(e.RowHandle, gvProblems.Columns["ID"]).ToString();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            MWDataManager.clsDataAccess _Bookings = new MWDataManager.clsDataAccess();
            _Bookings.ConnectionString = _theConnection;
            _Bookings.SqlStatement = " delete from tbl_BookingsDailyProblems \r\n" +
                                     "  where id = " + ID + "  \r\n" +
                                     "  \r\n" +
                                     " \r\n" +
                                     " ";
            _Bookings.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Bookings.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Bookings.ExecuteInstruction();
            LoadProblems();
        }

        private void TonsNM_Click(object sender, EventArgs e)
        {
            var progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe";
            var keyboardPath = Path.Combine(progFiles, "TabTip.exe");

            //this.keyboardProc = Process.Start(keyboardPath);

            Process process = new Process();

            process.StartInfo.FileName = progFiles;//Filename
            process.Start();
            process.Close();
        }

        private void TonnesDS_TextChanged(object sender, EventArgs e)
        {
            if (TonnesDS.Text != "")
            {
                if (Convert.ToDecimal(TonnesDS.Text) > 10000)
                {
                    MessageBox.Show("Tonnes Greater than 10 000, please ensure this is correct", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TonnesDS.Focus();
                }
            }
        }

        private void TonnesAS_TextChanged(object sender, EventArgs e)
        {
            if (TonnesAS.Text != "")
            {
                if (Convert.ToDecimal(TonnesAS.Text) > 10000)
                {
                    MessageBox.Show("Tonnes Greater than 10 000, please ensure this is correct", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TonnesAS.Focus();
                }
            }
        }

        private void TonnesNS_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TonnesNS_TextChanged_1(object sender, EventArgs e)
        {
            if (TonnesNS.Text != "")
            {
                if (Convert.ToDecimal(TonnesNS.Text) > 10000)
                {
                    MessageBox.Show("Tonnes Greater than 10 000, please ensure this is correct", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TonnesNS.Focus();
                }
            }
        }
    }
}
