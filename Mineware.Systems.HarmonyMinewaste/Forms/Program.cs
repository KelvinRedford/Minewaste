using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

using System.Configuration;
using System.Threading;
using System.Globalization;
using Microsoft.Win32;
using System.Diagnostics;
//using Mineware.Systems.Global.sysMessages;

namespace HIMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) 
        {
            Application.EnableVisualStyles();

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            //UserLookAndFeel.Default.SetSkinStyle(ConfigurationManager.AppSettings["DevExpress Dark Style"]);
            UserLookAndFeel.Default.SetSkinStyle("Office 2013");
            //UserLookAndFeel.Default.SetSkinMaskColors(System.Drawing.Color.FromArgb(0xF5, 0xF3, 0xFB), System.Drawing.Color.Blue);
            //Application.Run(new Classes.MainScreen(args));


            Application.Run(new SplashScreen());


        }
    }
}
