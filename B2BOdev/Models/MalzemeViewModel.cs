namespace B2BOdev.Models
{
    public class MalzemeViewModel
    {
        public int MalzemeId { get; set; }
        public string MalzemeKod { get; set; }
        public string MalzemeAd { get; set; }
        public string MarkaAdi { get; set; } // Marka adı
        public string KategoriAdi { get; set; } // Kategori adı
        public string Aciklama { get; set; }
        public decimal? SatVergiOr { get; set; }
        public string OzelKod1 { get; set; }
        public string OzelKod2 { get; set; }
        public string OzelKod3 { get; set; }
        public string OzelKod4 { get; set; }
        public string OzelKod5 { get; set; }
        public string BirimAdi { get; set; } // Birim adı
    }

}
