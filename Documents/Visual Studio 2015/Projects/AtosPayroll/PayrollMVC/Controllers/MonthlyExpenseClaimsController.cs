using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PayrollDatabaseAccess;

namespace PayrollMVC.Controllers
{
    public class MonthlyExpenseClaimsController : Controller
    {
        private AtosPayrollEntities db = new AtosPayrollEntities();
        private int? MonthlyClaimsID;

        // GET: MonthlyExpenseClaims
        public ActionResult Index()
        {
            var monthlyExpenseClaims = db.MonthlyExpenseClaims.Include(m => m.Customer).Include(m => m.CustomerEmployee).Include(m => m.ExpenseItem).Include(m => m.Status);
            return View(monthlyExpenseClaims.ToList());
        }

        // GET: MonthlyExpenseClaims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyExpenseClaim monthlyExpenseClaim = db.MonthlyExpenseClaims.Find(id);
            if (monthlyExpenseClaim == null)
            {
                return HttpNotFound();
            }
            return View(monthlyExpenseClaim);
        }

        // GET: MonthlyExpenseClaims/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName");
            ViewBag.CustomerEmployeeID = new SelectList(db.CustomerEmployees, "ID", "EmployeeName");
            ViewBag.ExpenseItemID = new SelectList(db.ExpenseItems, "ID", "ExpenseItemName");
            ViewBag.StatusID = new SelectList(db.Status, "ID", "StatusName");
            return View();
        }

        // POST: MonthlyExpenseClaims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,CustomerID,CustomerEmployeeID,ExpenseItemID,Cost,WBS,StatusID,Approved,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MonthlyExpenseClaim monthlyExpenseClaim)
        {
            if (ModelState.IsValid)
            {
                // If user is 
                // if  (HelperClassLibrary.Enumerations.EmployeeRoles.BA || HelperClassLibrary.Enumerations.EmployeeRoles.Developer)
               int UserRole =  HelperClassLibrary.UserData.GetEmployeeRoleID(User.Identity.Name);
                if (UserRole == (int)HelperClassLibrary.Enumerations.EmployeeRoles.BA || UserRole == (int)HelperClassLibrary.Enumerations.EmployeeRoles.Developer)
                    monthlyExpenseClaim.StatusID = (int)HelperClassLibrary.Enumerations.MonthlyExpenseClaimsStatuses.FirstStep;
                db.MonthlyExpenseClaims.Add(monthlyExpenseClaim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", monthlyExpenseClaim.CustomerID);
            ViewBag.CustomerEmployeeID = new SelectList(db.CustomerEmployees, "ID", "EmployeeName", monthlyExpenseClaim.CustomerEmployeeID);
            ViewBag.ExpenseItemID = new SelectList(db.ExpenseItems, "ID", "ExpenseItemName", monthlyExpenseClaim.ExpenseItemID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "StatusName", monthlyExpenseClaim.StatusID);
            return View(monthlyExpenseClaim);
        }

        // GET: MonthlyExpenseClaims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyExpenseClaim monthlyExpenseClaim = db.MonthlyExpenseClaims.Find(id);
            MonthlyClaimsID = id;
            if (monthlyExpenseClaim == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", monthlyExpenseClaim.CustomerID);
            ViewBag.CustomerEmployeeID = new SelectList(db.CustomerEmployees, "ID", "EmployeeName", monthlyExpenseClaim.CustomerEmployeeID);
            ViewBag.ExpenseItemID = new SelectList(db.ExpenseItems, "ID", "ExpenseItemName", monthlyExpenseClaim.ExpenseItemID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "StatusName", monthlyExpenseClaim.StatusID);
            return View(monthlyExpenseClaim);
        }

        // POST: MonthlyExpenseClaims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,CustomerID,CustomerEmployeeID,ExpenseItemID,Cost,WBS,StatusID,Approved,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MonthlyExpenseClaim monthlyExpenseClaim)
        {
            if (ModelState.IsValid)
            {
               if (HelperClassLibrary.MonthlyExpenseClaimsData.GetStatusID(MonthlyClaimsID.Value) == (int)HelperClassLibrary.Enumerations.MonthlyExpenseClaimsStatuses.FirstStep)

                db.Entry(monthlyExpenseClaim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", monthlyExpenseClaim.CustomerID);
            ViewBag.CustomerEmployeeID = new SelectList(db.CustomerEmployees, "ID", "EmployeeName", monthlyExpenseClaim.CustomerEmployeeID);
            ViewBag.ExpenseItemID = new SelectList(db.ExpenseItems, "ID", "ExpenseItemName", monthlyExpenseClaim.ExpenseItemID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "StatusName", monthlyExpenseClaim.StatusID);
            return View(monthlyExpenseClaim);
        }

        // GET: MonthlyExpenseClaims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyExpenseClaim monthlyExpenseClaim = db.MonthlyExpenseClaims.Find(id);
            if (monthlyExpenseClaim == null)
            {
                return HttpNotFound();
            }
            return View(monthlyExpenseClaim);
        }

        // POST: MonthlyExpenseClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonthlyExpenseClaim monthlyExpenseClaim = db.MonthlyExpenseClaims.Find(id);
            db.MonthlyExpenseClaims.Remove(monthlyExpenseClaim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
