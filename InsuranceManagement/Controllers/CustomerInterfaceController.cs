using InsuranceManagement.DAL;
using InsuranceManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InsuranceManagement.Controllers
{
    public class CustomerInterfaceController : Controller
    {

        private InsuranceManagementContext db = new InsuranceManagementContext();

        public ActionResult Index(int id)
        {
            Customer customer = db.Custommers.FirstOrDefault(c => c.AccountId == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            Customer customer = db.Custommers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {

                using (var dbContext = new InsuranceManagementContext())
                {
                    dbContext.Entry(customer).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index", new { id = customer.AccountId});
            }
            return View(customer);
        }

        public ActionResult ApproveContract(int contractId, int customerId)
        {
            using (var dbContext = new InsuranceManagementContext())
            {
                Contract contract = dbContext.Contracts.SingleOrDefault(c => c.ContractId == contractId);
                contract.Status = ContractStatus.Approved;
                dbContext.SaveChanges();
            }
            var contracts = db.Contracts.Where(c => c.CustomerId == customerId).ToList();
            return RedirectToAction("ShowContract", new { id = customerId });
        }

        public ActionResult ShowContract(int id)
        {
            var contracts = db.Contracts.Where(c => c.CustomerId == id);

            var customer = db.Custommers.SingleOrDefault(c => c.CustomerId == id);
            ViewBag.AccountId = customer.AccountId;

            return View(contracts.OrderByDescending(d => d.SigningDate).ToList());
        }

        public ActionResult ChooseInsurance(int id)
        {
            ViewBag.custommerId = id;
            var Insurances = db.Insurances.ToList(); 
            return View(Insurances);
        }

        public ActionResult ChooseAgent(int id, int customerId)
        {
            ViewBag.CustomerId = customerId;
            ViewBag.InsuranceId = id;
            var Agents = db.Agents.ToList();
            return View(Agents);
        }

        public ActionResult ConfirmContract(int customerId, int agentId, int insuranceId)
        {
            Insurance insurance = db.Insurances.Find(insuranceId);
            Contract contract = new Contract
            {
                CustomerId = customerId,
                AgentId = agentId,
                InsuranceId = insuranceId,
                SigningDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(insurance.YearsOfPayment),
                Status = ContractStatus.Buying
            };
            @ViewBag.CustomerName = db.Custommers.Find(customerId).Name;
            @ViewBag.AgentName = db.Agents.Find(agentId).Name;
            @ViewBag.InsuranceName = db.Insurances.Find(insuranceId).Name;
            return View(contract);
        }


        [HttpPost]
        public ActionResult CreateContract(Contract contract)
        {
            if (ModelState.IsValid)
            {
                //return Content(contract.SigningDate.ToString());
                db.Contracts.Add(contract);
                db.SaveChanges();
                Customer customer = db.Custommers.Find(contract.CustomerId);
                return RedirectToAction("ShowContract", new { id = customer.CustomerId });
            }

            return Content(contract.CustomerId.ToString());
        }
    }
}