using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Obligatorio1.Services;

namespace Obligatorio1.Controllers
{
    public class DepositController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (Convert.ToString(Session["Role"]) == "deposito")
            {
                ProductServices proxy = new ProductServices();
                ViewBag.productsList = proxy.GetProducts();

                return View("Deposit");
            }
            else return Redirect("../Home/Index");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session["LoggedUser"] = null;
            Session["Role"] = null;
            return Redirect("../Home/Index");
        }
        [HttpGet]
        public ActionResult Imports(string idProduct)
        {
            if (Convert.ToString(Session["Role"]) == "deposito")
            {
                ViewBag.idProduct = idProduct;
                return View("Imports");
            }
            else return Redirect("Index");
        }
        [HttpPost]
        public ActionResult AddImport()
        {
            throw new NotImplementedException();
        }
    }
}