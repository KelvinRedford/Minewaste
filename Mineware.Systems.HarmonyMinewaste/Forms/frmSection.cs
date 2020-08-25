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
    public partial class frmSection : DevExpress.XtraEditors.XtraForm
    {
        public string _theConnection;
        public frmSection()
        {
            InitializeComponent();
        }

        Mineware.Systems.Minewaste.GlobalItems procs = new Mineware.Systems.Minewaste.GlobalItems();

        private void frmSection_Load(object sender, EventArgs e)
        {
            //this.Icon = Mineware.Systems.Minewaste.Properties.Resources.button_teal;

            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = _theConnection;

            _dbMan.SqlStatement = "select * from tbl_Section_Hier order by HierID  " +
                                      " ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();
          
            DataTable dt = _dbMan.ResultsDataTable;
            int x = 0;
            int y = -1;
            foreach (DataRow dr in dt.Rows)
            {
                HierLst.Items.Add(dr["Description"].ToString());

                if (dr["Description"].ToString() == Heirlbl.Text)
                    y = x;

                x = x + 1;

            }

            HierLst.SelectedIndex = y;
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SecIDTxt.Text == "")
            {
                MessageBox.Show("Please enter a Section.", "Insufficient information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (HierLst.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter a Hierarchical ID.", "Insufficient information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string Reportto = "";
                
            if (Reporttocmd.Text != "")
                Reportto = procs.ExtractBeforeColon(Reporttocmd.Text);

            int Heir = HierLst.SelectedIndex + 1;

            if (SecIDTxt.Enabled == true)
            {
                MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
                _dbMan.ConnectionString = _theConnection;
                _dbMan.SqlStatement = "INSERT INTO [dbo].[tbl_Section] VALUES ('" + PM1lbl.Text + "', '" + SecIDTxt.Text + "', '" + SecNameTxt.Text + "' , 'Pro' ";

                if (HierLst.SelectedIndex > 0)
                    _dbMan.SqlStatement = _dbMan.SqlStatement + ", '" + Reportto + "'  ";
                else
                    _dbMan.SqlStatement = _dbMan.SqlStatement + ", null  ";

                _dbMan.SqlStatement = _dbMan.SqlStatement + ", '" + Heir + "' , 'Pro', null) ";
                _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan.ExecuteInstruction();
            }
            else
            {
                MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
                _dbMan.ConnectionString = _theConnection;
                _dbMan.SqlStatement = "update [tbl_Section] set name = '" + SecNameTxt.Text + "'  ";

                if (HierLst.SelectedIndex > 0)
                    _dbMan.SqlStatement = _dbMan.SqlStatement + ", reporttosectionid =  '" + Reportto + "'  ";
                else
                    _dbMan.SqlStatement = _dbMan.SqlStatement + ",reporttosectionid = null ";

                _dbMan.SqlStatement = _dbMan.SqlStatement + ", hierid = '" + Heir + "'  where sectionid = '" + SecIDTxt.Text + "' and prodmonth = '" + PM1lbl.Text + "' ";
                _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan.ExecuteInstruction();


            }


            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
            Close();

        }

        private void HierLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttocmd.Items.Clear();

            int aa = HierLst.SelectedIndex;
            aa = aa;


            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = _theConnection;

            _dbMan.SqlStatement = "select * from [tbl_Section] where prodmonth = '" + PM1lbl.Text + "' ";
            _dbMan.SqlStatement = _dbMan.SqlStatement + "and hierid = '" + aa + "' order by sectionid  ";
                                     
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            DataTable dt = _dbMan.ResultsDataTable;
            int x = 0;
            int y = -1;
           
            foreach (DataRow dr in dt.Rows)
            {
                Reporttocmd.Items.Add(dr["sectionid"].ToString()+':'+ dr["name"].ToString());
                if (dr["sectionid"].ToString() == Reptolbl.Text)
                  y = x; 
                x = x + 1;
            }
            Reporttocmd.SelectedIndex = y;

            if (SecIDTxt.Enabled == true)
            {
                Reporttocmd.Text = "";
                if (Reporttocmd.Items.Count > 0)
                    Reporttocmd.SelectedIndex = 0;
            }

        }
    }
}
