using NeIstersen.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Core.Entity
{
    public class CoreEntity
    {
        //BUTUN SINIFLARIN BASE SINIFIDIR.


        //tabloların(urun categori calısan vb.) durumlarını belirlemek amacıyla enum klasorunu altına status adında enum acılmıstır.

        public Status Durumu { get; set; }

        //bütün sınıflarda ıd proportisi olusturmamak icin tanımladım. 
        public Guid ID { get; set; }
        

        //Alttaki özellikler loglama icin eklenmistir.(İlk ekleme anı)

        public string EkleyenBilgisayarIsmi { get; set; }
        public string EkleyenIP { get; set; }
        public Guid EkleyenBy { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public string EkleyenKullaniciAdi { get; set; }


        //Alttaki özellikler Güncelleme Anı icin Loglamadır.

        public string GuncelleyenBilgisayarIsmi { get; set; }
        public string GulleyenIP { get; set; }
        public Guid GuncelleyenBy { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public string GuncelleyenKullaniciAdi { get; set; }
    }
}
