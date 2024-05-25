using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("dish")]
    public class Dish
    {
        [Key]
        [Column("id_dish")]
        public int Id { get; set; }

        [Column("title")]
        [Display(Name = "Назва")]
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Column("recipe")]
        [Required]
        [Display(Name = "Рецепт")]
        [DataType(DataType.Text)]
        public string Recipe { get; set; }

        [Column("weight")]
        [Range(1, int.MaxValue, ErrorMessage = "Значення повино бути більше нуля")]
        [Required]
        [Display(Name = "Вага")]
        public int Weight { get; set; }

        [Column("unit")]
        [Required]
        [MaxLength(2)]
        [Display(Name = "Кількість")]
        public string Unit { get; set; }

        [Column("price")]
        [Required]
        [Display(Name = "Ціна")]
        public decimal Price {get;set;}

        public virtual ICollection<MenuDish> MenuDishes { get; set; }
        public virtual ICollection<Composition> Compositions { get; set; }
        public virtual ICollection<MenuDishReserveDish> menuDishReserveDishes {get;set;}
    }
}
