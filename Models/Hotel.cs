using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("hotel")]
    public class Hotel
    {
        [Key]
        [Column("id_hotel")]
        public int Id { get; set; }
        [Column("name_hotel")]
        [Display(Name = "Назва готелю")]
        public string Name { get; set; }
        [Column("stars")]
        [Range(1,5,ErrorMessage = "Диапазон от 1 до 5")]
        [Display(Name = "Рейтинг")]
        public int Stars { get; set; }
        [MaxLength(20,ErrorMessage = "Максимальное количество символов 20")]
        [Column("city")]
        [Display(Name = "Місто")]
        public string City { get; set; }
        [MaxLength(50, ErrorMessage = "Максимальное количество символов 50")]
        [Column("street")]
        [Display(Name = "Вулиця")]
        public string Street { get; set; }

        [Column("owner_id")]
        public string OwnerId { get; set; }
        public Account Owner { get; set; } 

    }
}
