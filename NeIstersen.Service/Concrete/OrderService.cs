using NeIstersen.Model.Entity;
using NeIstersen.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Service.Concrete
{
    public class OrderService:BaseService<Order>
    {
        //onay bekleyen siparisler
        public List<Order> OnayBekleyenSiparis()
        {
            List<Order> liste = new List<Order>();
            liste = _context.Orders.Where(order => order.SiparisStatu != OrderStatus.Reddedildi
              && order.SiparisStatu != OrderStatus.IptalEdildi
              && order.SiparisStatu != OrderStatus.Yok).ToList();
            return liste;

        }

        //public List<Order> LastOrders(int count)
        //{
        //    return _context.Orders.Where(order => order.SiparisStatu != OrderStatus.Declined
        //   && order.SiparisStatu != OrderStatus.Cancelled
        //   && order.SiparisStatu != OrderStatus.Completed).OrderByDescending(o => o.CreatedDate).Take(count).ToList();
        //}
    }
}
