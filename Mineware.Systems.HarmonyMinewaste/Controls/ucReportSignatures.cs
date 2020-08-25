using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using Mineware.Systems.Global;
using Mineware.Systems.GlobalConnect;

namespace Mineware.Systems.Minewaste.Controls
{
    public partial class ucReportSignatures : ucBaseUserControl
    {
        public ucReportSignatures()
        {
            InitializeComponent();
        }

        string Status = "";
        string Name = "";

        private void GVEmp_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            Status = GVEmp.GetRowCellValue(e.RowHandle, "Description").ToString();
            Name = GVEmp.GetRowCellValue(e.RowHandle, "Name").ToString();

            StatusCmb.Text = Status;
            NameTxt.Text = Name;

            NameTxt.Enabled = true;
            saveBtn.Enabled = true;




        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

            _dbMan.SqlStatement = " update tbl_Codes_NamesSignatures  " +
                                  " set Name = '"+NameTxt.Text+ "' where Description = '" + StatusCmb.Text + "' ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();
            LoadGrid();
        }

        private void ucReportSignatures_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        void LoadGrid()
        {
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

            _dbMan.SqlStatement = " select * from tbl_Codes_NamesSignatures  " +
                                  " order by ID";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            DataTable dt = _dbMan.ResultsDataTable;
            DataSet ds = new DataSet();
            if (ds.Tables.Count > 0)
                ds.Tables.Clear();
            ds.Tables.Add(dt);
            //Grd3Mnth.Visible = true;

            GCEmp.DataSource = ds.Tables[0];

            GCStatus.FieldName = "Description";
            GCName.FieldName = "Name";
           
        }
    }
}
