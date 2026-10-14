using System.ComponentModel.DataAnnotations;

namespace B2BOdev.Models
{
    public class Teklif
    {
        [Key]
        public int TeklifID { get; set; }

        public int FirmaID { get; set; }
        public Firma Firma { get; set; }

        public DateTime Tarih { get; set; } = DateTime.Now;
        
        public decimal ToplamTutar { get; set; }

        public string Durum { get; set; } = "Taslak";  

        public string Aciklama { get; set; }

        public ICollection<TeklifDetay> TeklifDetaylari { get; set; }
    }
}
