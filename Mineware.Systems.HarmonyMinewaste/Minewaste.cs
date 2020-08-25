using System.Collections.Generic;
using System.Linq;
using Mineware.Menu.Structure;
using DevExpress.XtraEditors;
using System.Drawing;
using Mineware.Systems.GlobalConnect;
using Mineware.Plugin.Interface;
using Mineware.Systems.Global;
using Mineware.Systems.Global.ReportsControls;
using System;
using Mineware.Systems.MinewasteGlobal;

namespace Mineware.Systems.Minewaste
{
    class Minewaste : PluginInterface
    {
        public string SystemTag
        {
            get
            {
                return MinewasteResource.systemTag;
            }
        }

        public string SystemDBTag
        {
            get
            {
                return MinewasteResource.systemDBTag;

            }
        }     

      
        static void Main(string[] args)
        {
        }

        public global::DevExpress.XtraNavBar.NavBarItem getApplicationSettingsNavBarItem()
        {
            return null;
        }

        public ucBaseUserControl getApplicationSettingsScreen()
        {
            return null;
        }

        public ucBaseUserControl getMainMenuAdditionalItem()
        {
            //ucBaseUserControl TheResult = new ucBaseUserControl();
            return null;
        }

        public TileItem getMainMenuItem()
        {
            int theLevel = TUserInfo.theSecurityLevel(TMinewasteGlobal.MinewasteMenuStructure.miMinewaste_Minewaste_MinewareSystemsMinewaste.ItemID);
            if (theLevel > 0)
            {
                var theResult = new TileItem();
                var imageServices = Properties.Resources.IMS48x48;
                theResult.Text = "<size=20>Minewaste</size>";
                theResult.TextAlignment = TileItemContentAlignment.TopLeft;
                theResult.AppearanceItem.Normal.BackColor = Color.FromArgb(255,0,0);
                theResult.AppearanceItem.Normal.BackColor2 = Color.FromArgb(255, 0, 0);
                theResult.AppearanceItem.Normal.BorderColor = Color.Transparent;
                theResult.ImageAlignment = TileItemContentAlignment.BottomRight;
                theResult.Image = imageServices;
                theResult.Tag = MinewasteResource.systemTag;
                theResult.ItemSize = TileItemSize.Wide;
                return theResult;

               
            }
           

            //int theLevel2 = TUserInfo.theSecurityLevel(THarmonyPASGlobal.SafetyMenuStruct.miHRM_SAF_MinewareSystemsHarmonyHRM.ItemID);
            //if (theLevel2 > 0)
            //{
            //    var theResult2 = new TileItem();
            //    var imageServices2 = resHarmonyPAS.SafetyStart48x48;
            //    theResult2.Text = "<size=20>Human Resources Management</size>";
            //    theResult2.TextAlignment = TileItemContentAlignment.TopLeft;
            //    theResult2.AppearanceItem.Normal.BackColor = Color.FromArgb(285, 0, 0);
            //    theResult2.AppearanceItem.Normal.BackColor2 = Color.FromArgb(285, 0, 0);
            //    theResult2.AppearanceItem.Normal.BorderColor = Color.Transparent;
            //    theResult2.ImageAlignment = TileItemContentAlignment.BottomRight;
            //    theResult2.Image = imageServices2;
            //    theResult2.Tag = resHarmonyPAS.systemTag;
            //    theResult2.ItemSize = TileItemSize.Wide;
            //    return theResult2;
            //}
            else
            {
                return null;
            }
        }

        public ucBaseUserControl getMenuItem(string itemID)
        {
            ucBaseUserControl theResult = new ucBaseUserControl();

            if (TMinewasteGlobal.MinewasteMenuStructure.miBookings_MinewasteBookings_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucBookings();
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miPlanning_MinewastePlanning_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucPlanning();
            }
            
            ///System Admin
            if (TMinewasteGlobal.MinewasteMenuStructure.miSections_MinewasteSettingsSections_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucSections();
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miPumpStationProbCategories_MinewasteSettingsPumpStationProbCat_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucProbCatPumpStation();
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miPumpStationProblems_MinewasteSettingsPumpStationProbs_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucProblemPump();
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miCalendarDurations_MinewasteSettingsCalDurations_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucCalndarsAssign();
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miOperationShifts_MinewasteSettingsOppShifts_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucCalendars();
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miProblemCategories_MinewasteSettingsProbCategories_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucProbCat();
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miProblems_MinewasteSettingsProblems_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucProblems();
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miPumpStations_MinewasteSettingsPumpStations_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucPumpStationSetup();
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miReportFooters_MinewasteSettingsRepFooter_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucReportSignatures();
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miUserRights_MinewasteSettingsUserRights_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucSetupUsers();
            }

            ///Reports
            if (TMinewasteGlobal.MinewasteMenuStructure.miPlanningReportGunHours_MinewasteReportsPlanGunHrs_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucReportsViewer("Planning Report Gun Hours");
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miRunningHoursPerShift_MinewasteReportsRunHrsShift_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucReportsViewer("Running Hours per Shift");
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miRunningHoursDowntime_MinewasteReportsRunHrsDownTime_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucReportsViewer("Running Hours Downtime");
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miTonnesRemined_MinewasteReportsTonsRemined_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucReportsViewer("Tonnes Re-Mined");
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miTonnesRemined_MinewasteReportsTonsRemined_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucReportsViewer("Pump Station Downtime");
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miRunningHours_MinewasteReportsRunHrs_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucReportsViewer("Running Hours");
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miComplianceToPlan_MinewasteReportsCompToPlan_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucReportsViewer("Compliance to Plan");
            }
            if (TMinewasteGlobal.MinewasteMenuStructure.miPlanningReport_MinewasteReportsPlanReport_MinewareSystemsMinewaste.ItemID == itemID)
            {
                theResult = new Controls.ucReportsViewer("Planning Report");
            }
            
            return theResult;


        }

        public mainMenu getMenuStructure()
        {
            return TMinewasteGlobal.MinewasteMenuStructure.theMenu;
        }

        //public mainMenuSafety GetMenuSafety()
        //{
        //    return THarmonyPASGlobal.SafetyMenuStruct.theMenu;
        //}

        public List<clsParameters> getParameters()
        {
	        var parameters = new List<clsParameters>();
			var section = TMinewasteGlobal.UserInfo.FirstOrDefault().ReportSections.FirstOrDefault();
	        parameters.Add(new clsParameters()
	        {
		        ParameterName = "Section Id",
		        Value = section
	        });
	        return parameters;
        }

        public ReportSettings getReportSettings(string itemID)
        {
            ReportSettings theResult = new ReportSettings();

            //if (THarmonyPASGlobal.HarmonyPasMenuStructure.miPlanningProtocolReport_HPASPlanningProtocolReport_MinewareSystemsHarmonyPAS.ItemID == itemID)
            //{
            //    theResult = new ucPlanningProtocolReport();
            //}

            theResult = null;

            return theResult;
            

        }

        public ucBaseUserControl getStartScreen()
        {
            return new Controls.Dashboard.ucDashboard();
            
        }

        public string getSystemDBTag()
        {
            return MinewasteResource.systemDBTag;
        }

        public string getSystemTag()
        {
            return MinewasteResource.systemTag;
        }

        public global::DevExpress.XtraNavBar.NavBarItem getUserSettingsNavBarItem()
        {
            var theResult = new DevExpress.XtraNavBar.NavBarItem() { Caption = "Minewaste", Tag = MinewasteResource.systemTag };
            return theResult;
        }

        public ucBaseUserControl getUserSettingsScreen(ScreenStatus _theScreenStatus, string _userID, TUserCurrentInfo userInfo, string theConnection)
        {   
            Controls.Users.UserProductionSettingsUserControl theResult = 
                    new Controls.Users.UserProductionSettingsUserControl() { theScreenStatus = _theScreenStatus, UserID = _userID, theSystemDBTag = MinewasteResource.systemDBTag, theSystemTag = MinewasteResource.systemTag, UserCurrentInfo = userInfo };
            theResult.currentConnection = theConnection;
            return theResult;
        }

        public void InitializeModule()
        {

            TMinewasteGlobal.MinewasteMenuStructure.setMenuItems();            
            TMinewasteGlobal.MinewasteMenuStructure.theMenu.systemDBTag = MinewasteResource.systemDBTag;
            TMinewasteGlobal.MinewasteMenuStructure.theMenu.systemTag = MinewasteResource.systemTag;          

        }

        public void LoggedOn()
        {
            // Use this section to load all module settings like user logon info or production info
            //THarmonyPASGlobal.get(resHarmonyPAS .systemDBTag,TUserInfo .Connection );            
            TMinewasteGlobal.SetProductionGlobalInfo(MinewasteResource.systemDBTag);
            TMinewasteGlobal.getSystemSettingsProductionInfo(MinewasteResource.systemDBTag);
            TMinewasteGlobal.SetUserInfo(MinewasteResource.systemDBTag);
            TMinewasteGlobal.getUserInfo(MinewasteResource.systemDBTag);
            



        }

    }


}
