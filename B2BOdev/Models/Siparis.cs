using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B2BOdev.Models
{
    public class Siparis
    {
        [Key]
        public int SipID { get; set; }
        public int FirmaId{ get; set; }
        public Firma Firma { get; set; }
        public DateTime Tarih{ get; set; }
        public string SipNo{ get; set; }
        public int DurumID{ get; set; }
        public Durum Durum{ get; set; }
        public string Aciklama{ get; set; }
        [ForeignKey("Adres")]
        public int teslimatadresıd{ get; set; }
        public Adres Adres{ get; set; }

        public ICollection<SiparisDetay> SiparisDetay { get; set; }
    }
}
