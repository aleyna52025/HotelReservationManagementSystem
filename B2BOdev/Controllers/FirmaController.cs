using B2BOdev.Data;
using B2BOdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2BOdev.Controllers
{
    public class FirmaController : Controller
    {
        private readonly UygulamaDbContext _context;
        public FirmaController(UygulamaDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            var firmalar = await _context.Firma
                 .Where(f => f.Del == null || f.Del == 0)
                 .ToListAsync();
            return View(firmalar);

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirmaKod,FirmaUnvanı,VergiNo,VergiDairesi,tel,Eposta")] Firma firma)
        {
            // if (ModelState.IsValid)
            {
                _context.Add(firma);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(firma);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var firma = _context.Firma.FirstOrDefault(f => f.FirmaID == id);
            if (firma == null)
                return NotFound();

            return View(firma);
        }

        [HttpPost]
        public IActionResult Edit(Firma firma)
        {
            //   if (ModelState.IsValid)
            {
                _context.Firma.Update(firma);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(firma);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var firma = _context.Firma.FirstOrDefault(f => f.FirmaID == id);
            if (firma == null)
                return NotFound();

            return View(firma);
        }

        [HttpGet]
        public IActionResult DeleteConfirmed(int id)
        {
            var firma = _context.Firma.FirstOrDefault(f => f.FirmaID == id);
            if (firma != null)
            {
                firma.Del = 1;
                _context.Firma.Update(firma);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EditPartial(int? id)
        {
            Firma firma = new Firma();

            if (id > 0)
            {
                firma = await _context.Firma.FirstOrDefaultAsync(f => f.FirmaID == id);
                if (firma == null)
                    return NotFound();
            }

            return PartialView("_EditPartial", firma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPartial(Firma firma)
        {
            if (ModelState.IsValid)
            {
                Firma firmaDB;

                if (firma.FirmaID > 0)
                {
                    firmaDB = await _context.Firma.FindAsync(firma.FirmaID);
                    if (firmaDB == null)
                        return Json(new { success = false, message = "Firma bulunamadı" });

                    firmaDB.FirmaKod = firma.FirmaKod;
                    firmaDB.FirmaUnvanı = firma.FirmaUnvanı;
                    firmaDB.VergiNo = firma.VergiNo;
                    firmaDB.VergiDairesi = firma.VergiDairesi;
                    firmaDB.tel = firma.tel;
                    firmaDB.Eposta = firma.Eposta;
                }
                else
                {
                    firmaDB = new Firma
                    {
                        FirmaKod = firma.FirmaKod,
                        FirmaUnvanı = firma.FirmaUnvanı,
                        VergiNo = firma.VergiNo,
                        VergiDairesi = firma.VergiDairesi,
                        tel = firma.tel,
                        Eposta = firma.Eposta
                    };
                    _context.Firma.Add(firmaDB);
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "İşlem başarılı" });
            }

            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return Json(new { success = false, message = "Geçersiz veri", errors });
        }


    }
}
