using hotelcourseworkV2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Owner()
        {
            ViewData["Hotel"] = _context.hotels.Include(o => o.Owner).ToList();
            ViewData["User"] = _userManager.Users;
            return View();
        }
    }
}
