using NeIstersen.Model.Entity;
using NeIstersen.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeIstersen.UI.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        OrderService _orderService;
        OrderDetailService _orderDetailservice;
        ProductService _productService;


        public OrderController()
        {
            _orderService = new OrderService();
            _orderDetailservice = new OrderDetailService();
            _productService = new ProductService();
        }
        public ViewResult OnayBekleyenSiparis()
        {
            return View(_orderService.OnayBekleyenSiparis());
        }

        public ViewResult TumSiparis()
        {
            return View(_orderService.GetActive());
        }

        public ViewResult Detail(Guid id)
        {

            return View(_orderDetailservice.GetDefault(od => od.OrderID == id));
        }

        public RedirectToRouteResult SiparisOnay(Guid id)
        {
            //Sipariş yakalanır.
            Order order = _orderService.GetByID(id);

            //Stoktan Düşme İşlemi Her bir sipariş detayında gezilir ve içerisindeki ürün yakalanır. Sonrasında stoklardan siparişteki miktar kadar düşülür ve ürün güncellenir.

            foreach (var item in order.OrderDetails)
            {
                Product nextProduct = _productService.GetByID(item.ProductID);
                nextProduct.Stok -= item.Miktar;
                _productService.Update(nextProduct);
                _productService.Save();
            }
            //order.GuncelleyenBy = userID;
            order.SiparisStatu = OrderStatus.Onaylandi;
            _orderService.Update(order);
            _orderService.Save();

            return RedirectToAction("TumSiparis");
        }

        public RedirectToRouteResult SiparisRed(Guid id)
        {
            Order order = _orderService.GetByID(id);
            //order.ModifiedBy = userID;
            order.SiparisStatu = OrderStatus.Reddedildi;
            //_orderService.Remove(order);
            _orderService.Save();
            return RedirectToAction("TumSiparis");
        }
    }
}