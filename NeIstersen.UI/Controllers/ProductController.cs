using NeIstersen.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeIstersen.UI.Controllers
{
    public class ProductController : Controller
    {
        ProductService _pServis = new ProductService();

        //categori idye gore product veren action
        public ActionResult List(Guid? id)
        {
            CategoryService categoryService = new CategoryService();
            ViewBag.Aktif = categoryService.GetActive();
            //ID NULL GELME DURUMU
            if (id == null) return RedirectToAction("Index", "Home");

            return View(_pServis.CategoriIdyeGoreUrunler((Guid)id));
        }

        public ActionResult Detail(Guid? id)
        {
            //ID NULL GELME DURUMU
            if (id == null) return RedirectToAction("Index", "Home");

            return View(_pServis.ProdutidyeGoreUrun((Guid)id));
            
        }

    }
}