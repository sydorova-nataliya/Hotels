using hotelcourseworkV2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using hotelcourseworkV2.Models;

namespace hotelcourseworkV2.Controllers
{
    public class OwnerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public OwnerController(ApplicationDbContext context,
                                UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize(Roles = "Владелец сети")]
        public async Task<IActionResult> Owner(string searchString)
        {
            var hotels = from h in _context.hotels.Include(h => h.Owner)
                         select h;

            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                hotels = hotels.Where(h => h.Name.Contains(searchString) || h.City.Contains(searchString));
            }
            ViewData["Hotel"] = await hotels.ToListAsync();
            ViewData["User"] = _userManager.Users;
            return View();
        }
    }
}
