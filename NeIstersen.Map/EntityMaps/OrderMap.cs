using NeIstersen.Core.Map;
using NeIstersen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Map.EntityMaps
{
    public class OrderMap:CoreMap<Order>
    {
        public OrderMap()
        {
            ToTable("dbo.Orders");
            Property(o => o.ToplamTutar).IsOptional();
            Property(o => o.SiparisTarihi).HasColumnType("datetime2").IsOptional();
            Property(o => o.SiparisStatu).IsOptional();
            Property(o => o.OnayTarihi).HasColumnType("datetime2").IsOptional();


            //Order - AppUser İlişkisi
            HasRequired(o => o.AppUser)
                .WithMany(user => user.Orders)
                .HasForeignKey(o => o.AppUserID)
                .WillCascadeOnDelete(false);

            //Order - OrderDetail İlişkisi
            HasMany(o => o.OrderDetails)
                .WithRequired(od => od.Order)
                .HasForeignKey(od => od.OrderID)
                .WillCascadeOnDelete(false);
        }
    }
}
