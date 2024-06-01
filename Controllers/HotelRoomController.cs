using Microsoft.AspNetCore.Mvc;
using hotelcourseworkV2.Data;
using Microsoft.EntityFrameworkCore;


namespace hotelcourseworkV2.Controllers
{
    public class HotelRoomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelRoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult HotelRoomList(int id)
        {
            var room = _context.hotelRooms.Where(h => h.HotelId == id).Include(t=>t.typeRoom).ToList();
            var reservedRoomIds = _context.reserves.Select(r => r.HotelTypeRoomId).Distinct().ToList();
            var roomList = _context.hotelRooms.Where(r => r.HotelId == id && !reservedRoomIds.Contains(r.Id)).Include(t => t.typeRoom).ToList();
            ViewBag.AllRooms = _context.hotelRooms.Where(c => c.HotelId == id).Count();
            ViewBag.OcupiedRooms = _context.hotelRooms.Where(r => r.HotelId == id && reservedRoomIds.Contains(r.Id)).Count();
            ViewBag.FreeRoom = ViewBag.AllRooms - ViewBag.OcupiedRooms;
            
            if(@User.IsInRole("Горничные")){
                return View(room);
            }else{
                return View(roomList);
            }
        }

    }
}
