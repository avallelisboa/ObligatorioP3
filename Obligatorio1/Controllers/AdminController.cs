using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Obligatorio1.Services;

namespace Obligatorio1.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Index()
        {
            if (Convert.ToString(Session["Role"]) == "admin")
            {
                ProductServices proxy = new ProductServices();
                ViewBag.productsList = proxy.GetProducts();

                return View("Admin");
            }
            else return Redirect("../Home/Index");
        }


        public ActionResult Clients()
        {
            if (Convert.ToString(Session["Role"]) == "admin")
            {
                ClientServices proxy = new ClientServices();
                ViewBag.clientsList = proxy.GetClients();

                return View("Clients");
            }
            else return Redirect("../Home/Index");
        }

        public ActionResult GetExpectedIncome(long tin)
        {
            if (Convert.ToString(Session["Role"]) == "admin")
            {
                ClientServices proxy = new ClientServices();
                Session["expectedIncome"] = proxy.GetExpectedIncome(tin);

                return Redirect("Clients");
            }
            else return Redirect("../Home/Index");            
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("../Home/Index");
        }
    }
}