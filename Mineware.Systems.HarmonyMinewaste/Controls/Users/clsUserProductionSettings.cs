using Mineware.Systems.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Mineware.Systems.GlobalConnect;
using Mineware.Systems.Minewaste;

namespace Mineware.Systems.Minewaste.Controls.Users
{
    class clsUserProductionSettings : IDisposable
    {
        public TUserCurrentInfo UserCurrentInfo = new TUserCurrentInfo();
        private MWDataManager.clsDataAccess TheData = new MWDataManager.clsDataAccess();
        private StringBuilder sb = new StringBuilder();
        private Mineware.Systems.Global.sysMessages.sysMessagesClass myMessage = new Global.sysMessages.sysMessagesClass();

        public DataTable getUserSections(string userID, string type)
        {
            return null;
        }
        public DataTable getUserInfo(string userID)
        {
            return null;
        }



        public bool SaveUserSettings(DataTable userInfo,string userID)
        {
            bool theResult = false;
            TheData.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            TheData.queryReturnType = MWDataManager.ReturnType.DataTable;
            TheData.ConnectionString = TConnections.GetConnectionString(MinewasteResource.systemDBTag, this.UserCurrentInfo.Connection);
            TheData.SqlStatement = "SELECT * FROM USERS WHERE UserID = '" + userID + "'";
            TheData.ExecuteInstruction();

            string _wpproduction;
            string _wpsurface;
            string _wpunderground;
            string _wpeditname;
            string _wpeditattribute;
            string _wpclassify;

            if (TheData.ResultsDataTable.Rows.Count == 1)
            {
                sb.Clear();
                foreach (DataRow dr in userInfo.Rows)
                {
                    _wpproduction = "N";
                    _wpsurface = "N";
                    _wpunderground = "N";
                    _wpeditname = "N";
                    _wpeditattribute = "N";
                    _wpclassify = "N";
                    if (Convert.ToBoolean(dr["WPProduction"].ToString()) == true)
                        _wpproduction = "Y";
                    if (Convert.ToBoolean(dr["WPSurface"].ToString()) == true)
                        _wpsurface = "Y";
                    if (Convert.ToBoolean(dr["WPUnderGround"].ToString()) == true)
                        _wpunderground = "Y";
                    if (Convert.ToBoolean(dr["WPEditName"].ToString()) == true)
                        _wpeditname = "Y";
                    if (Convert.ToBoolean(dr["WPEditAttribute"].ToString()) == true)
                        _wpeditattribute = "Y";
                    if (Convert.ToBoolean(dr["WPClassify"].ToString()) == true)
                        _wpclassify = "Y";
                    try
                    {
                        sb.AppendLine("UPDATE [dbo].[USERS]");
                        sb.AppendLine("   SET [BackDateBooking] = " + dr["BackDateBooking"].ToString());
                        sb.AppendLine("      ,[DaysBackdate] = " + dr["DaysBackdate"].ToString());                       
                        sb.AppendLine("      ,[WPProduction] = '" + _wpproduction+"' ");
                        sb.AppendLine("      ,[WPSurface] = '" + _wpsurface + "' ");
                        sb.AppendLine("      ,[WPUnderGround] = '" + _wpunderground + "' ");
                        sb.AppendLine("      ,[WPEditName] = '" + _wpeditname + "' ");
                        sb.AppendLine("      ,[WPEditAttribute] = '" + _wpeditattribute + "' ");
                        sb.AppendLine("      ,[WPClassify] = '" + _wpclassify + "' ");
                        sb.AppendLine(" WHERE [UserID] = '" + userID + "'");

                        TheData.SqlStatement = sb.ToString();

                        TheData.ExecuteInstruction();
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "EDIT USER SETTINGS", userID, UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "EDIT USER BACK DATED BOOKINGS", userID + " : " + dr["BackDateBooking"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "EDIT USER WP PRODUCTION", userID + " : " + dr["WPProduction"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "EDIT USER WP SURFACE", userID + " : " + dr["WPSurface"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "EDIT USER WP UNDERGROUND", userID + " : " + dr["WPUnderGround"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "EDIT USER WP EDIT NAME", userID + " : " + dr["WPEditName"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "EDIT USER WP EDIT ATTRIBUTE", userID + " : " + dr["WPEditAttribute"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "EDIT USER CLASSIFY", userID + " : " + dr["WPClassify"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "EDIT USER ALLOW BACKDATED BOOKINGS", userID + " : " + dr["BackDateBooking"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "EDIT USER ALLOW DAYS BACKDATED BOOKINGS", userID + " : " + dr["DaysBackdate"].ToString(), UserCurrentInfo.Connection);
                        theResult = true;
                    }
                    catch (Exception e)
                    {
                        myMessage.viewMessage(MessageType.Error, "Error Saving User", MinewasteResource.systemName, "DL_Users", "SaveUserSettings", e.Message, ButtonTypes.OK, MessageDisplayType.FullScreen);
                        theResult = false;
                    }
                }

            } // update
            else
            {
                sb.Clear();
                foreach (DataRow dr in userInfo.Rows)
                {
                    _wpproduction = "N";
                    _wpsurface = "N";
                    _wpunderground = "N";
                    _wpeditname = "N";
                    _wpeditattribute = "N";
                    _wpclassify = "N";
                    if (Convert.ToBoolean(dr["WPProduction"].ToString()) == true)
                        _wpproduction = "Y";
                    if (Convert.ToBoolean(dr["WPSurface"].ToString()) == true)
                        _wpsurface = "Y";
                    if (Convert.ToBoolean(dr["WPUnderGround"].ToString()) == true)
                        _wpunderground = "Y";
                    if (Convert.ToBoolean(dr["WPEditName"].ToString()) == true)
                        _wpeditname = "Y";
                    if (Convert.ToBoolean(dr["WPEditAttribute"].ToString()) == true)
                        _wpeditattribute = "Y";
                    if (Convert.ToBoolean(dr["WPClassify"].ToString()) == true)
                        _wpclassify = "Y";
                    sb.AppendLine("INSERT INTO [dbo].[USERS]");
                    sb.AppendLine("           ([UserID]");
                    sb.AppendLine("           ,[BackDateBooking]");
                    sb.AppendLine("           ,[DaysBackdate]");
                    sb.AppendLine("           ,[WPProduction]");
                    sb.AppendLine("           ,[WPSurface]");
                    sb.AppendLine("           ,[WPUnderGround]");                    
                    sb.AppendLine("           ,[WPEditName]");
                    sb.AppendLine("           ,[WPEditAttribute]");
                    sb.AppendLine("           ,[WPClassify])");
                    sb.AppendLine("     VALUES");
                    sb.AppendLine("           ('" + userID + "'");
                    sb.AppendLine("           ," + dr["BackDateBooking"].ToString());
                    sb.AppendLine("           ," + dr["DaysBackdate"].ToString());
                    sb.AppendLine("           ,'" + _wpproduction+"' ");
                    sb.AppendLine("           ,'" + _wpsurface + "' ");
                    sb.AppendLine("           ,'" + _wpunderground + "' ");
                    sb.AppendLine("           ,'" + _wpeditname + "' ");
                    sb.AppendLine("           ,'" + _wpeditattribute + "' ");
                    sb.AppendLine("           ,'" + _wpclassify + "') ");

                    TheData.SqlStatement = sb.ToString();
                    try
                    {
                        TheData.ExecuteInstruction();
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "NEW USER SETTINGS", userID, UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "NEW USER BACK DATED BOOKINGS", userID + " : " + dr["BackDateBooking"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "NEW USER ALLOW BACKDATED BOOKINGS", userID + " : " + dr["BackDateBooking"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "NEW USER WP PRODUCTION", userID + " : " + dr["WPProduction"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "NEW USER WP SURFACE", userID + " : " + dr["WPSurface"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "NEW USER WP UNDERGRUND", userID + " : " + dr["WPUnderGround"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "NEW USER WP EDIT NAME", userID + " : " + dr["WPEditName"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "NEW USER WP EDIT ATTRIBUTE", userID + " : " + dr["WPEditAttribute"].ToString(), UserCurrentInfo.Connection);
                        TUserInfo.ActionLog(MinewasteResource.systemTag, "NEW USER WP CLASSIFY", userID + " : " + dr["WPClassify"].ToString(), UserCurrentInfo.Connection);
                        theResult = true;
                    }
                    catch (Exception e)
                    {
                        myMessage.viewMessage(MessageType.Error, "Error Adding User", MinewasteResource.systemName, "clsUserProductionSettings", "SaveUserSettings", e.Message, ButtonTypes.OK, MessageDisplayType.FullScreen);
                        theResult = false;
                    }
                } // insert                
            }
            return theResult;
        }
        public bool SaveUserSections(DataTable theSecions, string userID, string theType)
        {
            bool theResult = true;
            TheData.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            TheData.queryReturnType = MWDataManager.ReturnType.DataTable;
            TheData.ConnectionString = TConnections.GetConnectionString(MinewasteResource.systemDBTag, this.UserCurrentInfo.Connection);
            //DataRow[] userSections = theSecions.Select("Updated = 1");
            sb.Clear();
            if (theSecions.Rows.Count != 0)
            {
                try
                {
                    TheData.SqlStatement = String.Format("DELETE FROM [dbo].[USERS_SECTION] WHERE [UserID] = '{0}' and [LinkType] = '{1}' ", userID, theType);
                    TheData.ExecuteInstruction();

                    string Linked;
                    foreach (DataRow dr in theSecions.Rows)
                    {
                        Linked = dr["IsLinked"].ToString();
                        if (Linked == "True")
                        {
                            TheData.SqlStatement = String.Format("INSERT INTO [dbo].[USERS_SECTION] ([UserID] ,[SectionID],[LinkType]) VALUES ('{0}','{1}', '{2}')", userID, dr["SectionID"], theType);
                            TheData.ExecuteInstruction();
                        }
                    }
                    theResult = true;
                }
                catch (Exception e)
                {

                    myMessage.viewMessage(MessageType.Error, "Error Saving Sections", MinewasteResource.systemName, "DL_Users", "SaveUserSections", e.Message, ButtonTypes.OK, MessageDisplayType.FullScreen);
                    theResult = false;
                }
            }
            else theResult = true;

            return theResult;
        }

        public void Dispose()
        {
            if (TheData != null)
            {
                //TheData.Dispose();
                TheData = null;
            }
        }
            
    }
}
