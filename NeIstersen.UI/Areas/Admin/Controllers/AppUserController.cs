using NeIstersen.Model.Entity;
using NeIstersen.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeIstersen.UI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {

        AppUserService _appUserService;
        public AppUserController()
        {
            _appUserService = new AppUserService();
        }
        public ActionResult List()
        {
            return View(_appUserService.GetActive());
        }

        public ActionResult Delete(Guid id)
        {
            _appUserService.Remove(id);
            _appUserService.Save();

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(Guid id)
        {
            return View(_appUserService.GetByID(id));
        }
        [HttpPost]
        public ActionResult Update(AppUser data)
        {
            

            AppUser guncellenecek = _appUserService.GetByID(data.ID);

            guncellenecek.Adi = data.Adi;
            guncellenecek.SoyAdi = data.SoyAdi;
            guncellenecek.Email = data.Email;
            guncellenecek.Parola = data.Parola;
            guncellenecek.Rolu = data.Rolu;
            _appUserService.Update(guncellenecek);
            _appUserService.Save();
            return RedirectToAction("List");
        }
    }
}