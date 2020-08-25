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

namespace Mineware.Systems.Minewaste.Controls
{
    public partial class ucReportsViewerStream : ucBaseUserControl
    {
        Report theReport5 = new Report();
        public ucReportsViewerStream()
        {
            InitializeComponent();
        }

        private void ucReportsViewerStream_Load(object sender, EventArgs e)
        {
            ///Load Sections fro scheduling

            MWDataManager.clsDataAccess _getSec = new MWDataManager.clsDataAccess();
            _getSec.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _getSec.SqlStatement = " select distinct(Section) Sec, 2 orderby from tbl_Calendar_days where  Section is not null and section <> 'Additional' " +
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
            SecCmb.DataSource = ds.Tables[0];
            SecCmb.DisplayMember = "Sec";
            SecCmb.ValueMember = "Sec";
            SecCmb.SelectedIndex = -1;
        }

        private void AddBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            if (string.IsNullOrEmpty(SecCmb.Text))
            {
                MessageBox.Show("Please Select a section");

                return;
            }


            string Section = SecCmb.Text;

            if (SecCmb.Text == "Total Mine Waste")
            {
                MWDataManager.clsDataAccess _dbMan333 = new MWDataManager.clsDataAccess();
                _dbMan333.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbMan333.SqlStatement = " exec [sp_PumpStationStream90/180Tot] '" + SecCmb.Text + "'  ";
                _dbMan333.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan333.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan333.ResultsTableName = "BreakdownChart90-180";
                _dbMan333.ExecuteInstruction();




                MWDataManager.clsDataAccess _dbMan33333 = new MWDataManager.clsDataAccess();
                _dbMan33333.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbMan33333.SqlStatement = " exec [sp_PumpStationStream14-28Tot] '" + SecCmb.Text + "'  ";
                _dbMan33333.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan33333.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan33333.ResultsTableName = "BreakdownChart14-28";
                _dbMan33333.ExecuteInstruction();


                MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
                _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbMan.SqlStatement = " exec [sp_PumpStationStream7Tot] '" + SecCmb.Text + "'  ";
                _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan.ResultsTableName = "BreakdownChart7";
                _dbMan.ExecuteInstruction();


               
                DataTable dt333 = _dbMan333.ResultsDataTable;
               
                DataTable dt33333 = _dbMan33333.ResultsDataTable;
                DataTable dt = _dbMan.ResultsDataTable;
                

                DataSet DS = new DataSet();




             
                DS.Tables.Add(dt333);
               
                DS.Tables.Add(dt33333);
                DS.Tables.Add(dt);
              




                theReport5.RegisterData(DS);

                //theReport5.RegisterData(DSa);


                theReport5.Load("PumpStationDowntimeStreamTot.frx");
                theReport5.SetParameterValue("Section", SecCmb.Text);

               //theReport5.Design();

                RepPC.Clear();

                theReport5.Prepare();

                theReport5.Preview = RepPC;

                theReport5.ShowPrepared();
            }
            else
            {




              


                MWDataManager.clsDataAccess _dbMan333 = new MWDataManager.clsDataAccess();
                _dbMan333.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbMan333.SqlStatement = " exec [sp_PumpStationStream90/180] '" + SecCmb.Text + "'  ";
                _dbMan333.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan333.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan333.ResultsTableName = "BreakdownChart90-180";
                _dbMan333.ExecuteInstruction();


            

                MWDataManager.clsDataAccess _dbMan33333 = new MWDataManager.clsDataAccess();
                _dbMan33333.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbMan33333.SqlStatement = " exec [sp_PumpStationStream14-28] '" + SecCmb.Text + "'  ";
                _dbMan33333.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan33333.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan33333.ResultsTableName = "BreakdownChart14-28";
                _dbMan33333.ExecuteInstruction();


                MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
                _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                _dbMan.SqlStatement = " exec [sp_PumpStationStream7] '" + SecCmb.Text + "'  ";
                _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan.ResultsTableName = "BreakdownChart7";
                _dbMan.ExecuteInstruction();


             


                
                DataTable dt333 = _dbMan333.ResultsDataTable;
                
                DataTable dt33333 = _dbMan33333.ResultsDataTable;
                DataTable dt = _dbMan.ResultsDataTable;
               

                DataSet DS = new DataSet();




              
                DS.Tables.Add(dt333);
               
                DS.Tables.Add(dt33333);
                DS.Tables.Add(dt);
               




                theReport5.RegisterData(DS);

                //theReport5.RegisterData(DSa);


                theReport5.Load("PumpStationDowntimeStream.frx");
                theReport5.SetParameterValue("Section", SecCmb.Text);

               // theReport5.Design();

                RepPC.Clear();

                theReport5.Prepare();

                theReport5.Preview = RepPC;

                theReport5.ShowPrepared();
            }

            
        }
    }
}
