using NeIstersen.Model.Entity;
using NeIstersen.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeIstersen.UI.Areas.Member.Controllers
{

    [Roles(Role.Admin, Role.Member)]
    public class BaseController : Controller
    {
        // GET: Member/Base
        public ActionResult Index123()
        {
            return View();
        }
    }
}