using hotelcourseworkV2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace hotelcourseworkV2.Controllers
{
    public class GuestController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GuestController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Зарегистрированный клиент")]
        public IActionResult Guest()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewData["Reserve"] = _context.reserves
                                        .Include(s => s.HotelTypeRoom)
                                        .ThenInclude(t => t.typeRoom)
                                        .Include(u => u.Quest)
                                        .Where(g => g.QuestId == userId)
                                        .ToList();
            return View();
        }
    }
}
