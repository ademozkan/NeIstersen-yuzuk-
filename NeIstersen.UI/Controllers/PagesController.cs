using NeIstersen.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeIstersen.UI.Controllers
{
    public class PagesController : Controller
    {
        //partial view kullanımını bıraktım nasıl yapıldıgını gösterdim yerine RenderSection kullandım.

        //Geriye Filtre ve Category menusunu donduren Partial view
        public PartialViewResult MainMenu()
        {
            //return PartialView("_MainMenu", categoryService.GetActive());
            return PartialView("_MainMenu");
        }
    }
}