using hotelcourseworkV2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hotelcourseworkV2.Controllers
{
    public class ReseptionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ReseptionController(ApplicationDbContext context, 
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }
        [Authorize(Roles = "Сотрудник рецепции")]
        public async Task<IActionResult> Reseption(string searchString)
        {
            var guestRole = await _roleManager.FindByNameAsync("Зарегистрированный клиент");
            var guestUsers = await _userManager.GetUsersInRoleAsync(guestRole.Name);
            var hotels = from h in _context.hotels.Include(h => h.Owner)
                select h;

            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                hotels = hotels.Where(h => h.Name.Contains(searchString) || h.City.Contains(searchString));
            }
            ViewData["Hotel"] = await hotels.ToListAsync();
            ViewData["User"] = guestUsers;
            //ViewData["User"] = _userManager.Users;
            ViewData["Reserve"] = _context.reserves.Include(s => s.HotelTypeRoom).ThenInclude(t => t.typeRoom).ToList();
            ViewData["Services"] = _context.servicesReserves.Include(t => t.TypeService).ToList();
            return View();
        }
    }
}
