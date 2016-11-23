using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClassLibrary
{
    public static class MonthlyExpenseClaimsData
    {
      private static PayrollDatabaseAccess.AtosPayrollEntities ent;

        public static int GetLastMonthlyExpenseClaimID()
        {
            ent = new PayrollDatabaseAccess.AtosPayrollEntities();
            return ent.MonthlyExpenseClaims.Count();
        }

        /// <summary>
        /// GetStatusID
        /// </summary>
        /// <param name="ID">ID from current MonthlyExpenseClaims ID</param>
        /// <returns>StatusID</returns>
        public static int GetStatusID(int ID)
        {
            ent = new PayrollDatabaseAccess.AtosPayrollEntities();
            return ent.MonthlyExpenseClaims.Single(c => c.ID == ID).StatusID;
        }
    }
}
