namespace B2BOdev.Models
{
    public class DashboardViewModel
    {
        public int ToplamSiparisSayisi { get; set; }
        public Dictionary<string, int> EnCokSatilanMalzemeler { get; set; }
        public Dictionary<string, int> AylikSiparisSayilari { get; set; }
    }
}
