using NeIstersen.Core.Map;
using NeIstersen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Map.EntityMaps
{
    public class CategoryMap:CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");

            Property(cat => cat.Adi).IsRequired();

            //Kategori - Ürün İlişkisi => Zaten sınıflar içerisinde gerekli ilişki tanımlamalarını gerçekleştirdiğimiz için, alttaki kodları yazmamıza gerek yok.

            HasMany(cat => cat.Products)  //Kategorinin bir sürü ürünü vardır.
                .WithRequired(product => product.Category) //Ürünlerin zorunlu kategorisi vardır.
                .HasForeignKey(product => product.CategoryID) //İkincil anahtar üründeki CategoryID'dir.
                .WillCascadeOnDelete(false); //Kategoriler silindiğinde ürünler silinmesin(false yazdıgımız için)

        }
    }
}
