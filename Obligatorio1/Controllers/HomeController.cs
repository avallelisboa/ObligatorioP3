using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Obligatorio1.Models.BL;
using Obligatorio1.Models.Repositories;

namespace Obligatorio1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(int id, string password, string role)
        {
            Session["RegisterError"] = null;


            if(id <= 0 || password == null || role == null)
            {
                Session["RegisterError"] = "Debe completar todos los datos de forma correcta";
                return Redirect("../Home/Index");
            }

            if(role == "admin")
            {
                Admin admin = new Admin(id, password);                
                var result = admin.isUserValid();

                bool isCorrect; string resultMessage;
                isCorrect = result.Item1;
                resultMessage = result.Item2;

                if (!isCorrect)
                {
                    Session["RegisterError"] = resultMessage;
                    return Redirect("../Home/Index");
                }
                else
                {
                    //TO DO Insert it into the database



                    Session["RegisterError"] = resultMessage;
                    return Redirect("../Home/Index");
                }
            }

            else if(role == "deposito")
            {
                Deposit deposit = new Deposit(id, password);
                var result = deposit.isUserValid();

                bool isCorrect; string resultMessage;
                isCorrect = result.Item1;
                resultMessage = result.Item2;

                if (!isCorrect)
                {
                    Session["RegisterError"] = resultMessage;
                    return Redirect("../Home/Index");
                }
                else
                {
                    //TO DO Insert it into the database



                    Session["RegisterError"] = resultMessage;
                    return Redirect("../Home/Index");
                }
            }
            else
            {
                Session["RegisterError"] = "El rol ingresado no es válido";
                return Redirect("../Home/Index");
            }            
        }

        [HttpPost]
        public ActionResult Login(int id, string password)
        {
            Session["LoginError"] = null;

            IRepository<User> userRepository = new UserRepository();
            //ToDo

            Session["LoginError"] = "Los Datos no son correctos";
            return Redirect("../Home/Index");
        }
    }
}