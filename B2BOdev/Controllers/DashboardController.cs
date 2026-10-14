using B2BOdev.Data;
using B2BOdev.Models;
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace B2BOdev.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UygulamaDbContext _context;

        public DashboardController(UygulamaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new DashboardViewModel();

            // Toplam sipariş sayısı
            viewModel.ToplamSiparisSayisi = _context.Siparis.Count();

            // En çok satılan malzemeler (top 5)
            viewModel.EnCokSatilanMalzemeler = _context.SiparisDetay
                .Include(x => x.Malzeme)
                .GroupBy(x => x.Malzeme.MalzemeAd)
                .Select(g => new { MalzemeAd = g.Key, Miktar = g.Sum(x => x.Miktar) })
                .OrderByDescending(x => x.Miktar)
                .Take(5)
                .ToDictionary(x => x.MalzemeAd, x => (int)x.Miktar);

            // Aylık sipariş sayısı (son 12 ay)
            viewModel.AylikSiparisSayilari = _context.Siparis
      .AsEnumerable() // Belleğe al
      .GroupBy(s => new { s.Tarih.Year, s.Tarih.Month })
      .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
      .Take(12)
      .ToDictionary(
          g => CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key.Month) + " " + g.Key.Year,
          g => g.Count()
      );

            return View(viewModel);
        }
    }
}
