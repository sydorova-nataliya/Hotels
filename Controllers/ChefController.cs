using hotelcourseworkV2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hotelcourseworkV2.Controllers
{
    public class ChefController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChefController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Повар в отеле")]
        public IActionResult Chef()
        {
            ViewData["Menu"] = _context.menus.Include(h=>h.Hotel).Include(md => md.MenuDishes).ToList();
            ViewData["Ingridient"] = _context.ingredients.ToList();
            ViewData["Composition"] = _context.compositions.ToList();
            ViewData["Dish"] = _context.dishes.ToList();
            return View();
        }
    }
}
