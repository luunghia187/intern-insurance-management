using InsuranceManagement.DAL;
using InsuranceManagement.Models;
using InsuranceManagement.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace InsuranceManagement.Controllers
{
    public class LoginController : Controller
    {
        private InsuranceManagementContext db = new InsuranceManagementContext();

        enum Roles
        {
            Defaul,
            Admin,
            Customer,
            Agent
        }
       
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account model)
        {
            if (ModelState.IsValid)
            {
                bool isUserExit = db.Accounts.Any(acc => acc.AccountName == model.AccountName
                                              && acc.AccountPassWork == model.AccountPassWork);
                if (isUserExit)
                {
                    var userAccount = db.Accounts.SingleOrDefault(c => c.AccountName == model.AccountName);

                    switch (userAccount.RoleId)
                    {
                        case (int)Roles.Admin:
                            return RedirectToAction("Index", "Home");
                        case (int)Roles.Customer:
                            return RedirectToRoute(new { action = "Index", controller = "CustomerInterface", id = userAccount.AccountId });
                        case (int)Roles.Agent:
                            return RedirectToRoute(new { action = "Index", controller = "AgentInterface", id = userAccount.AccountId });
                    }
                }
                else
                {
                    ViewData["ErrorMessage"] = "Login Failed. Check Account Name, Pass Work and try again!.";
                    return View("Index", model);
                }
            }
            return View("Index", model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerRegister(RegisterViewModel registerCustomer)
        {
            bool isExists = db.Accounts.Any(acc => acc.AccountName == registerCustomer.Account.AccountName);
            if (isExists)
            {
                return View("RegisterError");
            }

            if (ModelState.IsValid)
            {
                registerCustomer.Account.RoleId = (int)Roles.Customer;
                db.Accounts.Add(registerCustomer.Account);
                db.SaveChanges();

                registerCustomer.Customer.AccountId = registerCustomer.Account.AccountId;
                db.Custommers.Add(registerCustomer.Customer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Role = "Customer";
            return View("Register");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgentRegister(RegisterViewModel registerAgent)
        {
            bool isExists = db.Accounts.Any(acc => acc.AccountName == registerAgent.Account.AccountName);
            if (isExists)
            {
                return View("RegisterError");
            }

            if (ModelState.IsValid)
            {
                registerAgent.Account.RoleId = (int)Roles.Agent;
                db.Accounts.Add(registerAgent.Account);
                db.SaveChanges();

                registerAgent.Agent.AccountId = registerAgent.Account.AccountId;
                db.Agents.Add(registerAgent.Agent);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Role = "Agent";
            return View("Register");
        }
    }
}