using DevExpress.XtraEditors;
using Mineware.Menu.Structure;
using Mineware.Systems.Global;
using Mineware.Systems.Global.ReportsControls;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Mineware.Systems.GlobalConnect;
using Mineware.Systems.HarmonyPASGlobal;
using Mineware.Plugin.Interface;

namespace Mineware.Systems.Safety
{
    public class Safety : PluginInterface
    {
        public string systemTag;

        private SafetyMenuStructure SafetyMenu = new SafetyMenuStructure();

        public string SystemTag
        {
            get
            {
                return SafetyResource.systemTag;
            }
        }

        public string SystemDBTag
        {
            get
            {
                return SafetyResource.systemDBTag;

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


        public mainMenu getMenuStructure()
        {
            return SafetyMenu.theMenu;
        }

        public List<clsParameters> getParameters()
        {
            var parameters = new List<clsParameters>();
            var section = THarmonyPASGlobal.UserInfo.FirstOrDefault().ReportSections.FirstOrDefault();
            parameters.Add(new clsParameters()
            {
                ParameterName = "Section Id",
                Value = section
            });
            return parameters;
        }

        public DevExpress.XtraEditors.TileItem getMainMenuItem()
        {
            int theLevel = TUserInfo.theSecurityLevel(THarmonyPASGlobal.HarmonyPasMenuStructure.miPAS_HPAS_MinewareSystemsHarmonyPAS.ItemID);
            if (theLevel > 0)
            {
                var theResult = new TileItem();
                var imageServices = SafetyResource.SafetyStart48x48;
                theResult.Text = "<size=20>HRM</size>";
                theResult.TextAlignment = TileItemContentAlignment.TopLeft;
                theResult.AppearanceItem.Normal.BackColor = Color.FromArgb(255, 140, 0);
                theResult.AppearanceItem.Normal.BackColor2 = Color.FromArgb(255, 165, 0);
                theResult.AppearanceItem.Normal.BorderColor = Color.Transparent;
                theResult.ImageAlignment = TileItemContentAlignment.BottomRight;
                theResult.Image = imageServices;
                theResult.Tag = SafetyResource.systemTag;
                theResult.ItemSize = TileItemSize.Wide;
                return theResult;
            }
            else
            {
                return null;
            }
        }

        public Image getMenuItemImageSmall(string itemID)
        {
            return null;
        }


      

        public ucReportSettingsControl getReportSettings(string itemID)
        {

            ucReportSettingsControl theResult = new ucReportSettingsControl();

            //if (itemID == SafetyMenu.miCheckListReport_SAFCheckListReport_MinewareSystemsSafety.ItemID)
            //{
            //    theResult = new Reports.CheckListReport.CheckListReportUserControl(); 
            //}
            //else
            //{
                //if (itemID == SafetyMenu.miAuditsAuthorizationReport_SAFDailyManagement_MinewareSystemsSafety.ItemID)
                //{

                //    theResult = new Reports.AuditsAuthorizationReport.ucAuditsAuthorizationReport();  
                //}

                if (itemID == SafetyMenu.miGenericReport_SAFGenericRep_MinewareSystemsSafety.ItemID)
                {
                    theResult = new Reports.GenericReport.ucGenericReport();
                }

                //if (itemID == SafetyMenu.miWorkplacesAuditedNotAudited_SAFWPAudit_MinewareSystemsSafety.ItemID)
                //{
                //    theResult = new Reports.WorkplaceNotAudited.ucWorkplaceNotAudited();
                //}

                if (itemID == SafetyMenu.miActionManagerReport_SAFActionManagerReport_MinewareSystemsSafety.ItemID)
                {
                    theResult = new Reports.ActionManagerReport.ucActionManagerReport(); 
                }
            //}
            return theResult;
                
            
        }      
       

        public ucBaseUserControl getMenuItem(string itemID)
        {
            ucBaseUserControl theResult = new ucBaseUserControl();

            //Daily Capture - Planning
            if (SafetyMenu.miOCRSchedular_SAFOCRSched_MinewareSystemsSafety.ItemID == itemID)
            {
                theResult = new Controls.Daily_Capture.Planning.ucPlanning();
            }


            //Line Actions

            if (SafetyMenu.miOpenActions_SAFOpenActions_MinewareSystemsSafety.ItemID == itemID)
            {
                theResult = new Controls.ActionManager.ucMainPage();
            }            


            //GeoStructure & Workplaces
            if (SafetyMenu.miGeoStructure_SAFGeoStruct_MinewareSystemsSafety.ItemID == itemID)
            {
                theResult = new Controls.SystemAdmin.GeoStructure.ucGeoStructure();
            }            
            if (SafetyMenu.miWorkplaces_SAFWP_MinewareSystemsSafety.ItemID == itemID)
            {
                theResult = new Controls.SystemAdmin.Workplaces.ucWorkplaces();
            }

            //Other Setup Codes
            if (SafetyMenu.miActivities_SAFActivities_MinewareSystemsSafety.ItemID == itemID)
            {
                theResult = new Controls.SystemAdmin.Activities.ucActivities();
            }
            if (SafetyMenu.miThresholds_SAFThresholds_MinewareSystemsSafety.ItemID == itemID)
            {
                theResult = new Controls.SystemAdmin.Thresholds.ThresholdsUserControl();
            }


            //Users
            if (SafetyMenu.miAdditionalUsers_SAFUsers_MinewareSystemsSafety.ItemID == itemID)
            {
                theResult = new Controls.SystemAdmin.Users.ucUsers();
            }



            return theResult;
        }

        public ucBaseUserControl getStartScreen()
        {
            return new Controls.DashBoard.ucDashBoard();
        }

        public string getSystemDBTag()
        {
            return SafetyResource.systemDBTag;
        }

        public string getSystemTag()
        {
            return SafetyResource.systemTag;
        }

        public global::DevExpress.XtraNavBar.NavBarItem getUserSettingsNavBarItem()
        {
            var theResult = new DevExpress.XtraNavBar.NavBarItem() { Caption = "Line Action Manager", Tag = SafetyResource.systemTag };
            return theResult;
        }

        public ucBaseUserControl getUserSettingsScreen(ScreenStatus _theScreenStatus, string _userID, TUserCurrentInfo userInfo, string theConnection)
        {          
            return null;
        }

        public void InitializeModule()
        {
            THarmonyPASGlobal.HarmonyPasMenuStructure.setMenuItems();
            THarmonyPASGlobal.HarmonyPasMenuStructure.theMenu.systemDBTag = SafetyResource.systemDBTag;
            THarmonyPASGlobal.HarmonyPasMenuStructure.theMenu.systemTag = SafetyResource.systemTag;
        }

        public void LoggedOn()
        {
            // Use this section to load all module settings like user logon info or production info
            //THarmonyPASGlobal.get(resHarmonyPAS .systemDBTag,TUserInfo .Connection );
            THarmonyPASGlobal.SetProductionGlobalInfo(SafetyResource.systemDBTag);
            THarmonyPASGlobal.getSystemSettingsProductionInfo(SafetyResource.systemDBTag);
            THarmonyPASGlobal.SetUserInfo(SafetyResource.systemDBTag);
            //THarmonyPASGlobal.getUserInfo(resHarmonyPAS.systemDBTag);
        }


        //public ucBaseUserControl getUserSettingsScreen(ScreenStatus _theScreenStatus, string _userID, TUserCurrentInfo userInfo, string theConnection)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<clsParameters> getParameters()
        //{
        //    List<clsParameters> theResult = new List<clsParameters>();
        //    clsParameters p1 = new clsParameters() { ParameterName = "Prodmonth", Value = "201505" };
        //    theResult.Add(p1);
        //    return theResult;
        //}


    }
}
