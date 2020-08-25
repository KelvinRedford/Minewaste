using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Mineware.Systems.GlobalConnect;
using MWDataManager;

namespace Mineware.Systems.MinewasteGlobal
{
	public class GlobalItems : clsBase
	{
		private readonly Dictionary<string, string> _connectionIfo = new Dictionary<string, string>();

		public GlobalItems(string theSystemDbTag, string connection)
		{
			_connectionIfo.Clear();

			theData.ConnectionString = TConnections.GetConnectionString(theSystemDbTag, connection);
			theData.queryExecutionType = ExecutionType.GeneralSQLStatement;
			theData.queryReturnType = ReturnType.DataTable;
			theData.SqlStatement = "SELECT [Operation], [ConnectionName] FROM [dbo].[HROperations]";
			theData.ExecuteInstruction();
			foreach (DataRow row in theData.ResultsDataTable.Rows)
			{
				var con = row["ConnectionName"].ToString();
				if (!string.IsNullOrEmpty(con) && !_connectionIfo.ContainsKey(con))
				{
					_connectionIfo.Add(con, row["Operation"].ToString());
				}
			}
		}
       
        public DataTable getCritical_Skills()
        {

            theData.queryExecutionType = ExecutionType.GeneralSQLStatement;
            theData.queryReturnType = ReturnType.DataTable;
            sb.Clear();
            sb.AppendLine("SELECT [CriticalSkillHeadingDesc] FROM [HR].[dbo].[HRCriticalSkillHeading]");
            theData.SqlStatement = sb.ToString();
            theData.ExecuteInstruction();
            return theData.ResultsDataTable;
        }

        public DataTable GetOrgUnitList()
        {
            theData.queryExecutionType = ExecutionType.GeneralSQLStatement;
            theData.queryReturnType = ReturnType.DataTable;
            sb.Clear();
            sb.AppendLine("Select Distinct pm.OrgUnitDay OrgUnit, c.CrewName OrgUnitDesc  ");
            sb.AppendLine("From Planmonth pm ");
            sb.AppendLine("inner join Crew c ");
            sb.AppendLine("on pm.OrgUnitDay = c.GangNo ");
            sb.AppendLine("where pm.PlanCode = 'MP' and pm.Activity = 0");
            theData.SqlStatement = sb.ToString();
            theData.ExecuteInstruction();
            return theData.ResultsDataTable;
        }


        public DataTable GetMethodGroupOrgUnits()
        {
            theData.queryExecutionType = ExecutionType.GeneralSQLStatement;
            theData.queryReturnType = ReturnType.DataTable;
            sb.Clear();
            sb.AppendLine("Select Distinct OrgUnit, c.CrewName OrgUnitDesc  ");
            sb.AppendLine("From HRMethodGroup m ");
            sb.AppendLine("inner join Crew c ");
            sb.AppendLine("on m.OrgUnit = c.GangNo ");
            theData.SqlStatement = sb.ToString();
            theData.ExecuteInstruction();
            return theData.ResultsDataTable;
        }

        public DataTable GetActivityList()
        {
            theData.queryExecutionType = ExecutionType.GeneralSQLStatement;
            theData.queryReturnType = ReturnType.DataTable;
            theData.SqlStatement = "SELECT Top 1 [Activity],[Description]  FROM [CODE_ACTIVITY] ";
            theData.ExecuteInstruction();
            return theData.ResultsDataTable;
        }

        public DataTable GetOrgUnit()
        {
            theData.queryExecutionType = ExecutionType.GeneralSQLStatement;
            theData.queryReturnType = ReturnType.DataTable;
            sb.Clear();

            sb.AppendLine("select Distinct pm.OrgUnitDay OrgUnit, c.CrewName OrgUnitDesc ");
            sb.AppendLine("from Crew c ");
            sb.AppendLine("inner ");
            sb.AppendLine("join Planmonth pm ");
            sb.AppendLine("on pm.OrgUnitDay = c.GangNo ");
            sb.AppendLine("inner ");
            sb.AppendLine("join SECTION_COMPLETE sc ");
            sb.AppendLine("on pm.Prodmonth = sc.Prodmonth ");
            sb.AppendLine("and pm.Sectionid = sc.SectionID ");
            theData.SqlStatement = sb.ToString();
            theData.ExecuteInstruction();
            return theData.ResultsDataTable;
        }
        

        public DataTable GetDesignationList()
        {
            theData.queryExecutionType = ExecutionType.GeneralSQLStatement;
            theData.queryReturnType = ReturnType.DataTable;
            sb.Clear();
            sb.AppendLine("SELECT DISTINCT OccDescription AS Designation  FROM EmployeeAll e ");
            sb.AppendLine("inner join EmployeeOccupation o ");
            sb.AppendLine("on e.OccNo = o.OccNo ");
            sb.AppendLine("inner join planmonth pm  ");
            sb.AppendLine("on e.GangNo = pm.OrgUnitDay ");

            theData.SqlStatement = sb.ToString();
            theData.ExecuteInstruction();
            return theData.ResultsDataTable;
        }

        public DataTable GetMoOrgUnits(string prodMonth)
        {
            sb.Clear();
            sb.AppendLine("select Distinct SectionID, [Name] ");
            sb.AppendLine("from Section ");
            sb.AppendLine("where Hierarchicalid = 4 and ProdMonth = '" + prodMonth + "'");
            theData.SqlStatement = sb.ToString();
            theData.queryExecutionType = ExecutionType.GeneralSQLStatement;
            theData.queryReturnType = theData.queryReturnType = ReturnType.DataTable;

            theData.ExecuteInstruction();
            return theData.ResultsDataTable;
        }

        public DataTable GetReportSections()
        {
            theData.queryExecutionType = ExecutionType.GeneralSQLStatement;
            theData.queryReturnType = ReturnType.DataTable;
            sb.Clear();
            sb.AppendLine("SELECT DISTINCT SM_org OrgUnit, SM_Org_desc OrgUnitDesc FROM dbo.Production_Orgunit_View ");

            sb.AppendLine("UNION ");
            sb.AppendLine("SELECT DISTINCT MO_org OrgUnit,MO_Org_desc OrgUnitDesc FROM dbo.Production_Orgunit_View ");

            sb.AppendLine("UNION ");
            sb.AppendLine("SELECT DISTINCT PS_org OrgUnit,PS_Org_desc OrgUnitDesc FROM dbo.Production_Orgunit_View ");

            sb.AppendLine("ORDER BY OrgUnit");
            theData.SqlStatement = sb.ToString();
            theData.ExecuteInstruction();
            return theData.ResultsDataTable;
        }

    }
}