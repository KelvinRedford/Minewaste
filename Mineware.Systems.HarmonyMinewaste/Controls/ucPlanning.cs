using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using FastReport;
using Mineware.Systems.Global;
using Mineware.Systems.GlobalConnect;
using Mineware.Systems.MinewasteGlobal;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Mineware.Systems.Minewaste.Controls
{
    public partial class ucPlanning : ucBaseUserControl
    {
        //DataTable dtPlanning;
        object PlanningCode = "";
        Report theReport = new Report();


        decimal TotTonnesDaily = 0;
        public ucPlanning()
        {
            InitializeComponent();
            gcPlanning.DataSource = GetDataSource();
            //Dates.FieldName = "Dates";

            gvPlan.OptionsSelection.MultiSelect = true;
            gvPlan.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gvPlan.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;

            gcPlanning.ProcessGridKey += gcPlanning_ProcessGridKey;



        }

        private string ClipboardData
        {
            get
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData == null) return "";

                if (iData.GetDataPresent(DataFormats.Text))
                    return (string)iData.GetData(DataFormats.Text);
                return "";
            }
            set { Clipboard.SetDataObject(value); }
        }

        void LoadPlanSched()
        {

            //Check if planning Exists

            MWDataManager.clsDataAccess _Check = new MWDataManager.clsDataAccess();
            _Check.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _Check.SqlStatement = " select * from tbl_Planning where prodmonth =  '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + "' " +
                                     "  and section = '" + barSection.EditValue + "'\r\n";
            _Check.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Check.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Check.ExecuteInstruction();


            MWDataManager.clsDataAccess _getDates = new MWDataManager.clsDataAccess();
            _getDates.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _getDates.SqlStatement = " select min(BeginDate) SD, max(EndDate) ED from tbl_Calendar_Days where prodmonth =  '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + "' " +
                                     "  \r\n";
            _getDates.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _getDates.queryReturnType = MWDataManager.ReturnType.DataTable;
            _getDates.ExecuteInstruction();


            DateTime startdate = Convert.ToDateTime(_getDates.ResultsDataTable.Rows[0][0].ToString());
            DateTime enddate = Convert.ToDateTime(_getDates.ResultsDataTable.Rows[0][1].ToString());


            MWDataManager.clsDataAccess _getPlanSched = new MWDataManager.clsDataAccess();
            _getPlanSched.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

            //if (_Check.ResultsDataTable.Rows.Count > 0)
            //{
            //    _getPlanSched.SqlStatement = " exec sp_GetPlanningSchedulePlanning '" + barYear.EditValue + "', '" + barSection.EditValue + "' " +
            //                            "  \r\n";
            //}
            //else
            //{


            _getPlanSched.SqlStatement = " exec sp_GetPlanningSchedule '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + "', '" + barSection.EditValue + "' " +
                                     "  \r\n";

            //}

            _getPlanSched.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _getPlanSched.queryReturnType = MWDataManager.ReturnType.DataTable;
            _getPlanSched.ExecuteInstruction();

            gcDay1.Visible = true;
            gcDay1.Caption = startdate.ToString("dd MMM");
            gcDay2.Visible = true;
            gcDay2.Caption = startdate.AddDays(+1).ToString("dd MMM");
            gcDay3.Visible = true;
            gcDay3.Caption = startdate.AddDays(+2).ToString("dd MMM");
            gcDay4.Visible = true;
            gcDay4.Caption = startdate.AddDays(+3).ToString("dd MMM");
            gcDay5.Visible = true;
            gcDay5.Caption = startdate.AddDays(+4).ToString("dd MMM");
            gcDay6.Visible = true;
            gcDay6.Caption = startdate.AddDays(+5).ToString("dd MMM");
            gcDay7.Visible = true;
            gcDay7.Caption = startdate.AddDays(+6).ToString("dd MMM");
            gcDay8.Visible = true;
            gcDay8.Caption = startdate.AddDays(+7).ToString("dd MMM");
            gcDay9.Visible = true;
            gcDay9.Caption = startdate.AddDays(+8).ToString("dd MMM");
            gcDay10.Visible = true;
            gcDay10.Caption = startdate.AddDays(+9).ToString("dd MMM");
            gcDay11.Visible = true;
            gcDay11.Caption = startdate.AddDays(+10).ToString("dd MMM");
            gcDay12.Visible = true;
            gcDay12.Caption = startdate.AddDays(+11).ToString("dd MMM");
            gcDay13.Visible = true;
            gcDay13.Caption = startdate.AddDays(+12).ToString("dd MMM");
            gcDay14.Visible = true;
            gcDay14.Caption = startdate.AddDays(+13).ToString("dd MMM");
            gcDay15.Visible = true;
            gcDay15.Caption = startdate.AddDays(+14).ToString("dd MMM");
            gcDay16.Visible = true;
            gcDay16.Caption = startdate.AddDays(+15).ToString("dd MMM");
            gcDay17.Visible = true;
            gcDay17.Caption = startdate.AddDays(+16).ToString("dd MMM");
            gcDay18.Visible = true;
            gcDay18.Caption = startdate.AddDays(+17).ToString("dd MMM");
            gcDay19.Visible = true;
            gcDay19.Caption = startdate.AddDays(+18).ToString("dd MMM");
            gcDay20.Visible = true;
            gcDay20.Caption = startdate.AddDays(+19).ToString("dd MMM");
            gcDay21.Visible = true;
            gcDay21.Caption = startdate.AddDays(+20).ToString("dd MMM");
            gcDay22.Visible = true;
            gcDay22.Caption = startdate.AddDays(+21).ToString("dd MMM");
            gcDay23.Visible = true;
            gcDay23.Caption = startdate.AddDays(+22).ToString("dd MMM");
            gcDay24.Visible = true;
            gcDay24.Caption = startdate.AddDays(+23).ToString("dd MMM");
            gcDay25.Visible = true;
            gcDay25.Caption = startdate.AddDays(+24).ToString("dd MMM");
            gcDay26.Visible = true;
            gcDay26.Caption = startdate.AddDays(+25).ToString("dd MMM");
            gcDay27.Visible = true;
            gcDay27.Caption = startdate.AddDays(+26).ToString("dd MMM");
            gcDay28.Visible = true;
            gcDay28.Caption = startdate.AddDays(+27).ToString("dd MMM");
            gcDay29.Visible = true;
            gcDay29.Caption = startdate.AddDays(+28).ToString("dd MMM");
            gcDay30.Visible = true;
            gcDay30.Caption = startdate.AddDays(+29).ToString("dd MMM");
            gcDay31.Visible = true;
            gcDay31.Caption = startdate.AddDays(+30).ToString("dd MMM");
            gcDay32.Visible = true;
            gcDay32.Caption = startdate.AddDays(+31).ToString("dd MMM");
            gcDay33.Visible = true;
            gcDay33.Caption = startdate.AddDays(+32).ToString("dd MMM");
            gcDay34.Visible = true;
            gcDay34.Caption = startdate.AddDays(+33).ToString("dd MMM");
            gcDay35.Visible = true;
            gcDay35.Caption = startdate.AddDays(+34).ToString("dd MMM");
            gcDay36.Visible = true;
            gcDay36.Caption = startdate.AddDays(+35).ToString("dd MMM");
            gcDay37.Visible = true;
            gcDay37.Caption = startdate.AddDays(+36).ToString("dd MMM");
            gcDay38.Visible = true;
            gcDay38.Caption = startdate.AddDays(+37).ToString("dd MMM");
            gcDay39.Visible = true;
            gcDay39.Caption = startdate.AddDays(+38).ToString("dd MMM");
            gcDay40.Visible = true;
            gcDay40.Caption = startdate.AddDays(+39).ToString("dd MMM");


            DataTable dt = _getPlanSched.ResultsDataTable;
            DataSet ds = new DataSet();
            if (ds.Tables.Count > 0)
                ds.Tables.Clear();
            ds.Tables.Add(dt);
            gcPlanSced.DataSource = ds.Tables[0];
            //gcTram.DataBindings();
            gcSection.FieldName = "SectionID";
            //gcPlanSced.ForceInitialize();
            //gvPlanSched.ClearGrouping();
            //gvPlanSched.Columns["SectionID"].GroupIndex = 0;
            //// gvTram.EndSort();
            //gvPlanSched.ExpandAllGroups();
            gcSection.Visible = false;
            gcWPID.FieldName = "WorkplaceID";
            gcDam.FieldName = "Dam";
            gcGun.FieldName = "Gun";
            gcBench.FieldName = "Bench";
            gcDirection.FieldName = "Direction";
            gcPosition.FieldName = "Postion";
            gcStream.FieldName = "Stream";
            gcTotTonnes.FieldName = "Tonnes";

            gcDailyTonnes.FieldName = "TonnesDaily";
            gcStartDate.FieldName = "StartDate";
            gcEndDate.FieldName = "EndDate";
            gcSecStartDate.FieldName = "SecStart";

            gcDay1.FieldName = "day1";
            gcDay2.FieldName = "day2";
            gcDay3.FieldName = "day3";
            gcDay4.FieldName = "day4";
            gcDay5.FieldName = "day5";
            gcDay6.FieldName = "day6";
            gcDay7.FieldName = "day7";
            gcDay8.FieldName = "day8";
            gcDay9.FieldName = "day9";
            gcDay10.FieldName = "day10";
            gcDay11.FieldName = "day11";
            gcDay12.FieldName = "day12";
            gcDay13.FieldName = "day13";
            gcDay14.FieldName = "day14";
            gcDay15.FieldName = "day15";
            gcDay16.FieldName = "day16";
            gcDay17.FieldName = "day17";
            gcDay18.FieldName = "day18";
            gcDay19.FieldName = "day19";
            gcDay20.FieldName = "day20";
            gcDay21.FieldName = "day21";
            gcDay22.FieldName = "day22";
            gcDay23.FieldName = "day23";
            gcDay24.FieldName = "day24";
            gcDay25.FieldName = "day25";
            gcDay26.FieldName = "day26";
            gcDay27.FieldName = "day27";
            gcDay28.FieldName = "day28";
            gcDay29.FieldName = "day29";
            gcDay30.FieldName = "day30";
            gcDay31.FieldName = "day31";
            gcDay32.FieldName = "day32";
            gcDay33.FieldName = "day33";
            gcDay34.FieldName = "day34";
            gcDay35.FieldName = "day35";
            gcDay36.FieldName = "day36";
            gcDay37.FieldName = "day37";
            gcDay38.FieldName = "day38";
            gcDay39.FieldName = "day39";
            gcDay40.FieldName = "day40";

            //Set visiblity Dates

            if (startdate.AddDays(+19) > enddate)
                gcDay20.Visible = false;

            if (startdate.AddDays(+20) > enddate)
                gcDay21.Visible = false;

            if (startdate.AddDays(+21) > enddate)
                gcDay22.Visible = false;

            if (startdate.AddDays(+22) > enddate)
                gcDay23.Visible = false;

            if (startdate.AddDays(+23) > enddate)
                gcDay24.Visible = false;

            if (startdate.AddDays(+24) > enddate)
                gcDay25.Visible = false;

            if (startdate.AddDays(+25) > enddate)
                gcDay26.Visible = false;

            if (startdate.AddDays(+26) > enddate)
                gcDay27.Visible = false;

            if (startdate.AddDays(+27) > enddate)
                gcDay28.Visible = false;

            if (startdate.AddDays(+28) > enddate)
                gcDay29.Visible = false;

            if (startdate.AddDays(+29) > enddate)
                gcDay30.Visible = false;

            if (startdate.AddDays(+30) > enddate)
                gcDay31.Visible = false;

            if (startdate.AddDays(+31) > enddate)
                gcDay32.Visible = false;

            if (startdate.AddDays(+32) > enddate)
                gcDay33.Visible = false;

            if (startdate.AddDays(+33) > enddate)
                gcDay34.Visible = false;

            if (startdate.AddDays(+34) > enddate)
                gcDay35.Visible = false;

            if (startdate.AddDays(+35) > enddate)
                gcDay36.Visible = false;

            if (startdate.AddDays(+36) > enddate)
                gcDay37.Visible = false;

            if (startdate.AddDays(+37) > enddate)
                gcDay38.Visible = false;

            if (startdate.AddDays(+38) > enddate)
                gcDay39.Visible = false;

            if (startdate.AddDays(+39) > enddate)
                gcDay40.Visible = false;



        }


        void LoadPlanSchedMidmonth()
        {

            //Check if planning Exists

            MWDataManager.clsDataAccess _Check = new MWDataManager.clsDataAccess();
            _Check.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _Check.SqlStatement = " select * from tbl_Planning where prodmonth =  '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + "' " +
                                     "  and section = '" + barSection.EditValue + "'\r\n";
            _Check.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _Check.queryReturnType = MWDataManager.ReturnType.DataTable;
            _Check.ExecuteInstruction();


            MWDataManager.clsDataAccess _getDates = new MWDataManager.clsDataAccess();
            _getDates.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _getDates.SqlStatement = " select min(BeginDate) SD, max(EndDate) ED from tbl_Calendar_Days where prodmonth =  '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + "' " +
                                     "  \r\n";
            _getDates.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _getDates.queryReturnType = MWDataManager.ReturnType.DataTable;
            _getDates.ExecuteInstruction();


            DateTime startdate = Convert.ToDateTime(_getDates.ResultsDataTable.Rows[0][0].ToString());
            DateTime enddate = Convert.ToDateTime(_getDates.ResultsDataTable.Rows[0][1].ToString());


            MWDataManager.clsDataAccess _getPlanSched = new MWDataManager.clsDataAccess();
            _getPlanSched.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);


            _getPlanSched.SqlStatement = " exec sp_GetPlanningSchedule '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + "', '" + barSection.EditValue + "' " +
                                          "  \r\n";

            _getPlanSched.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _getPlanSched.queryReturnType = MWDataManager.ReturnType.DataTable;
            _getPlanSched.ExecuteInstruction();

            gcDay1MM.Visible = true;
            gcDay1MM.Caption = startdate.ToString("dd MMM");
            gcDay2MM.Visible = true;
            gcDay2MM.Caption = startdate.AddDays(+1).ToString("dd MMM");
            gcDay3MM.Visible = true;
            gcDay3MM.Caption = startdate.AddDays(+2).ToString("dd MMM");
            gcDay4MM.Visible = true;
            gcDay4MM.Caption = startdate.AddDays(+3).ToString("dd MMM");
            gcDay5MM.Visible = true;
            gcDay5MM.Caption = startdate.AddDays(+4).ToString("dd MMM");
            gcDay6MM.Visible = true;
            gcDay6MM.Caption = startdate.AddDays(+5).ToString("dd MMM");
            gcDay7MM.Visible = true;
            gcDay7MM.Caption = startdate.AddDays(+6).ToString("dd MMM");
            gcDay8MM.Visible = true;
            gcDay8MM.Caption = startdate.AddDays(+7).ToString("dd MMM");
            gcDay9MM.Visible = true;
            gcDay9MM.Caption = startdate.AddDays(+8).ToString("dd MMM");
            gcDay10MM.Visible = true;
            gcDay10MM.Caption = startdate.AddDays(+9).ToString("dd MMM");
            gcDay11MM.Visible = true;
            gcDay11MM.Caption = startdate.AddDays(+10).ToString("dd MMM");
            gcDay12MM.Visible = true;
            gcDay12MM.Caption = startdate.AddDays(+11).ToString("dd MMM");
            gcDay13MM.Visible = true;
            gcDay13MM.Caption = startdate.AddDays(+12).ToString("dd MMM");
            gcDay14MM.Visible = true;
            gcDay14MM.Caption = startdate.AddDays(+13).ToString("dd MMM");
            gcDay15MM.Visible = true;
            gcDay15MM.Caption = startdate.AddDays(+14).ToString("dd MMM");
            gcDay16MM.Visible = true;
            gcDay16MM.Caption = startdate.AddDays(+15).ToString("dd MMM");
            gcDay17MM.Visible = true;
            gcDay17MM.Caption = startdate.AddDays(+16).ToString("dd MMM");
            gcDay18MM.Visible = true;
            gcDay18MM.Caption = startdate.AddDays(+17).ToString("dd MMM");
            gcDay19MM.Visible = true;
            gcDay19MM.Caption = startdate.AddDays(+18).ToString("dd MMM");
            gcDay20MM.Visible = true;
            gcDay20MM.Caption = startdate.AddDays(+19).ToString("dd MMM");
            gcDay21MM.Visible = true;
            gcDay21MM.Caption = startdate.AddDays(+20).ToString("dd MMM");
            gcDay22MM.Visible = true;
            gcDay22MM.Caption = startdate.AddDays(+21).ToString("dd MMM");
            gcDay23MM.Visible = true;
            gcDay23MM.Caption = startdate.AddDays(+22).ToString("dd MMM");
            gcDay24MM.Visible = true;
            gcDay24MM.Caption = startdate.AddDays(+23).ToString("dd MMM");
            gcDay25MM.Visible = true;
            gcDay25MM.Caption = startdate.AddDays(+24).ToString("dd MMM");
            gcDay26MM.Visible = true;
            gcDay26MM.Caption = startdate.AddDays(+25).ToString("dd MMM");
            gcDay27MM.Visible = true;
            gcDay27MM.Caption = startdate.AddDays(+26).ToString("dd MMM");
            gcDay28MM.Visible = true;
            gcDay28MM.Caption = startdate.AddDays(+27).ToString("dd MMM");
            gcDay29MM.Visible = true;
            gcDay29MM.Caption = startdate.AddDays(+28).ToString("dd MMM");
            gcDay30MM.Visible = true;
            gcDay30MM.Caption = startdate.AddDays(+29).ToString("dd MMM");
            gcDay31MM.Visible = true;
            gcDay31MM.Caption = startdate.AddDays(+30).ToString("dd MMM");
            gcDay32MM.Visible = true;
            gcDay32MM.Caption = startdate.AddDays(+31).ToString("dd MMM");
            gcDay33MM.Visible = true;
            gcDay33MM.Caption = startdate.AddDays(+32).ToString("dd MMM");
            gcDay34MM.Visible = true;
            gcDay34MM.Caption = startdate.AddDays(+33).ToString("dd MMM");
            gcDay35MM.Visible = true;
            gcDay35MM.Caption = startdate.AddDays(+34).ToString("dd MMM");
            gcDay36MM.Visible = true;
            gcDay36MM.Caption = startdate.AddDays(+35).ToString("dd MMM");
            gcDay37MM.Visible = true;
            gcDay37MM.Caption = startdate.AddDays(+36).ToString("dd MMM");
            gcDay38MM.Visible = true;
            gcDay38MM.Caption = startdate.AddDays(+37).ToString("dd MMM");
            gcDay39MM.Visible = true;
            gcDay39MM.Caption = startdate.AddDays(+38).ToString("dd MMM");
            gcDay40MM.Visible = true;
            gcDay40MM.Caption = startdate.AddDays(+39).ToString("dd MMM");


            DataTable dt = _getPlanSched.ResultsDataTable;
            DataSet ds = new DataSet();
            if (ds.Tables.Count > 0)
                ds.Tables.Clear();
            ds.Tables.Add(dt);
            gcMidmonth.DataSource = ds.Tables[0];
            //gcTram.DataBindings();
            gcSectionMM.FieldName = "SectionID";
            //gcPlanSced.ForceInitialize();
            //gvPlanSched.ClearGrouping();
            //gvPlanSched.Columns["SectionID"].GroupIndex = 0;
            //// gvTram.EndSort();
            //gvPlanSched.ExpandAllGroups();
            gcSectionMM.Visible = false;
            gcWPIDMM.FieldName = "WorkplaceID";
            gcDamMM.FieldName = "Dam";
            gcGunMM.FieldName = "Gun";
            gcBenchMM.FieldName = "Bench";
            gcDirectionMM.FieldName = "Direction";
            gcPositionMM.FieldName = "Postion";
            gcStreamMM.FieldName = "Stream";
            gcTotTonnesMM.FieldName = "Tonnes";

            gcDailyTonnesMM.FieldName = "TonnesDaily";
            gcStartMM.FieldName = "StartDate";
            gcEndMM.FieldName = "EndDate";
            gcSecStartDateMM.FieldName = "SecStart";

            gcMidStart.FieldName = "MidStartDate";
            gcMidTonnes.FieldName = "MidTonnesDaily";

            gcDay1MM.FieldName = "day1";
            gcDay2MM.FieldName = "day2";
            gcDay3MM.FieldName = "day3";
            gcDay4MM.FieldName = "day4";
            gcDay5MM.FieldName = "day5";
            gcDay6MM.FieldName = "day6";
            gcDay7MM.FieldName = "day7";
            gcDay8MM.FieldName = "day8";
            gcDay9MM.FieldName = "day9";
            gcDay10MM.FieldName = "day10";
            gcDay11MM.FieldName = "day11";
            gcDay12MM.FieldName = "day12";
            gcDay13MM.FieldName = "day13";
            gcDay14MM.FieldName = "day14";
            gcDay15MM.FieldName = "day15";
            gcDay16MM.FieldName = "day16";
            gcDay17MM.FieldName = "day17";
            gcDay18MM.FieldName = "day18";
            gcDay19MM.FieldName = "day19";
            gcDay20MM.FieldName = "day20";
            gcDay21MM.FieldName = "day21";
            gcDay22MM.FieldName = "day22";
            gcDay23MM.FieldName = "day23";
            gcDay24MM.FieldName = "day24";
            gcDay25MM.FieldName = "day25";
            gcDay26MM.FieldName = "day26";
            gcDay27MM.FieldName = "day27";
            gcDay28MM.FieldName = "day28";
            gcDay29MM.FieldName = "day29";
            gcDay30MM.FieldName = "day30";
            gcDay31MM.FieldName = "day31";
            gcDay32MM.FieldName = "day32";
            gcDay33MM.FieldName = "day33";
            gcDay34MM.FieldName = "day34";
            gcDay35MM.FieldName = "day35";
            gcDay36MM.FieldName = "day36";
            gcDay37MM.FieldName = "day37";
            gcDay38MM.FieldName = "day38";
            gcDay39MM.FieldName = "day39";
            gcDay40MM.FieldName = "day40";

            //Set visiblity Dates

            if (startdate.AddDays(+19) > enddate)
                gcDay20MM.Visible = false;

            if (startdate.AddDays(+20) > enddate)
                gcDay21MM.Visible = false;

            if (startdate.AddDays(+21) > enddate)
                gcDay22MM.Visible = false;

            if (startdate.AddDays(+22) > enddate)
                gcDay23MM.Visible = false;

            if (startdate.AddDays(+23) > enddate)
                gcDay24MM.Visible = false;

            if (startdate.AddDays(+24) > enddate)
                gcDay25MM.Visible = false;

            if (startdate.AddDays(+25) > enddate)
                gcDay26MM.Visible = false;

            if (startdate.AddDays(+26) > enddate)
                gcDay27MM.Visible = false;

            if (startdate.AddDays(+27) > enddate)
                gcDay28MM.Visible = false;

            if (startdate.AddDays(+28) > enddate)
                gcDay29MM.Visible = false;

            if (startdate.AddDays(+29) > enddate)
                gcDay30MM.Visible = false;

            if (startdate.AddDays(+30) > enddate)
                gcDay31MM.Visible = false;

            if (startdate.AddDays(+31) > enddate)
                gcDay32MM.Visible = false;

            if (startdate.AddDays(+32) > enddate)
                gcDay33MM.Visible = false;

            if (startdate.AddDays(+33) > enddate)
                gcDay34MM.Visible = false;

            if (startdate.AddDays(+34) > enddate)
                gcDay35MM.Visible = false;

            if (startdate.AddDays(+35) > enddate)
                gcDay36MM.Visible = false;

            if (startdate.AddDays(+36) > enddate)
                gcDay37MM.Visible = false;

            if (startdate.AddDays(+37) > enddate)
                gcDay38MM.Visible = false;

            if (startdate.AddDays(+38) > enddate)
                gcDay39MM.Visible = false;

            if (startdate.AddDays(+39) > enddate)
                gcDay40MM.Visible = false;



        }

        public int LocateRowByMultipleValues(ColumnView view, GridColumn[] columns,
        object[] values, int startRowHandle)
        {
            // Check whether or not the arrays have the same length 
            if (columns.Length != values.Length)
                return DevExpress.XtraGrid.GridControl.InvalidRowHandle;
            // Obtain the number of data rows within the view 
            int dataRowCount;
            if (view is CardView)
                dataRowCount = (view as CardView).RowCount;
            else
                dataRowCount = (view as GridView).DataRowCount;
            // Traverse the data rows to find a match 
            bool match;
            object currValue;
            for (int currentRowHandle = startRowHandle; currentRowHandle < dataRowCount;
            currentRowHandle++)
            {
                match = true;
                for (int i = 0; i < columns.Length; i++)
                {
                    currValue = view.GetRowCellValue(currentRowHandle, columns[i]);
                    if (currValue.Equals("ID"))
                        match = true;
                }
                if (match)
                    //gvPlan.Columns[0]["ID"].R = false;
                    return currentRowHandle;
            }
            // Return the invalid row handle if no matches are found 
            return DevExpress.XtraGrid.GridControl.InvalidRowHandle;
        }

        private void ucPlanning_Load(object sender, EventArgs e)
        {
            gcPlanning.Visible = false;
            PlanCodesDP.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            barYear.EditValue = (DateTime.Now.Year * 100) + DateTime.Now.Month;
            //procs.ProdMonthVis(Convert.ToInt32(PM1Txt.Text));
            barProdMonth.EditValue = TMinewasteGlobal.ProdMonthAsDate(GlobalVar.ProdMonth.ToString());


            barYear.EditValue = DateTime.Now.Year;

            ////Set selected row color planning schedule

            gvPlanSched.OptionsSelection.EnableAppearanceFocusedCell = true;
            gvPlanSched.OptionsSelection.EnableAppearanceFocusedRow = false;
            gvPlanSched.Appearance.FocusedRow.ForeColor = Color.Black;
            gvPlanSched.Appearance.SelectedRow.ForeColor = Color.Black;
            gvPlanSched.Appearance.SelectedRow.Options.UseForeColor = true;


            LoadSec();




        }

        void LoadSec()
        {
            ///Load Sections fro scheduling

            MWDataManager.clsDataAccess _getSec = new MWDataManager.clsDataAccess();
            _getSec.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _getSec.SqlStatement = " select distinct(Section) Sec from tbl_Calendar_days where prodmonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + "' " +
                                     "  \r\n";
            _getSec.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _getSec.queryReturnType = MWDataManager.ReturnType.DataTable;
            _getSec.ExecuteInstruction();

            DataTable dt = _getSec.ResultsDataTable;


            DataSet ds = new DataSet();
            if (ds.Tables.Count > 0)
                ds.Tables.Clear();
            ds.Tables.Add(dt);
            //Grd3Mnth.Visible = true;
            LookUpEditSection.DataSource = ds.Tables[0];
            LookUpEditSection.DisplayMember = "Sec";
            LookUpEditSection.ValueMember = "Sec";
        }



        private void gcPlanning_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                string[] data = ClipboardData.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (data.Length < 1) return;
                int startRow = gvPlan.FocusedRowHandle;
                foreach (string row in data)
                {
                    AddRow(row, startRow++);
                    if (!gvPlan.IsValidRowHandle(startRow)) break;
                }
                e.SuppressKeyPress = true;
                e.Handled = true;
            }

        }


        private void AddRow(string data, int rowHandle)
        {
            if (data == string.Empty) return;
            string[] rowData = data.Split('\t');
            int column = gvPlan.FocusedColumn.VisibleIndex;
            for (int i = 0; i < rowData.Length; i++)
            {
                if (i >= gvPlan.VisibleColumns.Count) break;
                gvPlan.SetRowCellValue(rowHandle, gvPlan.VisibleColumns[column + i], rowData[i]);
            }
        }

        private object GetDataSource()
        {
            BindingList<Record> records = new BindingList<Record>();
            for (int i = 0; i < 1000; i++)
                records.Add(new Record()
                {
                    Dates = "DATES"
                    ,
                    IDs = "ID"
                    ,
                    Dumps = "DUMP"
                    ,
                    Dams = "DAM"
                    ,
                    Guns = "GUN"
                    ,
                    Benchs = "BENCH"
                    ,
                    Directions = "DIRECTION"
                    ,
                    Positions = "POSITION"
                    ,
                    Streams = "STREAM"
                    ,
                    Durations = "DURATION"
                    ,
                    Rates = "RATE"
                    ,
                    Starts = "START"
                    ,
                    Finnishs = "FINNISH"
                    ,
                    AUs = "AU"
                    ,
                    Tonness = "TONNES"
                    ,
                    KGs = "KG",
                    RecievedKgs = "KGREC"
                    + i
                });
            return records;


        }

        private void gvPlan_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {


        }

        private void PlanningTabCntrl_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void PlanningTabCntrl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (PlanningTabCntrl.SelectedTabPageIndex == 0)
            {
                barProdMonth.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barSection.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barYear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //PlanFilterRG.Visible = false;
                PlanCodesDP.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                GetImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            if (PlanningTabCntrl.SelectedTabPageIndex == 1)
            {

                barProdMonth.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barSection.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barYear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //PlanFilterRG.Visible = true;
                PlanCodesDP.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                PlanCodesDP.Enabled = false;
                GetImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            if (PlanningTabCntrl.SelectedTabPageIndex == 2)
            {
                GetImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barProdMonth.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barSection.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barYear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //PlanFilterRG.Visible = false;
                PlanCodesDP.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                GetImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                GetImageBtn.Enabled = false;
            }
            if (PlanningTabCntrl.SelectedTabPageIndex == 3)
            {
                barProdMonth.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barSection.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barYear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //PlanFilterRG.Visible = false;
                PlanCodesDP.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                GetImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
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

        void LoadPlan()
        {
            string Machine = "";
            TimeSpan span;
            int ss;

            int ProgDailyTonnes = 0;
            int TonnesDailyNew = 0;

            string first = "N";

            string Comp = "N";

            string prevmach = "";
            int prevcol = 0;
            int prevtons = 0;

            for (int row = 0; row < gvPlanSched.RowCount; row++)
            {
                DateTime SecBeginDate = Convert.ToDateTime(gvPlanSched.GetRowCellValue(row, gvPlanSched.Columns["SecStart"]).ToString());
                DateTime BeginDate = Convert.ToDateTime(gvPlanSched.GetRowCellValue(row, gvPlanSched.Columns["StartDate"]).ToString());
                string DailyTonnes = gvPlanSched.GetRowCellValue(row, gvPlanSched.Columns["TonnesDaily"]).ToString();
                string TotTonnes = gvPlanSched.GetRowCellValue(row, gvPlanSched.Columns["Tonnes"]).ToString();
                Machine = gvPlanSched.GetRowCellValue(row, gvPlanSched.Columns["Gun"]).ToString();

                //Midmonth


                span = BeginDate.Subtract(SecBeginDate);

                ss = Convert.ToInt32(span.Days);

                ProgDailyTonnes = 0;
                TonnesDailyNew = 0;

                Comp = "N";

                first = "Y";

                for (int col = 11; col < 45; col++)
                {
                    DailyTonnes = gvMidmonth.GetRowCellValue(row, gvMidmonth.Columns[col]).ToString();

                    if (col > ss + 11)
                    {
                        if (Comp == "N")
                        {
                            ProgDailyTonnes = ProgDailyTonnes + Convert.ToInt32(DailyTonnes);

                            if (ProgDailyTonnes > Convert.ToInt32(TotTonnes))
                            {
                                //ProgDailyTonnes = ProgDailyTonnes + Convert.ToInt32(DailyTonnes);
                                TonnesDailyNew = Convert.ToInt32(DailyTonnes) - ProgDailyTonnes + Convert.ToInt32(TotTonnes);
                                gvPlanSched.SetRowCellValue(row, gvPlanSched.Columns[col], Convert.ToString(TonnesDailyNew));
                                prevcol = col;
                                prevmach = Machine;
                                prevtons = TonnesDailyNew;
                                Comp = "Y";
                            }
                            else
                            {

                                gvPlanSched.SetRowCellValue(row, gvPlanSched.Columns[col], DailyTonnes);

                                if (prevmach == Machine)
                                {
                                    if (prevcol == col)
                                    {
                                        //ProgDailyTonnes = ProgDailyTonnes + (Convert.ToInt32(DailyTonnes) - prevtons);
                                        //ProgDailyTonnes = ProgDailyTonnes + Convert.ToInt32(DailyTonnes);
                                        gvPlanSched.SetRowCellValue(row, gvPlanSched.Columns[col], Convert.ToString(Convert.ToInt32(DailyTonnes) - prevtons));
                                        ProgDailyTonnes = ProgDailyTonnes - (Convert.ToInt32(DailyTonnes) - prevtons);

                                    }


                                }

                            }


                        }


                    }
                }
                //gvPlanSched.SetRowCellValue(row, gvPlanSched.Columns[col], DailyTonnes);

            }
        }



        void LoadPlanMidmonth()
        {
            string Machine = "";
            TimeSpan span;
            TimeSpan spanMM;
            int ss;
            int ssMM;

            int ProgDailyTonnes = 0;
            int TonnesDailyNew = 0;

            string first = "N";

            string Comp = "N";

            string prevmach = "";
            int prevcol = 0;
            int prevtons = 0;


            for (int row = 0; row < gvMidmonth.RowCount; row++)
            {
                DateTime SecBeginDate = Convert.ToDateTime(gvMidmonth.GetRowCellValue(row, gvMidmonth.Columns["SecStart"]).ToString());
                DateTime BeginDate = Convert.ToDateTime(gvMidmonth.GetRowCellValue(row, gvMidmonth.Columns["StartDate"]).ToString());
                string DailyTonnes = gvMidmonth.GetRowCellValue(row, gvMidmonth.Columns["TonnesDaily"]).ToString();
                string TotTonnes = gvMidmonth.GetRowCellValue(row, gvMidmonth.Columns["Tonnes"]).ToString();
                Machine = gvMidmonth.GetRowCellValue(row, gvMidmonth.Columns["Gun"]).ToString();

                //MidmonthPlan
                DateTime MidBeginDate = Convert.ToDateTime(gvMidmonth.GetRowCellValue(row, gvMidmonth.Columns["MidStartDate"]).ToString());
                string MidDailyTonnes = gvMidmonth.GetRowCellValue(row, gvMidmonth.Columns["MidTonnesDaily"]).ToString();


                gcMidStart.FieldName = "MidStartDate";
                gcMidTonnes.FieldName = "MidTonnesDaily";


                span = BeginDate.Subtract(SecBeginDate);

                ss = Convert.ToInt32(span.Days);


                spanMM = MidBeginDate.Subtract(SecBeginDate);
                ssMM = Convert.ToInt32(spanMM.Days);

                ProgDailyTonnes = 0;
                TonnesDailyNew = 0;

                Comp = "N";

                first = "Y";

                for (int col = 11; col < 45; col++)
                {
                    if (col > 11)
                    {

                        gvMidmonth.SetRowCellValue(row, gvMidmonth.Columns[col], DailyTonnes);

                    }
                }


                for (int col = 11; col < 45; col++)
                {
                    if (col > ssMM + 11)
                    {

                        gvMidmonth.SetRowCellValue(row, gvMidmonth.Columns[col], MidDailyTonnes);

                    }
                }


            }
        }

        //string Code = "";
        private void gvPlanSched_RowCellClick(object sender, RowCellClickEventArgs e)
        {

            gvGunHrs2.PostEditor();

            //if (e.Column.FieldName == "day1")
            //{
            //    if (Convert.ToString(PlanningCode) == "C")
            //    {
            //        string PlanTonnes = gvPlanSched.GetRowCellValue(e.RowHandle, gvPlanSched.Columns["TonnesDaily"]).ToString();
            //        string TotTonnes = gvPlanSched.GetRowCellValue(e.RowHandle, gvPlanSched.Columns["Tonnes"]).ToString();

            //        gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day1"], PlanTonnes);
            //    }
            //    else
            //    {
            //        gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day1"], PlanningCode);
            //    }

            //}           




            //if (e.Column.FieldName == "day2")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day2"], PlanningCode);

            //if (e.Column.FieldName == "day3")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day3"], PlanningCode);

            //if (e.Column.FieldName == "day4")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day4"], PlanningCode);

            //if (e.Column.FieldName == "day5")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day5"], PlanningCode);

            //if (e.Column.FieldName == "day6")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day6"], PlanningCode);

            //if (e.Column.FieldName == "day7")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day7"], PlanningCode);

            //if (e.Column.FieldName == "day8")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day8"], PlanningCode);

            //if (e.Column.FieldName == "day9")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day9"], PlanningCode);

            //if (e.Column.FieldName == "day10")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day10"], PlanningCode);

            //if (e.Column.FieldName == "day11")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day11"], PlanningCode);

            //if (e.Column.FieldName == "day12")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day12"], PlanningCode);

            //if (e.Column.FieldName == "day13")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day13"], PlanningCode);

            //if (e.Column.FieldName == "day14")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day14"], PlanningCode);

            //if (e.Column.FieldName == "day15")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day15"], PlanningCode);

            //if (e.Column.FieldName == "day16")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day16"], PlanningCode);

            //if (e.Column.FieldName == "day17")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day17"], PlanningCode);

            //if (e.Column.FieldName == "day18")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day18"], PlanningCode);

            //if (e.Column.FieldName == "day19")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day19"], PlanningCode);

            //if (e.Column.FieldName == "day20")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day20"], PlanningCode);

            //if (e.Column.FieldName == "day21")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day21"], PlanningCode);

            //if (e.Column.FieldName == "day22")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day22"], PlanningCode);

            //if (e.Column.FieldName == "day23")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day23"], PlanningCode);

            //if (e.Column.FieldName == "day24")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day24"], PlanningCode);

            //if (e.Column.FieldName == "day25")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day25"], PlanningCode);

            //if (e.Column.FieldName == "day26")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day26"], PlanningCode);

            //if (e.Column.FieldName == "day27")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day27"], PlanningCode);

            //if (e.Column.FieldName == "day28")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day28"], PlanningCode);

            //if (e.Column.FieldName == "day29")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day29"], PlanningCode);

            //if (e.Column.FieldName == "day30")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day30"], PlanningCode);

            //if (e.Column.FieldName == "day31")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day31"], PlanningCode);

            //if (e.Column.FieldName == "day32")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day32"], PlanningCode);

            //if (e.Column.FieldName == "day33")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day33"], PlanningCode);

            //if (e.Column.FieldName == "day34")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day34"], PlanningCode);

            //if (e.Column.FieldName == "day35")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day35"], PlanningCode);

            //if (e.Column.FieldName == "day36")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day36"], PlanningCode);

            //if (e.Column.FieldName == "day37")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day37"], PlanningCode);

            //if (e.Column.FieldName == "day38")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day38"], PlanningCode);

            //if (e.Column.FieldName == "day39")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day39"], PlanningCode);

            //if (e.Column.FieldName == "day40")
            //    gvPlanSched.SetRowCellValue(e.RowHandle, gvPlanSched.Columns["day40"], PlanningCode);


        }

        private void gvPlan_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

        }

        // object aa = 0;

        private void gvPlanSched_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            //if (e.Value == aa) e.DisplayText = "";

        }

        private void gvPlanSched_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Tonnes")
                {
                    //bool value = Convert.ToBoolean(currentView.GetRowCellValue(e.RowHandle, "Flag_Customer"));
                    //if (value)
                    e.Appearance.BackColor = System.Drawing.Color.LightGray;


                }
                if (e.Column.FieldName == "day1")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }
                if (e.Column.FieldName == "day2")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day3")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day4")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day5")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day6")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }

                }

                if (e.Column.FieldName == "day7")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }

                }

                if (e.Column.FieldName == "day8")
                {
                    if (e.CellValue != DBNull.Value)
                    {

                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day9")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day10")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }


                if (e.Column.FieldName == "day11")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day12")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day13")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day14")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day15")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day16")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day17")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day18")

                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day19")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day20")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day21")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day22")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day23")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day24")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day25")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day26")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day27")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day28")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day29")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day30")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day31")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day32")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day33")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day34")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day35")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day36")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day37")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day38")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day39")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }

                if (e.Column.FieldName == "day40")
                {
                    if (e.CellValue != DBNull.Value)
                    {
                        if (e.CellValue.ToString() == "CM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "SS")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "MM")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() == "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                        }
                        if (e.CellValue.ToString() != "CM" && e.CellValue.ToString() != "SS" && e.CellValue.ToString() != "MM" && e.CellValue.ToString() != "EP")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        }
                    }
                }
            }
            catch { return; }

        }

        private void gvGunHrs_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "HoursDaily")
            {
                e.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            }
        }

        private void gvGunHrs_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

            //gvGunHrs2.SetRowCellValue(e.RowHandle, gvGunHrs2.Columns["TonnesDaily"], cellValue * val);

        }

        private void gvGunHrs_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

        }

        private void gvGunHrs_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {


        }

        private void LBPlanCodes_SelectedValueChanged(object sender, EventArgs e)
        {
            PlanningCode = ExtractBeforeColon(LBPlanCodes.SelectedValue.ToString());
        }

        private void gvPlan_RowCellClick(object sender, RowCellClickEventArgs e)
        {

        }

        private void gvPlan_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {

        }

        private void gvPlanSched_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            //    Rectangle r = e.Bounds;

            //    // Draw the cell value.  This draws the text with the highlight.
            //    e.Appearance.DrawString(e.Cache, e.DisplayText, r);

            //    // this will draw the black border around the cell
            //    using (Pen p = new Pen(Color.Black, 1))
            //    {
            //        Rectangle rect = e.Bounds;
            //        rect.Width -= 1;
            //        rect.Height -= 1;
            //        e.Graphics.DrawRectangle(p, rect);
            //    }

            //    // Set e.Handled to true to prevent default painting
            //    e.Handled = true;
        }


        private void gvGunHrs2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "HoursDaily")
            {
                e.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            }
            if (e.Column.FieldName == "HoursDailyMM")
            {
                e.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            }
            if (e.Column.FieldName == "StartDateMM")
            {
                e.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            }
        }

        private void gvGunHrs2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {


            try
            {

                if (e.Column.FieldName != "HoursDaily")
                {

                }
                else
                {
                    gcGunHrs.ForceInitialize();
                    gvGunHrs2.Columns["SectionID"].GroupIndex = -1;
                    gvGunHrs2.Columns["SectionID"].Visible = true;


                    for (int row = 0; row < gvGunHrs2.RowCount; row++)
                    {
                        //MainPlan
                        decimal perc = 0;
                        decimal TonnesDaily = 0;
                        int TonnesDaily2 = 0;
                        int hoursmonthly = 0;

                        perc = (Convert.ToDecimal(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[2]).ToString()) / 44) * 100;
                        int TotalShifts = (Convert.ToInt32(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns["TotalShifts"]).ToString()));
                        TonnesDaily = (Convert.ToDecimal(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[13]).ToString()) / TotalShifts) * (perc / 100);
                        TonnesDaily2 = Convert.ToInt32(TonnesDaily);



                        hoursmonthly = Convert.ToInt32(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns["HoursDaily"]).ToString()) * (Convert.ToInt32(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns["TotalShifts"]).ToString()));

                        gvGunHrs2.SetRowCellValue(row, gvGunHrs2.Columns[12], perc);
                        gvGunHrs2.SetRowCellValue(row, gvGunHrs2.Columns["TonnesDaily2"], TonnesDaily2);
                        gvGunHrs2.SetRowCellValue(row, gvGunHrs2.Columns["HoursMonthly"], hoursmonthly);

                    }

                    gcGunHrs.ForceInitialize();
                    gvGunHrs2.ClearGrouping();
                    gvGunHrs2.Columns["SectionID"].GroupIndex = 0;
                    gvGunHrs2.Columns["SectionID"].Visible = false;
                    gvGunHrs2.ExpandAllGroups();
                }

                if (e.Column.FieldName != "HoursDailyMM")
                {
                }
                else
                {
                    //Midmonth
                    decimal percMM = 0;
                    decimal TonnesDailyMM = 0;
                    int TonnesDaily2MM = 0;
                    int hoursmonthlyMM = 0;

                    gcGunHrs.ForceInitialize();
                    gvGunHrs2.Columns["SectionID"].GroupIndex = -1;
                    gvGunHrs2.Columns["SectionID"].Visible = true;
                    for (int row = 0; row < gvGunHrs2.RowCount; row++)
                    {
                        percMM = (Convert.ToDecimal(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[7]).ToString()) / 44) * 100;

                        TonnesDailyMM = (Convert.ToDecimal(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[13]).ToString()) / (Convert.ToInt32(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns["TotalShifts"]).ToString()))) * (percMM / 100);
                        TonnesDaily2MM = Convert.ToInt32(TonnesDailyMM);

                        hoursmonthlyMM = Convert.ToInt32(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns["HoursDailyMM"]).ToString()) * (Convert.ToInt32(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns["TotalShifts"]).ToString()));

                        gvGunHrs2.SetRowCellValue(row, gvGunHrs2.Columns[14], percMM);
                        gvGunHrs2.SetRowCellValue(row, gvGunHrs2.Columns["TonnesDaily2MM"], TonnesDaily2MM);
                        gvGunHrs2.SetRowCellValue(row, gvGunHrs2.Columns["HoursMonthlyMM"], hoursmonthlyMM);
                    }
                    gcGunHrs.ForceInitialize();
                    gvGunHrs2.ClearGrouping();
                    gvGunHrs2.Columns["SectionID"].GroupIndex = 0;
                    gvGunHrs2.Columns["SectionID"].Visible = false;
                    gvGunHrs2.ExpandAllGroups();

                }
            }
            catch { return; }


        }

        private void GetImageBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            GetImage GetImage = new GetImage();
            GetImage._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            GetImage.ProdmonthLbl.Text = TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString();
            GetImage.SectionLbl.Text = barSection.EditValue.ToString();
            GetImage.ShowDialog(this);
        }

        private void SecCmb_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (barSection.EditValue.ToString() != "")
            {
                GetImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                GetImageBtn.Enabled = true;
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gcPlanning.Visible = true;

            if (PlanningTabCntrl.SelectedTabPageIndex == 0)
            {
                barSection.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                ////Load Grid if planning exists
                MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
                _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbMan.SqlStatement = "";
                _dbMan.SqlStatement = _dbMan.SqlStatement + " select *, convert(Decimal(18,0),isnull(Tonnes, 0)) Tonnes2 from tbl_Planmonth  \r\n";
                _dbMan.SqlStatement = _dbMan.SqlStatement + " where prodmonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + "' \r\n ";
                _dbMan.SqlStatement = _dbMan.SqlStatement + " order by SectionID, WorkplaceID, Gun, Dam, StartDate, EndDate\r\n ";
                _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan.ExecuteInstruction();

                if (_dbMan.ResultsDataTable.Rows.Count > 0)
                {

                    DataTable dt = _dbMan.ResultsDataTable;
                    DataSet ds = new DataSet();
                    if (ds.Tables.Count > 0)
                        ds.Tables.Clear();
                    ds.Tables.Add(dt);

                    gcPlanning.DataSource = ds.Tables[0];
                    Dates.FieldName = "Prodmonth";
                    IDs.FieldName = "WorkplaceID";
                    Dumps.FieldName = "SectionID";
                    Dams.FieldName = "Dam";
                    Guns.FieldName = "Gun";
                    Benchs.FieldName = "Bench";
                    Directions.FieldName = "Direction";
                    Positions.FieldName = "Postion";
                    Streams.FieldName = "Stream";
                    Durations.FieldName = "Duration";
                    Rates.FieldName = "Rate";
                    Starts.FieldName = "StartDate";
                    Finnishs.FieldName = "EndDate";
                    AUs.FieldName = "AU_OK";
                    Tonness.FieldName = "Tonnes2";
                    KGs.FieldName = "Kg";
                    RecievedKgs.FieldName = "KgRec";

                }
                else
                {
                    GridColumn[] cols = new GridColumn[] { Dates, IDs };
                    object[] values = new object[] { "Dates", "ID" };
                    int rowHandle = LocateRowByMultipleValues(gvPlan, cols, values, 0);
                }
            }

            if (PlanningTabCntrl.SelectedTabPageIndex == 1)
            {
                barSection.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                MWDataManager.clsDataAccess _dbManGunHrs = new MWDataManager.clsDataAccess();
                _dbManGunHrs.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbManGunHrs.SqlStatement = "";
                _dbManGunHrs.SqlStatement = _dbManGunHrs.SqlStatement + " sp_Planning_GunHrs '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + "' \r\n";
                _dbManGunHrs.SqlStatement = _dbManGunHrs.SqlStatement + "    \r\n";

                _dbManGunHrs.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManGunHrs.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManGunHrs.ExecuteInstruction();

                if (_dbManGunHrs.ResultsDataTable.Rows.Count > 0)
                {

                    DataTable dt2 = _dbManGunHrs.ResultsDataTable;
                    DataSet ds2 = new DataSet();
                    if (ds2.Tables.Count > 0)
                        ds2.Tables.Clear();
                    ds2.Tables.Add(dt2);
                    gcGunHrs.DataSource = ds2.Tables[0];
                    gcSection2.Visible = false;
                    gcSection2.FieldName = "SectionID";
                    gcGun3.FieldName = "Gun";
                    gcHrsDay2.FieldName = "HoursDaily";
                    gcHoursMonth2.FieldName = "HoursMonthly";
                    gcTonnesMonth2.FieldName = "TonnesMonthly";
                    gcTonnesDay2.FieldName = "TonnesDaily2";

                    //Midmonth Data
                    gcStartDateMM.FieldName = "StartDateMM";
                    gcHrsDayMM.FieldName = "HoursDailyMM";
                    gcHoursMonthMM.FieldName = "HoursMonthlyMM";
                    gcTonnesMonthMM.FieldName = "TonnesMonthlyMM";
                    gcTonnesDayMM.FieldName = "TonnesDaily2MM";

                    gcShift2.FieldName = "TotalShifts";
                    gcPercMainPlan.FieldName = "PercMainPlan";
                    gcTonsDailySecMain.FieldName = "TotTonsDailySec";

                    gcPercMidMonthPlan.FieldName = "PercMidPlan";
                    gcTonsDailySecMidMonth.FieldName = "TotTonsDailySecMidMonth";

                    gcGunHrs.ForceInitialize();
                    gvGunHrs2.ClearGrouping();
                    gvGunHrs2.Columns[0].GroupIndex = 0;
                    gvGunHrs2.Columns[0].Visible = false;
                    gvGunHrs2.ExpandAllGroups();

                    ///Summary Item

                    //GridView View = gvGunHrs2;    
                    GridGroupSummaryItem item1 = new GridGroupSummaryItem();

                    item1.FieldName = "HoursDaily";
                    item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item1.ShowInGroupColumnFooter = gvGunHrs2.Columns["HoursDaily"];
                    // Add the summary item to the collection 
                    gvGunHrs2.GroupSummary.Add(item1);

                    gcGunHrs.ForceInitialize();
                    //gvGunHrs2.ClearGrouping();            
                    gvGunHrs2.Columns["SectionID"].GroupIndex = -1;
                    gvGunHrs2.Columns["SectionID"].Visible = true;


                    for (int row = 0; row < gvGunHrs2.RowCount; row++)
                    {
                        TotTonnesDaily = (Convert.ToDecimal(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns["TonnesDaily2"]).ToString()));
                        //gvGunHrs2.SetRowCellValue(row, gvGunHrs2.Columns[12], perc);
                    }

                    gcGunHrs.ForceInitialize();
                    gvGunHrs2.ClearGrouping();
                    gvGunHrs2.Columns["SectionID"].GroupIndex = 0;
                    gvGunHrs2.Columns["SectionID"].Visible = false;
                    gvGunHrs2.ExpandAllGroups();



                }
            }

            if (PlanningTabCntrl.SelectedTabPageIndex == 2)
            {
                barSection.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                gcPlanSced.Visible = true;
                if (barSection.EditValue.ToString() == "")
                    return;


                //LoadMidmonthGrid
                LoadPlanSchedMidmonth();
                LoadPlanMidmonth();

                LoadPlanSched();
                LoadPlan();


            }

            if (PlanningTabCntrl.SelectedTabPageIndex == 3)
            {
                barSection.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                gcBudget.Visible = true;

                MWDataManager.clsDataAccess _dbManBudget = new MWDataManager.clsDataAccess();
                _dbManBudget.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbManBudget.SqlStatement = " exec sp_Planning_Budget '" + barYear.EditValue + "'";



                _dbManBudget.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManBudget.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManBudget.ExecuteInstruction();

                DataTable dt2 = _dbManBudget.ResultsDataTable;
                DataSet ds2 = new DataSet();
                if (ds2.Tables.Count > 0)
                    ds2.Tables.Clear();
                ds2.Tables.Add(dt2);
                //Grd3Mnth.Visible = true;
                gcBudget.DataSource = ds2.Tables[0];

                // gvTram.EndSort();

                //gcSection.Visible = false;
                gcBudgetSec.FieldName = "section";
                gcBudgetTonnes.FieldName = "JanTonnes";
                gcBudgetKG.FieldName = "JanKG";
                gcBudgetGT.FieldName = "JanGT";
                gcEstKg.FieldName = "JanKgPerc";

                gcBudgetTonnesFeb.FieldName = "FebTonnes";
                gcBudgetKGFeb.FieldName = "FebKG";
                gcBudgetGTFeb.FieldName = "FebGT";
                gcEstKgFeb.FieldName = "FebKgPerc";

                gcBudgetTonnesMarch.FieldName = "MarchTonnes";
                gcBudgetKGMarch.FieldName = "MarchKG";
                gcBudgetGTMarch.FieldName = "MarchGT";
                gcEstKgMarch.FieldName = "MarchKgPerc";

                gcBudgetTonnesApr.FieldName = "AprTonnes";
                gcBudgetKGApr.FieldName = "AprKG";
                gcBudgetGTApr.FieldName = "AprGT";
                gcEstKgApr.FieldName = "AprKgPerc";

                gcBudgetTonnesMay.FieldName = "MayTonnes";
                gcBudgetKGMay.FieldName = "MayKG";
                gcBudgetGTMay.FieldName = "MayGT";
                gcEstKgMay.FieldName = "MayKgPerc";

                gcBudgetTonnesJune.FieldName = "JuneTonnes";
                gcBudgetKGJune.FieldName = "JuneKG";
                gcBudgetGTJune.FieldName = "JuneGT";
                gcEstKgJune.FieldName = "JuneKgPerc";

                gcBudgetTonnesJuly.FieldName = "JulyTonnes";
                gcBudgetKGJuly.FieldName = "JulyKG";
                gcBudgetGTJuly.FieldName = "JulyGT";
                gcEstKgJuly.FieldName = "JulyKgPerc";

                gcBudgetTonnesAug.FieldName = "AugTonnes";
                gcBudgetKGAug.FieldName = "AugKG";
                gcBudgetGTAug.FieldName = "AugGT";
                gcEstKgAug.FieldName = "AugKgPerc";

                gcBudgetTonnesSept.FieldName = "SeptTonnes";
                gcBudgetKGSept.FieldName = "SeptKG";
                gcBudgetGTSept.FieldName = "SeptGT";
                gcEstKgSept.FieldName = "SeptKgPerc";

                gcBudgetTonnesOct.FieldName = "OctTonnes";
                gcBudgetKGOct.FieldName = "OctKG";
                gcBudgetGTOct.FieldName = "OctGT";
                gcEstKgOct.FieldName = "OctKgPerc";

                gcBudgetTonnesNov.FieldName = "NovTonnes";
                gcBudgetKGNov.FieldName = "NovKG";
                gcBudgetGTNov.FieldName = "NovGT";
                gcEstKgNov.FieldName = "NovKgPerc";

                gcBudgetTonnesDec.FieldName = "DecTonnes";
                gcBudgetKGDec.FieldName = "DecKG";
                gcBudgetGTDec.FieldName = "DecGT";
                gcEstKgDec.FieldName = "DecKgPerc";
            }
        }

        private void SaveBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;


            if (PlanningTabCntrl.SelectedTabPageIndex == 0)
            {

                char[] charsToTrim = { 'm', 'i', 'T', '/', 'm', 'o', 'd' };
                char[] charsToTrim2 = { 'd' };

                MWDataManager.clsDataAccess _dbManSave7 = new MWDataManager.clsDataAccess();
                _dbManSave7.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbManSave7.SqlStatement = "";
                _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + " delete from tbl_PlanmonthTemp where prodmonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + "' \r\n";

                for (int row = 0; row < gvPlan.RowCount; row++)
                {

                    string WPID = "";
                    string Dump = "";
                    string Dam = "";
                    string Gun = "";
                    string Bench = "";
                    string Direction = "";
                    string Position = "";
                    string Stream = "";
                    decimal Duration = 0;
                    decimal Rate = 0;
                    DateTime Start = DateTime.Now;
                    DateTime Finnish = DateTime.Now;
                    decimal AU = 0;
                    decimal Tonnes = 0;
                    decimal Kg = 0;
                    decimal KgRec = 0;

                    string test = gvPlan.GetRowCellValue(row, gvPlan.Columns[1]).ToString();

                    if (test != "ID")
                    {
                        try
                        {
                            WPID = gvPlan.GetRowCellValue(row, gvPlan.Columns[1]).ToString();
                            Dump = gvPlan.GetRowCellValue(row, gvPlan.Columns[2]).ToString();
                            Dam = gvPlan.GetRowCellValue(row, gvPlan.Columns[3]).ToString();
                            Gun = gvPlan.GetRowCellValue(row, gvPlan.Columns[4]).ToString();
                            Bench = gvPlan.GetRowCellValue(row, gvPlan.Columns[5]).ToString();
                            Direction = gvPlan.GetRowCellValue(row, gvPlan.Columns[6]).ToString();
                            Position = gvPlan.GetRowCellValue(row, gvPlan.Columns[7]).ToString();
                            Stream = gvPlan.GetRowCellValue(row, gvPlan.Columns[8]).ToString();
                            Duration = Convert.ToDecimal(gvPlan.GetRowCellValue(row, gvPlan.Columns[9]).ToString().TrimEnd(charsToTrim2));
                            Rate = Convert.ToDecimal(gvPlan.GetRowCellValue(row, gvPlan.Columns[10]).ToString().TrimEnd(charsToTrim));

                            Start = Convert.ToDateTime(gvPlan.GetRowCellValue(row, gvPlan.Columns[11]).ToString());

                            Finnish = Convert.ToDateTime(gvPlan.GetRowCellValue(row, gvPlan.Columns[12]).ToString());
                            AU = Convert.ToDecimal(gvPlan.GetRowCellValue(row, gvPlan.Columns[13]).ToString());
                            Tonnes = Convert.ToDecimal(gvPlan.GetRowCellValue(row, gvPlan.Columns[14]).ToString());
                            Kg = Convert.ToDecimal(gvPlan.GetRowCellValue(row, gvPlan.Columns[15]).ToString());
                            KgRec = Convert.ToDecimal(gvPlan.GetRowCellValue(row, gvPlan.Columns[16]).ToString());
                        }
                        catch
                        {
                            MessageBox.Show("Please ensure that all fields correspond, and the date format is correct.", "Insufficient information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }


                        _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + "  insert into  tbl_PlanmonthTemp values ( \r\n";
                        _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + " " + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + ", '" + WPID + "', \r\n";
                        _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + " '" + Dump + "', '" + Dam + "' \r\n ";
                        _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + " , '" + Gun + "', '" + Bench + "', '" + Direction + "', '" + Position + "', '" + Stream + "', '" + Duration + "' \r\n ";
                        _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + " , " + Rate + ",'" + Start + "','" + Finnish + "'," + AU + "," + Tonnes + "," + Kg + "," + KgRec + ") \r\n";


                    }
                }

                _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + "  Exec sp_PlanningInsert '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + "' \r\n ";
                _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + "  --Exec sp_PlanningUpdateCalendardays '" + barYear.EditValue + "' \r\n ";
                _dbManSave7.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManSave7.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManSave7.ExecuteInstruction();


            }

            if (PlanningTabCntrl.SelectedTabPageIndex == 1)
            {

                gcGunHrs.ForceInitialize();
                gvGunHrs2.ClearGrouping();
                gvGunHrs2.Columns["SectionID"].GroupIndex = -1;

                //Check If Midmonth Plan Exists

                //MWDataManager.clsDataAccess _dbManCheck = new MWDataManager.clsDataAccess();
                //_dbManCheck.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                //_dbManCheck.SqlStatement = "select * from tbl_PlanningGun_Midmonth where Prodmonth = " + barYear.EditValue + " and Section = '" + SecCmb.Text + "' ";
                //_dbManCheck.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                //_dbManCheck.queryReturnType = MWDataManager.ReturnType.DataTable;
                //_dbManCheck.ExecuteInstruction();


                MWDataManager.clsDataAccess _dbManSave = new MWDataManager.clsDataAccess();
                _dbManSave.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbManSave.SqlStatement = "";
                for (int row = 0; row < gvGunHrs2.RowCount; row++)
                {

                    string Section = "";
                    string Gun = "";
                    decimal HrsDaily = 0;
                    decimal HrsMonthly = 0;
                    decimal TonnesDaily = 0;
                    decimal TonnesMonthly = 0;

                    Section = gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[0]).ToString();
                    Gun = gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[1]).ToString();
                    HrsDaily = Convert.ToDecimal(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[2]).ToString());
                    HrsMonthly = Convert.ToDecimal(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[3]).ToString());
                    TonnesDaily = Convert.ToDecimal(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[4]).ToString());
                    TonnesMonthly = Convert.ToDecimal(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[5]).ToString());


                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  BEGIN TRY insert into  tbl_PlanningGun values ( \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + " " + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + ", '" + Section + "', \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + " '" + Gun + "', '" + HrsDaily + "' \r\n ";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + " , '" + HrsMonthly + "', '" + TonnesDaily + "', '" + TonnesMonthly + "' \r\n ";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + " ) END TRY \r\n";

                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  BEGIN CATCH update tbl_PlanningGun set \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  HoursDaily = '" + HrsDaily + "', \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  HoursMonthly = '" + HrsMonthly + "', \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  TonnesDaily = '" + TonnesDaily + "', \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  TonnesMonthly = '" + TonnesMonthly + "' \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + " where Prodmonth = " + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + " \r\n ";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + " and Section = '" + Section + "'  \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + " and Gun = '" + Gun + "'  END CATCH\r\n";


                    DateTime StartDate = DateTime.Now;
                    decimal HrsDailyMM = 0;
                    decimal HrsMonthlyMM = 0;
                    decimal TonnesDailyMM = 0;
                    decimal TonnesMonthlyMM = 0;

                    StartDate = Convert.ToDateTime(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[6]).ToString());
                    HrsDailyMM = Convert.ToDecimal(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[7]).ToString());
                    HrsMonthlyMM = Convert.ToDecimal(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[8]).ToString());
                    TonnesDailyMM = Convert.ToDecimal(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[9]).ToString());
                    TonnesMonthlyMM = Convert.ToDecimal(gvGunHrs2.GetRowCellValue(row, gvGunHrs2.Columns[10]).ToString());

                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  BEGIN TRY insert into  tbl_PlanningGun_Midmonth values ( \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + " " + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + ", '" + Section + "', \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + " '" + Gun + "', '" + StartDate + "', '" + HrsDailyMM + "' \r\n ";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + " , '" + HrsMonthlyMM + "', '" + TonnesDailyMM + "', '" + TonnesMonthlyMM + "' \r\n ";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + " ) END TRY \r\n";

                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  BEGIN CATCH update tbl_PlanningGun_Midmonth set \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  StartDate = '" + StartDate + "', \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  HoursDaily = '" + HrsDailyMM + "', \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  HoursMonthly = '" + HrsMonthlyMM + "', \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  TonnesDaily = '" + TonnesDailyMM + "', \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  TonnesMonthly = '" + TonnesMonthlyMM + "' \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + " where Prodmonth = " + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + " \r\n ";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + " and Section = '" + Section + "'  \r\n";
                    _dbManSave.SqlStatement = _dbManSave.SqlStatement + " and Gun = '" + Gun + "'  END CATCH\r\n";
                }
                _dbManSave.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManSave.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManSave.ExecuteInstruction();

                gcGunHrs.ForceInitialize();
                gvGunHrs2.ClearGrouping();
                gvGunHrs2.Columns["SectionID"].GroupIndex = 0;
                gvGunHrs2.Columns["SectionID"].Visible = false;
                gvGunHrs2.ExpandAllGroups();
            }

            if (PlanningTabCntrl.SelectedTabPageIndex == 2)
            {
                gcPlanSced.ForceInitialize();
                gvPlanSched.ClearGrouping();
                gvPlanSched.Columns["SectionID"].GroupIndex = -1;

                MWDataManager.clsDataAccess _getDates = new MWDataManager.clsDataAccess();
                _getDates.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _getDates.SqlStatement = " select min(BeginDate) StartDate, Max(EndDate)EndDate from tbl_Calendar_Days where prodmonth = " + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + " " +
                                         "  \r\n";
                _getDates.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _getDates.queryReturnType = MWDataManager.ReturnType.DataTable;
                _getDates.ExecuteInstruction();

                DateTime startdate = DateTime.Now;
                startdate = Convert.ToDateTime(_getDates.ResultsDataTable.Rows[0][0].ToString());

                MWDataManager.clsDataAccess _dbManSave = new MWDataManager.clsDataAccess();
                _dbManSave.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbManSave.SqlStatement = "";

                for (int row = 0; row < gvPlanSched.RowCount; row++)
                {
                    string Section = "";
                    string WPID = "";
                    string Dump = "";
                    string Dam = "";
                    string Gun = "";
                    string Bench = "";
                    string Direction = "";
                    string Position = "";
                    string Stream = "";


                    Section = barSection.EditValue.ToString();
                    WPID = gvPlanSched.GetRowCellValue(row, gvPlanSched.Columns[1]).ToString();
                    Dam = gvPlanSched.GetRowCellValue(row, gvPlanSched.Columns[2]).ToString();
                    Gun = gvPlanSched.GetRowCellValue(row, gvPlanSched.Columns[3]).ToString();
                    Bench = gvPlanSched.GetRowCellValue(row, gvPlanSched.Columns[4]).ToString();
                    Direction = gvPlanSched.GetRowCellValue(row, gvPlanSched.Columns[5]).ToString();
                    Position = gvPlanSched.GetRowCellValue(row, gvPlanSched.Columns[6]).ToString();
                    Stream = gvPlanSched.GetRowCellValue(row, gvPlanSched.Columns[7]).ToString();


                    for (int col = 12; col <= 46; col++)
                    {
                        string PlanTonnes = gvPlanSched.GetRowCellValue(row, gvPlanSched.Columns[col]).ToString();

                        DateTime thedate = startdate.AddDays(col - 12);

                        if (gvPlanSched.Columns[col].Visible == true)
                        {

                            _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  BEGIN TRY insert into  tbl_Planning values ( \r\n";
                            _dbManSave.SqlStatement = _dbManSave.SqlStatement + " " + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + ",'" + String.Format("{0:yyyy-MM-dd}", thedate) + "', '" + Section + "', \r\n";
                            _dbManSave.SqlStatement = _dbManSave.SqlStatement + " '" + WPID + "', '" + Bench + "' \r\n ";
                            _dbManSave.SqlStatement = _dbManSave.SqlStatement + " , '" + Gun + "', '" + Dam + "', '" + Stream + "', '" + Position + "' \r\n ";
                            _dbManSave.SqlStatement = _dbManSave.SqlStatement + " , '" + PlanTonnes + "') END TRY \r\n";

                            _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  BEGIN CATCH update tbl_Planning set \r\n";
                            _dbManSave.SqlStatement = _dbManSave.SqlStatement + "  Tonnes = '" + PlanTonnes + "' \r\n";
                            _dbManSave.SqlStatement = _dbManSave.SqlStatement + " where Prodmonth = " + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + " and calendardate = '" + String.Format("{0:yyyy-MM-dd}", thedate) + "' \r\n ";
                            _dbManSave.SqlStatement = _dbManSave.SqlStatement + " and Section = '" + Section + "'  \r\n";
                            _dbManSave.SqlStatement = _dbManSave.SqlStatement + " and Workplaceid = '" + WPID + "'  END CATCH\r\n";
                        }
                    }
                }
                _dbManSave.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManSave.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManSave.ExecuteInstruction();


            }


            if (PlanningTabCntrl.SelectedTabPageIndex == 3)
            {
                MWDataManager.clsDataAccess _dbManSaveBudget = new MWDataManager.clsDataAccess();
                _dbManSaveBudget.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbManSaveBudget.SqlStatement = "";
                for (int row = 0; row < gvBudget.RowCount; row++)
                {
                    string Section = "";
                    decimal TonnesJan = 0;
                    decimal kgJan = 0;
                    decimal gtJan = 0;
                    decimal kgPercJan = 0;

                    Section = gvBudget.GetRowCellValue(row, gvBudget.Columns[0]).ToString();
                    TonnesJan = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[1]).ToString());
                    kgJan = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[2]).ToString());
                    gtJan = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[3]).ToString());
                    kgPercJan = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[4]).ToString());

                    string pmJan = Convert.ToString(barYear.EditValue) + "01";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  tbl_PlanningBudget values ( " + barYear.EditValue + ", \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + pmJan + ", '" + Section + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + TonnesJan + ", " + kgJan + ", " + gtJan + ", " + kgPercJan + " ) \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_PlanningBudget set \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Tonnes = '" + TonnesJan + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  kg = '" + kgJan + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  gt = '" + gtJan + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  percKg = '" + kgPercJan + "' \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Prodmonth = " + pmJan + " \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + Section + "'  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and year = " + barYear.EditValue + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";

                    //feb
                    decimal TonnesFeb = 0;
                    decimal kgFeb = 0;
                    decimal gtFeb = 0;
                    decimal kgPercFeb = 0;

                    TonnesFeb = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[5]).ToString());
                    kgFeb = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[6]).ToString());
                    gtFeb = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[7]).ToString());
                    kgPercFeb = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[8]).ToString());

                    string pmFeb = Convert.ToString(barYear.EditValue) + "02";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  tbl_PlanningBudget values (" + barYear.EditValue + ", \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + pmFeb + ", '" + Section + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + TonnesFeb + ", " + kgFeb + ", " + gtFeb + ", " + kgPercFeb + " ) \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_PlanningBudget set \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Tonnes = '" + TonnesFeb + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  kg = '" + kgFeb + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  gt = '" + gtFeb + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  percKg = '" + kgPercFeb + "' \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Prodmonth = " + pmFeb + "\r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + Section + "'  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and year = " + barYear.EditValue + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";


                    //March

                    decimal TonnesMarch = 0;
                    decimal kgMarch = 0;
                    decimal gtMarch = 0;
                    decimal kgPercMarch = 0;

                    TonnesMarch = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[9]).ToString());
                    kgMarch = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[10]).ToString());
                    gtMarch = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[11]).ToString());
                    kgPercMarch = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[12]).ToString());

                    string pmMarch = Convert.ToString(barYear.EditValue) + "03";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  tbl_PlanningBudget values (" + barYear.EditValue + ", \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + pmMarch + ", '" + Section + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + TonnesMarch + ", " + kgMarch + ", " + gtMarch + ", " + kgPercMarch + " ) \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_PlanningBudget set \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Tonnes = '" + TonnesMarch + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  kg = '" + kgMarch + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  gt = '" + gtMarch + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  percKg = '" + kgPercMarch + "' \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Prodmonth = " + pmMarch + "\r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + Section + "'  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and year = " + barYear.EditValue + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";

                    //Apr

                    decimal TonnesApr = 0;
                    decimal kgApr = 0;
                    decimal gtApr = 0;
                    decimal kgPercApr = 0;

                    TonnesApr = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[13]).ToString());
                    kgApr = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[14]).ToString());
                    gtApr = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[15]).ToString());
                    kgPercApr = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[16]).ToString());

                    string pmApr = Convert.ToString(barYear.EditValue) + "04";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  tbl_PlanningBudget values (" + barYear.EditValue + ", \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + pmApr + ", '" + Section + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + TonnesApr + ", " + kgApr + ", " + gtApr + ", " + kgPercApr + " ) \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_PlanningBudget set \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Tonnes = '" + TonnesApr + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  kg = '" + kgApr + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  gt = '" + gtApr + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  percKg = '" + kgPercApr + "' \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Prodmonth = " + pmApr + "\r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + Section + "'  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and year = " + barYear.EditValue + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";


                    //May

                    decimal TonnesMay = 0;
                    decimal kgMay = 0;
                    decimal gtMay = 0;
                    decimal kgPercMay = 0;

                    TonnesMay = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[17]).ToString());
                    kgMay = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[18]).ToString());
                    gtMay = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[19]).ToString());
                    kgPercMay = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[20]).ToString());

                    string pmMay = Convert.ToString(barYear.EditValue) + "05";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  tbl_PlanningBudget values (" + barYear.EditValue + ", \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + pmMay + ", '" + Section + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + TonnesMay + ", " + kgMay + ", " + gtMay + ", " + kgPercMay + " ) \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_PlanningBudget set \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Tonnes = '" + TonnesMay + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  kg = '" + kgMay + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  gt = '" + gtMay + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  percKg = '" + kgPercMay + "' \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Prodmonth = " + pmMay + "\r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + Section + "'  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and year = " + barYear.EditValue + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";


                    //June

                    decimal TonnesJune = 0;
                    decimal kgJune = 0;
                    decimal gtJune = 0;
                    decimal kgPercJune = 0;

                    TonnesJune = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[21]).ToString());
                    kgJune = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[22]).ToString());
                    gtJune = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[23]).ToString());
                    kgPercJune = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[24]).ToString());

                    string pmJune = Convert.ToString(barYear.EditValue) + "06";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  tbl_PlanningBudget values (" + barYear.EditValue + ", \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + pmJune + ", '" + Section + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + TonnesJune + ", " + kgJune + ", " + gtJune + ", " + kgPercJune + " ) \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_PlanningBudget set \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Tonnes = '" + TonnesJune + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  kg = '" + kgJune + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  gt = '" + gtJune + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  percKg = '" + kgPercJune + "' \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Prodmonth = " + pmJune + "\r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + Section + "'  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and year = " + barYear.EditValue + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";


                    //July

                    decimal TonnesJuly = 0;
                    decimal kgJuly = 0;
                    decimal gtJuly = 0;
                    decimal kgPercJuly = 0;

                    TonnesJuly = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[25]).ToString());
                    kgJuly = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[26]).ToString());
                    gtJuly = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[27]).ToString());
                    kgPercJuly = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[28]).ToString());

                    string pmJuly = Convert.ToString(barYear.EditValue) + "07";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  tbl_PlanningBudget values (" + barYear.EditValue + ", \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + pmJuly + ", '" + Section + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + TonnesJuly + ", " + kgJuly + ", " + gtJuly + ", " + kgPercJuly + " ) \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_PlanningBudget set \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Tonnes = '" + TonnesJuly + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  kg = '" + kgJuly + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  gt = '" + gtJuly + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  percKg = '" + kgPercJuly + "' \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Prodmonth = " + pmJuly + "\r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + Section + "'  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and year = " + barYear.EditValue + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";

                    //Aug

                    decimal TonnesAug = 0;
                    decimal kgAug = 0;
                    decimal gtAug = 0;
                    decimal kgPercAug = 0;

                    TonnesAug = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[29]).ToString());
                    kgAug = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[30]).ToString());
                    gtAug = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[31]).ToString());
                    kgPercAug = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[32]).ToString());

                    string pmAug = Convert.ToString(barYear.EditValue) + "08";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  tbl_PlanningBudget values (" + barYear.EditValue + ", \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + pmAug + ", '" + Section + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + TonnesAug + ", " + kgAug + ", " + gtAug + ", " + kgPercAug + " ) \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_PlanningBudget set \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Tonnes = '" + TonnesAug + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  kg = '" + kgAug + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  gt = '" + gtAug + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  percKg = '" + kgPercAug + "' \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Prodmonth = " + pmAug + "\r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + Section + "'  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and year = " + barYear.EditValue + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";

                    //Sept

                    decimal TonnesSept = 0;
                    decimal kgSept = 0;
                    decimal gtSept = 0;
                    decimal kgPercSept = 0;

                    TonnesSept = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[33]).ToString());
                    kgSept = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[34]).ToString());
                    gtSept = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[35]).ToString());
                    kgPercSept = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[36]).ToString());

                    string pmSept = Convert.ToString(barYear.EditValue) + "09";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  tbl_PlanningBudget values (" + barYear.EditValue + ", \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + pmSept + ", '" + Section + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + TonnesSept + ", " + kgSept + ", " + gtSept + ", " + kgPercSept + " ) \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_PlanningBudget set \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Tonnes = '" + TonnesSept + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  kg = '" + kgSept + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  gt = '" + gtSept + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  percKg = '" + kgPercSept + "' \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Prodmonth = " + pmSept + "\r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + Section + "'  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and year = " + barYear.EditValue + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";


                    //Oct

                    decimal TonnesOct = 0;
                    decimal kgOct = 0;
                    decimal gtOct = 0;
                    decimal kgPercOct = 0;

                    TonnesOct = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[37]).ToString());
                    kgOct = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[38]).ToString());
                    gtOct = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[39]).ToString());
                    kgPercOct = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[40]).ToString());

                    string pmOct = Convert.ToString(barYear.EditValue) + "10";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  tbl_PlanningBudget values (" + barYear.EditValue + ", \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + pmOct + ", '" + Section + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + TonnesOct + ", " + kgOct + ", " + gtOct + ", " + kgPercOct + " ) \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_PlanningBudget set \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Tonnes = '" + TonnesOct + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  kg = '" + kgOct + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  gt = '" + gtOct + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  percKg = '" + kgPercOct + "' \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Prodmonth = " + pmOct + "\r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + Section + "'  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and year = " + barYear.EditValue + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";


                    //Nov

                    decimal TonnesNov = 0;
                    decimal kgNov = 0;
                    decimal gtNov = 0;
                    decimal kgPercNov = 0;

                    TonnesNov = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[41]).ToString());
                    kgNov = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[42]).ToString());
                    gtNov = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[43]).ToString());
                    kgPercNov = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[44]).ToString());

                    string pmNov = Convert.ToString(barYear.EditValue) + "11";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  tbl_PlanningBudget values (" + barYear.EditValue + ", \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + pmNov + ", '" + Section + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + TonnesNov + ", " + kgNov + ", " + gtNov + ", " + kgPercNov + " ) \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_PlanningBudget set \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Tonnes = '" + TonnesNov + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  kg = '" + kgNov + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  gt = '" + gtNov + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  percKg = '" + kgPercNov + "' \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Prodmonth = " + pmNov + "\r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + Section + "'  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and year = " + barYear.EditValue + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";

                    //Dec

                    decimal TonnesDec = 0;
                    decimal kgDec = 0;
                    decimal gtDec = 0;
                    decimal kgPercDec = 0;

                    TonnesDec = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[45]).ToString());
                    kgDec = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[46]).ToString());
                    gtDec = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[47]).ToString());
                    kgPercDec = Convert.ToDecimal(gvBudget.GetRowCellValue(row, gvBudget.Columns[48]).ToString());

                    string pmDec = Convert.ToString(barYear.EditValue) + "12";

                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN TRY insert into  tbl_PlanningBudget values (" + barYear.EditValue + ", \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + pmDec + ", '" + Section + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " " + TonnesDec + ", " + kgDec + ", " + gtDec + ", " + kgPercDec + " ) \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END TRY \r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  BEGIN CATCH update tbl_PlanningBudget set \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  Tonnes = '" + TonnesDec + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  kg = '" + kgDec + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  gt = '" + gtDec + "', \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + "  percKg = '" + kgPercDec + "' \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " where Prodmonth = " + pmDec + "\r\n ";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and Section = '" + Section + "'  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " and year = " + barYear.EditValue + "  \r\n";
                    _dbManSaveBudget.SqlStatement = _dbManSaveBudget.SqlStatement + " END CATCH\r\n";
                }
                _dbManSaveBudget.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManSaveBudget.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManSaveBudget.ExecuteInstruction();
            }
            Cursor.Current = Cursors.Default;
            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);

        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (PlanningTabCntrl.SelectedTabPageIndex == 1)
            {
                MWDataManager.clsDataAccess _dbManGunHours = new MWDataManager.clsDataAccess();
                _dbManGunHours.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbManGunHours.SqlStatement = " Select Section, Gun, replace(HoursDaily,'.',':')HoursDaily, replace(HoursMonthly,'.',':')HoursMonthly, TonnesDaily, TonnesMonthly ,HoursDaily HoursDaily2,HoursMonthly HoursMonthly2  from tbl_PlanningGun \r\n" +
                                    " where Prodmonth = " + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + " \r\n";
                _dbManGunHours.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManGunHours.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManGunHours.ExecuteInstruction();


                MWDataManager.clsDataAccess _dbManGunHoursMid = new MWDataManager.clsDataAccess();
                _dbManGunHoursMid.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbManGunHoursMid.SqlStatement = " Select StartDate, Section, Gun, replace(HoursDaily,'.',':')HoursDaily, replace(HoursMonthly,'.',':')HoursMonthly, TonnesDaily, TonnesMonthly ,HoursDaily HoursDaily2,HoursMonthly HoursMonthly2  from tbl_PlanningGun_Midmonth \r\n" +
                                    " where Prodmonth = " + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(barProdMonth.EditValue)).ToString() + " \r\n";
                _dbManGunHoursMid.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManGunHoursMid.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManGunHoursMid.ExecuteInstruction();

                DataTable dtReport1 = _dbManGunHours.ResultsDataTable;
                DataSet ds = new DataSet();
                ds.Tables.Add(dtReport1);

                DataTable dtReport2 = _dbManGunHoursMid.ResultsDataTable;

                ds.Tables.Add(dtReport2);

                theReport.RegisterData(ds);

                theReport.Load("PlanningReportGunHours.frx");
                theReport.SetParameterValue("Prodmonth", barYear.EditValue);
                //theReport.Design();
                theReport.Prepare();
                theReport.Report.Show();
            }
            if (PlanningTabCntrl.SelectedTabPageIndex == 2)
            {
                MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
                _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbMan.SqlStatement = "declare @start datetime;    \r\n" +
                                      "set @start = (select MIN(calendardate) from [dbo].[tbl_Planning] where Prodmonth = " + barYear.EditValue + ")  \r\n" +
                                      "select workplaceid, gun, SECTION, Dam,Bench, Postion,Stream  , @start startdate,    \r\n" +
                                      "SUM(day1)day1, SUM(day2) day2, SUM(day3) day3, SUM(day4) Day4, SUM(day5) day5,   \r\n" +
                                      "SUM(day6) day6, SUM(day7) day7, SUM(day8) day8, SUM(day9) day9, SUM(day10) day10,   \r\n" +
                                      "SUM(day11) day11, SUM(day12) day12, SUM(day13) day13, SUM(day14) Day14, SUM(day15) day15,  \r\n" +
                                      "SUM(day16) day16, SUM(day17) day17, SUM(day18) day18, SUM(day19) day19, SUM(day20) day20,  \r\n" +
                                      "SUM(day21) day21, SUM(day22) day22, SUM(day23) day23, SUM(day24) Day24, SUM(day25) day25,  \r\n" +
                                      "SUM(day26) day26, SUM(day27) day27, SUM(day28) day28, SUM(day29) day29, SUM(day30) day30,  \r\n" +
                                      "SUM(day31) day31, SUM(day32) day32, SUM(day33) day33, SUM(day34) Day34, SUM(day35) day35,  \r\n" +
                                      "SUM(day36) day36, SUM(day37) day37, SUM(day38) day38, SUM(day39) day39, SUM(day40) day40, sum(convert(numeric(18,5),tons)) totalTons    \r\n" +
                                      "from(SELECT *,case when Tonnes = '' then 0 else tonnes end AS tons,       \r\n" +
                                      "case when Calendardate = @start then Tonnes else 0 end as day1,  \r\n" +
                                      "case when Calendardate = @start + 1 then Tonnes else 0 end as day2,  \r\n" +
                                      "case when Calendardate = @start + 2 then Tonnes else 0 end as day3,  \r\n" +
                                      "case when Calendardate = @start + 3 then Tonnes else 0 end as day4,  \r\n" +
                                      "case when Calendardate = @start + 4 then Tonnes else 0 end as day5,  \r\n" +
                                      "case when Calendardate = @start + 5 then Tonnes else 0 end as day6,  \r\n" +
                                      "case when Calendardate = @start + 6 then Tonnes else 0 end as day7,  \r\n" +
                                      "case when Calendardate = @start + 7 then Tonnes else 0 end as day8,  \r\n" +
                                      "case when Calendardate = @start + 8 then Tonnes else 0 end as day9,  \r\n" +
                                      "case when Calendardate = @start + 9 then Tonnes else 0 end as day10,  \r\n" +
                                      "case when Calendardate = @start + 10 then Tonnes else 0 end as day11,  \r\n" +
                                      "case when Calendardate = @start + 11 then Tonnes else 0 end as day12,  \r\n" +
                                      "case when Calendardate = @start + 12 then Tonnes else 0 end as day13,  \r\n" +
                                      "case when Calendardate = @start + 13 then Tonnes else 0 end as day14,  \r\n" +
                                      "case when Calendardate = @start + 14 then Tonnes else 0 end as day15,  \r\n" +
                                      "case when Calendardate = @start + 15 then Tonnes else 0 end as day16,  \r\n" +
                                      "case when Calendardate = @start + 16 then Tonnes else 0 end as day17,  \r\n" +
                                      "case when Calendardate = @start + 17 then Tonnes else 0 end as day18,  \r\n" +
                                      "case when Calendardate = @start + 18 then Tonnes else 0 end as day19,  \r\n" +
                                      "case when Calendardate = @start + 19 then Tonnes else 0 end as day20,  \r\n" +
                                      "case when Calendardate = @start + 20 then Tonnes else 0 end as day21,  \r\n" +
                                      "case when Calendardate = @start + 21 then Tonnes else 0 end as day22,  \r\n" +
                                      "case when Calendardate = @start + 22 then Tonnes else 0 end as day23,  \r\n" +
                                      "case when Calendardate = @start + 23 then Tonnes else 0 end as day24,  \r\n" +
                                      "case when Calendardate = @start + 24 then Tonnes else 0 end as day25,  \r\n" +
                                      "case when Calendardate = @start + 25 then Tonnes else 0 end as day26,  \r\n" +
                                      "case when Calendardate = @start + 26 then Tonnes else 0 end as day27,  \r\n" +
                                      "case when Calendardate = @start + 27 then Tonnes else 0 end as day28,  \r\n" +
                                      "case when Calendardate = @start + 28 then Tonnes else 0 end as day29,  \r\n" +
                                      "case when Calendardate = @start + 29 then Tonnes else 0 end as day30,  \r\n" +
                                      "case when Calendardate = @start + 30 then Tonnes else 0 end as day31,  \r\n" +
                                      "case when Calendardate = @start + 31 then Tonnes else 0 end as day32,  \r\n" +
                                      "case when Calendardate = @start + 32 then Tonnes else 0 end as day33,  \r\n" +
                                      "case when Calendardate = @start + 33 then Tonnes else 0 end as day34,  \r\n" +
                                      "case when Calendardate = @start + 34 then Tonnes else 0 end as day35,  \r\n" +
                                      "case when Calendardate = @start + 35 then Tonnes else 0 end as day36,  \r\n" +
                                      "case when Calendardate = @start + 36 then Tonnes else 0 end as day37,  \r\n" +
                                      "case when Calendardate = @start + 37 then Tonnes else 0 end as day38,  \r\n" +
                                      "case when Calendardate = @start + 38 then Tonnes else 0 end as day39,  \r\n" +
                                      "case when Calendardate = @start + 39 then Tonnes else 0 end as day40   \r\n" +
                                      " FROM [dbo].[tbl_Planning]  WHERE SECTION = '" + barSection.EditValue + "' AND Prodmonth = " + barYear.EditValue + ") a group by workplaceid, gun, SECTION,Dam,Bench,Postion,stream ";
                _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan.ExecuteInstruction();
                DataTable dtReport = _dbMan.ResultsDataTable;
                decimal TotalTons = 0;
                foreach (DataRow dr in dtReport.Rows)
                {
                    TotalTons = TotalTons + Convert.ToDecimal(dr["totalTons"]);
                }
                MWDataManager.clsDataAccess _dbMantons = new MWDataManager.clsDataAccess();
                _dbMantons.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbMantons.SqlStatement = "     " +
                                        " select a.*, b.plantonnes from ( \r\n" +
                                        " Select Section, Tonnes budgetTonnes \r\n" +
                                        " from tbl_PlanningBudget \r\n" +
                                        " Where Prodmonth = '" + barYear.EditValue + "' \r\n" +
                                        " and SECTION = '" + barSection.EditValue + "' )a \r\n" +
                                        " left outer join( \r\n" +
                                        " select Section, sum(TonnesMonthly)plantonnes  from tbl_PlanningGun \r\n" +
                                        " Where Prodmonth = '" + barYear.EditValue + "' \r\n" +
                                        " and SECTION = '" + barSection.EditValue + "' \r\n" +
                                        " group by Section )b \r\n" +
                                        " on a.Section = b.Section \r\n";

                _dbMantons.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMantons.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMantons.ResultsTableName = "Budget";
                _dbMantons.ExecuteInstruction();

                DataTable dtReport1 = _dbMantons.ResultsDataTable;
                DataSet ds = new DataSet();
                ds.Tables.Add(dtReport);
                DataSet ds1 = new DataSet();
                ds1.Tables.Add(dtReport1);

                theReport.RegisterData(ds);
                theReport.RegisterData(ds1);
                theReport.Load("PlanningReport.frx");
                theReport.SetParameterValue("Prodmonth", barYear.EditValue);
                //theReport.Design();
                theReport.Prepare();
                theReport.Report.Show();
            }

        }

        private void barProdMonth_EditValueChanged(object sender, EventArgs e)
        {
            LoadSec();
        }
    }
}
