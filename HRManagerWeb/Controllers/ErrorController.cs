using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRManagerWeb.Controllers
{
    public class ErrorController : Controller
    {
        public ErrorController() { }

        public ActionResult Error()
        {
            return View();
        }
        public ActionResult UserUnavailable()
        {
            return View();
        }
    }
}