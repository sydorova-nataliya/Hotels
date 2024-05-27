using hotelcourseworkV2.Data;
using hotelcourseworkV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace hotelcourseworkV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string searchString)
        {

             var hotels = from h in _context.hotels.Include(h => h.Owner)
                         select h;

            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                hotels = hotels.Where(h => h.Name.Contains(searchString) || h.City.Contains(searchString));
            }
            
            // Передача параметров поиска и фильтрации в представление
            ViewData["Hotel"] = await hotels.ToListAsync();
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}