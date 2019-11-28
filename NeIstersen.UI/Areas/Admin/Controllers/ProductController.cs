using NeIstersen.Core.Entity.Enum;
using NeIstersen.Model.Entity;
using NeIstersen.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeIstersen.UI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        CategoryService _categoryService;
        ProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
        }

        [HttpGet]
        public ActionResult List()
        {
            return View(_productService.GetActive());
        }

        
        public ActionResult Add()
        {
            return View(_categoryService.GetActive());
        }

        [HttpPost]
        public ActionResult Add(Product data)
        {
            //databasede bu isimde product varmı sorgulayan metod
            if (_productService.ProductVarmı(data))
            {
                ViewBag.UrunVar = "Bu İsimde Urun Bulunmaktadır";
                return View("Add", _categoryService.GetActive());
            };
            _productService.Add(data);
            _productService.Save();
            return RedirectToAction("List");
        }


        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            _productService.Remove(id);
            _productService.Save();
            return RedirectToAction("List");
        }


        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return RedirectToAction("List");

            Product guncellenecek = _productService.GetByID((Guid)id);

            ViewData["Categories"] = _categoryService.GetActive();

            return View(guncellenecek);
        }

        [HttpPost]
        public ActionResult Update(Product data)
        {
            

            Product guncellenecek = _productService.GetByID(data.ID);

            
           
            guncellenecek.Adi = data.Adi;
            guncellenecek.AlisFiyat = data.AlisFiyat;
            guncellenecek.SatisFiyat = data.SatisFiyat;
            guncellenecek.Stok = data.Stok;
            guncellenecek.WebdeGoster = data.WebdeGoster;
            guncellenecek.MobildeGoster = data.MobildeGoster;
            guncellenecek.Ozellikler = data.Ozellikler;
            guncellenecek.CategoryID = data.CategoryID;

           
            _productService.Update(guncellenecek);
            _productService.Save();
            return RedirectToAction("List");

        }

    }
}