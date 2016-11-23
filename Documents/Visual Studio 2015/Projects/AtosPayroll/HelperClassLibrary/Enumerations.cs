using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClassLibrary
{
   
    public class Enumerations
    {
        #region Monthly Expenses
        public enum MonthlyExpenseClaimsStatuses { FirstStep, PendingLineManagerApproval,LineManagerApproved,PayrollManagerApproved };
        #endregion

        #region Employee Roles
        public enum EmployeeRoles
        {
            Developer,
            BA,
            PayrollManager,
            LineManager,
            HRManager,
            CTO,
            CIO,
            CFO,
            CEO
        }
        #endregion
    }



}
