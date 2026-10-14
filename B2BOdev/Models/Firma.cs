using System.ComponentModel.DataAnnotations;

namespace B2BOdev.Models
{
    public class Firma
    {
        public Firma()
        {
            this.FirmaKategori = new HashSet<FirmaKategori>();

        }
        [Key]
        public int FirmaID { get; set; }
        public string FirmaKod { get; set; }
        public string FirmaUnvanı { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set;}
        public string tel { get; set; }
          public int Del { get; set; }
        [Required(ErrorMessage = "E-posta alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Eposta { get; set; }
 
        public Adres Adres { get; set; }

        public ICollection<FirmaKategori> FirmaKategori { get; set; }
    } 
}
