using NeIstersen.Core.Map;
using NeIstersen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Map.EntityMaps
{
    public class OrderDetailMap:CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetails");

            Property(od => od.Fiyat).IsOptional();
            Property(od => od.Miktar).IsOptional();
            Property(od => od.Indirim).IsOptional();
            Property(od => od.YuzukOlcusu).IsOptional();

            //OrderDetail - Product İlişkisi
            HasRequired(od => od.Product)
                .WithMany(product => product.OrderDetails)
                .HasForeignKey(od => od.ProductID)
                .WillCascadeOnDelete(false);
        }
    }
}
