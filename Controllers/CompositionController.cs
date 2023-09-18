using hotelcourseworkV2.Data;
using hotelcourseworkV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hotelcourseworkV2.Controllers
{
    public class CompositionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompositionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CompositionCreate()
        {
            ViewBag.DishId = new SelectList(_context.dishes, "Id", "Title");
            ViewBag.IngredientId = new SelectList(_context.ingredients, "Id", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult CompositionCreate(Composition model)
        {

             _context.compositions.Add(model);
             _context.SaveChanges();

                

            ViewBag.DishId = new SelectList(_context.dishes, "Id", "Title", model.DishId);
            ViewBag.IngredientId = new SelectList(_context.ingredients, "Id", "Title", model.IngredientId);

            return RedirectToAction("Chef", "Chef");
        }

    }
}
