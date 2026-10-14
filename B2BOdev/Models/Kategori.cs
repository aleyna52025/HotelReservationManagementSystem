using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B2BOdev.Models
{
    public class Kategori
    {
        public Kategori()
        {
            this.Malzeme = new HashSet<Malzeme>();
            this.AltKategoriler = new HashSet<Kategori>();
        }

        [Key]
        public int KategoriId { get; set; }

        public string KategoriAd { get; set; }

        public string KategoriTip { get; set; }

 
        public int? UstKategoriId { get; set; }

        [ForeignKey("UstKategoriId")]
        public virtual Kategori UstKategori { get; set; }

      
        public virtual ICollection<Kategori> AltKategoriler { get; set; }

        public ICollection<Malzeme> Malzeme { get; set; }
    }
}
