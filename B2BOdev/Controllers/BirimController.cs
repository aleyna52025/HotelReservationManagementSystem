using B2BOdev.Data;
using B2BOdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2BOdev.Controllers
{
    public class BirimController : Controller
    {
        private readonly UygulamaDbContext _context;


        public BirimController(UygulamaDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _context.Birim.ToListAsync();
            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BirimAd", "BirimKod")] Birim birim)
        {
            _context.Add(birim);
            await _context.SaveChangesAsync();
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var birim = await _context.Birim.FirstOrDefaultAsync(b=>b.BirimID==id);
            if (birim == null)
                return NotFound();
            return View(birim);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Birim birim)
        {
            _context.Update(birim);
            _context.SaveChanges();
            return View(birim);
        }

        [HttpGet]
        public async Task<IActionResult> EditPartial(int? id)
        {

            Birim birim = new Birim();

            if (id>0)
            {
                birim = await _context.Birim.FirstOrDefaultAsync(b => b.BirimID == id);
                if (birim == null)
                    return NotFound();
            }

            return PartialView("_EditPartial", birim);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPartial(Birim birim)
        {
           if (ModelState.IsValid)
            {
                Birim birimDB = new Birim();
                if (birim.BirimID>0)
                {
                    birimDB = _context.Birim.Find(birim.BirimID);
                }

                birimDB.BirimKod = birim.BirimKod;
                birimDB.BirimAd = birim.BirimAd;

                if (birim.BirimID== 0)
                {
                    _context.Birim.Add(birimDB);
                }
              await  _context.SaveChangesAsync();

                return Json(new { success = true });
            }

            return PartialView("_EditPartial", birim);
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Birim.FindAsync(id);
            if (entity == null)
                return NotFound();

            return View(entity); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _context.Birim.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.Birim.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
