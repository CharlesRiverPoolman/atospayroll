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
    public class CustomerEmployeesController : Controller
    {
        private AtosPayrollEntities db = new AtosPayrollEntities();

        // GET: CustomerEmployees
        public ActionResult Index()
        {
            var customerEmployees = db.CustomerEmployees.Include(c => c.Customer);
            return View(customerEmployees.ToList());
        }

        // GET: CustomerEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerEmployee customerEmployee = db.CustomerEmployees.Find(id);
            if (customerEmployee == null)
            {
                return HttpNotFound();
            }
            return View(customerEmployee);
        }

        // GET: CustomerEmployees/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName");
            return View();
        }

        // POST: CustomerEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerID,EmployeeName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] CustomerEmployee customerEmployee)
        {
            if (ModelState.IsValid)
            {
                db.CustomerEmployees.Add(customerEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", customerEmployee.CustomerID);
            return View(customerEmployee);
        }

        // GET: CustomerEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerEmployee customerEmployee = db.CustomerEmployees.Find(id);
            if (customerEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", customerEmployee.CustomerID);
            return View(customerEmployee);
        }

        // POST: CustomerEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerID,EmployeeName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] CustomerEmployee customerEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", customerEmployee.CustomerID);
            return View(customerEmployee);
        }

        // GET: CustomerEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerEmployee customerEmployee = db.CustomerEmployees.Find(id);
            if (customerEmployee == null)
            {
                return HttpNotFound();
            }
            return View(customerEmployee);
        }

        // POST: CustomerEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerEmployee customerEmployee = db.CustomerEmployees.Find(id);
            db.CustomerEmployees.Remove(customerEmployee);
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
