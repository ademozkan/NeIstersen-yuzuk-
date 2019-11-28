using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeIstersen.UI.Controllers
{
    public class ErrorController : Controller
    {
        //hata oldugunda cıkacak sayfa
        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}