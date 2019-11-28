using NeIstersen.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Model.Entity
{
    public enum OrderStatus
    {
        Yok = 0,
        SiparisAlindi = 2,
        Hazırlanıyor = 4,
        Onaylandi = 6,
        IptalEdildi = 8,
        Reddedildi = 10,
        Eksik = 12
            
    }
    public class Order:CoreEntity
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public OrderStatus SiparisStatu { get; set; }
        public decimal ToplamTutar { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime OnayTarihi { get; set; }

        //Sipariş Detay İlişkisi
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        //Kullanıcı İlişkisi
        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}
