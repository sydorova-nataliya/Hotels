using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("ingredient")]
    public class Ingredient
    {
        [Key]
        [Column("id_ingredient")]
        public int Id { get; set; }

        [Column("title")]
        [Required]
        [MaxLength(30)]
        [Display(Name = "Назва")]
        public string Title { get; set; }

        [Column("quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше нуля")]
        [Display(Name = "Кількість")]
        public int Quantity { get; set; }

        [Column("unit")]
        [Required]
        [MaxLength(20)]
        [Display(Name = "Юніт")]
        public string Unit { get; set; }
    }
}