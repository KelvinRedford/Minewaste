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
    public partial class frmCalType : DevExpress.XtraEditors.XtraForm
    {
        public string _theConnection;
        public frmCalType()
        {
            InitializeComponent();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CalTypeTxt.Text == "")
            {
                MessageBox.Show("Please enter the Calendar Type.", "Insufficient information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            MWDataManager.clsDataAccess _dbManDelete = new MWDataManager.clsDataAccess();
            _dbManDelete.ConnectionString = _theConnection;
            _dbManDelete.SqlStatement = " delete from tbl_Calendar_Code where calendarcode = '" + CalTypeTxt.Text + "' \r\n";            
            _dbManDelete.SqlStatement = _dbManDelete.SqlStatement + "  ";

            _dbManDelete.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbManDelete.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbManDelete.ExecuteInstruction();

            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = _theConnection;
            _dbMan.SqlStatement = " insert into tbl_Calendar_Code (calendarcode, Active) ";
            _dbMan.SqlStatement = _dbMan.SqlStatement + " VALUES ( '" + CalTypeTxt.Text + "', 'Y') ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);

            Close();

        }

        private void frmCalType_Load(object sender, EventArgs e)
        {
            //this.Icon = Mineware.Systems.Minewaste.Properties.Resources.button_teal;
        }
    }
}
