using B2BOdev.Data;
using B2BOdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2BOdev.Controllers
{
    public class DurumController:Controller
    {
        private readonly UygulamaDbContext _context;
        public DurumController(UygulamaDbContext context)
        {
            _context = context;
        }

      
        public async Task<IActionResult> Index()
        {
            var list=await _context.Durum.ToListAsync();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("durumıd,durumu")] Durum durum)
        {
            // if (ModelState.IsValid)
            {
                _context.Add(durum);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(durum);
        }




        [HttpGet]
        public async Task<IActionResult> EditPartial(int? id)
        {

            Durum durum = new Durum();

            if (id > 0)
            {
                durum = await _context.Durum.FirstOrDefaultAsync(b => b.durumId == id);
                if (durum == null)
                    return NotFound();
            }

            return PartialView("_EditPartial", durum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPartial(Durum durum)
        {
            if (ModelState.IsValid)
            {
                Durum durumDB = new Durum();
                if (durum.durumId> 0)
                {
                    durumDB = _context.Durum.Find(durum.durumId);
                }

                durumDB.durumu = durum.durumu; 
               
                if (durum.durumId == 0)
                {
                    _context.Durum.Add(durumDB);
                }
             await   _context.SaveChangesAsync();

                return Json(new { success = true });
            }

            return PartialView("_EditPartial", durum);
        }

    }
}
