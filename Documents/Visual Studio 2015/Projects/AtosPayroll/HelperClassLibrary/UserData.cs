using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClassLibrary
{
   public static  class UserData
    {
       static PayrollDatabaseAccess.AtosPayrollEntities ent = new PayrollDatabaseAccess.AtosPayrollEntities();

        public static int GetEmployeeID(string Account)
        {
            return ent.Employees.Single(c => c.Account == Account).ID;
        }

        public static int GetEmployeeRoleID(string Account)
        {
            return ent.Employees.Single(c => c.Account == Account).EmployeeRoleID;
        }

        public static int GetEmployeeLocation(string Account)
        {
            return ent.Employees.Single(c => c.Account == Account).LocationID;
        }

        public static int GetEmployeeRoleReportToID(string Account)
        {
            int LocationID = GetEmployeeLocation(Account);
            return ent.Employees.Single(c => c.LocationID == LocationID && c.Account == Account).EmployeeRoleReportToID;
        }
    }
}
