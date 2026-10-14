using System.ComponentModel.DataAnnotations;

namespace B2BOdev.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int FirmaID { get; set; }
        public Firma firma { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Personel { get; set; }
    }
}
