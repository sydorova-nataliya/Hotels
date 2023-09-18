using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("menu")]
    public class Menu
    {
        [Key]
        [Column("id_menu")]
        public int Id { get; set; }
        [Column("id_hotel")]
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }
        [Column("id_dish")]
        public int DishId { get; set; }
        [ForeignKey("DishId")]
        public Dish Dish { get; set; }
        [Column("price")]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше нуля")]
        public decimal Price { get; set; }
    }
}
