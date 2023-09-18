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
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Column("recipe")]
        [Required]
        public string Recipe { get; set; }

        [Column("weight")]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше нуля")]
        [Required]
        public int Weight { get; set; }

        [Column("unit")]
        [Required]
        [MaxLength(2)]
        public string Unit { get; set; }
    }
}
