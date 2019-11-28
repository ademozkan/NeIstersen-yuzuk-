using NeIstersen.Model.Entity;
using NeIstersen.Service.Concrete;
using NeIstersen.Service.TransferObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NeIstersen.UI.Controllers
{
    public class AccountController : Controller
    {
        AppUserService _appUserService = new AppUserService();

        //Giris islemLERİNİ KONTROL ETTİGİM SAYFADIR


        [HttpPost]
        public ActionResult Login(LoginVM data)
        {
             

            //LoginVM içerisinde yazılan required benzeri kuralları kontrol etme işlemi(ALANLAR BOS BIRAKILMISMI).
            if (ModelState.IsValid)
            {
                //username ve passswordu eşleşen kişiyi buluyorum.
                AppUser currentUser = _appUserService.GetByDefault(user => user.KullaniciAdi == data.KullaniciAdi && user.Parola == data.Parola);

                //Bu kişinin bulunup bulunmadığına bakıyoruz.
                if (currentUser != null)
                {
                    
                    //Bu kişi için bir session yani seans oluşturuyoruz.
                    //True yapılırsa, cookie olarak açılır ve tarayıcı kapansa da saklanmaya devam eder, false yapılırsa session yani seans olarak açılır ve tarayıcı kapatıldığında kullanıcı bilgileri kaybolur.
                    //kullanıcı adını essiz kılıyoruz

                    FormsAuthentication.SetAuthCookie(currentUser.KullaniciAdi, true);

                    //Eğer rolü admin ise admin area içerisine yönlendiriyoruz.
                    if (currentUser.Rolu == Role.Admin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }

                    //Eğer admin değilse, geldiği sayfaya döner.
                    return Redirect(Request.UrlReferrer.ToString());
                }

            }

            //İstersek, yeni kullanıcı sayfasına da yönlendirebiliriz.
            return RedirectToAction("Signup");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("sepet");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(AppUser data)
        {

            if (_appUserService.GetByDefault(x => x.KullaniciAdi == data.KullaniciAdi) != null)
            {
                
                ViewBag.Message = "Bu Kullanıcı Adı Alınmıştır!";
                return View();
            }

            //her girenin rolu basta member olsun
            data.Rolu = Role.Member;
            _appUserService.Add(data);
            _appUserService.Save();

            return RedirectToAction("Index", "Home");
        }


    }


}