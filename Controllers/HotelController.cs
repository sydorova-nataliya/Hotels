using hotelcourseworkV2.Data;
using hotelcourseworkV2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hotelcourseworkV2.Controllers
{
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public HotelController(ApplicationDbContext context, UserManager<IdentityUser> userManger)
        {
            _context = context;
            _userManager = userManger;
        }

        [HttpGet]
        public async Task<IActionResult> CreateHotel()
        {
            var directors = await _userManager.GetUsersInRoleAsync("Директор");
            ViewBag.OwnerId = new SelectList(directors, "Id", "UserName");
            return View();
        }

        [HttpPost]
        public IActionResult CreateHotel(Hotel hotel)
        {
            _context.hotels.Add(hotel);
            _context.SaveChanges();
            return RedirectToAction("Owner","Owner");
        }
    }
}
