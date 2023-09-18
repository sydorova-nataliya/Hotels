using hotelcourseworkV2.Data;
using hotelcourseworkV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hotelcourseworkV2.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult MenuCreate()
        {
            ViewBag.HotelId = new SelectList(_context.hotels, "Id", "Name");
            ViewBag.DishId = new SelectList(_context.dishes, "Id", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult MenuCreate(Menu model)
        {

             _context.menus.Add(model);
             _context.SaveChanges();

            ViewBag.HotelId = new SelectList(_context.hotels, "Id", "Name", model.HotelId);
            ViewBag.DishId = new SelectList(_context.dishes, "Id", "Title", model.DishId);
            return RedirectToAction("Chef", "Chef");
        }

        [HttpPost]
        public IActionResult MenuDelete(int id)
        {
            var menu = _context.menus.Find(id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.menus.Remove(menu);
            _context.SaveChanges();

            return RedirectToAction("Chef", "Chef");
        }
    }
}
