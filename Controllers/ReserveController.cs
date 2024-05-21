using hotelcourseworkV2.Data;
using hotelcourseworkV2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace hotelcourseworkV2.Controllers
{
    public class ReserveController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ReserveController(ApplicationDbContext context,
                                UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> ReserveCreate(int id)
        {
            var room = _context.hotelRooms.FirstOrDefault(h => h.Id == id);
            if (room != null)
            {
                ViewBag.RoomId = room.Id;
            }
            var guests = await _userManager.GetUsersInRoleAsync("Зарегистрированный клиент");
            //ViewBag.HotelTypeRoomId = new SelectList(_context.hotelRooms.ToList(), "Id", "NumberRoom");
            ViewBag.QuestId = new SelectList(guests, "Id", "UserName");

            return View();
        }

        public IActionResult ReserveCreate(ReserveRoom reserve)
        {
            reserve.DepartureDate = reserve.DepartureDate.ToUniversalTime();
            reserve.ArrivalDate = reserve.ArrivalDate.ToUniversalTime();
            reserve.BookingDate = reserve.BookingDate.ToUniversalTime();

            _context.reserves.Add(reserve);
            _context.SaveChanges();
            var user = HttpContext.User;
            if (user.IsInRole("Сотрудник рецепции"))
            {
                return RedirectToAction("Reseption", "Reseption");
            }
            else
            {
                return RedirectToAction("Guest", "Guest");
            }
        }

        [HttpGet]
        public IActionResult ReserveRoom(int id)
        {
            var room = _context.hotelRooms.FirstOrDefault(h => h.Id == id);
            if (room != null)
            {
                ViewBag.RoomId = room.Id;
            }
            ViewBag.QuestId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return View();
        }

        public IActionResult ReserveRoom(ReserveRoom reserve)
        {
            reserve.DepartureDate = reserve.DepartureDate.ToUniversalTime();
            reserve.ArrivalDate = reserve.ArrivalDate.ToUniversalTime();
            reserve.BookingDate = reserve.BookingDate.ToUniversalTime();
            _context.reserves.Add(reserve);
            _context.SaveChanges();
            var user = HttpContext.User;
            if (user.IsInRole("Сотрудник рецепции"))
            {
                return RedirectToAction("Reseption", "Reseption");
            }
            else
            {
                return RedirectToAction("Guest", "Guest");
            }
        }

        [HttpGet]
        public IActionResult ReserveDelete(int id)
        {
            var reserve = _context.reserves.Find(id);
            if (reserve == null)
            {
                return NotFound();
            }

            _context.reserves.Remove(reserve);
            _context.SaveChanges();

            var user = HttpContext.User;

            if (user.IsInRole("Сотрудник рецепции"))
            {
                return RedirectToAction("Reseption", "Reseption");
            }
            else
            {
                return RedirectToAction("Guest", "Guest");
            }
        }

    }
}
