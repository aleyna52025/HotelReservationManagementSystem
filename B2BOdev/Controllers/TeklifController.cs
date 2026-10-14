using B2BOdev.Data;
using B2BOdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace B2BOdev.Controllers
{
    public class TeklifController:Controller
    {
        private readonly UygulamaDbContext _context;
        public TeklifController(UygulamaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var liste=_context.Teklifler.Include(t=>t.Firma).ToList();
            return View(liste);
        }
        public IActionResult Create()
        {
            ViewBag.Firma = new SelectList(_context.Firma.ToList(), "FirmaID", "FirmaUnvanı");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teklif teklif)
        {
       //   if(ModelState.IsValid)
          { 
            teklif.Tarih = DateTime.Now;
            _context.Teklifler.Add(teklif);
            _context.SaveChanges();
            return RedirectToAction("Edit", new { id = teklif.TeklifID });
        }
            ViewBag.Firmalar = new SelectList(_context.Firma.ToList(), "FirmaID", "FirmaUnvanı", teklif.FirmaID);
            return View(teklif);
        }
        public IActionResult Edit(int id)
        {
            var teklif = _context.Teklifler.Include(t => t.Firma)
                                           .Include(t => t.TeklifDetaylari)
                                           .ThenInclude(td => td.Malzeme)
                                           .Include(t => t.TeklifDetaylari)
                                           .ThenInclude(td => td.Birim)   
                                           .FirstOrDefault(t => t.TeklifID == id);

            if (teklif == null)
                return NotFound();

            ViewBag.Malzemeler = new SelectList(_context.Malzeme.ToList(), "MalzemeId", "MalzemeAd");
            ViewBag.Birimler = new SelectList(_context.Birim.ToList(), "BirimID", "BirimAd");   

            return View(teklif);
        }

        [HttpPost]
        public IActionResult AddDetay(int TeklifID, int MalzemeID, int Miktar, decimal BirimFiyat, int BirimId, float Kdv, float IndOran)
        {
            float fiyat = (float)BirimFiyat;
            float indTutar = fiyat * Miktar * (IndOran/100f);
            float toplam = fiyat * Miktar - indTutar;
            float toplamKdv = toplam *( Kdv/100f);
            float genelToplam = toplam + toplamKdv;

            var detay = new TeklifDetay
            {
                TeklifID = TeklifID,
                MalzemeID = MalzemeID,
                Miktar = Miktar,
                BirimFiyat = BirimFiyat,
                BirimId = BirimId,
                Kdv = Kdv,
                IndOran = IndOran,
                IndTutar = indTutar,
                Toplam = toplam,
                ToplamKdv = toplamKdv,
                GenelToplam = genelToplam
            };

            _context.TeklifDetaylari.Add(detay);
            _context.SaveChanges();

            return RedirectToAction("Edit", new { id = TeklifID });
        }

        public IActionResult SipariseCevir(int id)
        {
            var teklif = _context.Teklifler
                .Include(t => t.Firma)
                .Include(t => t.TeklifDetaylari)
                .ThenInclude(td => td.Malzeme)
                .FirstOrDefault(t => t.TeklifID == id);

            if (teklif == null || teklif.TeklifDetaylari == null || !teklif.TeklifDetaylari.Any())
            {
                return NotFound("Teklif bulunamadı veya detay yok.");
            }

            var siparis = new Siparis
            {
                FirmaId = teklif.FirmaID,
                Tarih = DateTime.Now,
                Aciklama = teklif.Aciklama,
                teslimatadresıd = 3, // Dilersen ViewBag ile seçtirebilirsin
                SipNo = "SIP-" + DateTime.Now.Ticks,
                DurumID = 1,
                SiparisDetay = new List<SiparisDetay>()
            };

            foreach (var detay in teklif.TeklifDetaylari)
            {
                siparis.SiparisDetay.Add(new SiparisDetay
                {
                    MalzemeID = detay.MalzemeID,
                    BirimId = detay.BirimId,
                    Miktar = detay.Miktar,
                    Fiyat = (float)detay.BirimFiyat,
                    Kdv = detay.Kdv,
                    IndOran = detay.IndOran,
                    IndTutar = detay.IndTutar,
                    Toplam = detay.Toplam,
                    ToplamKdv = detay.ToplamKdv,
                    GenelToplam = detay.GenelToplam
                });
            }

            _context.Siparis.Add(siparis);

            teklif.Durum = "Onaylandı";
            _context.SaveChanges();

            return RedirectToAction("Index", "Siparis");
        }


    }
}
