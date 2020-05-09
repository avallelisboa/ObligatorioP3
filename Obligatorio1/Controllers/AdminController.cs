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
        // GET: Admin
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
                ViewBag.clientList = proxy.GetClients();

                return View("Clients");
            }
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