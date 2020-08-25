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
    public partial class ucProbCat : ucBaseUserControl
    {
        public ucProbCat()
        {
            InitializeComponent();
        }

        private void AddBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddProbCatFrm AddProbCatFrm = new AddProbCatFrm();
            AddProbCatFrm._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            AddProbCatFrm.ShowDialog(this);
            LoadGrid();
        }

        private void ucProbCat_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        void LoadGrid()
        {
            ///Load Problem Categories
            ///
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

            _dbMan.SqlStatement = "select * from tbl_ProbCatagories\r\n " +
                         "  order by ProbCatDesc \r\n" +
                         "   \r\n" +
                         "  \r\n" +
                         " ";

            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            DataTable dt = _dbMan.ResultsDataTable;
            DataSet ds = new DataSet();
            if (ds.Tables.Count > 0)
                ds.Tables.Clear();
            ds.Tables.Add(dt);
            //Grd3Mnth.Visible = true;
            ProblemGrid.DataSource = ds.Tables[0];
            gcProbID.FieldName = "ProbCatID";
            gcProblem.FieldName = "ProbCatDesc";
            //gcProbCat.FieldName = "ProbCatDesc";
        }
    }
}
