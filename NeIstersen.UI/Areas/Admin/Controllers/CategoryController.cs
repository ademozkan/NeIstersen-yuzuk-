using NeIstersen.Model.Entity;
using NeIstersen.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeIstersen.UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        CategoryService _categoryService = new CategoryService();

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(Category data)
        {
            
            //databasede bu isimde category varmı sorgulayan metod
            if (_categoryService.CategoryVarmi(data))
            {
                ViewBag.CategoryVar = "Bu İsimde Kategori Bulunmaktadır";
                return View("Add");
                
            }
            //bunuda yapacan kim ekledi
            //data.CreatedBy = userID;
            _categoryService.Add(data);
            _categoryService.Save();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {

            return View(_categoryService.GetActive());
        }

        public ActionResult Delete(Guid id)
        {
            _categoryService.Remove(id);
            _categoryService.Save();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(Guid id)
        {
            Category guncellenecek = _categoryService.GetByID(id);

            return View(guncellenecek);
        }

        [HttpPost]
        public ActionResult Update(Category data)
        {
            Category guncellenecek = _categoryService.GetByID(data.ID);
            guncellenecek.Adi = data.Adi;
            guncellenecek.Aciklama = data.Aciklama;
            
            _categoryService.Update(guncellenecek);
            _categoryService.Save();
            return RedirectToAction("List");
        }

    }
}