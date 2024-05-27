﻿using hotelcourseworkV2.Data;
using hotelcourseworkV2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace hotelcourseworkV2.Controllers
{
   public class HotelController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        
        public HotelController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> CreateHotel()
        {
            var directors = await _userManager.GetUsersInRoleAsync("Директор");
            ViewBag.OwnerId = new SelectList(directors, "Id", "UserName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel(Hotel hotel, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                hotel.ImagePath = "/images/" + fileName;
            }
            _context.hotels.Add(hotel);
            _context.SaveChanges();
            return RedirectToAction("Owner", "Owner");
        }

        [HttpGet]
        public async Task<IActionResult> EditHotelAsync(int id)
        {
            var hotel = _context.hotels.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }

            var directors = await _userManager.GetUsersInRoleAsync("Директор");
            ViewBag.OwnerId = new SelectList(directors, "Id", "UserName", hotel.OwnerId);
            
            return View(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> EditHotel(Hotel hotel,IFormFile imageFile)
        {
            if (imageFile != null)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                hotel.ImagePath = "/images/" + fileName;
            }
            if (!ModelState.IsValid)
            {
                _context.Update(hotel);
                _context.SaveChanges();
                return RedirectToAction("Owner", "Owner");
            }
            return View(hotel);
        }

        [HttpPost]
        public IActionResult DeleteHotel(int id)
        {
            var hotel = _context.hotels.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.hotels.Remove(hotel);
            _context.SaveChanges();
            
            return RedirectToAction("Owner", "Owner");
        }


        public IActionResult ConfirmDeleteHotel(int id)
        {
            var hotel = _context.hotels.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        private bool HotelExists(int id)
        {
            return _context.hotels.Any(e => e.Id == id);
        }
    }

}
