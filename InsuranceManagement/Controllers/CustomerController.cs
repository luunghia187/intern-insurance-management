using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InsuranceManagement.DAL;
using InsuranceManagement.Models;

namespace InsuranceManagement.Controllers
{
    public class CustomerController : Controller
    {
        private InsuranceManagementContext db = new InsuranceManagementContext();
        public ActionResult Index()
        {
            var custommers = db.Custommers;
            return View(custommers.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Custommers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Custommers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Custommers.Find(id);
            db.Custommers.Remove(customer);
            Account account = db.Accounts.Find(customer.AccountId);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ResetPassword(int id)
        {
            Customer customer = db.Custommers.Find(id);
            Account account = db.Accounts.Find(customer.AccountId);
            account.AccountPassWork = "12345678";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
