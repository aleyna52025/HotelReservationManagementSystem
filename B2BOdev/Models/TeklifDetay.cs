using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace B2BOdev.Models
{
    public class TeklifDetay
    {
        [Key]
        public int TeklifDetayID { get; set; }

        public int TeklifID { get; set; }
        public Teklif Teklif { get; set; }

        public int MalzemeID { get; set; }
        public Malzeme Malzeme { get; set; }

        public int Miktar { get; set; }

        public decimal BirimFiyat { get; set; }
        public int BirimId { get; set; }
        public Birim Birim { get; set; }

        public float Kdv { get; set; }
        public float IndOran { get; set; }
        public float IndTutar { get; set; }
        public float Toplam { get; set; }
        public float ToplamKdv { get; set; }
        public float GenelToplam { get; set; }
    }
}
