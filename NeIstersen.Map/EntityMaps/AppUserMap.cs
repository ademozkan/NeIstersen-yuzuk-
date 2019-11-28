using NeIstersen.Core.Map;
using NeIstersen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Map.EntityMaps
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            //db de tablo ismi(dbo yazmaya gerek yoktur.)db deki user ile karısmasın diye users dedim.
            ToTable("dbo.Users");

            Property(user => user.Rolu).IsOptional();//opsitonel
            Property(user => user.KullaniciAdi).IsRequired();//zorunlu
            Property(user => user.Email).IsRequired();
            Property(user => user.Parola).IsRequired();
            Property(user => user.DogumTarhi).HasColumnType("datetime2").IsOptional();
        }
    }
}
