using System.Data.Entity;
using MS_Rentacar.Entities.EntityFramework;
using System;

namespace MS_Rentacar.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        public MyInitializer()
        {

        }
      
        protected override void Seed(DatabaseContext context)
        {
            Hakkimizda about = new Hakkimizda()
            {
                Id=Guid.NewGuid().ToString(),
                Aciklama="Lorem Ipsum",
                ImageUrl="aaa"
            };
            KiralamaKosullari kk = new KiralamaKosullari(){ Id = Guid.NewGuid().ToString(), Aciklama = "Lorem Ipsum" };
            İletisim iletisim = new İletisim(){ Id = Guid.NewGuid().ToString(), Telefon1 = "Lorem Ipsum" , Telefon2 = "Lorem Ipsum", Email1 = "Lorem Ipsum", Email2 = "Lorem Ipsum",Adres="Adres" };
            MsUser admin = new MsUser (){ Id = Guid.NewGuid().ToString(), Username = "Admin", Password = "msrentacar", Name = "Ad", Surname = "Soyad", Email = "admin@mail.com"};
            context.MsUser.Add(admin);
            context.Hakkimizda.Add(about);
            context.KiralamaKosullari.Add(kk);
            context.Iletisim.Add(iletisim);

            context.SaveChanges();
        }
    }
}