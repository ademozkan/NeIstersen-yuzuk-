using NeIstersen.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeIstersen.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            CategoryService categoryService = new CategoryService();
            ViewBag.Aktif = categoryService.GetActive();
            ProductService _pService = new ProductService();
            return View(_pService.SonEklenenUrunler(4));
            
        }
    }
}