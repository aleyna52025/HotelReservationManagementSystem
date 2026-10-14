using System.ComponentModel.DataAnnotations;

namespace B2BOdev.Models
{
    public class Birim
    {

        public Birim()
        {
            this.Malzeme = new HashSet<Malzeme>();
            this.SiparisDetay = new HashSet<SiparisDetay>();
        }

        [Key]
        public int BirimID { get; set; }
        public string BirimAd { get; set; }
        public string BirimKod { get; set; }
        public virtual ICollection<Malzeme> Malzeme { get; set; }
        public virtual ICollection<SiparisDetay> SiparisDetay { get; set; }
    }
}
