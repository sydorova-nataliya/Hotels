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
        [Display(Name = "Готель")]
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

        [Display(Name = "Страви")]
        public virtual ICollection<MenuDish> MenuDishes { get; set; }
    }
}
