using System.Security.Claims;
using hotelcourseworkV2.Data;
using hotelcourseworkV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hotelcourseworkV2.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetRoomPrice(int typeRoomId)
        {
            var roomType = _context.typeRooms.FirstOrDefault(rt => rt.Id == typeRoomId);
            if (roomType == null)
            {
                return NotFound();
            }

            return Json(new { price = roomType.Price });
        }

        [HttpGet]
        public IActionResult CreateRoom()
        {
            var userId =  User.FindFirstValue(ClaimTypes.NameIdentifier);
            var typeRooms = _context.typeRooms.ToList();
            ViewBag.HotelId = new SelectList(_context.hotels.Where(h => h.OwnerId == userId).ToList(), "Id", "Name");
            ViewBag.TypeRoomId = new SelectList(typeRooms, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreateRoom(HotelRoom room)
        {
            _context.hotelRooms.Add(room);
            _context.SaveChanges();
            return RedirectToAction("Director","Director");
        }
    }
}
