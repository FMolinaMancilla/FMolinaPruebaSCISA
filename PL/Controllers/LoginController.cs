using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {

            ML.Doctor doctor = new ML.Doctor();
            ML.Result result = new ML.Result();

            result = BL.Doctor.GetByEmail(Email);

            if (result.Correct == true)
            {
                doctor = (ML.Doctor)result.Object;

                if (doctor.Email == Email && doctor.Password == Password)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Contraseña incorrecta";
                }
            }
            else
            {
                ViewBag.Message = "El email es invalido" + result.ErrorMessage;
            }

            return View();
        }
    }
}