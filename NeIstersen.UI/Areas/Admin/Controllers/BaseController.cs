using NeIstersen.Model.Entity;
using NeIstersen.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeIstersen.UI.Areas.Admin.Controllers
{
    [Roles(Role.Admin)]
    public class BaseController : Controller
    {
        
        public ActionResult Index1()
        {
            return View();
        }
    }
}