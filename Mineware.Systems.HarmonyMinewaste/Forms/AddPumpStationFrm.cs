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
    public partial class AddPumpStationFrm : DevExpress.XtraEditors.XtraForm
    {
        public string _theConnection;
        public AddPumpStationFrm()
        {
            InitializeComponent();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.Text == "Add Pump Station")
            {
                MWDataManager.clsDataAccess _dbManSave7 = new MWDataManager.clsDataAccess();
                _dbManSave7.ConnectionString = _theConnection;
                _dbManSave7.SqlStatement = "";
                _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + " insert into tbl_PumpStations  \r\n";
                _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + " Values('" + DescTxt.Text + "', '" + SecCmb.SelectedText.ToString() + "')  \r\n ";
                _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + "   \r\n ";


                _dbManSave7.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManSave7.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManSave7.ExecuteInstruction();
            }
            else
            {
                MWDataManager.clsDataAccess _dbManSave7 = new MWDataManager.clsDataAccess();
                _dbManSave7.ConnectionString = _theConnection;
                _dbManSave7.SqlStatement = "";
                _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + " update tbl_PumpStations  \r\n";
                _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + " set section =  '" + SecCmb.SelectedText.ToString() + "' \r\n ";
                _dbManSave7.SqlStatement = _dbManSave7.SqlStatement + " where Description = '" + PumpLbl.Text + "'  \r\n ";


                _dbManSave7.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManSave7.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManSave7.ExecuteInstruction();
            }

            this.Close();

            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
        }

        private void AddPumpStationFrm_Load(object sender, EventArgs e)
        {
            ///ComboBox Dam
            ///
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = _theConnection;
            _dbMan.SqlStatement = "";
            _dbMan.SqlStatement = _dbMan.SqlStatement + " select distinct section from tbl_Planning   \r\n";
            _dbMan.SqlStatement = _dbMan.SqlStatement + "  \r\n ";
            _dbMan.SqlStatement = _dbMan.SqlStatement + "   \r\n ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            if (_dbMan.ResultsDataTable.Rows.Count > 0)
            {

                DataTable dt = _dbMan.ResultsDataTable;
                DataSet ds = new DataSet();
                if (ds.Tables.Count > 0)
                    ds.Tables.Clear();
                ds.Tables.Add(dt);

                DescTxt.Enabled = true;

                SecCmb.DataSource = ds.Tables[0];
                SecCmb.DisplayMember = "section";
                SecCmb.SelectedIndex = -1;



            }

            if (this.Text == "Edit Pump Station")           
            {
                MWDataManager.clsDataAccess _dbManEdit = new MWDataManager.clsDataAccess();
                _dbManEdit.ConnectionString = _theConnection;
                _dbManEdit.SqlStatement = "";
                _dbManEdit.SqlStatement = _dbManEdit.SqlStatement + " select * from tbl_PumpStations  \r\n";
                _dbManEdit.SqlStatement = _dbManEdit.SqlStatement + "  where description = '"+PumpLbl.Text.ToString()+"'\r\n ";
                _dbManEdit.SqlStatement = _dbManEdit.SqlStatement + "   \r\n ";
                _dbManEdit.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbManEdit.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbManEdit.ExecuteInstruction();

                if (_dbManEdit.ResultsDataTable.Rows.Count > 0)
                {

                    DataTable dt2 = _dbManEdit.ResultsDataTable;
                    DataSet ds2 = new DataSet();
                    if (ds2.Tables.Count > 0)
                        ds2.Tables.Clear();
                    ds2.Tables.Add(dt2);

                    DescTxt.Enabled = false;

                    DescTxt.Text = _dbManEdit.ResultsDataTable.Rows[0]["Description"].ToString();
                    
                    SecCmb.SelectedText = _dbManEdit.ResultsDataTable.Rows[0]["Section"].ToString();                



                }
            }
        }
    }
}
