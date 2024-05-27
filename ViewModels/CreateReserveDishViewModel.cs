using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using hotelcourseworkV2.Models;
namespace hotelcourseworkV2.ViewModels
{
    public class CreateReserveDishViewModel
    {
        
        [Display(Name = "Кімната")]
        public int reserveRoomId {get;set;}

        [Display(Name = "Коментарі")]
        [MaxLength(500, ErrorMessage = "Максимальна кількість символів 500")]
        [DataType(DataType.Text)]
        public string ?Description {get;set;}
    
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Додайде дату")]
        [Display(Name = "Дата замолення")]
        public DateTime BookingDate { get; set; } = DateTime.Now;

        [Display(Name = "Ціна")]
        public decimal Price { get; set; }
        public int RoomNumber {get;set;}
        public string HotelName {get;set;}
        public List<int> selectDish {get; set; }
        public List<Dish> MenuDishes {get;set;}

    }
}