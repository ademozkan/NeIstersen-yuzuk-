using NeIstersen.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Core.Map
{
    //EntityTypeConfiguration sınıfı bizden bir tip bekler. butip kurallarını yazacagımız sınıftır. T yazarak core map sınıfından miras alan sınıflarda; bizden CoreEntity tipinde yada bu sınıftan miras alan bir sınıf tipinde bekleyecektir. T yerine entitylerimizden bir sınıf yazıcaz ve dokulen kolaonların ayarlarıyla degisiklık yapabiliriz.
    public class CoreMap<T>: EntityTypeConfiguration<T> where T : CoreEntity
    {
        //coremapten miras alındıgı anda gerceklesir.
        public CoreMap()
        {
            //kendi kendine ıd olusturması idyi tanıtma birbir artırma vb. kolon sırası
            Property(core => core.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnOrder(1);

            //doldurulması zorunlu degıl
            Property(core => core.Durumu).IsOptional();

            //Eklemede Kullanılan propertylerin Kuralları
            Property(core => core.EklenmeTarihi).HasColumnType("datetime2").IsOptional();
            Property(core => core.EkleyenBy).IsOptional();


            //Güncellemede Kullanılan propertylerin Kuralları
            Property(core => core.GuncellemeTarihi).HasColumnType("datetime2").IsOptional();
            Property(core => core.GuncelleyenBy).IsOptional();

        }
    }
}
