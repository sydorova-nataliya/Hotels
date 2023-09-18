using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("composition")]
    public class Composition
    {

        [Key]
        [Column("id_dish", Order = 0)]
        public int DishId { get; set; }

        [Column("id_ingredient", Order = 1)]
        public int IngredientId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(2)]
        public string Unit { get; set; }

        [ForeignKey("DishId")]
        public Dish Dish { get; set; }

        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }
    }
}
