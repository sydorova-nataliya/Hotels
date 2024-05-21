using hotelcourseworkV2.Data;
using hotelcourseworkV2.Models;
using hotelcourseworkV2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace hotelcourseworkV2.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult MenuList(int id)
        {
            var menu = _context.menus
                .Where(m => m.HotelId == id)
                .Include(m => m.Hotel)
                .Include(m => m.MenuDishes)
                    .ThenInclude(md => md.Dish)
                .ToList();

            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }
        public IActionResult MenuCreate()
        {
            var viewModel = new MenuCreateViewModel
            {
                AvailableDishes = _context.dishes.ToList()
            };
            ViewBag.Hotels = new SelectList(_context.hotels, "Id", "Name");
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MenuCreate(MenuCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var existingMenu = _context.menus.FirstOrDefault(m => m.HotelId == model.HotelId);
                if (existingMenu != null)
                {
                    TempData["Message"] = "Меню для цього готелю вже існує.";
                    model.AvailableDishes = _context.dishes.ToList();
                    ViewBag.Hotels = new SelectList(_context.hotels, "Id", "Name", model.HotelId);
                    return View(model);
                }

                var menu = new Menu
                {
                    HotelId = model.HotelId,
                    MenuDishes = model.SelectedDishIds.Select(dishId => new MenuDish { DishId = dishId }).ToList()
                };

                _context.menus.Add(menu);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Меню успішно створено.";
                return RedirectToAction("Chef", "Chef");
            }

            model.AvailableDishes = _context.dishes.ToList();
            ViewBag.Hotels = new SelectList(_context.hotels, "Id", "Name", model.HotelId);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> MenuDelete(int id)
        {
            var menu = await _context.menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.menus.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction("Chef", "Chef");
        }

        [HttpPost]
        public async Task<IActionResult> MenuDishDelete(int id)
        {
            var menuDish = await _context.menuDishes.FindAsync(id);
            if (menuDish == null)
            {
                return NotFound();
            }

            _context.menuDishes.Remove(menuDish);
            await _context.SaveChangesAsync();
            return RedirectToAction("Chef", "Chef");
        }


        public async Task<IActionResult> EditMenu(int id)
        {
            var menu = await _context.menus
                .Include(m => m.MenuDishes)
                .ThenInclude(md => md.Dish)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (menu == null)
            {
                return NotFound();
            }

            var viewModel = new MenuCreateViewModel
            {
                Id = menu.Id,
                HotelId = menu.HotelId,
                SelectedDishIds = menu.MenuDishes.Select(md => md.DishId).ToList(),
                AvailableDishes = _context.dishes.ToList()
            };

            ViewBag.Hotels = new SelectList(_context.hotels, "Id", "Name", menu.HotelId);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMenu(MenuCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var menu = await _context.menus
                    .Include(m => m.MenuDishes)
                    .FirstOrDefaultAsync(m => m.Id == model.Id);

                if (menu == null)
                {
                    return NotFound();
                }

                menu.HotelId = model.HotelId;
                menu.MenuDishes = model.SelectedDishIds.Select(dishId => new MenuDish { DishId = dishId, MenuId = menu.Id }).ToList();

                _context.Update(menu);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Меню успішно оновлено.";
                return RedirectToAction("Chef", "Chef");
            }

            model.AvailableDishes = _context.dishes.ToList();
            ViewBag.Hotels = new SelectList(_context.hotels, "Id", "Name", model.HotelId);
            return View(model);
        }



    }
}
