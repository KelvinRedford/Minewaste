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
    public partial class AddProbCatFrm : DevExpress.XtraEditors.XtraForm
    {
        public string _theConnection;
        public AddProbCatFrm()
        {
            InitializeComponent();
        }

        private void AddProbCatFrm_Load(object sender, EventArgs e)
        {
            //this.Icon = Mineware.Systems.Minewaste.Properties.Resources.button_teal;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CatDescTxt.Text == "")
            {
                MessageBox.Show("Please enter a Problem Description.", "Insufficient information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }          

            
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = _theConnection;

            _dbMan.SqlStatement = " insert into tbl_ProbCatagories values ('" + CatDescTxt.Text.ToString() + "' )\r\n";
            _dbMan.SqlStatement = _dbMan.SqlStatement + "   ";
            _dbMan.SqlStatement = _dbMan.SqlStatement + "  ";

            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);

            this.Close();
        }
    }
}
