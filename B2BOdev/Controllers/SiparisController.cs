using B2BOdev.Data;
using B2BOdev.Models;
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace B2BOdev.Controllers
{
    public class SiparisController : Controller
    {
        private readonly UygulamaDbContext _context;

        public SiparisController(UygulamaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var firmaId = HttpContext.Session.GetInt32("FirmaID");

            if (firmaId == null)
            {
                return RedirectToAction("Login", "User");  
            }

            var siparisler = _context.Siparis
                .Include(s => s.Firma)
                .Include(s => s.Durum)
                .Include(s => s.Adres)
                .Where(s => s.FirmaId == firmaId)
                .ToList();

            return View(siparisler);
        }



        public async Task<IActionResult> Create()
        {
            var malzemeler = await _context.Malzeme
                .Include(m => m.Birim)
                .Include(m => m.Kategori)
                .Where(m => m.Del == 0)
                .ToListAsync();

            ViewBag.Firmalar = new SelectList(await _context.Firma.ToListAsync(), "FirmaID", "FirmaUnvanı");
            ViewBag.Adresler = new SelectList(await _context.Adres.ToListAsync(), "AdresID", "Adres1");

            var kategoriler = await _context.Kategori
                .Include(k => k.UstKategori)
                .ToListAsync();

            var kategoriListesi = kategoriler.Select(k => new
            {
                KategoriId = k.KategoriId,
                KategoriAd = k.KategoriAd,
                UstKategoriAd = k.UstKategori != null ? k.UstKategori.KategoriAd : "Ana Kategori"
            }).ToList();

            ViewBag.Kategoriler = kategoriListesi;

            return View(malzemeler);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int FirmaId, int teslimatadresıd, string Aciklama, string SiparisDetayJson)
        {
            if (string.IsNullOrEmpty(SiparisDetayJson))
            {
                ModelState.AddModelError("", "Sepet boş.");
                return RedirectToAction(nameof(Create));
            }

            var siparisDetayler = JsonSerializer.Deserialize<List<SiparisDetayViewModel>>(SiparisDetayJson);
            if (siparisDetayler == null || !siparisDetayler.Any())
            {
                ModelState.AddModelError("", "Sepet detayları boş.");
                return RedirectToAction(nameof(Create));
            }

     
            var yeniSiparis = new Siparis
            {
                FirmaId = FirmaId,
                teslimatadresıd = teslimatadresıd,
                Aciklama = Aciklama,
                Tarih = DateTime.Now,
                DurumID = 1, 
                SipNo = "SP" + DateTime.Now.Ticks.ToString().Substring(10),
                SiparisDetay = new List<SiparisDetay>()
            };
 
            foreach (var detay in siparisDetayler)
            {
                yeniSiparis.SiparisDetay.Add(new SiparisDetay
                {
                    MalzemeID = detay.MalzemeID,
                    BirimId = detay.BirimId,
                    Miktar = detay.Miktar,
                    Fiyat = detay.Fiyat,
                    Kdv = detay.Kdv,
                    IndOran = detay.IndOran,
                    IndTutar = 0,
                    Toplam = detay.Miktar * detay.Fiyat,
                    ToplamKdv = (detay.Miktar * detay.Fiyat) * detay.Kdv / 100,
                    GenelToplam = (detay.Miktar * detay.Fiyat) + ((detay.Miktar * detay.Fiyat) * detay.Kdv / 100)
                });
            }

           
            _context.Siparis.Add(yeniSiparis);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var siparis = await _context.Siparis
                .Include(s => s.SiparisDetay)  
                .FirstOrDefaultAsync(m => m.SipID == id);

            if (siparis == null)
                return NotFound();

            ViewBag.Firmalar = _context.Firma.ToList();
            ViewBag.Durumlar = _context.Durum.ToList();
            ViewBag.Adresler = _context.Adres.ToList();
            ViewBag.Malzemeler = _context.Malzeme.ToList();
            ViewBag.Birimler = _context.Birim.ToList();

            return View(siparis);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Siparis siparis)
        {
            if (id != siparis.SipID)
                return NotFound();

       
            {
                try
                {
                    _context.Update(siparis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiparisExists(siparis.SipID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Firmalar = _context.Firma.ToList();
            ViewBag.Durumlar = _context.Durum.ToList();
            ViewBag.Adresler = _context.Adres.ToList();
            ViewBag.Malzemeler = _context.Malzeme.ToList();
            ViewBag.Birimler = _context.Birim.ToList();

            return View(siparis);

        }

        private bool SiparisExists(int id)
        {
            return _context.Siparis.Any(e => e.SipID == id);
        }
    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var siparis = await _context.Siparis
                .Include(s => s.Firma)
                .Include(s => s.Durum)
                .Include(s => s.Adres)
                .FirstOrDefaultAsync(m => m.SipID == id);

            if (siparis == null)
                return NotFound();

            return View(siparis);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siparis = await _context.Siparis.FindAsync(id);
            if (siparis != null)
            {
                _context.Siparis.Remove(siparis);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var siparis = await _context.Siparis
                .Include(s => s.Firma)
                .Include(s => s.Durum)
                .Include(s => s.Adres)
                .Include(s => s.SiparisDetay)
                    .ThenInclude(sd => sd.Malzeme)
                .Include(s => s.SiparisDetay)
                    .ThenInclude(sd => sd.Birim)
                .FirstOrDefaultAsync(m => m.SipID == id);

            if (siparis == null)
                return NotFound();

            return View(siparis);
        }

        public async Task<IActionResult> EditPartial(int id)
        {
            var siparis = await _context.Siparis
                .Include(s => s.SiparisDetay)
                .FirstOrDefaultAsync(m => m.SipID == id);

            if (siparis == null)
                return NotFound();

            ViewBag.Firmalar = _context.Firma.ToList();
            ViewBag.Durumlar = _context.Durum.ToList();
            ViewBag.Adresler = _context.Adres.ToList();
            ViewBag.Malzemeler = _context.Malzeme.ToList();
            ViewBag.Birimler = _context.Birim.ToList();

            return PartialView("_EditPartial", siparis);  
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPartial(int id, Siparis siparis)
        {
            if (id != siparis.SipID)
                return NotFound();

        
          //  if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siparis);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Sipariş güncellendi.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Siparis.Any(e => e.SipID == id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index)); 
            }
 
            ViewBag.Firmalar = _context.Firma.ToList();
            ViewBag.Durumlar = _context.Durum.ToList();
            ViewBag.Adresler = _context.Adres.ToList();
            ViewBag.Malzemeler = _context.Malzeme.ToList();
            ViewBag.Birimler = _context.Birim.ToList();

            return PartialView("_EditPartial", siparis);  
        }

    }
}