using NeIstersen.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Model.Entity
{
    public class Product:CoreEntity
    {
        public Product()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public string Adi { get; set; }
        public long Stok { get; set; }
        
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool WebdeGoster { get; set; }
        public bool MobildeGoster { get; set; }
        

        //ayrı olarakyapılabilir bu bölum
        public string Ozellikler { get; set; }

        //Kategori İlişkisi
        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        //Sipariş Detay İlişkisi
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        //VİRTUAL entityfremwork tarafı icin.
    }
}
