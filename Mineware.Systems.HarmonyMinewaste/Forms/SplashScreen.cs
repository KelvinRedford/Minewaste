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

using System.IO;
using System.Data;

using DevExpress.XtraSplashScreen;

using System.Threading;
using System.Globalization;
using Microsoft.Win32;
using System.Diagnostics;

using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Management.Automation.Host;
using DevExpress.XtraEditors;


namespace HIMS
{
    public partial class SplashScreen : DevExpress.XtraEditors.XtraForm
    {
        string[] theArgs;

        //string ConnLoc = "N";


        public SplashScreen()
        {
            //theArgs = args;
            InitializeComponent();
        }

     

        public void LogonProc()
        {
            //if (ConnLoc == "N")
            //{
            label1.Visible = false;
            label4.Visible = false;
            UsernameTxt.Visible = false;
            PasswordTxt.Visible = false;
            LogonBtn.Visible = false;
            CloseBtn.Visible = false;

            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
                _dbMan.ConnectionString = ConfigurationSettings.AppSettings["SQLConnectionStr"];

                _dbMan.SqlStatement = "select * from tbl_Users " +
                                          "where UserID = '" + Environment.UserName + "'";
                _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
                _dbMan.ExecuteInstruction();
                DataTable SubA = _dbMan.ResultsDataTable;

                if (SubA.Rows.Count > 0)
                {
                this.Hide();
                Classes.MainScreen MainScreen = new Classes.MainScreen();
                        this.Hide();
                      //  this.Close();
                        MainScreen.labName.Text = Environment.UserName;
                        MainScreen.LocalIndLbl.Text = "N";
                        MainScreen.ShowDialog(this);
                        this.Close();            

                }
                else
                {
                    label1.Visible = true;
                    label4.Visible = true;
                    UsernameTxt.Visible = true;
                    PasswordTxt.Visible = true;
                    LogonBtn.Visible = true;
                    CloseBtn.Visible = true;

                    progressPanel1.Visible = false;
                    //MessageBox.Show("User not found. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //LogonBtn.Enabled = true;
                }

            //}
            //else
            //{

            //    string[] lines = System.IO.File.ReadAllLines(@"C:\Mineware.Systems.HarmonyMinewasteLocalDataFiles\WriteLines.txt");

            //    // Display the file contents by using a foreach loop.

            //    foreach (string line in lines)
            //    {
            //        // Use a tab to indent each line of the file.

            //        if (line == Environment.UserName)
            //        {
            //            string UserExists = "true";

            //            Classes.MainScreen MainScreen = new Classes.MainScreen();
            //            //this.Hide();
            //            MainScreen.labName.Text = clsUserInfo.UserName;
            //            MainScreen.LocalIndLbl.Text = "Y";
            //            MainScreen.ShowDialog();
            //            //this.Close();

            //        }
            //    }


            //}

            

        }

        private void LogonBtn_Click(object sender, EventArgs e)
        {
            

            

        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            UsernameLbl.Text = Environment.UserName;

            timer1.Tick += new EventHandler(timer1_Tick); // Everytime timer ticks, timer_Tick will be called
            timer1.Interval = (1000) * (1);              // Timer will tick evert second
            timer1.Enabled = true;                       // Enable the timer
            timer1.Start();

            ////UserDetailControl.Visible = false;
            //UserDetailPnl.Controls.Clear();
            //Cursor = Cursors.WaitCursor;
            //HIMS.Classes.ucLoading Tiles = new HIMS.Classes.ucLoading();
            //UserDetailPnl.Controls.Add(Tiles);
            //Tiles.Dock = DockStyle.Fill;


            //UsernameLbl.Text = Environment.UserName;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //this.WindowState = FormWindowState.Maximized;

            string machine = SystemInformation.ComputerName;

            if (machine == "DESKTOP-SRNAB4N")
            {
                //UsernameTxt.Text = "MINEWARE";
                //PasswordTxt.Text = "annelie";
            }


            //string[] lines = { "First line", "Second line", "Third line" };
            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            //System.IO.File.WriteAllLines(@"C:\Mineware.Systems.HarmonyMinewasteLocalDataFiles\WriteLines.txt", lines)

           



        }



        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PasswordTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TopDockPnl_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            //if (e.Button == TopDockPnl.CustomHeaderButtons[0])
            //Application.Exit();

            //if (e.Button == TopDockPnl.CustomHeaderButtons[1])
            //{
            //    try
            //    {
            //        System.Diagnostics.Process[] remoteByName = System.Diagnostics.Process.GetProcessesByName("vpncli");
            //        if (remoteByName.Length == 0)
            //        {

            //            var newProcessInfo = new System.Diagnostics.ProcessStartInfo();
            //            newProcessInfo.FileName = @"C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe";
            //            newProcessInfo.Arguments = @"C:\Mineware.Systems.HarmonyMinewasteLocalDataFiles\VpnConnect.ps1";
            //            newProcessInfo.Verb = "runas";
            //            newProcessInfo.CreateNoWindow = true;
            //            newProcessInfo.UseShellExecute = false;
            //            System.Diagnostics.Process.Start(newProcessInfo);

            //            //lueConnections.Text = "Cisco AnyConnect VPN Client";
            //            //LogonProc();


            //        }


            //    }
            //    catch
            //    {
            //        Console.WriteLine("Error:  While processing the request (Please check your internet connection.)");
            //        Console.ReadLine();

            //    }
            //}
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
           

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        int count = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            count = count + 1;
            
            if (count == 2)
            {
                LogonProc();
                this.Hide();
            }

           
        }

        private void TopDockPnl_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LogonBtn_Click_1(object sender, EventArgs e)
        {
            

            Logon();
            //this.Close();
        }

        void Logon()
        {
            MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            _dbMan.ConnectionString = ConfigurationSettings.AppSettings["SQLConnectionStr"];

            _dbMan.SqlStatement = "select * from tbl_Users " +
                                      "where UserID = '" + UsernameTxt.Text + "' and password = '" + PasswordTxt.Text + "'";
            _dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            _dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            _dbMan.ExecuteInstruction();
            DataTable SubA = _dbMan.ResultsDataTable;

            if (SubA.Rows.Count > 0)
            {

                SplashScreen Mainfrm;
                Mainfrm = (SplashScreen)this.FindForm();
                Mainfrm.WindowState = FormWindowState.Minimized;
                //alertControl1.Show(Mainfrm, "Notification", "Record Saved Successfuly.");

                Classes.MainScreen MainScreen = new Classes.MainScreen();
                this.Hide();
                this.Close();
                //Classes.MainScreen Spla = new Classes.MainScreen();
                //SplashScreen.WindowState = FormWindowState.Minimized;
                MainScreen.labName.Text = UsernameTxt.Text;
                MainScreen.LocalIndLbl.Text = "N";

                //SplashScreen Splash = new SplashScreen();
                //Splash.WindowState = FormWindowState.Minimized;

                //Application.Run(new Classes.MainScreen());
                //this.Hide();

                MainScreen.ShowDialog();
               



            }
            else
            {

                MessageBox.Show("User not found. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LogonBtn.Enabled = false;
            }
        }

        private void UsernameTxt_TextChanged(object sender, EventArgs e)
        {
            LogonBtn.Enabled = true;
        }

        private void PasswordTxt_TextChanged_1(object sender, EventArgs e)
        {
            LogonBtn.Enabled = true;
        }

        private void PasswordTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                //LogonProc();
                Logon();
            }
        }
    }
}
