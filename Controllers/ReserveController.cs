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
        public async Task<IActionResult> ReserveCreate()
        {
            var guests = await _userManager.GetUsersInRoleAsync("Зарегистрированный клиент");
            ViewBag.HotelTypeRoomId = new SelectList(_context.typeRooms.ToList(), "Id", "Name");
            ViewBag.QuestId = new SelectList(guests, "Id", "UserName");
            return View();
        }

        public IActionResult ReserveCreate(ReserveRoom reserve)
        {
            reserve.DepartureDate = DateTime.SpecifyKind(reserve.DepartureDate, DateTimeKind.Utc);
            reserve.ArrivalDate = DateTime.SpecifyKind(reserve.ArrivalDate, DateTimeKind.Utc);
            reserve.BookingDate = DateTime.SpecifyKind(reserve.BookingDate, DateTimeKind.Utc);

            // Проверяем существование связанных объектов перед сохранением
            var hotelTypeRoom = _context.typeRooms.FirstOrDefault(r => r.Id == reserve.HotelTypeRoomId);
            if (hotelTypeRoom == null)
            {

                // Обработка ошибки: неверное значение внешнего ключа HotelTypeRoomId
                return BadRequest("Invalid HotelTypeRoomId.");
            }

            var quest = _context.Users.FirstOrDefault(u => u.Id == reserve.QuestId);
            if (quest == null)
            {
                // Обработка ошибки: неверное значение внешнего ключа QuestId
                return BadRequest("Invalid QuestId.");
            }
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
        public IActionResult ReserveRoom()
        {
            ViewBag.HotelTypeRoomId = new SelectList(_context.typeRooms.ToList(), "Id", "Name");
            ViewBag.QuestId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return View();
        }

        public IActionResult ReserveRoom(ReserveRoom reserve)
        {
            reserve.DepartureDate = DateTime.SpecifyKind(reserve.DepartureDate, DateTimeKind.Utc);
            reserve.ArrivalDate = DateTime.SpecifyKind(reserve.ArrivalDate, DateTimeKind.Utc);
            reserve.BookingDate = DateTime.SpecifyKind(reserve.BookingDate, DateTimeKind.Utc);
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
