using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mineware.Systems.Global;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Mineware.Systems.Minewaste.Controls
{ 

    class clsBookings
    {
        private MWDataManager.clsDataAccess _Bookings = new MWDataManager.clsDataAccess();
        public string _theConnection;
        public DataTable getWorkplaceManagementData()
        {
            bool HasError = false;
            try
            {


                _Bookings.ConnectionString = _theConnection;
                _Bookings.SqlStatement = " exec sp_BookingsDaily " +
                                         " \r\n";
                _Bookings.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
                _Bookings.queryReturnType = MWDataManager.ReturnType.DataTable;
                _Bookings.ExecuteInstruction();
            }
            catch
            {
                HasError = true;
            }

            if (HasError == true)
            {
                return null;
            }
            else
            {
                return _Bookings.ResultsDataTable;
            }
        }
    }

   
}
