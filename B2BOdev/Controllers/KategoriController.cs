using B2BOdev.Data;
using B2BOdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace B2BOdev.Controllers
{
    public class KategoriController : Controller
    {
        private readonly UygulamaDbContext _context;
        public KategoriController(UygulamaDbContext context)
        {
            _context = context;
        }
      
        public async Task<IActionResult> Index()
        {
            var list = await _context.Kategori.ToListAsync();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KategoriAd,KategoriTip")] Kategori kategori)
        {
            _context.Add(kategori);
            await _context.SaveChangesAsync();
            RedirectToAction("Index");
            return View(kategori);

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var kategori = _context.Kategori.FirstOrDefault(k => k.KategoriId == id);
            return View(kategori);
        }
        [HttpPost]
        public IActionResult Edit(Kategori kategori)
        {
            _context.Kategori.Update(kategori);
            _context.SaveChanges();
            return View(kategori);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Kategori.FindAsync(id);
            if (entity == null)
                return NotFound();

            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _context.Kategori.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.Kategori.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EditPartial(int? id)
        {
            Kategori kategori = new Kategori();

            if (id > 0)
            {
                kategori = await _context.Kategori.FirstOrDefaultAsync(b => b.KategoriId == id);
                if (kategori == null)
                    return NotFound();
            }

            // Kategori listesini dropdown için hazırla
            ViewBag.UstKategoriler = new SelectList(
                await _context.Kategori
                    .Where(k => k.KategoriId != id) // kendisini üst kategori olarak seçemesin
                    .ToListAsync(),
                "KategoriId", "KategoriAd", kategori.UstKategoriId
            );

            return PartialView("_EditPartial", kategori); // ← SADECE BU DÖNMELİ
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPartial(Kategori kategori)
        {
           // if (ModelState.IsValid)
            {
                Kategori kategoriDB = new Kategori();

                if (kategori.KategoriId > 0)
                {
                    kategoriDB = await _context.Kategori.FindAsync(kategori.KategoriId);
                }

                kategoriDB.KategoriAd = kategori.KategoriAd;
                kategoriDB.KategoriTip = kategori.KategoriTip;
                kategoriDB.UstKategoriId = kategori.UstKategoriId; // EKLENDİ

                if (kategori.KategoriId == 0)
                {
                    _context.Kategori.Add(kategoriDB);
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            // Model geçerli değilse, dropdown tekrar gönderilmeli
            ViewBag.UstKategoriler = new SelectList(
                await _context.Kategori
                    .Where(k => k.KategoriId != kategori.KategoriId)
                    .ToListAsync(),
                "KategoriId", "KategoriAd", kategori.UstKategoriId
            );

            return PartialView("_EditPartial", kategori);
        }


    }
}
