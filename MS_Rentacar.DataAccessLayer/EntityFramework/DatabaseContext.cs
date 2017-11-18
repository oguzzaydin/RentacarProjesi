using MS_Rentacar.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Rentacar.DataAccessLayer.EntityFramework
{
    public class DatabaseContext : DbContext
    {

        public DbSet<MsUser> MsUser { get; set; }
        public DbSet<Urunler> Urunler { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<İletisim> Iletisim { get; set; }
        public DbSet<KiralamaKosullari> KiralamaKosullari { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<GelenMesajlar> GelenMesajlar { get; set; }
        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }
}
