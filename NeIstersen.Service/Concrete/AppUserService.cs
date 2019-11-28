using NeIstersen.Model.Entity;
using NeIstersen.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeIstersen.Service.Concrete
{
    public class AppUserService:BaseService<AppUser>
    {
        public AppUser GetuserByUserName(string userName)
        {
            return GetByDefault(user => user.KullaniciAdi == userName);
        }

        public Guid GetIDByUserName(string userName) => GetByDefault(user => user.KullaniciAdi == userName).ID;
    }
}
