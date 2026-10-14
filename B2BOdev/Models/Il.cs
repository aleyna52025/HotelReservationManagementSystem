using System.ComponentModel.DataAnnotations;

namespace B2BOdev.Models
{
    public class Il
    {
        [Key]
        public int Ilid { get; set; }
        public string IlAdi { get; set; }

        public ICollection<Ilce> Ilceler { get; set; }
        public ICollection<Adres> Adresler { get; set; }
    }
}
