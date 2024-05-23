using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("composition")]
    public class Composition
    {

        [Key]
        [Column("copmosition_id")]
        public int CompositionId {get;set;}
        [Column("id_dish", Order = 0)]
        [Display(Name = "Стравара")]
        public int DishId { get; set; }

        [Column("id_ingredient", Order = 1)]
        [Display(Name = "Інгрідієнти")]
        public int IngredientId { get; set; }

        [ForeignKey("DishId")]
        public Dish Dish { get; set; }

        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }
    }
}
