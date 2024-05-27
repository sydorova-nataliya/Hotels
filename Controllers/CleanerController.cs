using hotelcourseworkV2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using hotelcourseworkV2.Models;

namespace hotelcourseworkV2.Controllers
{
    public class CleanerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CleanerController(ApplicationDbContext context,
                                UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Горничные")]
        public async Task<IActionResult> Cleaner(string searchString)
        {
            var hotels = from h in _context.hotels.Include(h => h.Owner)
                         select h;

            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                hotels = hotels.Where(h => h.Name.Contains(searchString) || h.City.Contains(searchString));
            }
            ViewData["Hotel"] = await hotels.ToListAsync();
            return View();
        }

        public async Task<IActionResult> CleanRoom(int id)
        {
            // Найти комнату по идентификатору
            var room = await _context.hotelRooms.FirstOrDefaultAsync(r => r.Id == id);
            if (room == null)
            {
                return NotFound(new { success = false, message = "Room not found" });
            }

            // Найти все бронирования, связанные с этой комнатой
            var reservations = await _context.reserves.Where(r => r.HotelTypeRoomId == id).ToListAsync();
            if (reservations != null && reservations.Count > 0)
            {
                // Удалить все найденные бронирования
                _context.reserves.RemoveRange(reservations);
            }

            // Обновить статус комнаты
            room.IsStatus = true;
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }
    }
}
