using Microsoft.AspNetCore.Mvc;
using hotelcourseworkV2.Data;
using Microsoft.EntityFrameworkCore;



namespace hotelcourseworkV2.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AverageMonthlyRevenue()
        {
            var monthlyRevenue = _context.reserves
                .GroupBy(r => new { r.DepartureDate.Year, r.DepartureDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalRevenue = g.Sum(r => r.Price)
                })
                .ToList();

            return View(monthlyRevenue);
        }
    }
}
