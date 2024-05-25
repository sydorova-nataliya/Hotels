using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("menu_dish_reserve_dish")]
    public class MenuDishReserveDish
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("menu_dish_id")]
        public int MenuDishId { get; set; }
        public Dish MenuDish { get; set; }

        [Column("reserve_dish_id")]
        public int ReserveDishId { get; set; }
        public ReserveDish ReserveDish { get; set; }
    }
}
