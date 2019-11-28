using NeIstersen.Core.Map;
using NeIstersen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Map.EntityMaps
{
    public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            //tablo ismi db de
            ToTable("dbo.Products");
            Property(product => product.AlisFiyat).IsOptional();
            Property(product => product.SatisFiyat).IsOptional();
            Property(product => product.Stok).IsOptional();
            Property(product => product.MobildeGoster).IsOptional();
            Property(product => product.WebdeGoster).IsOptional();
            Property(product => product.Ozellikler).IsOptional();
            
            //Kategori ilişkisi categoryMap altında, OrderDetail ilişkisi OrderDetailMap altında var. Bu nedenle burada bir daha yazmaya gerek yoktur.
        }
    }
}
