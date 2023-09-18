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
        public IActionResult CreateRoom()
        {
            ViewBag.HotelId = new SelectList(_context.hotels.ToList(), "Id", "Name");
            ViewBag.TypeRoomId = new SelectList(_context.typeRooms.ToList(), "Id", "Name");
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
