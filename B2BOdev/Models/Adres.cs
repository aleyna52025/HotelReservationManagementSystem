using System.ComponentModel.DataAnnotations;

namespace B2BOdev.Models
{
    public class Adres
    {
        public Adres()
        {
            this.Siparis = new HashSet<Siparis>(); 
        }
        [Key]
        public int AdresID { get; set; }
        public string Adres1 { get; set; }
        public string Adres2 { get; set; }
        public int Ilid { get; set; }
        public Il Il { get; set; }
        public int Ilceid { get; set; }
        public Ilce Ilce { get; set; }
        public string Mahalle { get; set; }
        public string Tel { get; set; }
        public string Fax{ get; set; }
        public string CepTel{ get; set; }
        public string Del{ get; set; }
        public int FirmaId{ get; set; }
        public Firma firma{ get; set; }
        public ICollection<Siparis> Siparis{ get; set; }
       

    }
}
