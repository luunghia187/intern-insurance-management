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
    public class AgentController : Controller
    {
        private InsuranceManagementContext db = new InsuranceManagementContext();

        public ActionResult Index()
        {
            return View(db.Agents.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agent agent = db.Agents.Find(id);
            db.Agents.Remove(agent);
            Account account = db.Accounts.Find(agent.AccountId);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ResetPassword(int id)
        {
            Agent agent = db.Agents.Find(id);
            Account account = db.Accounts.Find(agent.AccountId);
            account.AccountPassWork = "12345678";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
