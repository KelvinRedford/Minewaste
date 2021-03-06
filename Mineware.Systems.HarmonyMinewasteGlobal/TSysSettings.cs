using System;
using System.Data;
using System.Text;
using Mineware.Systems.Global;
using Mineware.Systems.GlobalConnect;
using MWDataManager;
using Mineware.Systems.GlobalExtensions;

namespace Mineware.Systems.MinewasteGlobal
{
    //2019-04-08 - DvdB - Removed all static items from class  
	public class TSysSettings
	{
		private  int _prodMonth;
		private  DateTime _RunDate = DateTime.Now;
		private  int _currentProductionMonth;
		private  string _mine = "";
		private  int _prodMonthSec;
		private  int _millMonth;
		private  string _banner = "";
		private  decimal _stdAdv;
		private  string _checkMeas = "";
		private  string _planType = "";
		private  string _cleanShift = "";
		private  string _adjBook = "";
		private  int _blastQual;
		private  string _dsOrg = "N";
		private  string _cHkMeasLevel = "MO";
		private  string _planNotes = "";
		private  string _curDir = "";
		private  string _cylePlan = "";
		private  int _backDateDays;
		private  int _lockPlanShiftNo;
		private  int _daysToUnlockPlan;

		private  int _moHierarchicalId;

		private  double _rockDensity;
		private  double _bookingPer = 90;
		private  decimal _brokenRockDensity;
		private  int _year;
		private  int _isCentralizedDatabase;

		private  string _bonusDatabase = "";
		private  readonly string _PlanProtSaveDir = "";
		private  readonly string _SysAdmin_Database = "";
		private bool _enableUranium;

		public string SiteTag;
		private  bool _canReconBooking;
		private  DayOfWeek? _reconDayOfWeek;

		public double RockDensity
		{
			get { return _rockDensity; }
			set { _rockDensity = value; }
		}

		public int BackDateDays
		{
			get { return _backDateDays; }
			set { _backDateDays = value; }
		}

		public int LockPlanShiftNo
		{
			get { return _lockPlanShiftNo; }
			set { _lockPlanShiftNo = value; }
		}

		public int DaysToUnlockPlan
		{
			get { return _daysToUnlockPlan; }
			set { _daysToUnlockPlan = value; }
		}

		public int ProdMonth
		{
			get { return _prodMonth; }
			set { _prodMonth = value; }
		}

		public int CurrentProductionMonth
		{
			get { return _currentProductionMonth; }
		}

		public DateTime Rundate
		{
			get { return _RunDate; }
		}

		public string Mine
		{
			get { return _mine; }
		}

		public int Year
		{
			get { return _year; }
			set { _year = value; }
		}

		public int ProdMonthSec
		{
			get { return _prodMonthSec; }
			set { _prodMonthSec = value; }
		}

		public int MillMonth
		{
			get { return _millMonth; }
			set { _millMonth = value; }
		}

		public string Banner
		{
			get { return _banner; }
			set { _banner = value; }
		}

		public decimal StdAdv
		{
			get { return _stdAdv; }
			set { _stdAdv = value; }
		}

		public string CheckMeas
		{
			get { return _checkMeas; }
			set { _checkMeas = value; }
		}

		public string PlanType
		{
			get { return _planType; }
			set { _planType = value; }
		}

		public string CleanShift
		{
			get { return _cleanShift; }
			set { _cleanShift = value; }
		}

		public string AdjBook
		{
			get { return _adjBook; }
			set { _adjBook = value; }
		}

		public int BlastQual
		{
			get { return _blastQual; }
			set { _blastQual = value; }
		}

		public string DSOrg
		{
			get { return _dsOrg; }
			set { _dsOrg = value; }
		}

		public string CHkMeasLevel
		{
			get { return _cHkMeasLevel; }
			set { _cHkMeasLevel = value; }
		}

		public string PlanNotes
		{
			get { return _planNotes; }
			set { _planNotes = value; }
		}

		public string CurDir
		{
			get { return _curDir; }
			set { _curDir = value; }
		}

		public string CylePlan
		{
			get { return _cylePlan; }
			set { _cylePlan = value; }
		}

		public int MOHierarchicalID
		{
			get { return _moHierarchicalId; }
			set { _moHierarchicalId = value; }
		}

		public double BookingPer
		{
			get { return _bookingPer; }
			set { _bookingPer = value; }
		}

		public decimal BrokenRockDensity
		{
			get { return _brokenRockDensity; }
			set { _brokenRockDensity = value; }
		}

		public int IsCentralizedDatabase
		{
			get { return _isCentralizedDatabase; }
			set { _isCentralizedDatabase = value; }
		}

		public bool EnableUranium
		{
			get { return _enableUranium; }
		}

		public string Bonus_Database
		{
			get { return _bonusDatabase; }
			set { _bonusDatabase = value; }
		}

		public string PlanProtSaveDir
		{
			get { return _PlanProtSaveDir; }
		}

		public string SysAdmin_Database
		{
			get { return _SysAdmin_Database; }
		}

		public bool CanReconBooking
		{
			get { return _canReconBooking; }
		}

		public DayOfWeek? ReconDayOfWeek
		{
			get { return _reconDayOfWeek; }
		}

		//gets all the fields from the SYSSET table
		public void GetSysSettings(string systemDBTag, string connection)
		{
			var _dbMan = new clsDataAccess();
			_dbMan.ConnectionString = TConnections.GetConnectionString(systemDBTag, connection);

			_dbMan.SqlStatement = "Select * from SysSet";
			_dbMan.queryExecutionType = ExecutionType.GeneralSQLStatement;
			_dbMan.queryReturnType = ReturnType.DataTable;
			var DataResult = _dbMan.ExecuteInstruction();


			foreach (DataRow dr in _dbMan.ResultsDataTable.Rows)
			{
				var millmonth = dr["CurrentMillMonth"].ToString();

				if (millmonth == "")
				{
					millmonth = "0";
				}
				_millMonth = Convert.ToInt32(millmonth);
				var SubB = _dbMan.ResultsDataTable;

				_currentProductionMonth = Convert.ToInt32(dr["CurrentProductionMonth"].ToString());

				_prodMonth = Convert.ToInt32(dr["CurrentProductionMonth"].ToString());
				ProdMonth = Convert.ToInt32(dr["CurrentProductionMonth"].ToString());
				GlobalVar.ProdMonth = Convert.ToInt32(dr["CurrentProductionMonth"].ToString());

				_mine = dr["BANNER"].ToString();

				_moHierarchicalId = Convert.ToInt32(dr["MOHIERARCHICALID"].ToString());

				_RunDate = Convert.ToDateTime(dr["Rundate"].ToString());
				_isCentralizedDatabase = Convert.ToInt32(dr["IsCentralizedDatabase"].ToString());
				_enableUranium = false;

				var outvalue = string.Empty;
                if (dr.TryGetColumnFromRow("EnableUranium", out outvalue))
                {
                    _enableUranium = Convert.ToBoolean(outvalue);
            }
            if (dr.TryGetColumnFromRow("CheckMeas", out outvalue))
            {
                ConvertDayOfWeek(outvalue);

					_canReconBooking = _reconDayOfWeek != null;
            }
        }
		}

		private void ConvertDayOfWeek(string checkMeas)
		{
			switch (checkMeas)
			{
				case "None": _reconDayOfWeek = null;
					break;
				case "Mon": _reconDayOfWeek = DayOfWeek.Monday;
					break;
				case "Tue": _reconDayOfWeek = DayOfWeek.Tuesday;
					break;
				case "Wed": _reconDayOfWeek = DayOfWeek.Wednesday;
					break;
				case "Thu": _reconDayOfWeek = DayOfWeek.Thursday;
					break;
				case "Fri": _reconDayOfWeek = DayOfWeek.Friday;
					break;
				case "Sat": _reconDayOfWeek = DayOfWeek.Saturday;
					break;
				case "Sun": _reconDayOfWeek = DayOfWeek.Sunday;
					break;
			}
		}

		public void GetYear(string systemDBTag, string connection)
		{
			var _dbMan = new clsDataAccess();
			_dbMan.ConnectionString = TConnections.GetConnectionString(systemDBTag, connection);
			var sb = new StringBuilder();
			sb.AppendLine("select distinct [Year] [Year] from CalendarReport");

			_dbMan.SqlStatement = sb.ToString();
			_dbMan.queryExecutionType = ExecutionType.GeneralSQLStatement;
			_dbMan.queryReturnType = ReturnType.DataTable;
			_dbMan.ExecuteInstruction();

			var dt = _dbMan.ResultsDataTable;

			_year = Convert.ToInt32(dt.Rows[0]["Year"].ToString());
		}

		public DateTime ProdMonthAsDate(string theProdmont)
		{
			var theResult = DateTime.Now;
			var theYear = Convert.ToInt32(theProdmont.Substring(0, 4));
			var theMonth = Convert.ToInt32(theProdmont.Substring(4, 2));
			theResult = new DateTime(theYear, theMonth, 1);
			return theResult;
		}

		public string ProdMonthAsString(DateTime theProdmont)
		{
			var theResult = "";
			var year = theProdmont.Year.ToString();
			var month = theProdmont.Month.ToString();
			if (month.Length == 1)
			{
				month = "0" + month;
			}
			theResult = year + month;
			return theResult;
		}
	}
}