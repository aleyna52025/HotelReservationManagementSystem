using System.ComponentModel.DataAnnotations;

namespace B2BOdev.Models
{
    public class Malzeme
    {
        [Key]
        public int MalzemeId { get; set; }
        public string MalzemeKod { get; set; }
        public string MalzemeAd { get; set; }
        public int MarkaId { get; set; }
        public Marka Marka { get; set; }
        public int KAtegoriId { get; set; }
        public Kategori Kategori { get; set; }
        public string Aciklama { get; set; }
        public float SatVergiOran { get; set; }
        public int Del{ get; set; }
        public string? GorselYolu { get; set; }

        public string OzelKod1{ get; set; }
        public string OzelKod2{ get; set; }
        public string OzelKod3{ get; set; }
        public string OzelKod4{ get; set; }
        public string OzelKod5{ get; set; }
        public int BirimId { get; set; }
        public Birim Birim { get; set; }
     
        public ICollection<SiparisDetay> SiparisDetay { get; set; }
 

    }
}
