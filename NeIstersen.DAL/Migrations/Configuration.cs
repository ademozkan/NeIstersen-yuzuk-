namespace NeIstersen.DAL.Migrations
{
    using NeIstersen.Model.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NeIstersen.DAL.Context.NeIstersenContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        //ilk veri tabaný olusturulurken kolonlara veri ekleme test amaclý metot
        protected override void Seed(NeIstersen.DAL.Context.NeIstersenContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            List<AppUser> defaultUsers = new List<AppUser>();

            defaultUsers.Add(new AppUser
            {
                Adi= "Adem",
                SoyAdi = "Ozkan",
                Adres = "sivas,merkez",
                TelefonNumarasý = "978-807-8044",
                Email = "adem@hotmail.com",
                DogumTarhi = new DateTime(1995, 1, 11),
                Rolu = Role.Admin,
                KullaniciAdi = "admin",
                Parola = "123",
                Durumu = Core.Entity.Enum.Status.Aktif,
                EklenmeTarihi = DateTime.Now

            });

            context.Users.AddRange(defaultUsers);
            base.Seed(context);
        }
    }
}
