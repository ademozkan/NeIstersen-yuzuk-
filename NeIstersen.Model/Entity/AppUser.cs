using NeIstersen.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Model.Entity
{
    public enum Role
    {
        None = 0,
        Member = 2,
        Admin = 4,
        Guest = 6
    }
    public class AppUser:CoreEntity
    {
        public AppUser()
        {
            Orders = new List<Order>();
        }
        public string Adi { get; set; }
        public string SoyAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        public Role Rolu { get; set; }
        public string Adres { get; set; }
        public string TelefonNumarası { get; set; }
        public string Email { get; set; }
        public DateTime DogumTarhi { get; set; }
        
        //navigasyon
        //Sipariş İlişkisi
        public virtual ICollection<Order> Orders { get; set; }

    }
}
