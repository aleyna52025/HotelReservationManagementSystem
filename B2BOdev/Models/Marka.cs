using System.ComponentModel.DataAnnotations;

namespace B2BOdev.Models
{
    public class Marka
    {
        [Key]
        public int MarkaID { get; set; }
        public string MarkaAd { get; set; }
    }
}
