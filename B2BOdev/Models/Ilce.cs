using System.ComponentModel.DataAnnotations;

namespace B2BOdev.Models
{
    public class Ilce
    {
        [Key]
        public int Ilceid { get; set; }
        public string IlceAdi { get; set; }

        public int Ilid { get; set; }
        public Il Il { get; set; }

        public ICollection<Adres> Adresler { get; set; }
    }
}
