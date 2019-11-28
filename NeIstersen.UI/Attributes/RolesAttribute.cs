using NeIstersen.Model.Entity;
using NeIstersen.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeIstersen.UI.Attributes
{
    //role bazlı izinler icin yaptıgım etribut
    public class RolesAttribute: AuthorizeAttribute
    {
        Role[] _roles;
        AppUserService _appUserService;
        public RolesAttribute(params Role[] roles)
        {
            _appUserService = new AppUserService();
            _roles = new Role[roles.Length];
            //dısarıdan gelen diziyle tanımladıgımız diziyi kopyalama
            Array.Copy(roles, _roles, roles.Length);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Forms authentication anında olutuştuurlan seansta kulannıcının usernameini saklamıştık. Bunun kontorlü için account controller içerisine bakabilirsiniz. FormsAuth ile kullanıcı giriş yaptığında httpcontext sınıfından o kullanıcı ile ilgili saklanan bilgiye erişebiliriz.

            string userName = HttpContext.Current.User.Identity.Name;

            //Kullanıcının adının boş gelmediğinden emin oluyoruz.

            if (!string.IsNullOrWhiteSpace(userName))
            {


                //Kullanıcı adı eşleşen user nesnes, yakalanır.
                AppUser currentUser = _appUserService.GetByDefault(user => user.KullaniciAdi == userName);

                foreach (Role item in _roles)
                {
                    if (currentUser.Rolu == item)
                    {
                        return true;
                    }
                }

                return true;
            }
            //İstersek, Error controller açar ve unauthorized sayfasını hazırlarız.
            HttpContext.Current.Response.Redirect("~/Error/Unauthorized");
            return false;
        }
    }
}