using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using B2BOdev.Data;
using B2BOdev.Models;

namespace B2BOdev.Controllers
{
    public class AdresController : Controller
    {
        private readonly UygulamaDbContext _context;

        public AdresController(UygulamaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var adresler = _context.Adres
                .Include(a => a.Il)
                .Include(a => a.Ilce)
                .Include(a => a.firma);
            return View(await adresler.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Ilid"] = new SelectList(_context.Il, "Ilid", "IlAdi");
            ViewData["Ilceid"] = new SelectList(_context.Ilce, "Ilceid", "IlceAdi");
            ViewData["FirmaId"] = new SelectList(_context.Firma, "FirmaID", "FirmaUnvanı");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Adres adres)
        {
            _context.Add(adres);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<JsonResult> IlceleriGetir(int ilId)
        {
            var ilceler = await _context.Ilce
                .Where(i => i.Ilid == ilId)
                .Select(i => new { ilceid = i.Ilceid, ilceAdi = i.IlceAdi })
                .ToListAsync();
            return Json(ilceler);
        }

        [HttpGet]
        public async Task<IActionResult> GetAdres(int id)
        {
            var adres = await _context.Adres.FindAsync(id);
            if (adres == null) return NotFound();

            ViewData["Ilid"] = new SelectList(_context.Il, "Ilid", "IlAdi", adres.Ilid);
            ViewData["Ilceid"] = new SelectList(_context.Ilce.Where(x => x.Ilid == adres.Ilid), "Ilceid", "IlceAdi", adres.Ilceid);
            ViewData["FirmaId"] = new SelectList(_context.Firma, "FirmaID", "FirmaUnvanı", adres.FirmaId);
            return PartialView("_EditModalPartial", adres);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAdres(Adres adres)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                _context.Update(adres);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Bir hata oluştu.");
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var adres = await _context.Adres
                .Include(a => a.Il)
                .Include(a => a.Ilce)
                .Include(a => a.firma)
                .FirstOrDefaultAsync(m => m.AdresID == id);

            if (adres == null) return NotFound();

            return View(adres);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adres = await _context.Adres.FindAsync(id);
            if (adres != null)
            {
                _context.Adres.Remove(adres);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> EditPartial(int? id)
        {
            Adres adres = new Adres();

            if (id > 0)
            {
                adres = await _context.Adres
                    .Include(a => a.Il)
                    .Include(a => a.Ilce)
                    .Include(a => a.firma)
                    .FirstOrDefaultAsync(a => a.AdresID == id);

                if (adres == null)
                    return NotFound();
            }

            ViewBag.Ilid = new SelectList(_context.Il.ToList(), "IlID", "IlAd", adres.Ilid);
            ViewBag.Ilceid = new SelectList(_context.Ilce.ToList(), "IlceID", "IlceAd", adres.Ilceid);
            ViewBag.FirmaId = new SelectList(_context.Firma.ToList(), "FirmaID", "FirmaAd", adres.FirmaId);

            return PartialView("_EditPartial", adres);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPartial(Adres adres)
        {
            if (ModelState.IsValid)
            {
                Adres adresDB;

                if (adres.AdresID > 0)
                {
                    adresDB = await _context.Adres.FindAsync(adres.AdresID);
                    if (adresDB == null) return NotFound();
                }
                else
                {
                    adresDB = new Adres();
                    _context.Adres.Add(adresDB);
                }

                adresDB.Adres1 = adres.Adres1;
                adresDB.Adres2 = adres.Adres2;
                adresDB.Ilid = adres.Ilid;
                adresDB.Ilceid = adres.Ilceid;
                adresDB.Mahalle = adres.Mahalle;
                adresDB.Tel = adres.Tel;
                adresDB.Fax = adres.Fax;
                adresDB.CepTel = adres.CepTel;
                adresDB.FirmaId = adres.FirmaId;
                adresDB.Del = adres.Del;

                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }

            // Dropdownlar validasyon hatasında yeniden doldurulmalı
            ViewBag.Ilid = new SelectList(_context.Il.ToList(), "IliD", "IlAdi", adres.Ilid);
            ViewBag.Ilceid = new SelectList(_context.Ilce.ToList(), "Ilceid", "IlceAdi", adres.Ilceid);
            ViewBag.FirmaId = new SelectList(_context.Firma.ToList(), "FirmaID", "FirmaAd", adres.FirmaId);

            return PartialView("_EditPartial", adres);
        }
    }
}
