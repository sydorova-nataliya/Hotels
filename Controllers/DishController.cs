using hotelcourseworkV2.Data;
using hotelcourseworkV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace hotelcourseworkV2.Controllers
{
    public class DishController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DishController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult DishCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DishCreate(Dish model)
        {
            if (ModelState.IsValid)
            {
                _context.dishes.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Chef", "Chef");
            }

            return View(model);
        }
    }
}
