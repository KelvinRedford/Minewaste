using Mineware.Systems.Global;
using Mineware.Systems.GlobalConnect;
using Mineware.Systems.MinewasteGlobal;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Mineware.Systems.Minewaste.Controls
{
    public partial class ucSections : ucBaseUserControl
    {
        Procedures procs = new Procedures();
        public ucSections()
        {
            InitializeComponent();
        }

        private void ucSections_Load(object sender, EventArgs e)
        {
            //editProdmonth.EditValue = GlobalVar.ProdMonth;
            editProdmonth.EditValue = TMinewasteGlobal.ProdMonthAsDate(GlobalVar.ProdMonth.ToString());

        }



        private void LoadSections()
        {
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _dbMan.SqlStatement = "select a.*, b.description hierlvl  from [tbl_Section] a, tbl_Section_Hier b where a.HierID = b.HierID and prodmonth = '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "' order by a.HierID, sectionid " +
                                      " ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            DataTable dt = _dbMan.ResultsDataTable;

            SectionGrd.DataSource = dt;
            colSecId.FieldName = "SectionID";
            colSecName.FieldName = "Name";
            colHier.FieldName = "hierlvl";
            colRepTo.FieldName = "ReportToSectionid";

            colCross.FieldName = "CrossSectionid";


            btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            if (dt.Rows.Count < 1)
                btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


        }


        private void AddBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSection Sect = new frmSection();
            Sect._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            Sect.PM1lbl.Text = TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString();
            Sect.PMlbl.Text = TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString();

            Sect.ShowDialog();

            LoadSections();
        }





        private void bandedGridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            Sectionlbl.Text = bandedGridView2.GetRowCellValue(e.RowHandle, bandedGridView2.Columns[0]).ToString();
            Secnamelbl.Text = bandedGridView2.GetRowCellValue(e.RowHandle, bandedGridView2.Columns[1]).ToString();

            if (bandedGridView2.GetRowCellValue(e.RowHandle, bandedGridView2.Columns[4]) != null)
                Heirlbl.Text = bandedGridView2.GetRowCellValue(e.RowHandle, bandedGridView2.Columns[4]).ToString();
            else
                Heirlbl.Text = "";
            RepTolbl.Text = bandedGridView2.GetRowCellValue(e.RowHandle, bandedGridView2.Columns[3]).ToString();
        }

        private void EditBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Sectionlbl.Text == "Nothing")
            {
                MessageBox.Show("Please click on the grid to select Section.", "Insufficient information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                frmSection Sect = new frmSection();
                Sect._theConnection = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
                Sect.PM1lbl.Text = TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString();
                Sect.PMlbl.Text = TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString();
                Sect.SecIDTxt.Text = Sectionlbl.Text;
                Sect.SecNameTxt.Text = Secnamelbl.Text;
                Sect.Heirlbl.Text = Heirlbl.Text;
                Sect.Reptolbl.Text = RepTolbl.Text;

                Sect.SecIDTxt.Enabled = false;

                Sect.ShowDialog();

                LoadSections();

            }

        }

        private void btnCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = TConnections.GetConnectionString(theSystemDBTag, UserCurrentInfo.Connection);
            _dbMan.SqlStatement = "insert into tbl_section select '" + TMinewasteGlobal.ProdMonthAsString(Convert.ToDateTime(editProdmonth.EditValue)).ToString() + "',[SectionID],[Name],[SectionCode],[ReportToSectionid] " +
                                  " ,[HierID] ,[HierType],[CrossSectionid] from tbl_section where prodmonth = " +
                                  " (select MAX(prodmonth) pm from tbl_section) ";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();

            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
            LoadSections();
        }

        private void editProdmonth_EditValueChanged(object sender, EventArgs e)
        {
            LoadSections();
        }
    }
}
