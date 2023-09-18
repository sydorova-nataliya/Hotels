using hotelcourseworkV2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hotelcourseworkV2.Controllers
{
    public class DirectorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public DirectorController(ApplicationDbContext context,
                                UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize(Roles = "Директор")]
        public IActionResult Director()
        {
            ViewData["Hotel"] = _context.hotels.Include(o => o.Owner).ToList();
            ViewData["Room"] = _context.hotelRooms.Include(t => t.typeRoom).ToList();
            ViewData["User"] = _userManager.Users;
            return View();
        }
    }
}
