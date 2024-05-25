using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("menu_dish")]
    public class MenuDish
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Menu")]
        [Column("menu_id")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        [ForeignKey("Dish")]
        [Column("dish_id")]
        public int DishId { get; set; } 
        public Dish Dish { get; set; }
    }
}
