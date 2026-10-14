using System.ComponentModel.DataAnnotations;

namespace B2BOdev.Models
{
    public class Durum
    {
        public Durum()
        {
            this.Siparis = new HashSet<Siparis>();
          
        }
        [Key]
        public int durumId { get; set; }
        public string durumu { get; set; }
        public ICollection<Siparis> Siparis { get; set; }
    }
}
