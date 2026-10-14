using System.ComponentModel.DataAnnotations;

namespace B2BOdev.Models
{
    public class FirmaKategori
    {
        [Key]
        public int FirKatId {get;set;}
        public int FirmaID {get;set;}

        public Firma Firma {get;set;}
        public int KategoriId {get;set;}
        public Kategori Kategori {get;set;}
    }
}
