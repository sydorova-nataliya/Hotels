using hotelcourseworkV2.Data;
using hotelcourseworkV2.Models;
using hotelcourseworkV2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hotelcourseworkV2.Controllers
{
    public class DishController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DishController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult DishCreate()
        {
            var viewModel = new DishCreateViewModel
            {
                AvailableIngredients = _context.ingredients.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DishCreate(DishCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Определение нового объекта Dish без Id
                var dish = new Dish
                {
                    Title = viewModel.Title,
                    Recipe = viewModel.Recipe,
                    Weight = viewModel.Weight,
                    Unit = viewModel.Unit,
                    Price = viewModel.Price,
                    Compositions = new List<Composition>()
                };

                // Добавление Dish в контекст данных для последующего сохранения
                _context.dishes.Add(dish);
                await _context.SaveChangesAsync();

                // Присвоение Id только что сохраненного Dish
                viewModel.DishId = dish.Id;

                foreach (var ingredientId in viewModel.SelectedIngredients)
                {
                    // Создание нового объекта Composition с указанием DishId
                    var composition = new Composition
                    {
                        IngredientId = ingredientId,
                        DishId = dish.Id 
                    };
                    dish.Compositions.Add(composition);
                }

                // Сохранение изменений и перенаправление
                await _context.SaveChangesAsync();
                return RedirectToAction("Chef","Chef");
            }

            // Если модель невалидна, возвращаем представление снова
            viewModel.AvailableIngredients = await _context.ingredients.ToListAsync();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult EditDish(int id)
        {
            var dish = _context.dishes.Include(d => d.Compositions).FirstOrDefault(d => d.Id == id);
            if (dish == null)
            {
                return NotFound();
            }

            var viewModel = new DishCreateViewModel
            {
                Title = dish.Title,
                Recipe = dish.Recipe,
                Weight = dish.Weight,
                Unit = dish.Unit,
                Price = dish.Price,
                AvailableIngredients = _context.ingredients.ToList(),
                SelectedIngredients = dish.Compositions.Select(c => c.IngredientId).ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDish(int id, DishCreateViewModel viewModel)
        {
            var dish = await _context.dishes.Include(d => d.Compositions).FirstOrDefaultAsync(d => d.Id == id);
            if (dish == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    dish.Title = viewModel.Title;
                    dish.Recipe = viewModel.Recipe;
                    dish.Weight = viewModel.Weight;
                    dish.Unit = viewModel.Unit;
                    dish.Price = viewModel.Price;

                    // Обновление выбранных ингредиентов
                    dish.Compositions.Clear();
                    foreach (var ingredientId in viewModel.SelectedIngredients)
                    {
                        var composition = new Composition
                        {
                            IngredientId = ingredientId,
                            DishId = dish.Id
                        };
                        dish.Compositions.Add(composition);
                    }

                    _context.Update(dish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.dishes.AnyAsync(d => d.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Chef","Chef");
            }

            // Если модель невалидна, возвращаем представление снова с текущим состоянием модели
            viewModel.AvailableIngredients = await _context.ingredients.ToListAsync();
            return View(viewModel);
        }




        public IActionResult DeleteDish(int id){
            ViewBag.DishId = _context.dishes.FirstOrDefault(d => d.Id == id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDish(Dish dish)
        {
            _context.dishes.Remove(dish);
            _context.SaveChanges();

            return RedirectToAction("Chef","Chef");
        }

    }
}
    

