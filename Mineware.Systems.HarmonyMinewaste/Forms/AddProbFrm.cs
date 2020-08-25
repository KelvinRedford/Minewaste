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
    public partial class AddProbFrm : DevExpress.XtraEditors.XtraForm
    {
        public string _theConnection;
        public AddProbFrm()
        {
            InitializeComponent();
        }

        private void AddProbFrm_Load(object sender, EventArgs e)
        {
            //this.Icon = Mineware.Systems.Minewaste.Properties.Resources.button_teal;

            ///Load Category Combo
            ///
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = _theConnection;

            _dbMan.SqlStatement = " select *, convert(Varchar(10),ProbCatID)+':'+ProbCatDesc ProbCat from [tbl_ProbCatagories] \r\n";
            _dbMan.SqlStatement = _dbMan.SqlStatement + " ";
            _dbMan.SqlStatement = _dbMan.SqlStatement + "  ";

            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            DataTable dt2 = _dbMan.ResultsDataTable;
            DataSet ds2 = new DataSet();
            if (ds2.Tables.Count > 0)
                ds2.Tables.Clear();
            ds2.Tables.Add(dt2);
            //Grd3Mnth.Visible = true;

            foreach (DataRow dr in _dbMan.ResultsDataTable.Rows)
            {

                ProbCatCmb.Items.Add(dr["ProbCat"].ToString());

            }


        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ProbCodeTxt.Text == "")
            {
                MessageBox.Show("Please enter a Problem Code.", "Insufficient information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ProbDescTxt.Text == "")
            {
                MessageBox.Show("Please enter a Problem Description.", "Insufficient information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ProbCatCmb.Text == "")
            {
                MessageBox.Show("Please select a Problem Category.", "Insufficient information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = _theConnection;

            _dbMan.SqlStatement = " insert into tbl_Problems values ('" + ProbDescTxt.Text.ToString() + "', \r\n";
            _dbMan.SqlStatement = _dbMan.SqlStatement + " '" + Convert.ToInt32(ExtractBeforeColon(ProbCatCmb.Text.ToString())) + "', ";
            _dbMan.SqlStatement = _dbMan.SqlStatement + " '" + ProbCodeTxt.Text.ToString() + "' ) ";

            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
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
    }
}
