﻿#region Comments and History
/*
 * =======================================================================================
 *   Author   : Schalk Kotze
 *   Date     : 02 May 2010
 *   Purpose  : Static class for Global Vars
 *              No Instance constructor needed
 *              
 * =======================================================================================
*/
#endregion Comments and History

static class clsUserInfo
{
    
 #region class properties and globals

    private static  string m_UserID = "";
    private static string m_UserName = "";
    private static string m_UserBookSection = "";
    private static int m_Hier = 0;
    private static string m_Tram = "";
    private static string m_Hoist = "";
    private static string m_mill = "";
    private static string m_book = "";
    private static string m_dropraise = "N";
    private static string m_sys = "N";
    private static string m_plan = "N";
    private static string m_samp = "N";
    private static string m_Surv = "N";
    private static string m_Expl = "N";
    private static string m_Diamond = "N";
    
    
    
    
    public static string UserID { get { return m_UserID; } set { m_UserID = value; }}
    public static string UserName { get { return m_UserName; } set { m_UserName = value; }}
    public static string UserBookSection { get { return m_UserBookSection; } set { m_UserBookSection = value; } }
    public static int Hier { get { return m_Hier; } set { m_Hier = value; } }

    public static string Tram { get { return m_Tram; } set { m_Tram = value; } }
    public static string Hoist { get { return m_Hoist; } set { m_Hoist = value; } }
    public static string mill { get { return m_mill; } set { m_mill = value; } }
    public static string book { get { return m_book; } set { m_book = value; } }
    public static string dropraise { get { return m_dropraise; } set { m_dropraise = value; } }
    public static string sys { get { return m_sys; } set { m_sys = value; } }
    public static string plan { get { return m_plan; } set { m_plan = value; } }
    public static string samp { get { return m_samp; } set { m_samp = value; } }
    public static string Surv { get { return m_Surv; } set { m_Surv = value; } }
    public static string Expl { get { return m_Expl; } set { m_Expl = value; } }
    public static string DiamondDril { get { return m_Diamond; } set { m_Diamond = value; } }



 #endregion class properties and globals
}


