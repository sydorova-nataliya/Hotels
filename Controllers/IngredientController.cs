using hotelcourseworkV2.Data;
using hotelcourseworkV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace hotelcourseworkV2.Controllers
{
    public class IngredientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngredientController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult IngridientCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IngridientCreate(Ingredient model)
        {
            if (!ModelState.IsValid)
            {
                _context.ingredients.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Chef", "Chef");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult IngridientDelete(int id)
        {
            var ingredient = _context.dishes.FirstOrDefault(d => d.Id == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]
        public IActionResult IngridientDelete(Ingredient ingredient)
        {

            _context.ingredients.Remove(ingredient);
            _context.SaveChanges();

            return RedirectToAction("Chef", "Chef");
        }

    }
}
