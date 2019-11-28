using NeIstersen.Model.Entity;
using NeIstersen.Service.Concrete;
using NeIstersen.Service.TransferObjects.DataTransferObjects;
using NeIstersen.Service.TransferObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeIstersen.UI.Areas.Member.Controllers
{
    public class CartController : BaseController
    {
        // GET: Member/Cart
        ProductService _productService;
        AppUserService _appUserService;
        
        public CartController()
        {
            _appUserService = new AppUserService();
            _productService = new ProductService();
        }

        public JsonResult List()
        {
            //Sepet var mı ? 
            //Sepet session içerisinde saklanacak yani sepet tarayıcı kapandığında yok olacak.
            if (Session["sepet"] != null)
            {
                Cart cart = Session["sepet"] as Cart;
                return Json(cart.MyCart, JsonRequestBehavior.AllowGet);
            }
            return Json("Empty", JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(Guid id)
        {
            //Gelen idye ait ürünü yakalamalıyız.
            Product sepeteEklenecekUrun = _productService.GetByID(id);

            //Sonrasında bu ürün içerisinden gerekli özellikleri alıp, sepet elemanına çevirmeliyiz.
            CartItem sepetElemani = new CartItem();
            sepetElemani.ID = sepeteEklenecekUrun.ID;
            sepetElemani.UrunAdi = sepeteEklenecekUrun.Adi;
            sepetElemani.Fiyati = sepeteEklenecekUrun.SatisFiyat;
            //sepetElemani.YuzukOlcu=(int)ViewBag.yuzukolcusu;
            //sepetElemani.ImagePath = sepeteEklenecekUrun.ImagePath;
            sepetElemani.Miktari = 1; //Metot her çağırılışında bir adet ekleyeceğiz.
            
            Cart cart;


            //Daha önceden bir sepet var mı onu kontrol ediyoruz. Yoksa sepet oluşturulacak.
            if (Session["sepet"] != null)
            {
                //Session içerisinde sepet varsa, object tipinde gelecektir. O nesneyi cast ederek almalı ve yeni(veya miktarı arttırılacak) ürünü sepete eklemeliyiz.
                cart = Session["sepet"] as Cart;
                cart.AddItem(sepetElemani);
                //Son olarak , sepetin son halini tekrar aynı session içerisine atmalıyız.
                Session["sepet"] = cart;
            }
            else
            {
                //Session'da sepet yoksa, yeni bir session oluştur.
                cart = new Cart();
                cart.AddItem(sepetElemani);
                Session.Add("sepet", cart);
            }

            return Json(cart.MyCart, JsonRequestBehavior.AllowGet);
        }

        //sepet ikonunun ustundeki sayı icin
        public JsonResult CartItemCount()
        {
            if (Session["sepet"] != null)
            {
                Cart cart = Session["sepet"] as Cart;
                return Json(cart.MyCart.Count, JsonRequestBehavior.AllowGet);
            }
            return Json("0", JsonRequestBehavior.AllowGet);
        }

        
        
    }
}