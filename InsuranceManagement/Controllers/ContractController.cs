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
using PagedList;

namespace InsuranceManagement.Controllers
{
    public class ContractController : Controller
    {
        private InsuranceManagementContext db = new InsuranceManagementContext();

        public ActionResult Index(int? page)
        {
            var contracts = db.Contracts.OrderByDescending(d => d.SigningDate);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(contracts.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract contract = db.Contracts.Find(id);
            db.Contracts.Remove(contract);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddProof(int contractId)
        {
            Contract contract = db.Contracts.Find(contractId);
            return View(contract);
        }

        public ActionResult AcceptContract(Contract contract)
        {
            int contractId = contract.ContractId;
            string contractProof = contract.Proof;
            using (var dbContext = new InsuranceManagementContext())
            {
                Contract cont = dbContext.Contracts.SingleOrDefault(c => c.ContractId == contractId);
                cont.Proof = contractProof;
                cont.Status = ContractStatus.HoldOn;
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Sort(string SortBy)
        {
            var contracts = db.Contracts.OrderBy(c => c.ContractId);
            switch (SortBy)
            {
                case "AgentName":
                    contracts = db.Contracts.OrderBy(c => c.Agent.Name);
                    break;
                case "CustomerName":
                    contracts = db.Contracts.OrderBy(c => c.Customer.Name);
                    break;
                case "InsuranceId":
                    contracts = db.Contracts.OrderBy(c => c.InsuranceId);
                    break;
                case "SigningDate":
                    contracts = db.Contracts.OrderByDescending(c => c.SigningDate);
                    break;
                case "ExpirationDate":
                    contracts = db.Contracts.OrderBy(c => c.ExpirationDate);
                    break;
                case "Proof":
                    contracts = db.Contracts.OrderBy(c => c.Proof);
                    break;
                case "Status":
                    contracts = db.Contracts.OrderBy(c => c.Status);
                    break;
                default:
                    contracts = db.Contracts.OrderBy(c => c.Agent.Name);
                    break;
            }
            int pageSize = 5;
            int pageNumber = 1;
            return View("Index",contracts.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Search(string searchQuery)
        {
            var contracts = db.Contracts.Where(c => c.Agent.Name.Contains(searchQuery)
                                                || c.Customer.Name.Contains(searchQuery)).OrderByDescending(c => c.SigningDate);
            int pageSize = 5;
            int pageNumber = 1;
            return View("Index", contracts.ToPagedList(pageNumber, pageSize));
        }
    }
}
