using B2BOdev.Models;
using Microsoft.EntityFrameworkCore;

namespace B2BOdev.Data
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options)
           : base(options)
        {

        }
        public DbSet<Adres> Adres { get; set; }
        public DbSet<Birim> Birim { get; set; }
        public DbSet<Firma> Firma { get; set; }
        public DbSet<Durum> Durum{ get; set; }
        public DbSet<Il> Il{ get; set; }
        public DbSet<Ilce> Ilce{ get; set; }

        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<FirmaKategori> FirmaKategori { get; set; }
        public DbSet<Malzeme> Malzeme { get; set; }
        public DbSet<Marka> Marka { get; set; }

        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<SiparisDetay> SiparisDetay { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Teklif> Teklifler { get; set; }
        public DbSet<TeklifDetay> TeklifDetaylari { get; set; }



    }
}
