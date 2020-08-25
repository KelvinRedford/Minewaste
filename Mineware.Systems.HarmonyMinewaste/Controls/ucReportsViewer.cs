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
using FastReport;
using Mineware.Systems.Global;
using Mineware.Systems.GlobalConnect;
using Mineware.Systems.MinewasteGlobal;

namespace Mineware.Systems.Minewaste.Controls
{
    public partial class ucReportsViewer : ucBaseUserControl
    {
        Report theReport = new Report();
        Report theReport5 = new Report();
        Report theReport55 = new Report();
        Report theReport6 = new Report();
        Mineware.Systems.Minewaste.GlobalItems procs = new Mineware.Systems.Minewaste.GlobalItems();

        string ReportName = "";
        public ucReportsViewer(string reportName)
        {
            InitializeComponent();
            ReportName = reportName;
        }


        //string Gun = "";
        string Section = "";

        private void Application_Idle(object sender, EventArgs e)
        {
            
            
            Section = editSection.EditValue.ToString();
            

            if (theReport6.GetParameterValue("Gun") != null)
            {
                GunLbl.Text = theReport6.GetParameterValue("Gun").ToString();
            }

        }

        private void AddBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ReportName == "Planning Report Gun Hours")
            {
                MWDataManager.clsDataAccess _dbManGunHours = new MWDataManager.clsDataAccess();
                _dbManGunHours.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbManGunHours.SqlStatement = " Select Section, Gun, replace(HoursDaily,'.',':')HoursDaily, replace(HoursMonthly,'.',':')HoursMonthly, TonnesDaily, TonnesMonthly ,HoursDaily HoursDaily2,HoursMonthly HoursMonthly2  from tbl_PlanningGun \r\n" +
                                    " where Prodmonth = " + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + " \r\n" ;
                _dbManGunHours.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManGunHours.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManGunHours.ExecuteInstruction();



                MWDataManager.clsDataAccess _dbManGunHoursMid = new MWDataManager.clsDataAccess();
                _dbManGunHoursMid.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbManGunHoursMid.SqlStatement = " Select StartDate, Section, Gun, replace(HoursDaily,'.',':')HoursDaily, replace(HoursMonthly,'.',':')HoursMonthly, TonnesDaily, TonnesMonthly ,HoursDaily HoursDaily2,HoursMonthly HoursMonthly2  from tbl_PlanningGun_Midmonth \r\n" +
                                    " where Prodmonth = " + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + " \r\n" ;
                _dbManGunHoursMid.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManGunHoursMid.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManGunHoursMid.ExecuteInstruction();

                DataTable dtReport1 = _dbManGunHours.ResultsDataTable;
                DataSet ds = new DataSet();
                ds.Tables.Add(dtReport1);

                DataTable dtReport2 = _dbManGunHoursMid.ResultsDataTable;
                // DataSet ds = new DataSet();

                ds.Tables.Add(dtReport2);


                theReport.RegisterData(ds);
                theReport.Load(TGlobalItems.ReportsFolder + "\\PlanningReportGunHours.frx");
                //theReport.Load("PlanningReportGunHours.frx");
                theReport.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());
                //theReport.Design();
           

                RepPC.Clear();
                theReport.Prepare();
                theReport.Preview = RepPC;

                theReport.ShowPrepared();
            }

            if (ReportName == "Running Hours per Shift")
            {
                if (string.IsNullOrEmpty(editSection.EditValue.ToString()))
                {
                    MessageBox.Show("Please Select a section");

                    return;
                }

                if (editSection.EditValue.ToString() == "Total Mine Waste")
                {
                    return;
                }

                ///Get Guns                
                MWDataManager.clsDataAccess _dbMan4 = new MWDataManager.clsDataAccess();
                _dbMan4.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbMan4.SqlStatement = " select distinct gun from tbl_Planmonth \r\n  " +
                                      "  where prodmonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "'  \r\n  " +
                                      " and SectionID = '" + editSection.EditValue.ToString() + "'  ";
                _dbMan4.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan4.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan4.ExecuteInstruction();

                string gun1 = "";
                string gun2 = "";
                string gun3 = "";
                string gun4 = "";
                string gun5 = "";

                try { gun1 = _dbMan4.ResultsDataTable.Rows[0][0].ToString(); }
                catch { gun1 = ""; }

                try { gun2 = _dbMan4.ResultsDataTable.Rows[1][0].ToString(); }
                catch { gun2 = ""; }

                try { gun3 = _dbMan4.ResultsDataTable.Rows[2][0].ToString(); }
                catch { gun3 = ""; }

                try { gun4 = _dbMan4.ResultsDataTable.Rows[3][0].ToString(); }
                catch { gun4 = ""; }

                try { gun5 = _dbMan4.ResultsDataTable.Rows[4][0].ToString(); }
                catch { gun5 = ""; }


               //D/Shift

                MWDataManager.clsDataAccess _dbManBreak = new MWDataManager.clsDataAccess();
                _dbManBreak.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbManBreak.SqlStatement = " exec [sp_BookingsMonthlyShift] '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ,'" + editSection.EditValue.ToString() + "' ";

                _dbManBreak.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManBreak.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManBreak.ResultsTableName = "MainGraphs";
                _dbManBreak.ExecuteInstruction();

                DataTable dta = _dbManBreak.ResultsDataTable;


                //Progressive

                MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();
                _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbMan3.SqlStatement = "  \r\n  ";

                string Section = "";
                DateTime Calendardate = DateTime.Now;
                string calendardate2 = "";
                string Gun = "";
                string Shift = "";

                decimal planhrsDS = 0;
                decimal planhrsProgDS = 0;

                decimal planhrsAS = 0;
                decimal planhrsProgAS = 0;

                decimal planhrsNS = 0;
                decimal planhrsProgNS = 0;

                decimal bookhrsDS = 0;
                decimal bookhrsProgDS = 0;

                decimal bookhrsAS = 0;
                decimal bookhrsProgAS = 0;

                decimal bookhrsNS = 0;
                decimal bookhrsProgNS = 0;



                string Problem = "";

                int x = 0;
                int y = dta.Rows.Count - 2;
                foreach (DataRow dr in dta.Rows)
                {

                    Section = dr["Section"].ToString();

                    if (Gun != dr["Gun"].ToString())
                    {
                        planhrsProgDS = 0;
                        bookhrsProgDS = 0;

                        planhrsProgAS = 0;
                        bookhrsProgAS = 0;

                        planhrsProgNS = 0;
                        bookhrsProgNS = 0;
                    }

                    Gun = dr["Gun"].ToString();

                    Calendardate = Convert.ToDateTime(dr["Calendardate"].ToString());

                    calendardate2 = Convert.ToString(Calendardate).Substring(0, 10);

                    //Shift = dr["Shift"].ToString();

                   // Problem = dr["Problem"].ToString();

                    planhrsDS = Convert.ToDecimal(dr["plands"].ToString())/3;
                    planhrsProgDS = planhrsProgDS + planhrsDS;

                    planhrsAS = Convert.ToDecimal(dr["planas"].ToString()) / 3;
                    planhrsProgAS = planhrsProgAS + planhrsAS;

                    planhrsNS = Convert.ToDecimal(dr["planns"].ToString()) / 3;
                    planhrsProgNS = planhrsProgNS + planhrsNS;

                    bookhrsDS = Convert.ToDecimal(dr["bookds"].ToString());
                    bookhrsProgDS = bookhrsProgDS + Convert.ToDecimal(dr["bookds"].ToString());

                    bookhrsAS = Convert.ToDecimal(dr["bookas"].ToString());
                    bookhrsProgAS = bookhrsProgAS + Convert.ToDecimal(dr["bookas"].ToString());

                    bookhrsNS = Convert.ToDecimal(dr["bookns"].ToString());
                    bookhrsProgNS = bookhrsProgNS + Convert.ToDecimal(dr["bookns"].ToString());

                    //PlanTonnes = Convert.ToInt32(dr["PlanTonnes"].ToString());
                    //planTonnesProg = planTonnesProg + Convert.ToInt32(dr["PlanTonnes"].ToString());

                    //BookTonnes = Convert.ToInt32(dr["BookTonnes"].ToString());
                    //BookTonnesProg = BookTonnesProg + Convert.ToInt32(dr["BookTonnes"].ToString());

                    _dbMan3.SqlStatement = _dbMan3.SqlStatement + " select '" + x + "' order1, '" + calendardate2 + "' Calendardate, '" + Section + "' Section,'" + Gun + "' Gun, '" + planhrsDS + "' hr,'" + planhrsAS + "' hras,'" + planhrsNS + "' hrns, '" + planhrsProgDS + "' hrprog,'" + planhrsProgAS + "' hrprogas,'" + planhrsProgNS + "' hrprogns,'" + bookhrsDS + "' bookhr ,'" + bookhrsAS + "' bookhras ,'" + bookhrsNS + "' bookhrns ,'" + bookhrsProgDS + "' bookhrprog ,'" + bookhrsProgAS + "' bookhrprogas,'" + bookhrsProgNS + "' bookhrprogns  ";
                    if (x <= y)
                    {
                        _dbMan3.SqlStatement = _dbMan3.SqlStatement + "union all ";
                    }

                    x = x + 1;

                }

                _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan3.ExecuteInstruction();



               


                DataSet repDataSet = new DataSet();
                repDataSet.Tables.Add(_dbManBreak.ResultsDataTable);
                repDataSet.Tables.Add(_dbMan3.ResultsDataTable);
                //repDataSet.Tables.Add(_dbMan3AS.ResultsDataTable);




                theReport6.RegisterData(repDataSet);

                theReport6.Load(TGlobalItems.ReportsFolder + "ChartGunShift.frx");
                theReport6.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());
                theReport6.SetParameterValue("Section", editSection.EditValue.ToString());


                theReport6.SetParameterValue("Gun1", gun1);
                theReport6.SetParameterValue("Gun2", gun2);
                theReport6.SetParameterValue("Gun3", gun3);
                theReport6.SetParameterValue("Gun4", gun4);
                theReport6.SetParameterValue("Gun5", gun5);

                //theReport6.Design();

                RepPC.Clear();
                theReport6.Prepare();
                theReport6.Preview = RepPC;

                theReport6.ShowPrepared();
            }

            if (ReportName == "Running Hours Downtime")
            {
                if (editSection.EditValue.ToString() == "Total Mine Waste")
                {
                    if (string.IsNullOrEmpty(editSection.EditValue.ToString()))
                    {
                        MessageBox.Show("Please Select a section");

                        return;
                    }


                    string Section = editSection.EditValue.ToString();

                    string prodmonth = TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString();

                    MWDataManager.clsDataAccess _dbManBreak = new MWDataManager.clsDataAccess();
                    _dbManBreak.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                    _dbManBreak.SqlStatement = " exec [sp_MainCategoriesGenReportTot] '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ,'" + editSection.EditValue.ToString() + "' ";

                    _dbManBreak.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                    _dbManBreak.queryReturnType = MWDataManager.ReturnType.DataTable;
                    _dbManBreak.ResultsTableName = "MainCategories";
                    _dbManBreak.ExecuteInstruction();



                    DataTable dta = _dbManBreak.ResultsDataTable;


                    MWDataManager.clsDataAccess _dbManBreak2 = new MWDataManager.clsDataAccess();

                    _dbManBreak2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                    _dbManBreak2.SqlStatement = " exec [sp_MainCategoriesChartGenTot] '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ,'" + editSection.EditValue.ToString() + "' ";
                    _dbManBreak2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                    _dbManBreak2.queryReturnType = MWDataManager.ReturnType.DataTable;
                    _dbManBreak2.ResultsTableName = "MainCategoriesChart";
                    _dbManBreak2.ExecuteInstruction();

                    DataTable dta2 = _dbManBreak2.ResultsDataTable;

                    DataSet DSa = new DataSet();

                    DSa.Tables.Add(dta);
                    DSa.Tables.Add(dta2);


                    MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();
                    _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                    _dbMan3.SqlStatement = " exec sp_BreakdownCategoriesGenTot '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ";
                    _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                    _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;
                    _dbMan3.ResultsTableName = "Breakdown";
                    _dbMan3.ExecuteInstruction();

                    DataTable dt = _dbMan3.ResultsDataTable;

                    MWDataManager.clsDataAccess _dbMan33 = new MWDataManager.clsDataAccess();
                    _dbMan33.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                    _dbMan33.SqlStatement = " exec sp_BreakdownCategoriesChartGenTot '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ";

                    _dbMan33.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                    _dbMan33.queryReturnType = MWDataManager.ReturnType.DataTable;
                    _dbMan33.ResultsTableName = "BreakdownChart";
                    _dbMan33.ExecuteInstruction();


                    DataTable dt33 = _dbMan33.ResultsDataTable;

                    //get totals

                    MWDataManager.clsDataAccess _dbMan334 = new MWDataManager.clsDataAccess();
                    _dbMan334.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                    _dbMan334.SqlStatement = " exec [sp_MainCategoriesGenReportTotBottom2] '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ";

                    _dbMan334.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                    _dbMan334.queryReturnType = MWDataManager.ReturnType.DataTable;
                    _dbMan334.ResultsTableName = "BreakdownChartTotBottom";
                    _dbMan334.ExecuteInstruction();


                    DataTable dt334 = _dbMan334.ResultsDataTable;



                    MWDataManager.clsDataAccess _dbMan3344 = new MWDataManager.clsDataAccess();
                    _dbMan3344.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                    _dbMan3344.SqlStatement = " exec [sp_BreakdownCategoriesGenTotBottom2] '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ";

                    _dbMan3344.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                    _dbMan3344.queryReturnType = MWDataManager.ReturnType.DataTable;
                    _dbMan3344.ResultsTableName = "TotBottom";
                    _dbMan3344.ExecuteInstruction();


                    DataTable dt3344 = _dbMan3344.ResultsDataTable;

                    DataSet DS = new DataSet();

                    DS.Tables.Add(dt);
                    DS.Tables.Add(dt33);
                    DS.Tables.Add(dt334);
                    DS.Tables.Add(dt3344);


                    theReport55.RegisterData(DS);
                    theReport55.RegisterData(DSa);

                    theReport55.Load(TGlobalItems.ReportsFolder + "ProblemsReport2.frx");
                    theReport55.SetParameterValue("Section", editSection.EditValue.ToString());
                    theReport55.SetParameterValue("Section2", editSection.EditValue.ToString());
                    theReport55.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());

                    //theReport55.Design();

                    RepPC.Clear();
                    theReport55.Prepare();
                    theReport55.Preview = RepPC;
                    theReport55.ShowPrepared();

                }
                else
                {

                    if (editFilterBy.EditValue.ToString() == "1")
                    {
                        EditImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        if (string.IsNullOrEmpty(editSection.EditValue.ToString()))
                        {
                            MessageBox.Show("Please Select a section");

                            return;
                        }


                        if (string.IsNullOrEmpty(editGun.EditValue.ToString()))
                        {
                            MessageBox.Show("Please Select a gun");
                            return;
                        }

                        MWDataManager.clsDataAccess _dbManBreak = new MWDataManager.clsDataAccess();
                        _dbManBreak.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbManBreak.SqlStatement = " exec [sp_MainCategoriesGenReportGun] '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ,'" + editSection.EditValue.ToString() + "','" + editGun.EditValue + "' ";

                        _dbManBreak.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbManBreak.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbManBreak.ResultsTableName = "MainCategories";
                        _dbManBreak.ExecuteInstruction();


                        DataTable dta = _dbManBreak.ResultsDataTable;


                        MWDataManager.clsDataAccess _dbManBreak2 = new MWDataManager.clsDataAccess();

                        _dbManBreak2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbManBreak2.SqlStatement = " exec [sp_MainCategoriesChartGenGun] '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ,'" + editSection.EditValue.ToString() + "' ,'" + editGun.EditValue + "' ";
                        _dbManBreak2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                        _dbManBreak2.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbManBreak2.ResultsTableName = "MainCategoriesChart";
                        _dbManBreak2.ExecuteInstruction();

                        DataTable dta2 = _dbManBreak2.ResultsDataTable;

                        DataSet DSa = new DataSet();

                        DSa.Tables.Add(dta);
                        DSa.Tables.Add(dta2);

                        MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();
                        _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan3.SqlStatement = " exec [sp_BreakdownCategoriesGenGun] '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ,'" + editGun.EditValue + "' ";
                        _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan3.ResultsTableName = "Breakdown";
                        _dbMan3.ExecuteInstruction();

                        DataTable dt = _dbMan3.ResultsDataTable;


                        MWDataManager.clsDataAccess _dbMan33 = new MWDataManager.clsDataAccess();
                        _dbMan33.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan33.SqlStatement = " exec sp_BreakdownCategoriesChartGenGun '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ,'" + editGun.EditValue + "' ";

                        _dbMan33.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan33.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan33.ResultsTableName = "BreakdownChart";
                        _dbMan33.ExecuteInstruction();


                        DataTable dt33 = _dbMan33.ResultsDataTable;

                        //get totals

                        MWDataManager.clsDataAccess _dbMan334 = new MWDataManager.clsDataAccess();
                        _dbMan334.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan334.SqlStatement = " exec [sp_MainCategoriesGenReportTotBottomGun] '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "'  ,'" + editGun.EditValue + "' ";

                        _dbMan334.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan334.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan334.ResultsTableName = "BreakdownChartTotBottom";
                        _dbMan334.ExecuteInstruction();


                        DataTable dt334 = _dbMan334.ResultsDataTable;

                        MWDataManager.clsDataAccess _dbMan3344 = new MWDataManager.clsDataAccess();
                        _dbMan3344.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan3344.SqlStatement = " exec [sp_BreakdownCategoriesGenTotBottomGun] '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ,'" + editGun.EditValue + "'  ";

                        _dbMan3344.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan3344.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan3344.ResultsTableName = "TotBottom";
                        _dbMan3344.ExecuteInstruction();


                        DataTable dt3344 = _dbMan3344.ResultsDataTable;

                        DataSet DS = new DataSet();

                        DS.Tables.Add(dt);
                        DS.Tables.Add(dt33);
                        DS.Tables.Add(dt334);
                        DS.Tables.Add(dt3344);


                        if (dt.Rows.Count > 0)
                        {
                            theReport5.RegisterData(DS);
                            theReport5.RegisterData(DSa);

                            theReport5.Load(TGlobalItems.ReportsFolder + "ProblemsReport.frx");
                            theReport5.SetParameterValue("Section", editSection.EditValue.ToString());
                            theReport5.SetParameterValue("Section2", editSection.EditValue.ToString() + " " + editGun.EditValue);
                            theReport5.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());

                            //theReport5.Design();

                            RepPC.Clear();
                            theReport5.Prepare();
                            theReport5.Preview = RepPC;
                            theReport5.ShowPrepared();

                        }
                    }
                    else
                    {
                        FilterRG.Visible = false;
                        EditImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        if (string.IsNullOrEmpty(editSection.EditValue.ToString()))
                        {
                            MessageBox.Show("Please Select a section");

                            return;
                        }


                        string Section = editSection.EditValue.ToString();

                        string prodmonth = TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString();

                        MWDataManager.clsDataAccess _dbManBreak = new MWDataManager.clsDataAccess();
                        _dbManBreak.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbManBreak.SqlStatement = " exec [sp_MainCategoriesGenReport] '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ,'" + editSection.EditValue.ToString() + "' ";

                        _dbManBreak.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbManBreak.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbManBreak.ResultsTableName = "MainCategories";
                        _dbManBreak.ExecuteInstruction();



                        DataTable dta = _dbManBreak.ResultsDataTable;


                        MWDataManager.clsDataAccess _dbManBreak2 = new MWDataManager.clsDataAccess();

                        _dbManBreak2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbManBreak2.SqlStatement = " exec [sp_MainCategoriesChartGen] '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ,'" + editSection.EditValue.ToString() + "' ";
                        _dbManBreak2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                        _dbManBreak2.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbManBreak2.ResultsTableName = "MainCategoriesChart";
                        _dbManBreak2.ExecuteInstruction();

                        DataTable dta2 = _dbManBreak2.ResultsDataTable;

                        DataSet DSa = new DataSet();

                        DSa.Tables.Add(dta);
                        DSa.Tables.Add(dta2);


                        MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();
                        _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan3.SqlStatement = " exec sp_BreakdownCategoriesGen '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ";
                        _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan3.ResultsTableName = "Breakdown";
                        _dbMan3.ExecuteInstruction();

                        DataTable dt = _dbMan3.ResultsDataTable;

                        MWDataManager.clsDataAccess _dbMan33 = new MWDataManager.clsDataAccess();
                        _dbMan33.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan33.SqlStatement = " exec sp_BreakdownCategoriesChartGen '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ";

                        _dbMan33.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan33.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan33.ResultsTableName = "BreakdownChart";
                        _dbMan33.ExecuteInstruction();


                        DataTable dt33 = _dbMan33.ResultsDataTable;

                        //get totals

                        MWDataManager.clsDataAccess _dbMan334 = new MWDataManager.clsDataAccess();
                        _dbMan334.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan334.SqlStatement = " exec [sp_MainCategoriesGenReportTotBottom] '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ";

                        _dbMan334.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan334.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan334.ResultsTableName = "BreakdownChartTotBottom";
                        _dbMan334.ExecuteInstruction();


                        DataTable dt334 = _dbMan334.ResultsDataTable;



                        MWDataManager.clsDataAccess _dbMan3344 = new MWDataManager.clsDataAccess();
                        _dbMan3344.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan3344.SqlStatement = " exec [sp_BreakdownCategoriesGenTotBottom] '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ";

                        _dbMan3344.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan3344.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan3344.ResultsTableName = "TotBottom";
                        _dbMan3344.ExecuteInstruction();


                        DataTable dt3344 = _dbMan3344.ResultsDataTable;

                        DataSet DS = new DataSet();

                        DS.Tables.Add(dt);
                        DS.Tables.Add(dt33);
                        DS.Tables.Add(dt334);
                        DS.Tables.Add(dt3344);


                        if (dt.Rows.Count > 0)
                        {
                            theReport5.RegisterData(DS);
                            theReport5.RegisterData(DSa);

                            theReport5.Load(TGlobalItems.ReportsFolder + "ProblemsReport.frx");
                            theReport5.SetParameterValue("Section", editSection.EditValue.ToString());
                            theReport5.SetParameterValue("Section2", editSection.EditValue.ToString());
                            theReport5.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());

                            //theReport5.Design();

                            RepPC.Clear();
                            theReport5.Prepare();
                            theReport5.Preview = RepPC;
                            theReport5.ShowPrepared();

                        }
                    }
                }


            }


            if (ReportName == "Tonnes Re-Mined")
            {

                DataSet repDataSet = new DataSet();
                string prodmonth = TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString();

                MWDataManager.clsDataAccess _dbManBreak = new MWDataManager.clsDataAccess();

                _dbManBreak.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

                _dbManBreak.SqlStatement = " exec [sp_BookTonnesReport] '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "'  ";

                _dbManBreak.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                _dbManBreak.queryReturnType = MWDataManager.ReturnType.DataTable;

                _dbManBreak.ResultsTableName = "Tonnes";
                _dbManBreak.ExecuteInstruction();


                repDataSet.Tables.Add(_dbManBreak.ResultsDataTable);


                theReport6.RegisterData(repDataSet);

                theReport6.Load(TGlobalItems.ReportsFolder + "BookCompReportTonnesTotMine.frx");
                theReport6.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());
                //theReport6.SetParameterValue("Section", editSection.EditValue.ToString());



                //theReport6.Design();

                RepPC.Clear();
                theReport6.Prepare();
                theReport6.Preview = RepPC;

                theReport6.ShowPrepared();
            }

            if (ReportName == "Pump Station Downtime")
            {

                if (editSection.EditValue.ToString() == "Total Mine Waste")
                {
                    FilterRG.Visible = false;
                    EditImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    if (string.IsNullOrEmpty(editSection.EditValue.ToString()))
                    {
                        MessageBox.Show("Please Select a section");

                        return;
                    }


                    string Section = editSection.EditValue.ToString();

                    string prodmonth = TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString();

                    MWDataManager.clsDataAccess _dbManBreak = new MWDataManager.clsDataAccess();

                    _dbManBreak.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

                    _dbManBreak.SqlStatement = " exec [sp_MainCategoriesTot] '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ,'" + editSection.EditValue.ToString() + "' ";

                    _dbManBreak.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                    _dbManBreak.queryReturnType = MWDataManager.ReturnType.DataTable;

                    _dbManBreak.ResultsTableName = "MainCategories";
                    _dbManBreak.ExecuteInstruction();



                    DataTable dta = _dbManBreak.ResultsDataTable;



                    MWDataManager.clsDataAccess _dbManBreak2 = new MWDataManager.clsDataAccess();

                    _dbManBreak2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

                    _dbManBreak2.SqlStatement = " exec [sp_MainCategoriesChartTot] '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ,'" + editSection.EditValue.ToString() + "' ";

                    _dbManBreak2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                    _dbManBreak2.queryReturnType = MWDataManager.ReturnType.DataTable;

                    _dbManBreak2.ResultsTableName = "MainCategoriesChart";
                    _dbManBreak2.ExecuteInstruction();


                    DataTable dta2 = _dbManBreak2.ResultsDataTable;

                    DataSet DSa = new DataSet();



                    DSa.Tables.Add(dta);
                    DSa.Tables.Add(dta2);


                    MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();

                    _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

                    _dbMan3.SqlStatement = " exec sp_BreakdownCategoriesTot '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ";

                    _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                    _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;

                    _dbMan3.ResultsTableName = "Breakdown";



                    _dbMan3.ExecuteInstruction();


                    DataTable dt = _dbMan3.ResultsDataTable;


                    MWDataManager.clsDataAccess _dbMan33 = new MWDataManager.clsDataAccess();

                    _dbMan33.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

                    _dbMan33.SqlStatement = " exec sp_BreakdownCategoriesChartTot '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ";

                    _dbMan33.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                    _dbMan33.queryReturnType = MWDataManager.ReturnType.DataTable;

                    _dbMan33.ResultsTableName = "BreakdownChart";



                    _dbMan33.ExecuteInstruction();


                    DataTable dt33 = _dbMan33.ResultsDataTable;



                    MWDataManager.clsDataAccess _dbMan3334 = new MWDataManager.clsDataAccess();

                    _dbMan3334.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

                    _dbMan3334.SqlStatement = " exec sp_MainCategoriesTotBottom '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "', '" + editSection.EditValue.ToString() + "'   ";

                    _dbMan3334.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                    _dbMan3334.queryReturnType = MWDataManager.ReturnType.DataTable;

                    _dbMan3334.ResultsTableName = "MainCatTotBottom";

                    _dbMan3334.ExecuteInstruction();


                    DataTable dt3334 = _dbMan3334.ResultsDataTable;



                    MWDataManager.clsDataAccess _dbMan33341 = new MWDataManager.clsDataAccess();

                    _dbMan33341.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

                    _dbMan33341.SqlStatement = " exec sp_BreakdownCategoriesTotBottom '" + editSection.EditValue.ToString() + "', '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "'    ";

                    _dbMan33341.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                    _dbMan33341.queryReturnType = MWDataManager.ReturnType.DataTable;

                    _dbMan33341.ResultsTableName = "TotBottom";



                    _dbMan33341.ExecuteInstruction();


                    DataTable dt33341 = _dbMan33341.ResultsDataTable;

                    DataSet DS = new DataSet();



                    DS.Tables.Add(dt);
                    DS.Tables.Add(dt33);
                    DS.Tables.Add(dt3334);
                    DS.Tables.Add(dt33341);


                    if (dt.Rows.Count > 0)



                    {

                        theReport5.RegisterData(DS);

                        theReport5.RegisterData(DSa);


                        theReport5.Load(TGlobalItems.ReportsFolder + "PumpStationDowntime.frx");
                        theReport5.SetParameterValue("Section", editSection.EditValue.ToString());
                        theReport5.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());



                        //theReport5.Design();

                        RepPC.Clear();

                        theReport5.Prepare();

                        theReport5.Preview = RepPC;

                        theReport5.ShowPrepared();

                    }
                }
                else
                {

                    FilterRG.Visible = false;
                    EditImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    if (string.IsNullOrEmpty(editSection.EditValue.ToString()))
                    {
                        MessageBox.Show("Please Select a section");

                        return;
                    }


                    string Section = editSection.EditValue.ToString();

                    string prodmonth = TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString();

                    MWDataManager.clsDataAccess _dbManBreak = new MWDataManager.clsDataAccess();

                    _dbManBreak.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

                    _dbManBreak.SqlStatement = " exec [sp_MainCategories] '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ,'" + editSection.EditValue.ToString() + "' ";

                    _dbManBreak.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                    _dbManBreak.queryReturnType = MWDataManager.ReturnType.DataTable;

                    _dbManBreak.ResultsTableName = "MainCategories";
                    _dbManBreak.ExecuteInstruction();



                    DataTable dta = _dbManBreak.ResultsDataTable;



                    MWDataManager.clsDataAccess _dbManBreak2 = new MWDataManager.clsDataAccess();

                    _dbManBreak2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

                    _dbManBreak2.SqlStatement = " exec [sp_MainCategoriesChart] '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ,'" + editSection.EditValue.ToString() + "' ";

                    _dbManBreak2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                    _dbManBreak2.queryReturnType = MWDataManager.ReturnType.DataTable;

                    _dbManBreak2.ResultsTableName = "MainCategoriesChart";
                    _dbManBreak2.ExecuteInstruction();


                    DataTable dta2 = _dbManBreak2.ResultsDataTable;

                    DataSet DSa = new DataSet();



                    DSa.Tables.Add(dta);
                    DSa.Tables.Add(dta2);


                    MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();

                    _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

                    _dbMan3.SqlStatement = " exec sp_BreakdownCategories '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ";

                    _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                    _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;

                    _dbMan3.ResultsTableName = "Breakdown";



                    _dbMan3.ExecuteInstruction();


                    DataTable dt = _dbMan3.ResultsDataTable;


                    MWDataManager.clsDataAccess _dbMan33 = new MWDataManager.clsDataAccess();

                    _dbMan33.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

                    _dbMan33.SqlStatement = " exec sp_BreakdownCategoriesChart '" + editSection.EditValue.ToString() + "' , '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' ";

                    _dbMan33.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                    _dbMan33.queryReturnType = MWDataManager.ReturnType.DataTable;

                    _dbMan33.ResultsTableName = "BreakdownChart";



                    _dbMan33.ExecuteInstruction();


                    DataTable dt33 = _dbMan33.ResultsDataTable;


                    MWDataManager.clsDataAccess _dbMan3334 = new MWDataManager.clsDataAccess();

                    _dbMan3334.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

                    _dbMan3334.SqlStatement = " exec sp_MainCategoriesTotBottom2 '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "', '" + editSection.EditValue.ToString() + "'   ";

                    _dbMan3334.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                    _dbMan3334.queryReturnType = MWDataManager.ReturnType.DataTable;

                    _dbMan3334.ResultsTableName = "MainCatTotBottom";



                    _dbMan3334.ExecuteInstruction();


                    DataTable dt3334 = _dbMan3334.ResultsDataTable;



                    MWDataManager.clsDataAccess _dbMan33341 = new MWDataManager.clsDataAccess();

                    _dbMan33341.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

                    _dbMan33341.SqlStatement = " exec sp_BreakdownCategoriesTotBottom2 '" + editSection.EditValue.ToString() + "', '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "'    ";

                    _dbMan33341.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;

                    _dbMan33341.queryReturnType = MWDataManager.ReturnType.DataTable;

                    _dbMan33341.ResultsTableName = "TotBottom";



                    _dbMan33341.ExecuteInstruction();


                    DataTable dt33341 = _dbMan33341.ResultsDataTable;


                    DataSet DS = new DataSet();



                    DS.Tables.Add(dt);
                    DS.Tables.Add(dt33);
                    DS.Tables.Add(dt3334);
                    DS.Tables.Add(dt33341);


                    if (dt.Rows.Count > 0)



                    {

                        theReport5.RegisterData(DS);

                        theReport5.RegisterData(DSa);


                        theReport5.Load(TGlobalItems.ReportsFolder + "PumpStationDowntime.frx");
                        theReport5.SetParameterValue("Section", editSection.EditValue.ToString());
                        theReport5.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());



                        //theReport5.Design();

                        RepPC.Clear();

                        theReport5.Prepare();

                        theReport5.Preview = RepPC;

                        theReport5.ShowPrepared();

                    }

                }
            }


            if (ReportName == "Running Hours")
            {
                //FilterRG.Visible = true;
                EditImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                if (FilterRG.SelectedIndex == 0)
                {
                    if (editSection.EditValue.ToString() != "Total Mine Waste")
                    {
                        DataSet repDataSet = new DataSet();

                        ////Get Guns

                        ///Get Guns                
                        MWDataManager.clsDataAccess _dbMan4 = new MWDataManager.clsDataAccess();
                        _dbMan4.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan4.SqlStatement = " select distinct gun from tbl_Planmonth \r\n  " +
                                              "  where prodmonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "'  \r\n  " +
                                              " and SectionID = '" + editSection.EditValue.ToString() + "'  ";
                        _dbMan4.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan4.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan4.ExecuteInstruction();

                        string gun1 = "";
                        string gun2 = "";
                        string gun3 = "";
                        string gun4 = "";
                        string gun5 = "";

                        try { gun1 = _dbMan4.ResultsDataTable.Rows[0][0].ToString(); }
                        catch { gun1 = ""; }

                        try { gun2 = _dbMan4.ResultsDataTable.Rows[1][0].ToString(); }
                        catch { gun2 = ""; }

                        try { gun3 = _dbMan4.ResultsDataTable.Rows[2][0].ToString(); }
                        catch { gun3 = ""; }

                        try { gun4 = _dbMan4.ResultsDataTable.Rows[3][0].ToString(); }
                        catch { gun4 = ""; }

                        try { gun5 = _dbMan4.ResultsDataTable.Rows[4][0].ToString(); }
                        catch { gun5 = ""; }


                        


                        //Get Data
                        MWDataManager.clsDataAccess _dbMan2 = new MWDataManager.clsDataAccess();
                        _dbMan2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan2.SqlStatement = "  \r\n  " +
                                              " exec sp_GraphRunningHrsGun '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' , '" + editSection.EditValue.ToString() + "'    \r\n  " +
                                              "  ";
                        _dbMan2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan2.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan2.ExecuteInstruction();


                        //Get Data Total Sec
                        MWDataManager.clsDataAccess _dbMan22 = new MWDataManager.clsDataAccess();
                        _dbMan22.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan22.SqlStatement = "  \r\n  " +
                                              " exec sp_GraphRunningHrs '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' , '" + editSection.EditValue.ToString() + "'    \r\n  " +
                                              "  ";
                        _dbMan22.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan22.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan22.ExecuteInstruction();

                        //datatable

                        DataTable Neil = _dbMan2.ResultsDataTable;

                        DataTable Neil2 = _dbMan22.ResultsDataTable;

                        //Detail

                        MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();
                        _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan3.SqlStatement = "  \r\n  ";

                        string Section = "";
                        DateTime Calendardate = DateTime.Now;
                        string calendardate2 = "";
                        string Gun = "";
                        decimal planhrs = 0;
                        decimal planhrsProg = 0;

                        decimal bookhrs = 0;
                        decimal bookhrsProg = 0;

                        int PlanTonnes = 0;
                        int planTonnesProg = 0;

                        int BookTonnes = 0;
                        int BookTonnesProg = 0;


                        string Problem = "";

                        int x = 0;
                        int y = Neil.Rows.Count - 2;
                        foreach (DataRow dr in Neil.Rows)
                        {

                            Section = dr["Section"].ToString();

                            if (dr["gun"].ToString() != Gun)
                            {
                                bookhrsProg = 0;
                                planhrsProg = 0;
                            }

                            Gun = dr["gun"].ToString();

                            Calendardate = Convert.ToDateTime(dr["Calendardate"].ToString());

                            calendardate2 = Convert.ToString(Calendardate).Substring(0, 10);

                            Gun = dr["gun"].ToString();

                            Problem = dr["Problem"].ToString();

                            planhrs = Convert.ToDecimal(dr["planhrs"].ToString());
                            planhrsProg = planhrsProg + Convert.ToDecimal(dr["planhrs"].ToString());

                            bookhrs = Convert.ToDecimal(dr["hoursbooked"].ToString());
                            bookhrsProg = bookhrsProg + Convert.ToDecimal(dr["hoursbooked"].ToString());

                            PlanTonnes = Convert.ToInt32(dr["PlanTonnes"].ToString());
                            planTonnesProg = planTonnesProg + Convert.ToInt32(dr["PlanTonnes"].ToString());

                            BookTonnes = Convert.ToInt32(dr["BookTonnes"].ToString());
                            BookTonnesProg = BookTonnesProg + Convert.ToInt32(dr["BookTonnes"].ToString());

                            _dbMan3.SqlStatement = _dbMan3.SqlStatement + " select '" + x + "' order1, '" + calendardate2 + "' Calendardate, '" + Section + "' Section,'" + Gun + "' Gun, '" + planhrs + "' hr, '" + planhrsProg + "' hrprog,'" + bookhrs + "' bookhr ,'" + bookhrsProg + "' bookhrprog ,'" + PlanTonnes + "' PlanTonnes ,'" + planTonnesProg + "' PlanTonnesprog,'" + BookTonnes + "' BookTonnes,'" + BookTonnesProg + "' BookTonnesProg,'" + Problem + "' Problem  ";
                            if (x <= y)
                            {
                                _dbMan3.SqlStatement = _dbMan3.SqlStatement + "union all ";
                            }

                            x = x + 1;

                        }

                        _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan3.ExecuteInstruction();


                        ///Total Data
                        ///
                        MWDataManager.clsDataAccess _dbMan33 = new MWDataManager.clsDataAccess();
                        _dbMan33.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan33.SqlStatement = "  \r\n  ";

                        string Section2 = "";
                        DateTime Calendardate2 = DateTime.Now;
                        //string calendardate2 = "";
                        string Gun2 = "";
                        decimal planhrs2 = 0;
                        decimal planhrsProg2 = 0;

                        decimal bookhrs2 = 0;
                        decimal bookhrsProg2 = 0;

                        int PlanTonnes2 = 0;
                        int planTonnesProg2 = 0;

                        int BookTonnes2 = 0;
                        int BookTonnesProg2 = 0;

                        int x2 = 0;
                        int y2 = Neil2.Rows.Count - 2;
                        foreach (DataRow dr2 in Neil2.Rows)
                        {

                            Section2 = dr2["Section"].ToString();

                            Gun2 = dr2["gun"].ToString();

                            Calendardate = Convert.ToDateTime(dr2["Calendardate"].ToString());

                            calendardate2 = Convert.ToString(Calendardate).Substring(0, 10);

                            Gun2 = dr2["gun"].ToString();

                            planhrs2 = Convert.ToDecimal(dr2["planhrs"].ToString());
                            planhrsProg2 = planhrsProg2 + Convert.ToDecimal(dr2["planhrs"].ToString());

                            bookhrs2 = Convert.ToDecimal(dr2["hoursbooked"].ToString());
                            bookhrsProg2 = bookhrsProg2 + Convert.ToDecimal(dr2["hoursbooked"].ToString());

                            PlanTonnes2 = Convert.ToInt32(dr2["PlanTonnes"].ToString());
                            planTonnesProg2 = planTonnesProg2 + Convert.ToInt32(dr2["PlanTonnes"].ToString());

                            BookTonnes2 = Convert.ToInt32(dr2["BookTonnes"].ToString());
                            BookTonnesProg2 = BookTonnesProg + Convert.ToInt32(dr2["BookTonnes"].ToString());

                            _dbMan33.SqlStatement = _dbMan33.SqlStatement + " select '" + x + "' order1, '" + calendardate2 + "' Calendardate, '" + Section2 + "' Section,'" + Gun2 + "' Gun, '" + planhrs2 + "' hr, '" + planhrsProg2 + "' hrprog,'" + bookhrs2 + "' bookhr ,'" + bookhrsProg2 + "' bookhrprog ,'" + PlanTonnes2 + "' PlanTonnes ,'" + planTonnesProg2 + "' PlanTonnesprog,'" + BookTonnes2 + "' BookTonnes,'" + BookTonnesProg2 + "' BookTonnesProg  ";
                            if (x2 <= y2)
                            {
                                _dbMan33.SqlStatement = _dbMan33.SqlStatement + "union all ";
                            }

                            x2 = x2 + 1;

                        }

                        _dbMan33.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan33.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan33.ExecuteInstruction();

                        repDataSet.Tables.Add(_dbMan3.ResultsDataTable);
                        repDataSet.Tables.Add(_dbMan33.ResultsDataTable);


                        theReport6.RegisterData(repDataSet);

                        theReport6.Load(TGlobalItems.ReportsFolder + "RunningHoursReport.frx");
                        theReport6.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());
                        theReport6.SetParameterValue("Section", editSection.EditValue.ToString());


                        theReport6.SetParameterValue("Gun1", gun1);
                        theReport6.SetParameterValue("Gun2", gun2);
                        theReport6.SetParameterValue("Gun3", gun3);
                        theReport6.SetParameterValue("Gun4", gun4);
                        theReport6.SetParameterValue("Gun5", gun5);

                      // theReport6.Design();

                        RepPC.Clear();
                        theReport6.Prepare();
                        theReport6.Preview = RepPC;

                        theReport6.ShowPrepared();

                        Application.Idle += new System.EventHandler(this.Application_Idle);
                    }
                    else
                    {
                        DataSet repDataSet = new DataSet();


                        


                        //Get Data
                        MWDataManager.clsDataAccess _dbMan2 = new MWDataManager.clsDataAccess();
                        _dbMan2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan2.SqlStatement = "  \r\n  " +
                                               " exec sp_GraphRunningHrsTotNew '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' , '" + editSection.EditValue.ToString() + "'    \r\n  " +
                                               "  ";
                        _dbMan2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan2.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan2.ExecuteInstruction();

                        //datatable

                        DataTable Neil = _dbMan2.ResultsDataTable;



                        MWDataManager.clsDataAccess _dbMan4 = new MWDataManager.clsDataAccess();
                        _dbMan4.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan4.SqlStatement = "  \r\n  ";

                        string Section = "";
                        DateTime Calendardate = DateTime.Now;
                        string calendardate2 = "";
                        string Gun = "";
                        decimal planhrs = 0;
                        decimal planhrsProg = 0;

                        decimal bookhrs = 0;
                        decimal bookhrsProg = 0;

                        int PlanTonnes = 0;
                        int planTonnesProg = 0;

                        int BookTonnes = 0;
                        int BookTonnesProg = 0;

                        int x = 0;
                        int y = Neil.Rows.Count - 2;
                        foreach (DataRow dr in Neil.Rows)
                        {

                            //Section = dr["Section"].ToString();

                            Calendardate = Convert.ToDateTime(dr["Calendardate"].ToString());

                            calendardate2 = Convert.ToString(Calendardate).Substring(0, 10);

                            Gun = dr["gun"].ToString();

                            planhrs = Convert.ToDecimal(dr["planhrs"].ToString());
                            planhrsProg = planhrsProg + Convert.ToDecimal(dr["planhrs"].ToString());

                            bookhrs = Convert.ToDecimal(dr["hoursbooked"].ToString());
                            bookhrsProg = bookhrsProg + Convert.ToDecimal(dr["hoursbooked"].ToString());

                            PlanTonnes = Convert.ToInt32(dr["PlanTonnes"].ToString());
                            planTonnesProg = planTonnesProg + Convert.ToInt32(dr["PlanTonnes"].ToString());

                            BookTonnes = Convert.ToInt32(dr["BookTonnes"].ToString());
                            BookTonnesProg = BookTonnesProg + Convert.ToInt32(dr["BookTonnes"].ToString());

                            _dbMan4.SqlStatement = _dbMan4.SqlStatement + " select '" + x + "' order1, '" + calendardate2 + "' Calendardate, '" + Section + "' Section, '" + planhrs + "' hr, '" + planhrsProg + "' hrprog,'" + bookhrs + "' bookhr ,'" + bookhrsProg + "' bookhrprog ,'" + PlanTonnes + "' PlanTonnes ,'" + planTonnesProg + "' PlanTonnesprog,'" + BookTonnes + "' BookTonnes,'" + BookTonnesProg + "' BookTonnesProg  ";
                            if (x <= y)
                            {
                                _dbMan4.SqlStatement = _dbMan4.SqlStatement + "union all ";
                            }

                            x = x + 1;

                        }

                        _dbMan4.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan4.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan4.ExecuteInstruction();

                        repDataSet.Tables.Add(_dbMan4.ResultsDataTable);


                        theReport6.RegisterData(repDataSet);

                        theReport6.Load(TGlobalItems.ReportsFolder + "RunningHoursReportTot.frx");
                        theReport6.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());
                        theReport6.SetParameterValue("Section", editSection.EditValue.ToString());                   
                       

                       //theReport6.Design();

                        RepPC.Clear();
                        theReport6.Prepare();
                        theReport6.Preview = RepPC;

                        theReport6.ShowPrepared();

                        Application.Idle += new System.EventHandler(this.Application_Idle);
                    }
                }
                else
                {
                    if (editSection.EditValue.ToString() != "Total Mine Waste")
                    {
                        DataSet repDataSet = new DataSet();


                        //Get Data
                        MWDataManager.clsDataAccess _dbMan2 = new MWDataManager.clsDataAccess();
                        _dbMan2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan2.SqlStatement = "  \r\n  " +
                                              " exec sp_GraphRunningHrs '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' , '" + editSection.EditValue.ToString() + "'    \r\n  " +
                                              "  ";
                        _dbMan2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan2.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan2.ExecuteInstruction();

                        //datatable

                        DataTable Neil = _dbMan2.ResultsDataTable;



                        MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();
                        _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan3.SqlStatement = "  \r\n  ";

                        string Section = "";
                        DateTime Calendardate = DateTime.Now;
                        string Gun = "";
                        decimal planhrs = 0;
                        decimal planhrsProg = 0;

                        decimal bookhrs = 0;
                        decimal bookhrsProg = 0;

                        int PlanTonnes = 0;
                        int planTonnesProg = 0;

                        int BookTonnes = 0;
                        int BookTonnesProg = 0;

                        int x = 0;
                        int y = Neil.Rows.Count - 2;
                        foreach (DataRow dr in Neil.Rows)
                        {

                            Section = dr["Section"].ToString();

                            Calendardate = Convert.ToDateTime(dr["Calendardate"].ToString());

                            string calendardate2 = Convert.ToString(Calendardate).Substring(0, 10);

                            Gun = dr["gun"].ToString();

                            planhrs = Convert.ToDecimal(dr["planhrs"].ToString());
                            planhrsProg = planhrsProg + Convert.ToDecimal(dr["planhrs"].ToString());

                            bookhrs = Convert.ToDecimal(dr["hoursbooked"].ToString());
                            bookhrsProg = bookhrsProg + Convert.ToDecimal(dr["hoursbooked"].ToString());

                            PlanTonnes = Convert.ToInt32(dr["PlanTonnes"].ToString());
                            planTonnesProg = planTonnesProg + Convert.ToInt32(dr["PlanTonnes"].ToString());

                            BookTonnes = Convert.ToInt32(dr["BookTonnes"].ToString());
                            BookTonnesProg = BookTonnesProg + Convert.ToInt32(dr["BookTonnes"].ToString());

                            _dbMan3.SqlStatement = _dbMan3.SqlStatement + " select '" + x + "' order1, '" + calendardate2 + "' Calendardate, '" + Section + "' Section, '" + PlanTonnes + "' hr, '" + planTonnesProg + "' hrprog,'" + BookTonnes + "' bookhr ,'" + BookTonnesProg + "' bookhrprog ,'" + PlanTonnes + "' PlanTonnes ,'" + planTonnesProg + "' PlanTonnesprog,'" + BookTonnes + "' BookTonnes,'" + BookTonnesProg + "' BookTonnesProg  ";
                            if (x <= y)
                            {
                                _dbMan3.SqlStatement = _dbMan3.SqlStatement + "union all ";
                            }

                            x = x + 1;

                        }

                        _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan3.ExecuteInstruction();

                        repDataSet.Tables.Add(_dbMan3.ResultsDataTable);


                        theReport6.RegisterData(repDataSet);

                        theReport6.Load(TGlobalItems.ReportsFolder + "RunningTonnesReport.frx");
                        theReport6.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());
                        theReport6.SetParameterValue("Section", editSection.EditValue.ToString());

                        //theReport6.Design();

                        RepPC.Clear();
                        theReport6.Prepare();
                        theReport6.Preview = RepPC;

                        theReport6.ShowPrepared();
                    }
                    else
                    {
                        DataSet repDataSet = new DataSet();
                     
                        //Get Data
                        MWDataManager.clsDataAccess _dbMan2 = new MWDataManager.clsDataAccess();
                        _dbMan2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan2.SqlStatement = "  \r\n  " +
                                              " exec sp_GraphRunningHrsTot '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' , '" + editSection.EditValue.ToString() + "'    \r\n  " +
                                              "  ";
                        _dbMan2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan2.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan2.ExecuteInstruction();

                        //datatable

                        DataTable Neil = _dbMan2.ResultsDataTable;



                        MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();
                        _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan3.SqlStatement = "  \r\n  ";

                        string Section = "";
                        DateTime Calendardate = DateTime.Now;
                        string Gun = "";
                        decimal planhrs = 0;
                        decimal planhrsProg = 0;

                        decimal bookhrs = 0;
                        decimal bookhrsProg = 0;

                        int PlanTonnes = 0;
                        int planTonnesProg = 0;

                        int BookTonnes = 0;
                        int BookTonnesProg = 0;

                        int x = 0;
                        int y = Neil.Rows.Count - 2;
                        foreach (DataRow dr in Neil.Rows)
                        {

                            //Section = dr["Section"].ToString();

                            Calendardate = Convert.ToDateTime(dr["Calendardate"].ToString());

                            string calendardate2 = Convert.ToString(Calendardate).Substring(0, 10);

                            Gun = dr["gun"].ToString();

                            planhrs = Convert.ToDecimal(dr["planhrs"].ToString());
                            planhrsProg = planhrsProg + Convert.ToDecimal(dr["planhrs"].ToString());

                            bookhrs = Convert.ToDecimal(dr["hoursbooked"].ToString());
                            bookhrsProg = bookhrsProg + Convert.ToDecimal(dr["hoursbooked"].ToString());

                            PlanTonnes = Convert.ToInt32(dr["PlanTonnes"].ToString());
                            planTonnesProg = planTonnesProg + Convert.ToInt32(dr["PlanTonnes"].ToString());

                            BookTonnes = Convert.ToInt32(dr["BookTonnes"].ToString());
                            BookTonnesProg = BookTonnesProg + Convert.ToInt32(dr["BookTonnes"].ToString());

                            _dbMan3.SqlStatement = _dbMan3.SqlStatement + " select '" + x + "' order1, '" + calendardate2 + "' Calendardate, '" + Section + "' Section, '" + PlanTonnes + "' hr, '" + planTonnesProg + "' hrprog,'" + BookTonnes + "' bookhr ,'" + BookTonnesProg + "' bookhrprog ,'" + PlanTonnes + "' PlanTonnes ,'" + planTonnesProg + "' PlanTonnesprog,'" + BookTonnes + "' BookTonnes,'" + BookTonnesProg + "' BookTonnesProg  ";
                            if (x <= y)
                            {
                                _dbMan3.SqlStatement = _dbMan3.SqlStatement + "union all ";
                            }

                            x = x + 1;

                        }

                        _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan3.ExecuteInstruction();

                        repDataSet.Tables.Add(_dbMan3.ResultsDataTable);


                        theReport6.RegisterData(repDataSet);

                        theReport6.Load(TGlobalItems.ReportsFolder + "RunningTonnesReportTot.frx");
                        theReport6.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());
                        theReport6.SetParameterValue("Section", editSection.EditValue.ToString());

                      

                        //theReport6.Design();

                        RepPC.Clear();
                        theReport6.Prepare();
                        theReport6.Preview = RepPC;

                        theReport6.ShowPrepared();
                    }
                }
            }



                //MainScreen Mainfrm = new MainScreen();

                if (ReportName == "Compliance to Plan")
                {
                EditImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
               // FilterRG.Visible = true;
                if (FilterRG.SelectedIndex == 0)
                {
                    if (editSection.EditValue.ToString() == "Total Mine Waste")
                    {
                        DataSet repDataSet = new DataSet();

                        ///Get Guns                
                        MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();
                        _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan3.SqlStatement = " select distinct SectionID from tbl_Planmonth \r\n  " +
                                              "  where prodmonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "'  \r\n  " +
                                              " --and SectionID = '" + editSection.EditValue.ToString() + "'  ";
                        _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan3.ExecuteInstruction();

                        string gun1 = "";
                        string gun2 = "";
                        string gun3 = "";
                        string gun4 = "";
                        string gun5 = "";

                        try { gun1 = _dbMan3.ResultsDataTable.Rows[0][0].ToString(); }
                        catch { gun1 = ""; }

                        try { gun2 = _dbMan3.ResultsDataTable.Rows[1][0].ToString(); }
                        catch { gun2 = ""; }

                        try { gun3 = _dbMan3.ResultsDataTable.Rows[2][0].ToString(); }
                        catch { gun3 = ""; }

                        try { gun4 = _dbMan3.ResultsDataTable.Rows[3][0].ToString(); }
                        catch { gun4 = ""; }

                        try { gun5 = _dbMan3.ResultsDataTable.Rows[4][0].ToString(); }
                        catch { gun5 = ""; }


                        //Get Data
                        MWDataManager.clsDataAccess _dbMan2 = new MWDataManager.clsDataAccess();
                        _dbMan2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan2.SqlStatement = "  \r\n  " +
                                              " exec sp_BookingsMonthlyTotalMine '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "'     \r\n  " +
                                              "  ";
                        _dbMan2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan2.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan2.ExecuteInstruction();


                        //Get Data
                        MWDataManager.clsDataAccess _dbMan22 = new MWDataManager.clsDataAccess();
                        _dbMan22.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan22.SqlStatement = "  \r\n  " +
                                              " exec sp_BookingsMonthlyTotalMine2 '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "'     \r\n  " +
                                              "  ";
                        _dbMan22.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan22.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan22.ExecuteInstruction();


                        //Get Data
                        MWDataManager.clsDataAccess _dbMan4 = new MWDataManager.clsDataAccess();
                        _dbMan4.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan4.SqlStatement = "  \r\n  " +
                                              " exec sp_BookingsMonthlyTotTotMine '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' , '" + editSection.EditValue.ToString() + "'    \r\n  " +
                                              "  ";
                        _dbMan4.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan4.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan4.ExecuteInstruction();


                        repDataSet.Tables.Add(_dbMan2.ResultsDataTable);
                        repDataSet.Tables.Add(_dbMan4.ResultsDataTable);
                        repDataSet.Tables.Add(_dbMan22.ResultsDataTable);

                        theReport6.RegisterData(repDataSet);

                        theReport6.Load(TGlobalItems.ReportsFolder + "BookCompReport.frx");

                        theReport6.SetParameterValue("Gun1", gun1);
                        theReport6.SetParameterValue("Gun2", gun2);
                        theReport6.SetParameterValue("Gun3", gun3);
                        theReport6.SetParameterValue("Gun4", gun4);
                        theReport6.SetParameterValue("Gun5", gun5);
                        theReport6.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());
                        theReport6.SetParameterValue("Section", editSection.EditValue.ToString());

                        //theReport6.Design();

                        RepPC.Clear();
                        theReport6.Prepare();
                        theReport6.Preview = RepPC;

                        theReport6.ShowPrepared();
                    }
                    else
                    {
                        DataSet repDataSet = new DataSet();

                        ///Get Guns                
                        MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();
                        _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan3.SqlStatement = " select distinct gun from tbl_Planmonth \r\n  " +
                                              "  where prodmonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "'  \r\n  " +
                                              " and SectionID = '" + editSection.EditValue.ToString() + "'  ";
                        _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan3.ExecuteInstruction();

                        string gun1 = "";
                        string gun2 = "";
                        string gun3 = "";
                        string gun4 = "";
                        string gun5 = "";

                        try { gun1 = _dbMan3.ResultsDataTable.Rows[0][0].ToString(); }
                        catch { gun1 = ""; }

                        try { gun2 = _dbMan3.ResultsDataTable.Rows[1][0].ToString(); }
                        catch { gun2 = ""; }

                        try { gun3 = _dbMan3.ResultsDataTable.Rows[2][0].ToString(); }
                        catch { gun3 = ""; }

                        try { gun4 = _dbMan3.ResultsDataTable.Rows[3][0].ToString(); }
                        catch { gun4 = ""; }

                        try { gun5 = _dbMan3.ResultsDataTable.Rows[4][0].ToString(); }
                        catch { gun5 = ""; }


                        //Get Data
                        MWDataManager.clsDataAccess _dbMan2 = new MWDataManager.clsDataAccess();
                        _dbMan2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan2.SqlStatement = "  \r\n  " +
                                              " exec sp_BookingsMonthly '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' , '" + editSection.EditValue.ToString() + "'    \r\n  " +
                                              "  ";
                        _dbMan2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan2.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan2.ExecuteInstruction();



                        //Get Data
                        MWDataManager.clsDataAccess _dbMan22 = new MWDataManager.clsDataAccess();
                        _dbMan22.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan22.SqlStatement = "  \r\n  " +
                                              " exec sp_BookingsMonthlyProgSec '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' , '" + editSection.EditValue.ToString() + "'    \r\n  " +
                                              "  ";
                        _dbMan22.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan22.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan22.ExecuteInstruction();


                        //Get Data
                        MWDataManager.clsDataAccess _dbMan4 = new MWDataManager.clsDataAccess();
                        _dbMan4.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan4.SqlStatement = "  \r\n  " +
                                              " exec sp_BookingsMonthlyTot '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' , '" + editSection.EditValue.ToString() + "'    \r\n  " +
                                              "  ";
                        _dbMan4.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan4.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan4.ExecuteInstruction();


                        //Get Data
                        MWDataManager.clsDataAccess _dbMan44 = new MWDataManager.clsDataAccess();
                        _dbMan44.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan44.SqlStatement = "  \r\n  " +
                                              " exec sp_BookingsMonthlyTotSec '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' , '" + editSection.EditValue.ToString() + "'    \r\n  " +
                                              "  ";
                        _dbMan44.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan44.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan44.ExecuteInstruction();



                        repDataSet.Tables.Add(_dbMan2.ResultsDataTable);
                       
                        repDataSet.Tables.Add(_dbMan4.ResultsDataTable);
                        repDataSet.Tables.Add(_dbMan22.ResultsDataTable);
                        repDataSet.Tables.Add(_dbMan44.ResultsDataTable);

                        theReport6.RegisterData(repDataSet);

                        theReport6.Load(TGlobalItems.ReportsFolder + "BookCompReportSec.frx");

                        theReport6.SetParameterValue("Gun1", gun1);
                        theReport6.SetParameterValue("Gun2", gun2);
                        theReport6.SetParameterValue("Gun3", gun3);
                        theReport6.SetParameterValue("Gun4", gun4);
                        theReport6.SetParameterValue("Gun5", gun5);
                        theReport6.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());
                        theReport6.SetParameterValue("Section", editSection.EditValue.ToString());

                        //theReport6.Design();

                        RepPC.Clear();
                        theReport6.Prepare();
                        theReport6.Preview = RepPC;

                        theReport6.ShowPrepared();
                    }
                }
                else
                {
                    if (editSection.EditValue.ToString() == "Total Mine Waste")
                    {
                         DataSet repDataSet = new DataSet();

                        ///Get Guns                
                        MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();
                        _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan3.SqlStatement = " select distinct SectionID from tbl_Planmonth \r\n  " +
                                              "  where prodmonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "'  \r\n  " +
                                              " --and SectionID = '" + editSection.EditValue.ToString() + "'  ";
                        _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan3.ExecuteInstruction();

                        string gun1 = "";
                        string gun2 = "";
                        string gun3 = "";
                        string gun4 = "";
                        string gun5 = "";

                        try { gun1 = _dbMan3.ResultsDataTable.Rows[0][0].ToString(); }
                        catch { gun1 = ""; }

                        try { gun2 = _dbMan3.ResultsDataTable.Rows[1][0].ToString(); }
                        catch { gun2 = ""; }

                        try { gun3 = _dbMan3.ResultsDataTable.Rows[2][0].ToString(); }
                        catch { gun3 = ""; }

                        try { gun4 = _dbMan3.ResultsDataTable.Rows[3][0].ToString(); }
                        catch { gun4 = ""; }

                        try { gun5 = _dbMan3.ResultsDataTable.Rows[4][0].ToString(); }
                        catch { gun5 = ""; }


                        //Get Data
                        MWDataManager.clsDataAccess _dbMan2 = new MWDataManager.clsDataAccess();
                        _dbMan2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan2.SqlStatement = "  \r\n  " +
                                              " exec sp_BookingsMonthlyTotalMine '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' , '" + editSection.EditValue.ToString() + "'    \r\n  " +
                                              "  ";
                        _dbMan2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan2.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan2.ExecuteInstruction();


                        //Get Data
                        MWDataManager.clsDataAccess _dbMan4 = new MWDataManager.clsDataAccess();
                        _dbMan4.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan4.SqlStatement = "  \r\n  " +
                                              " exec sp_BookingsMonthlyTotTotMine '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' , '" + editSection.EditValue.ToString() + "'    \r\n  " +
                                              "  ";
                        _dbMan4.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan4.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan4.ExecuteInstruction();


                        repDataSet.Tables.Add(_dbMan2.ResultsDataTable);
                        repDataSet.Tables.Add(_dbMan4.ResultsDataTable);

                        theReport6.RegisterData(repDataSet);

                        theReport6.Load(TGlobalItems.ReportsFolder + "BookCompReport2.frx");

                        theReport6.SetParameterValue("Gun1", gun1);
                        theReport6.SetParameterValue("Gun2", gun2);
                        theReport6.SetParameterValue("Gun3", gun3);
                        theReport6.SetParameterValue("Gun4", gun4);
                        theReport6.SetParameterValue("Gun5", gun5);
                        theReport6.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());
                        theReport6.SetParameterValue("Section", editSection.EditValue.ToString());

                        //theReport6.Design();

                        RepPC.Clear();
                        theReport6.Prepare();
                        theReport6.Preview = RepPC;

                        theReport6.ShowPrepared();
                    }
                    else
                    {
                        DataSet repDataSet = new DataSet();

                        ///Get Guns                
                        MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();
                        _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan3.SqlStatement = " select distinct gun from tbl_Planmonth \r\n  " +
                                              "  where prodmonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "'  \r\n  " +
                                              " and SectionID = '" + editSection.EditValue.ToString() + "'  ";
                        _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan3.ExecuteInstruction();

                        string gun1 = "";
                        string gun2 = "";
                        string gun3 = "";
                        string gun4 = "";
                        string gun5 = "";

                        try { gun1 = _dbMan3.ResultsDataTable.Rows[0][0].ToString(); }
                        catch { gun1 = ""; }

                        try { gun2 = _dbMan3.ResultsDataTable.Rows[1][0].ToString(); }
                        catch { gun2 = ""; }

                        try { gun3 = _dbMan3.ResultsDataTable.Rows[2][0].ToString(); }
                        catch { gun3 = ""; }

                        try { gun4 = _dbMan3.ResultsDataTable.Rows[3][0].ToString(); }
                        catch { gun4 = ""; }

                        try { gun5 = _dbMan3.ResultsDataTable.Rows[4][0].ToString(); }
                        catch { gun5 = ""; }


                        //Get Data
                        MWDataManager.clsDataAccess _dbMan2 = new MWDataManager.clsDataAccess();
                        _dbMan2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan2.SqlStatement = "  \r\n  " +
                                              " exec sp_BookingsMonthly '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' , '" + editSection.EditValue.ToString() + "'    \r\n  " +
                                              "  ";
                        _dbMan2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan2.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan2.ExecuteInstruction();


                        //Get Data
                        MWDataManager.clsDataAccess _dbMan4 = new MWDataManager.clsDataAccess();
                        _dbMan4.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                        _dbMan4.SqlStatement = "  \r\n  " +
                                              " exec sp_BookingsMonthlyTot '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' , '" + editSection.EditValue.ToString() + "'    \r\n  " +
                                              "  ";
                        _dbMan4.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                        _dbMan4.queryReturnType = MWDataManager.ReturnType.DataTable;
                        _dbMan4.ExecuteInstruction();


                        repDataSet.Tables.Add(_dbMan2.ResultsDataTable);
                        repDataSet.Tables.Add(_dbMan4.ResultsDataTable);

                        theReport6.RegisterData(repDataSet);

                        theReport6.Load(TGlobalItems.ReportsFolder + "BookCompReportTonnes.frx");

                        theReport6.SetParameterValue("Gun1", gun1);
                        theReport6.SetParameterValue("Gun2", gun2);
                        theReport6.SetParameterValue("Gun3", gun3);
                        theReport6.SetParameterValue("Gun4", gun4);
                        theReport6.SetParameterValue("Gun5", gun5);
                        theReport6.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());
                        theReport6.SetParameterValue("Section", editSection.EditValue.ToString());

                        //theReport6.Design();

                        RepPC.Clear();
                        theReport6.Prepare();
                        theReport6.Preview = RepPC;

                        theReport6.ShowPrepared();
                    }
                }
            }

            if (ReportName == "Planning Report")
            {
                EditImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                FilterRG.Visible = false;
                if (editSection.EditValue.ToString() == "Total Mine Waste")
                {
                    DataSet repDataSet = new DataSet();

                    MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
                    _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                    _dbMan.SqlStatement = " \r\n  " +

                                            "select SectionID, SUM(Tonnes)planTonnes, SUM(Kg) planKG, SUM(Kg) * 1000 / (SUM(Tonnes) + 0.00001) gt, SUM(KgRec) PlanKgRec, 'Total Mine Waste' sec, '201705' pm \r\n  " +
                                            "from(Select * from tbl_PlanMonth where ProdMonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "'  )a \r\n  " +
                                            " group by SectionID  order by SectionID \r\n  ";

                    _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                    _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
                    _dbMan.ExecuteInstruction();


                    MWDataManager.clsDataAccess _dbManPic = new MWDataManager.clsDataAccess();
                    _dbManPic.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                    _dbManPic.SqlStatement = " select * from  tbl_PlanningImages\r\n  " +
                                          " where ProdMonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' \r\n  " +
                                          " and section = '" + editSection.EditValue.ToString() + "' ";
                    _dbManPic.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                    _dbManPic.queryReturnType = MWDataManager.ReturnType.DataTable;
                    _dbManPic.ExecuteInstruction();


                    ////get footer           


                    ///Get Signatures              
                    MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();
                    _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                    _dbMan3.SqlStatement = " select Name from tbl_Codes_NamesSignatures \r\n  " +
                                          "  order by ID  \r\n  " +
                                          "   ";
                    _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                    _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;
                    _dbMan3.ExecuteInstruction();

                    string Signature1 = "";
                    string Signature2 = "";
                    string Signature3 = "";
                    string Signature4 = "";
                    string Signature5 = "";

                    try { Signature1 = _dbMan3.ResultsDataTable.Rows[0][0].ToString(); }
                    catch { Signature1 = ""; }

                    try { Signature2 = _dbMan3.ResultsDataTable.Rows[1][0].ToString(); }
                    catch { Signature2 = ""; }

                    try { Signature3 = _dbMan3.ResultsDataTable.Rows[2][0].ToString(); }
                    catch { Signature3 = ""; }

                    try { Signature4 = _dbMan3.ResultsDataTable.Rows[3][0].ToString(); }
                    catch { Signature4 = ""; }

                    try { Signature5 = _dbMan3.ResultsDataTable.Rows[4][0].ToString(); }
                    catch { Signature5 = ""; }





                    repDataSet.Tables.Add(_dbMan.ResultsDataTable);
                    repDataSet.Tables.Add(_dbManPic.ResultsDataTable);

                    theReport5.RegisterData(repDataSet);

                    theReport5.Load(TGlobalItems.ReportsFolder + "\\PlanningReport2Tot.frx");
                    theReport5.SetParameterValue("Signature1", Signature1);
                    theReport5.SetParameterValue("Signature2", Signature2);
                    theReport5.SetParameterValue("Signature3", Signature3);
                    theReport5.SetParameterValue("Signature4", Signature4);
                    theReport5.SetParameterValue("Signature5", Signature5);

                   // theReport5.Design();

                    RepPC.Clear();
                    theReport5.Prepare();
                    theReport5.Preview = RepPC;

                    theReport5.ShowPrepared();
                }
                else
                {
                    DataSet repDataSet = new DataSet();

                    MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
                    _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                    _dbMan.SqlStatement = "select Gun, Bench, Dam, SUM(Tonnes) planTonnes, SUM(Kg) planKG, SUM(Kg)*1000/(SUM(Tonnes)+0.00001) gt,SUM(KgRec) PlanKgRec, '" + editSection.EditValue.ToString() + "' sec,'" + editProdmonth.EditValue + "' pm  \r\n  " +
                                          "from (Select* from tbl_PlanMonth where ProdMonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' and SectionID = '" + editSection.EditValue.ToString() + "' )a    \r\n  " +
                                          "group by Gun, Dam, Bench  order by Gun ";
                    _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                    _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
                    _dbMan.ExecuteInstruction();


                    MWDataManager.clsDataAccess _dbManPic = new MWDataManager.clsDataAccess();
                    _dbManPic.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                    _dbManPic.SqlStatement = " select * from  tbl_PlanningImages\r\n  " +
                                          " where ProdMonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' \r\n  " +
                                          " and section = '" + editSection.EditValue.ToString() + "' ";
                    _dbManPic.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                    _dbManPic.queryReturnType = MWDataManager.ReturnType.DataTable;
                    _dbManPic.ExecuteInstruction();


                    ////get footer           


                    ///Get Signatures              
                    MWDataManager.clsDataAccess _dbMan3 = new MWDataManager.clsDataAccess();
                    _dbMan3.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                    _dbMan3.SqlStatement = " select Name from tbl_Codes_NamesSignatures \r\n  " +
                                          "  order by ID  \r\n  " +
                                          "   ";
                    _dbMan3.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                    _dbMan3.queryReturnType = MWDataManager.ReturnType.DataTable;
                    _dbMan3.ExecuteInstruction();

                    string Signature1 = "";
                    string Signature2 = "";
                    string Signature3 = "";
                    string Signature4 = "";
                    string Signature5 = "";

                    try { Signature1 = _dbMan3.ResultsDataTable.Rows[0][0].ToString(); }
                    catch { Signature1 = ""; }

                    try { Signature2 = _dbMan3.ResultsDataTable.Rows[1][0].ToString(); }
                    catch { Signature2 = ""; }

                    try { Signature3 = _dbMan3.ResultsDataTable.Rows[2][0].ToString(); }
                    catch { Signature3 = ""; }

                    try { Signature4 = _dbMan3.ResultsDataTable.Rows[3][0].ToString(); }
                    catch { Signature4 = ""; }

                    try { Signature5 = _dbMan3.ResultsDataTable.Rows[4][0].ToString(); }
                    catch { Signature5 = ""; }





                    repDataSet.Tables.Add(_dbMan.ResultsDataTable);
                    repDataSet.Tables.Add(_dbManPic.ResultsDataTable);

                    theReport5.RegisterData(repDataSet);

                    theReport5.Load(TGlobalItems.ReportsFolder + "\\PlanningReport2.frx");
                    theReport5.SetParameterValue("Signature1", Signature1);
                    theReport5.SetParameterValue("Signature2", Signature2);
                    theReport5.SetParameterValue("Signature3", Signature3);
                    theReport5.SetParameterValue("Signature4", Signature4);
                    theReport5.SetParameterValue("Signature5", Signature5);

                    //theReport5.Design();

                    RepPC.Clear();
                    theReport5.Prepare();
                    theReport5.Preview = RepPC;

                    theReport5.ShowPrepared();
                }
                
            }

        }

        private void ucReportsViewer_Load(object sender, EventArgs e)
        {


            editProdmonth.EditValue = TMinewasteGlobal.ProdMonthAsDate(GlobalVar.ProdMonth.ToString());
            LoadSec();

            editGun.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            EditImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            editFilterBy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            if (ReportName == "Planning Report Gun Hours")
            {
                editSection.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                editSection.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }


            if (ReportName == "Running Hours Downtime")
            {
                editFilterBy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                EditImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }

            if (ReportName == "Running Hours")
            {
                FilterRG.Visible = true;
                EditImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            if (ReportName == "Planning Report")
            {
                EditImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                FilterRG.Visible = false;

            }
            if (ReportName == "Compliance to Plan")
            {
                EditImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                FilterRG.Visible = true;
            }

            if (ReportName == "Tonnes Re-Mined")
            {
                editSection.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                EditImageBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }


        void LoadSec()
        {

            
            ///Load Sections fro scheduling

            MWDataManager.clsDataAccess _getSec = new MWDataManager.clsDataAccess();
            _getSec.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _getSec.SqlStatement = " select distinct(Section) Sec, 2 orderby from tbl_Calendar_days where prodmonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' and Section is not null " +
                                     " union select 'Total Mine Waste' , 1 orderby  order by orderby \r\n";
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



        private void EditImageBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //string dt = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateEditItem.EditValue.ToString()));

            GetImage GetImage = new GetImage();
            GetImage._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection); 
            GetImage.ProdmonthLbl.Text = TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString();
            GetImage.SectionLbl.Text = editSection.EditValue.ToString().ToString();
            //ProbFrm.GunLbl.Text = GunEditItem.EditValue.ToString();
            //ProbFrm.BenchLbl.Text = BenchEditItem.EditValue.ToString();
            //ProbFrm.DamLbl.Text = DamEditItem.EditValue.ToString();
            GetImage.ShowDialog(this);
        }

        private void GunLbl_TextChanged(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;
            DataSet repDataSet = new DataSet();

            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _dbMan.SqlStatement = " Exec sp_GraphRunningHrsGunDetail '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "', \r\n  " +
                                  " '"+editSection.EditValue.ToString()+"',  \r\n  " +
                                  " '"+GunLbl.Text+"' ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();


            MWDataManager.clsDataAccess _dbMan2 = new MWDataManager.clsDataAccess();
            _dbMan2.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _dbMan2.SqlStatement = " Exec [sp_GraphRunningHrsGunDetailPerc] '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "', \r\n  " +
                                  " '" + editSection.EditValue.ToString() + "',  \r\n  " +
                                  " '" + GunLbl.Text + "' ";
            _dbMan2.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan2.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan2.ExecuteInstruction();

            repDataSet.Tables.Add(_dbMan.ResultsDataTable);
            repDataSet.Tables.Add(_dbMan2.ResultsDataTable);

            theReport5.RegisterData(repDataSet);

            theReport5.Load(TGlobalItems.ReportsFolder + "RunningHoursReportDetail.frx");
            theReport5.SetParameterValue("Sec", editSection.EditValue.ToString());
            theReport5.SetParameterValue("Gun", GunLbl.Text);
            theReport5.SetParameterValue("Prodmonth", TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString());


            //theReport5.Design();

            //RepPC.Clear();
            theReport5.Prepare();

            FastReport.Utils.XmlItem item = FastReport.Utils.Config.Root.FindItem("Forms").FindItem("PreviewForm");
            item.SetProp("Maximized", "0");
            item.SetProp("Left", "0");
            item.SetProp("Top", "0");
            theReport5.Prepare();
            //theReport5.Preview = RepPC;
            theReport5.Show();

            Cursor = Cursors.Default;
        }



        

        private void editSection_EditValueChanged(object sender, EventArgs e)
        {
            if (ReportName == "Running Hours Downtime")
            {
                if (editSection.EditValue.ToString() == "Total Mine Waste")
                {
                    editGun.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }
                else
                {
                    editGun.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                }
                try
                {
                    MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
                    _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                    _dbMan.SqlStatement = " select distinct gun from tbl_planmonth \r\n  " +
                                            " where SectionID = '" + editSection.EditValue.ToString() + "' \r\n  " +
                                            " and Prodmonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' \r\n  ";
                    _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                    _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
                    _dbMan.ExecuteInstruction();

                    DataTable dt = _dbMan.ResultsDataTable;


                    DataSet ds = new DataSet();
                    if (ds.Tables.Count > 0)
                        ds.Tables.Clear();
                    ds.Tables.Add(dt);
                    //Grd3Mnth.Visible = true;
                    LookUpEditGun.DataSource = ds.Tables[0];
                    LookUpEditGun.DisplayMember = "gun";
                    LookUpEditGun.ValueMember = "gun";
                }
                catch { return; };
            }
        }

        private void editFilterBy_EditValueChanged(object sender, EventArgs e)
        {
            if (editFilterBy.EditValue.ToString() == "0")
            {
                editGun.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            if (editFilterBy.EditValue.ToString() == "1")
            {
                editGun.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


                MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
                _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbMan.SqlStatement = " select distinct gun from tbl_planmonth \r\n  " +
                                        " where SectionID = '" + editSection.EditValue.ToString() + "' \r\n  " +
                                        " and Prodmonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' \r\n  ";
                _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan.ExecuteInstruction();

                DataTable dt = _dbMan.ResultsDataTable;


                DataSet ds = new DataSet();
                if (ds.Tables.Count > 0)
                    ds.Tables.Clear();
                ds.Tables.Add(dt);
                //Grd3Mnth.Visible = true;
                LookUpEditGun.DataSource = ds.Tables[0];
                LookUpEditGun.DisplayMember = "gun";
                LookUpEditGun.ValueMember = "gun";


            }
        }

        private void editProdmonth_EditValueChanged(object sender, EventArgs e)
        {
            LoadSec();
        }
    }
}
