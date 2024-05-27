using hotelcourseworkV2.Data;
using hotelcourseworkV2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using hotelcourseworkV2.ViewModels;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> ReserveRoom(int id)
        {
            var room = _context.hotelRooms.FirstOrDefault(h => h.Id == id);
            if (room != null)
            {
                ViewBag.Price = room.Price;
                ViewBag.RoomId = room.Id;
            }
            if (User.IsInRole("Сотрудник рецепции"))
            {
                var guests = await _userManager.GetUsersInRoleAsync("Зарегистрированный клиент");
                ViewBag.QuestId = new SelectList(guests, "Id", "UserName");
            }
            else
            {

                ViewBag.QuestId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }

            return View();
        }

        public IActionResult ReserveRoom(ReserveRoom reserve)
        {
            reserve.DepartureDate = reserve.DepartureDate.ToUniversalTime();
            reserve.ArrivalDate = reserve.ArrivalDate.ToUniversalTime();
            reserve.BookingDate = reserve.BookingDate.ToUniversalTime();
            var room = _context.hotelRooms.FirstOrDefault(r => r.Id == reserve.HotelTypeRoomId);
            if (room != null)
            {
                room.IsStatus = false; // Обновление статуса комнаты на false
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
        public IActionResult ReserveDelete(int id)
        {
            var reserve = _context.reserves.Find(id);
            if (reserve == null)
            {
                return NotFound();
            }

            var room = _context.hotelRooms.FirstOrDefault(r => r.Id == reserve.HotelTypeRoomId);
            if (room == null)
            {
                return NotFound(new { success = false, message = "Room not found" });
            }

            _context.reserves.Remove(reserve);
            if (room.IsStatus == true)
            {
                _context.SaveChanges();
            }
            else
            {
                room.IsStatus = true;
                _context.SaveChanges();
            }

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
        public IActionResult ReserveDishCreate(int menuid)
        {

            var menuDishIds = _context.menuDishes
                .Where(md => md.MenuId == menuid)
                .Select(md => md.DishId)
                .ToList();

            var menuDishes = _context.dishes
                .Where(d => menuDishIds.Contains(d.Id))
                .ToList();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = new CreateReserveDishViewModel
            {
                MenuDishes = menuDishes
            };

            var availableRooms = _context.reserves
                .Where(r => r.QuestId == userId)
                .Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = $"Номер: {r.HotelTypeRoom.NumberRoom} - Назва отелю: {r.HotelTypeRoom.hotel.Name}"
                })
                .ToList();

            ViewBag.Reserve = availableRooms;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ReserveDishCreate(CreateReserveDishViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {

                var reserveDish = new ReserveDish
                {
                    reserveRoomId = viewModel.reserveRoomId,
                    Description = viewModel.Description,
                    BookingDate = viewModel.BookingDate.ToUniversalTime(),
                    Price = viewModel.Price
                };

                _context.reserveDishes.Add(reserveDish);

                _context.SaveChanges();

                int reserveDishId = reserveDish.Id;

                foreach (var dishId in viewModel.selectDish)
                {
                    var menuDishReserveDish = new MenuDishReserveDish
                    {
                        MenuDishId = dishId,
                        ReserveDishId = reserveDishId
                    };

                    _context.menuDishReserveDishes.Add(menuDishReserveDish);
                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ReserveDishList()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var reservations = _context.reserveDishes
                .Where(rd => rd.reserveRoom.QuestId == userId)
                .Select(rd => new CreateReserveDishViewModel
                {
                    reserveRoomId = rd.reserveRoomId,
                    Description = rd.Description,
                    BookingDate = rd.BookingDate,
                    Price = rd.Price,
                    MenuDishes = rd.menuDishReserveDishes.Select(md => md.MenuDish).ToList(),
                    RoomNumber = rd.reserveRoom.HotelTypeRoom.NumberRoom,
                    HotelName = rd.reserveRoom.HotelTypeRoom.hotel.Name
                })
                .ToList();

            return View(reservations);
        }
    }
}
