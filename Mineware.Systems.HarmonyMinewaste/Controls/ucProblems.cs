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
    public partial class ucProblems : ucBaseUserControl
    {
        public ucProblems()
        {
            InitializeComponent();
        }

        private void AddBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddProbFrm AddProbFrm = new AddProbFrm();
            AddProbFrm._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            AddProbFrm.ShowDialog(this);
            LoadGrid();
        }

        private void ucProblems_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        void LoadGrid()
        {
            ///Load Problems
            ///
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);

            _dbMan.SqlStatement = "select a.*, b.ProbCatDesc from (\r\n " +
                         " select * from tbl_Problems )a  \r\n" +
                         " left outer join(  \r\n" +
                         " select * from tbl_ProbCatagories)b \r\n" +
                         " on a.ProbCatID = b.ProbCatID  order by problem";

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
            gcProbID.FieldName = "ProbID";
            gcProbCode.FieldName = "ProbCode";
            gcProblem.FieldName = "Problem";
            gcProbCat.FieldName = "ProbCatDesc";
        }
    }
}
