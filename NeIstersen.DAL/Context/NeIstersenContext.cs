using NeIstersen.Core.Entity;
using NeIstersen.Map.EntityMaps;
using NeIstersen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.DAL.Context
{
    public class NeIstersenContext:DbContext
    {
        public NeIstersenContext()
        {
            //db base baglanma
            Database.Connection.ConnectionString = @"server=.;database=NeIstersenDB;uid=sa;pwd=123;";
            

            //database stratejisidir(bu yontem test anında isimize yarar.) proje bıtımınde kapatılabilir.
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<NeIstersenContext>()); //Bu strateji sayesinde modeldeki bir değişimde (Örnek Product classına yeni bir property eklenmesi gibi) veritabanı Drop edilir ve baştan oluşturulur.

            //Stratejileri kapatmak icin:
            //Database.SetInitializer<OyunPazariContext>(null);

        }
        //Map sınıflarımızı da context'e dahil edebilmek için modellerin (entitylerin) tabloya dönüştürülmesi anında çalışacak olan onModelCreating metodunu yani modelleri tabloya dönüştüren metodu override ederek çağırıyoruz. DB Kurallarımızı da dahil etmesini sağlıyoruz
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());

            base.OnModelCreating(modelBuilder);
        }


        //Dbsetlerle tablolar oluşturma.
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        public override int SaveChanges()
        {
            //Otomatik loglama amaçlı kullanılan bazı özelliklerin doldurulması için, savechannges metodunu override ediyoruz.

            //İlk olarak yeni eklenen veya yeni güncellenen tüm kayıtları yakalamalıyız.

            //ChangeTracker nesnesi savechanges metodu çağırıldığında bizim yaptığımız tüm kayıtlardaki değişimleri takip eden nesnedir.

            //Alttaki kodda eklenmeyi bekleyen veya güncellenmeyi bekleyen tüm kayıtları yani entry'leri yakalıyoruz.
            var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);


            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime date = DateTime.Now;
            //Utility projesinden çekilir.
            //string ip = RemoteIP.IpAddress; //Buraya döncez
            string ip = default(string);

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (entity != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        //1 yazanları solid prensiplerinden öturu birkez tanımlamak icin yukarıda tanımladım.
                        entity.Durumu = Core.Entity.Enum.Status.Aktif;
                        entity.EkleyenKullaniciAdi = identity;//1
                        entity.EkleyenBilgisayarIsmi = computerName;//1
                        entity.EkleyenIP = ip;//1
                        entity.EklenmeTarihi = date;//1
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.GuncelleyenKullaniciAdi = identity;//1
                        entity.GuncelleyenBilgisayarIsmi = computerName;//1
                        entity.GulleyenIP = ip;//1
                        entity.GuncellemeTarihi = date;//1
                    }
                }
            }


            return base.SaveChanges();


        }


    }
}
