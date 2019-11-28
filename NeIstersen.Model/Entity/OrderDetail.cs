using NeIstersen.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Model.Entity
{
    public class OrderDetail:CoreEntity
    {
        public short Miktar { get; set; }
        public decimal Indirim { get; set; }
        public decimal Fiyat { get; set; }
        public int YuzukOlcusu { get; set; }

        //Ürün İlişkisi
        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }

        //Sipariş İlişkisi
        public Guid OrderID { get; set; }
        public virtual Order Order { get; set; }
    }
}
