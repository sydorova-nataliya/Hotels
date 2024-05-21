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
        public string Recipe { get; set; }

        [Column("weight")]
        [Range(1, int.MaxValue, ErrorMessage = "Значення повино бути більше нуля")]
        [Required]
        [Display(Name = "Масса")]
        public int Weight { get; set; }

        [Column("unit")]
        [Required]
        [MaxLength(2)]
        [Display(Name = "Юнит")]
        public string Unit { get; set; }
    }
}
