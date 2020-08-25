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

using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Columns;

using DevExpress.XtraEditors.Repository;
using Mineware.Systems.Global;
using Mineware.Systems.GlobalConnect;

namespace Mineware.Systems.Minewaste.Controls
{
    public partial class ucPumpStationSetup : ucBaseUserControl
    {
        Mineware.Systems.Minewaste.GlobalItems procs = new Mineware.Systems.Minewaste.GlobalItems();
        public ucPumpStationSetup()
        {
            InitializeComponent();
        }

        private void ucPumpStationSetup_Load(object sender, EventArgs e)
        {

            Loadgrid();




        }


        void Loadgrid()
        {
            MWDataManager.clsDataAccess _dbManSave7 = new MWDataManager.clsDataAccess();
            _dbManSave7.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _dbManSave7.SqlStatement = "";
            _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + " select *, Section sec from tbl_PumpStations  \r\n";
            _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + "  \r\n ";
            _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + "   \r\n ";
            _dbManSave7.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbManSave7.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbManSave7.ExecuteInstruction();

            if (_dbManSave7.ResultsDataTable.Rows.Count > 0)
            {

                DataTable dt = _dbManSave7.ResultsDataTable;
                DataSet ds = new DataSet();
                if (ds.Tables.Count > 0)
                    ds.Tables.Clear();
                ds.Tables.Add(dt);
                //Grd3Mnth.Visible = true;
                gcPumpStation.DataSource = ds.Tables[0];
                gcPump.FieldName = "Description";
                gcSec.FieldName = "sec";
                //SecCmb.Items.AddRange(new string[] { "London", "Berlin", "Paris" });
                //gcSec.ColumnEdit = SecCmb;

            }
        }

        private void AddBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddPumpStationFrm PumpStation = new AddPumpStationFrm();
            PumpStation._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            PumpStation.Text = "Add Pump Station";
            PumpStation.ShowDialog(this);
            Loadgrid();
        }

        private void PM1Txt_Click(object sender, EventArgs e)
        {
          
        }
        string Desc = "";
        private void gvPumpStation_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            Desc = gvPumpStation.GetRowCellValue(e.RowHandle, gvPumpStation.Columns["Description"]).ToString();
        }

        private void EditBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddPumpStationFrm PumpStation = new AddPumpStationFrm();
            PumpStation._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            PumpStation.Text = "Edit Pump Station";
            PumpStation.PumpLbl.Text = Desc;
            PumpStation.ShowDialog(this);
            Loadgrid();
        }
    }
}
