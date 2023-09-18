using hotelcourseworkV2.Data;
using Microsoft.AspNetCore.Mvc;
using hotelcourseworkV2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hotelcourseworkV2.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CreateServices()
        {
            ViewBag.TypeServiceId = new SelectList(_context.Services.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreateServices(ServicesReserve services)
        {
            _context.servicesReserves.Add(services);
            _context.SaveChanges();
            return RedirectToAction("Reseption", "Reseption");
        }

        [HttpGet]
        public IActionResult DeleteServices(int id)
        {
            var service = _context.servicesReserves.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.servicesReserves.Remove(service);
            _context.SaveChanges();

            return RedirectToAction("Reseption", "Reseption");
        }
    }
}
