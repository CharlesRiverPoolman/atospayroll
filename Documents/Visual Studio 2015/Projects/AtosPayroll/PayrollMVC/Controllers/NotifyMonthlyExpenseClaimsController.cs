using PayrollDatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PayrollMVC.Controllers
{
    public class NotifyMonthlyExpenseClaimsController : Controller
    {
        private AtosPayrollEntities db = new AtosPayrollEntities();
        // GET: NotifyMonthlyExpenseClaims
        public ActionResult Index()
        {
            var roles = db.EmployeeRoles.Where(c => c.Level == 1);
            ViewBag.EmployeeRoleID = new SelectList(roles, "ID", "RoleName");
            return View();
        }
       
        public void SendMail(int roleid)
        {
            HelperClassLibrary.Mail.SendMail(roleid);     
            
        }

      
    }
};