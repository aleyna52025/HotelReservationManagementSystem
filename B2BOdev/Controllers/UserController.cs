using Microsoft.AspNetCore.Mvc;
using B2BOdev.Models;
using B2BOdev.Data; // DbContext'in varsa
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace B2BOdev.Controllers
{
    public class UserController : Controller
    {
        private readonly UygulamaDbContext _context;

        public UserController(UygulamaDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
          var lis=await  _context.User.Include(u=>u.firma).ToListAsync();
        return View(lis);
        }
     
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _context.User
                .FirstOrDefaultAsync(u => u.email == email && u.password == password);

         
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult Create()
        {
            ViewData["FirmaID"] = new SelectList(_context.Firma, "FirmaID", "FirmaUnvanı");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("email, password, Ad, Soyad, Personel,FirmaID")]User user)
        {
            _context.Add(user);
           await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
