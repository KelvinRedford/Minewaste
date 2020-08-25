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
    public partial class ucCalendars : ucBaseUserControl
    {
        public ucCalendars()
        {
            InitializeComponent();
        }

        int selectedrow = 0;
       
        private void ucCalendars_Load(object sender, EventArgs e)
        {
            LoadDailyColumns();
            LoadCalendarType();


            txtYear.Value = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            txtMonth.Value = Convert.ToInt32(DateTime.Now.ToString("MM"));
        }


        private void LoadCalendarType()
        {
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

            _dbMan.SqlStatement = "select * from tbl_Calendar_Code order by calendarcode " +
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
            CalTypeGrd.DataSource = ds.Tables[0];
            colCalType.FieldName = "CalendarCode";

        }


        private void LoadDailyColumns()
        {
            gvDays.ColumnCount = 0;

            int x = 0;
            
            DataGridViewColumn newColSun = new DataGridViewColumn();
            DataGridViewCell cellSun = new DataGridViewTextBoxCell();
            newColSun.CellTemplate = cellSun;
            newColSun.HeaderText = "Sun";
            newColSun.Name = "Sun";
            newColSun.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            newColSun.Visible = true;
            newColSun.Width = 35+x;
            newColSun.Frozen = true;
            newColSun.ReadOnly = true;
            newColSun.ReadOnly = true;
            newColSun.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gvDays.Columns.Add(newColSun);

            DataGridViewColumn newColMon = new DataGridViewColumn();
            DataGridViewCell cellMon = new DataGridViewTextBoxCell();
            newColMon.CellTemplate = cellMon;
            newColMon.HeaderText = "Mon";
            newColMon.Name = "Mon";
            newColMon.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            newColMon.Visible = true;
            newColMon.Width = 35 + x;
            newColMon.Frozen = true;
            newColMon.ReadOnly = true;
            newColMon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gvDays.Columns.Add(newColMon);

            DataGridViewColumn newColTue = new DataGridViewColumn();
            DataGridViewCell cellTue = new DataGridViewTextBoxCell();
            newColTue.CellTemplate = cellTue;
            newColTue.HeaderText = "Tue";
            newColTue.Name = "Tue";
            newColTue.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            newColTue.Visible = true;
            newColTue.Width = 35 + x;
            newColTue.Frozen = true;
            newColTue.ReadOnly = true;
            newColTue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            gvDays.Columns.Add(newColTue);



            DataGridViewColumn newColWed = new DataGridViewColumn();
            DataGridViewCell cellWed = new DataGridViewTextBoxCell();
            newColWed.CellTemplate = cellWed;
            newColWed.HeaderText = "Wed";
            newColWed.Name = "Wed";
            newColWed.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            newColWed.Visible = true;
            newColWed.Width = 35 + x;
            newColWed.Frozen = true;
            newColWed.ReadOnly = true;
            newColWed.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            gvDays.Columns.Add(newColWed);

            DataGridViewColumn newColThu = new DataGridViewColumn();
            DataGridViewCell cellThu = new DataGridViewTextBoxCell();
            newColThu.CellTemplate = cellThu;
            newColThu.HeaderText = "Thu";
            newColThu.Name = "Thu";
            newColThu.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            newColThu.Visible = true;
            newColThu.Width = 35 + x;
            newColThu.Frozen = true;
            newColThu.ReadOnly = true;
            newColThu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gvDays.Columns.Add(newColThu);

            DataGridViewColumn newColFri = new DataGridViewColumn();
            DataGridViewCell cellFri = new DataGridViewTextBoxCell();
            newColFri.CellTemplate = cellFri;
            newColFri.HeaderText = "Fri";
            newColFri.Name = "Fri";
            newColFri.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            newColFri.Visible = true;
            newColFri.Width = 35 + x;
            newColFri.Frozen = true;
            newColFri.ReadOnly = true;
            newColFri.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gvDays.Columns.Add(newColFri);

            DataGridViewColumn newColSat = new DataGridViewColumn();
            DataGridViewCell cellSat = new DataGridViewTextBoxCell();
            newColSat.CellTemplate = cellSat;
            newColSat.HeaderText = "Sat";
            newColSat.Name = "Sat";
            newColSat.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            newColSat.Visible = true;
            newColSat.Width = 35 + x;
            //newColSat.Row. = 25;
            newColSat.Frozen = true;
            newColSat.ReadOnly = true;
            newColSat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gvDays.Columns.Add(newColSat);
            



        }


        private void LoadTheMonth()
        {

            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _dbMan.SqlStatement = _dbMan.SqlStatement = "select month(calendardate) aa, COUNT(calendardate) b " +
                                    "from dbo.tbl_Calendar_WorkingDays where CalendarCode = '" + Callbl.Text + "' " +
                                    "and YEAR(calendardate) = '" + txtYear.Value.ToString() + "' " +
                                    "group by month(calendardate) " +
                                    "order by month(calendardate) ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            DataTable dt = _dbMan.ResultsDataTable;

            Janlbl.BackColor = Color.White;
            Feblbl.BackColor = Color.White;
            Marlbl.BackColor = Color.White;
            Aprlbl.BackColor = Color.White;
            Maylbl.BackColor = Color.White;
            Junlbl.BackColor = Color.White;
            Jullbl.BackColor = Color.White;
            Auglbl.BackColor = Color.White;
            Seplbl.BackColor = Color.White;
            Octlbl.BackColor = Color.White;
            Novlbl.BackColor = Color.White;
            Declbl.BackColor = Color.White;

            Janlbl.Visible = true;
            Feblbl.Visible = true;
            Marlbl.Visible = true;
            Aprlbl.Visible = true;
            Maylbl.Visible = true;
            Junlbl.Visible = true;
            Jullbl.Visible = true;
            Auglbl.Visible = true;
            Seplbl.Visible = true;
            Octlbl.Visible = true;
            Novlbl.Visible = true;
            Declbl.Visible = true;
            
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["aa"].ToString() == "1")
                {
                    Janlbl.BackColor = Color.MediumSeaGreen;
                }
                if (dr["aa"].ToString() == "2")
                {
                    Feblbl.BackColor = Color.MediumSeaGreen;
                }
                if (dr["aa"].ToString() == "3")
                {
                    Marlbl.BackColor = Color.MediumSeaGreen;
                }
                if (dr["aa"].ToString() == "4")
                {
                    Aprlbl.BackColor = Color.MediumSeaGreen;
                }
                if (dr["aa"].ToString() == "5")
                {
                    Maylbl.BackColor = Color.MediumSeaGreen;
                }
                if (dr["aa"].ToString() == "6")
                {
                    Junlbl.BackColor = Color.MediumSeaGreen;
                }
                if (dr["aa"].ToString() == "7")
                {
                    Jullbl.BackColor = Color.MediumSeaGreen;
                }
                if (dr["aa"].ToString() == "8")
                {
                    Auglbl.BackColor = Color.MediumSeaGreen;
                }
                if (dr["aa"].ToString() == "9")
                {
                    Seplbl.BackColor = Color.MediumSeaGreen;
                }
                if (dr["aa"].ToString() == "10")
                {
                    Octlbl.BackColor = Color.MediumSeaGreen;
                }
                if (dr["aa"].ToString() == "11")
                {
                    Novlbl.BackColor = Color.MediumSeaGreen;
                }
                if (dr["aa"].ToString() == "12")
                {
                    Declbl.BackColor = Color.MediumSeaGreen;
                }
            }
        }

        private void LoadTheCalendar()
        {
                     
            lblSelectedDate.Text = Convert.ToDateTime(txtYear.Value + "/" + txtMonth.Value + "/01").ToString("MMMM");
            lblSelectedDate.Text = lblSelectedDate.Text + " " + Convert.ToDateTime(txtYear.Value + "/" + txtMonth.Value + "/01").ToString("yyyy");

            DateTime StartDate = new DateTime(Convert.ToInt32(txtYear.Value), Convert.ToInt32(txtMonth.Value), 1);
            int DaysInMonth = (System.DateTime.DaysInMonth(Convert.ToInt32(txtYear.Value), Convert.ToInt32(txtMonth.Value)));
            int DayOfWeek = Convert.ToInt32(StartDate.DayOfWeek);
            int TheDay = 1;

            gvDays.RowCount = 0;

            gvDays.ColumnCount = 7;

            for (int MyRows = 0; MyRows < 1; MyRows++)
            {
                int NewRow = gvDays.Rows.Add();
                gvDays.Rows[NewRow].Height = 20;
                gvDays.Rows[NewRow].Cells[0].Value = "";
                gvDays.Rows[NewRow].Cells[1].Value = "";
                gvDays.Rows[NewRow].Cells[2].Value = "";
                gvDays.Rows[NewRow].Cells[3].Value = "";
                gvDays.Rows[NewRow].Cells[4].Value = "";
                gvDays.Rows[NewRow].Cells[5].Value = "";
                gvDays.Rows[NewRow].Cells[6].Value = "";

                gvDays.Rows[NewRow].Cells[0].Style.BackColor = Color.White;
                gvDays.Rows[NewRow].Cells[1].Style.BackColor = Color.White;
                gvDays.Rows[NewRow].Cells[2].Style.BackColor = Color.White;
                gvDays.Rows[NewRow].Cells[3].Style.BackColor = Color.White;
                gvDays.Rows[NewRow].Cells[4].Style.BackColor = Color.White;
                gvDays.Rows[NewRow].Cells[5].Style.BackColor = Color.White;
                gvDays.Rows[NewRow].Cells[6].Style.BackColor = Color.White;


                for (int Days = DayOfWeek; Days < 7; Days++)
                {
                    gvDays.CurrentCell = gvDays[Days, 0];
                    gvDays.CurrentCell.Value = TheDay++;


                }
                

            }

            ////// Now load the rest of the Lines for the Calendar 
            for (int MyRows = 0; MyRows < 5; MyRows++)
            {
                int NewRow = gvDays.Rows.Add();
                gvDays.Rows[NewRow].Height = 20;
               
                for (int Days = 0; Days < 7; Days++)
                {
                    gvDays.CurrentCell = gvDays[Days, NewRow];
                    gvDays.CurrentCell.Value = "";
                    if (TheDay <= DaysInMonth)
                    {
                        gvDays.CurrentCell.Value = TheDay++;
                    }
                    else
                    {
                        gvDays.CurrentCell.Value = "";
                        gvDays.CurrentCell.Style.BackColor = Color.WhiteSmoke;
                    }
                }
            }

             
                for (int Days = 0; Days < 7; Days++)
                {                    
                   if (gvDays.Rows[0].Cells[Days].Value.ToString() == "")
                    gvDays[Days, 0].Style.BackColor = Color.WhiteSmoke;               
                }


            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _dbMan.SqlStatement = _dbMan.SqlStatement = "select DAY(CalendarDate) dd, * from dbo.tbl_Calendar_WorkingDays " +
                                    "where CalendarCode =  '" + Callbl.Text + "' " +
                                    "and MONTH(calendardate) = ' " + txtMonth.Value.ToString() + "' " +
                                    "and YEAR(calendardate) = '" + txtYear.Value.ToString() + "' and workingday = 'N' order by CalendarDate";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            DataTable dt = _dbMan.ResultsDataTable;

            foreach (DataRow r in dt.Rows)
            {

                for (int x = 0; x < 7; x++)
                {
                    for (int Line = 0; Line < gvDays.RowCount; Line++)
                    {
                        if (gvDays.Rows[Line].Cells[x].Value != null)
                        {
                            if (r["dd"].ToString() == gvDays.Rows[Line].Cells[x].Value.ToString())
                            {
                                gvDays[x, Line].Style.BackColor = Color.Tomato;

                            }

                        }
                    }

                }

            }



        }

        private void txtMonth_ValueChanged(object sender, EventArgs e)
        {
            LoadTheCalendar();
        }

        private void txtYear_ValueChanged(object sender, EventArgs e)
        {
            LoadTheCalendar();
        }

        private void bandedGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (selectedrow > -1)
            {
                txtMonth.Visible = true;
                txtYear.Visible = true;
                lblSelectedDate.Visible = true;

                gvDays.Visible = true;
                LoadTheCalendar();
                LoadTheMonth();
                CalChangeBtn.Visible = true;
            }
        }

        private void bandedGridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            
            if (e.RowHandle >= -1)
            { 
              selectedrow = e.RowHandle;
              Callbl.Text = bandedGridView2.GetRowCellValue(e.RowHandle, bandedGridView2.Columns[0]).ToString();
             }
        }

        private void AddBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCalType CalType = new frmCalType();
            CalType._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            CalType.ShowDialog();

            LoadCalendarType();
        }

        private void gvDays_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvDays.CurrentCell.Value == null || gvDays.CurrentCell.Value.ToString() == "")
            {
            }
            else
            {
                if (gvDays.CurrentCell.Style.BackColor == Color.Tomato)
                {
                    gvDays.CurrentCell.Style.BackColor = Color.White;
                    gvDays.CurrentCell.Style.SelectionBackColor = Color.White;
                    gvDays.CurrentCell.Style.SelectionForeColor = Color.Black;

                }
                else
                {
                    gvDays.CurrentCell.Style.SelectionBackColor = Color.Tomato;
                    gvDays.CurrentCell.Style.SelectionForeColor = Color.White;

                    gvDays.CurrentCell.Style.BackColor = Color.Tomato;
                }
            }
        }

        private void CalChangeBtn_Click(object sender, EventArgs e)
        {
            DateTime StartDate = new DateTime(Convert.ToInt32(txtYear.Value), Convert.ToInt32(txtMonth.Value), 1);
            DateTime CalDate = StartDate;

            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _dbMan.SqlStatement = "delete from dbo.tbl_Calendar_WorkingDays " +
                                    "where CalendarCode =  '" + Callbl.Text + "' " +
                                    "and MONTH(calendardate) = ' " + txtMonth.Value.ToString() + "' " +
                                    "and YEAR(calendardate) = '" + txtYear.Value.ToString() + "' ";


            for (int x = 0; x < 7; x++)
            {
                for (int Line = 0; Line < gvDays.RowCount; Line++)
                {
                    if (gvDays.Rows[Line].Cells[x].Value != "")
                    {
                        if (gvDays.Rows[Line].Cells[x].Value != null)
                        {


                            CalDate = StartDate.AddDays(Convert.ToInt32(gvDays.Rows[Line].Cells[x].Value.ToString()) - 1);

                            if (gvDays[x, Line].Style.BackColor == Color.Tomato)
                            {
                                _dbMan.SqlStatement = _dbMan.SqlStatement + "insert into dbo.tbl_Calendar_WorkingDays " +
                                            "values ('" + Callbl.Text + "', '" + CalDate.ToString("yyyy-MM-dd") + "', 'N')";
                            }
                            else
                            {
                                _dbMan.SqlStatement = _dbMan.SqlStatement + "insert into dbo.tbl_Calendar_WorkingDays " +
                                             "values ('" + Callbl.Text + "', '" + CalDate.ToString("yyyy-MM-dd") + "', 'Y')";
                            }
                        }
                    }
                }

            }

            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
            LoadTheMonth();


        }

       
    }
}
