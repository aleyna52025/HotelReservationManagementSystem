using B2BOdev.Data;
using B2BOdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2BOdev.Controllers
{
    public class MarkaController : Controller
    {
        private readonly UygulamaDbContext _context;
        public MarkaController(UygulamaDbContext context)
        {
            _context = context;
        }
     
        public async Task<IActionResult> Index()
        {
            var list = await _context.Marka.ToListAsync();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarkaAd")] Marka marka)
        {
            _context.Add(marka);
            await _context.SaveChangesAsync();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var marka = await _context.Marka.FirstOrDefaultAsync(m => m.MarkaID == id);
            if (marka == null)
                return NotFound();
            return View(marka);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Marka marka)
        {
            //   if (ModelState.IsValid)
            {
                _context.Marka.Update(marka);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marka);
        }
        [HttpGet]
        public async Task<IActionResult> EditPartial(int? id)
        {

            Marka marka= new Marka();

            if (id > 0)
            {
                marka = await _context.Marka.FirstOrDefaultAsync(b => b.MarkaID== id);
                if (marka == null)
                    return NotFound();
            }

            return PartialView("_EditPartial", marka);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPartial(Marka marka)
        {
            if (ModelState.IsValid)
            {
                Marka markaDb= new Marka();
                if (marka.MarkaID > 0)
                {
                    markaDb = _context.Marka.Find(marka.MarkaID);
                }

                markaDb.MarkaAd = marka.MarkaAd;
 

                if (marka.MarkaID== 0)
                {
                    _context.Marka.Add(markaDb);
                }
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }

            return PartialView("_EditPartial", marka);
        }

    }
}
