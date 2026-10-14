using B2BOdev.Data;
using B2BOdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2BOdev.Controllers
{
    public class MalzemeController : Controller
    {
        private readonly UygulamaDbContext _context;
        public MalzemeController(UygulamaDbContext context)
        {
            _context = context;
        }
      
        public async Task<IActionResult> Index()
        {
            var malzeme = await _context.Malzeme
                  .Include(m => m.Marka)
                  .Include(m => m.Kategori)
                  .Include(m => m.Birim).ToListAsync();
            var viewmodel = malzeme.Select(m => new MalzemeViewModel
            {
                MalzemeId = m.MalzemeId,
                MalzemeKod = m.MalzemeKod,
                MalzemeAd = m.MalzemeAd,
                MarkaAdi = m.Marka.MarkaAd,
                KategoriAdi = m.Kategori.KategoriAd,
                Aciklama = m.Aciklama,
                SatVergiOr = (decimal?)m.SatVergiOran,

            OzelKod1 = m.OzelKod1,
                OzelKod2 = m.OzelKod2,
                OzelKod3 = m.OzelKod3,
                OzelKod4 = m.OzelKod4,
                OzelKod5 = m.OzelKod5,
                BirimAdi = m.Birim.BirimAd
            }).ToList();
            return View(viewmodel);

        }
        public IActionResult Create()
        {
        
            ViewBag.MarkaListesi = _context.Marka.Select(m => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = m.MarkaID.ToString(),
                Text = m.MarkaAd
            }).ToList();

            ViewBag.KategoriListesi = _context.Kategori.Select(k => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = k.KategoriId.ToString(),
                Text = k.KategoriAd
            }).ToList();

            ViewBag.BirimListesi = _context.Birim.Select(b => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = b.BirimID.ToString(),
                Text = b.BirimAd
            }).ToList();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Malzeme malzeme, IFormFile GorselDosya)
        {
          //  if (ModelState.IsValid)
            {
                if (GorselDosya != null && GorselDosya.Length > 0)
                { 
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);
                     
                    var uniqueFileName = $"{Guid.NewGuid()}_{GorselDosya.FileName}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                     
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await GorselDosya.CopyToAsync(fileStream);
                    }
                     
                    malzeme.GorselYolu = "/images/" + uniqueFileName;
                }
                else
                {
                    malzeme.GorselYolu = "";  
                }

                _context.Add(malzeme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
             
            ViewBag.MarkaListesi = _context.Marka.Select(m => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = m.MarkaID.ToString(),
                Text = m.MarkaAd
            }).ToList();

            ViewBag.KategoriListesi = _context.Kategori.Select(k => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = k.KategoriId.ToString(),
                Text = k.KategoriAd
            }).ToList();

            ViewBag.BirimListesi = _context.Birim.Select(b => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = b.BirimID.ToString(),
                Text = b.BirimAd
            }).ToList();

            return View(malzeme);
        }

        public IActionResult Edit(int id)
        {
            var malzeme = _context.Malzeme.FirstOrDefault(m => m.MalzemeId == id);

            ViewBag.MarkaListesi = _context.Marka.Select(m => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = m.MarkaID.ToString(),
                Text = m.MarkaAd
            }).ToList();

            ViewBag.KategoriListesi = _context.Kategori.Select(k => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = k.KategoriId.ToString(),
                Text = k.KategoriAd
            }).ToList();

            ViewBag.BirimListesi = _context.Birim.Select(b => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = b.BirimID.ToString(),
                Text = b.BirimAd
            }).ToList();

            return View(malzeme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Malzeme malzeme, IFormFile GorselDosyasi)
        {
          //  if (ModelState.IsValid)
            {  
                if (GorselDosyasi != null && GorselDosyasi.Length > 0)
                {
                    var uzanti = Path.GetExtension(GorselDosyasi.FileName);
                    var dosyaAdi = Guid.NewGuid().ToString() + uzanti;
                    var kayitYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", dosyaAdi);

                    using (var stream = new FileStream(kayitYolu, FileMode.Create))
                    {
                        await GorselDosyasi.CopyToAsync(stream);
                    }

                  
                    malzeme.GorselYolu = "/images/" + dosyaAdi;
                }

                _context.Malzeme.Update(malzeme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
 
            ViewBag.MarkaListesi = _context.Marka.Select(m => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = m.MarkaID.ToString(),
                Text = m.MarkaAd
            }).ToList();

            ViewBag.KategoriListesi = _context.Kategori.Select(k => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = k.KategoriId.ToString(),
                Text = k.KategoriAd
            }).ToList();

            ViewBag.BirimListesi = _context.Birim.Select(b => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = b.BirimID.ToString(),
                Text = b.BirimAd
            }).ToList();

            return View(malzeme);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var malzeme = await _context.Malzeme
                .Include(m => m.Marka)
                .Include(k => k.Kategori)
                .Include(B => B.Birim)
                .FirstOrDefaultAsync(ma => ma.MalzemeId == id);

            if (malzeme == null)
                return NotFound();

            return View(malzeme);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var malzeme = await _context.Malzeme.FindAsync(id);
            if (malzeme == null)
                return NotFound();

            _context.Malzeme.Remove(malzeme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditPartial(int id)
        {
            var malzeme = await _context.Malzeme
                .Include(m => m.Marka)
                .Include(m => m.Kategori)
                .Include(m => m.Birim)
                .FirstOrDefaultAsync(m => m.MalzemeId == id);

            if (malzeme == null)
                return NotFound();

            var viewModel = new MalzemeViewModel
            {
                MalzemeId = malzeme.MalzemeId,
                MalzemeKod = malzeme.MalzemeKod,
                MalzemeAd = malzeme.MalzemeAd,
                MarkaAdi = malzeme.Marka?.MarkaAd,
                KategoriAdi = malzeme.Kategori?.KategoriAd,
                Aciklama = malzeme.Aciklama,
               
                OzelKod1 = malzeme.OzelKod1,
                OzelKod2 = malzeme.OzelKod2,
                OzelKod3 = malzeme.OzelKod3,
                OzelKod4 = malzeme.OzelKod4,
                OzelKod5 = malzeme.OzelKod5,
                BirimAdi = malzeme.Birim?.BirimAd
            };

            return PartialView("_EditPartial", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPartial(int id, MalzemeViewModel viewModel)
        {
            if (id != viewModel.MalzemeId)
                return NotFound();

          //  if (ModelState.IsValid)
            {
                var malzeme = await _context.Malzeme.FindAsync(id);
                if (malzeme == null)
                    return NotFound();
                 
                malzeme.MalzemeKod = viewModel.MalzemeKod;
                malzeme.MalzemeAd = viewModel.MalzemeAd;
                malzeme.Aciklama = viewModel.Aciklama;
              
                malzeme.OzelKod1 = viewModel.OzelKod1;
                malzeme.OzelKod2 = viewModel.OzelKod2;
                malzeme.OzelKod3 = viewModel.OzelKod3;
                malzeme.OzelKod4 = viewModel.OzelKod4;
                malzeme.OzelKod5 = viewModel.OzelKod5;

                try
                {
                    _context.Update(malzeme);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MalzemeExists(viewModel.MalzemeId))
                        return NotFound();
                    else
                        throw;
                }
            }
            return PartialView("_EditPartial", viewModel);
        }

        private bool MalzemeExists(int id)
        {
            return _context.Malzeme.Any(e => e.MalzemeId == id);
        }
   
}
}
