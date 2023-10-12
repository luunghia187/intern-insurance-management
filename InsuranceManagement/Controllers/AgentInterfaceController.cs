using InsuranceManagement.DAL;
using InsuranceManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceManagement.Controllers
{
    public class AgentInterfaceController : Controller
    {
        private InsuranceManagementContext db = new InsuranceManagementContext();

        public ActionResult Index(int id)
        {
            Agent agent = db.Agents.FirstOrDefault(c => c.AccountId == id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        public ActionResult Edit(int id)
        {
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Agent agent)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new InsuranceManagementContext())
                {
                    dbContext.Entry(agent).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index", new { id = agent.AccountId });
            }
            return View(agent);
        }

        public ActionResult ShowContract(int id)
        {
            var contracts = db.Contracts.Where(c => c.AgentId == id);

            var agent = db.Agents.FirstOrDefault(c => c.AgentId == id);
            ViewBag.AccountId = agent.AccountId;

            return View(contracts.OrderByDescending(d => d.SigningDate).ToList());
        }

        public ActionResult SellContract(int contractId, int agentId)
        {
            using (var dbContext = new InsuranceManagementContext())
            {
                Contract contract = dbContext.Contracts.SingleOrDefault(c => c.ContractId == contractId);
                contract.Status = ContractStatus.Pending;
                dbContext.SaveChanges();
            }
            var contracts = db.Contracts.Where(c => c.CustomerId == agentId).ToList();
            return RedirectToAction("ShowContract", new { id = agentId });
        }

    }
}