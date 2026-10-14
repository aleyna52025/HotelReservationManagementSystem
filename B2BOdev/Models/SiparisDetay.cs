using System.ComponentModel.DataAnnotations;

namespace B2BOdev.Models
{
    public class SiparisDetay
    {
        [Key]
        public int SipDetID { get; set; }
        public int SipId { get; set; }
        public Siparis Siparis { get; set; }
        public int MalzemeID { get; set; }
        public Malzeme Malzeme { get; set; }
        public int BirimId { get; set; }
        public Birim Birim { get; set; }
        public float Miktar{ get; set; }
        public float Fiyat{ get; set; }
        public float Kdv{ get; set; }
        public float IndOran{ get; set; }
        public float IndTutar{ get; set; }
        public float Toplam{ get; set; }
        public float ToplamKdv{ get; set; }
        public float GenelToplam{ get; set; }
    }
}
