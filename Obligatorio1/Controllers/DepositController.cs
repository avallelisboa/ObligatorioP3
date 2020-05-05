using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obligatorio1.Controllers
{
    public class DepositController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            if (Convert.ToString(Session["Role"]) == "deposito")
                return View("Deposit");
            else return Redirect("../Home/Index");
        }

        public ActionResult Logout()
        {
            Session["LoggedUser"] = null;
            Session["Role"] = null;
            return Redirect("../Home/Index");
        }
    }
}