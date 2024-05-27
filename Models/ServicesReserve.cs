using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("booking_service")]
    public class ServicesReserve
    {
        [Key]
        [Column("id_b_s")]
        public int Id { get; set; }

        [Column("id_service")]
        [ForeignKey("TypeService")]
        [Display(Name = "Тип сервісу")]
        public int TypeServiceId { get; set; }
        public Services TypeService { get; set; }

        [Column("amount_service")]
        [DefaultValue(1)]
        [Display(Name = "Кількість")]
        public int Amount { get; set; }

        [Column("price")]
        [Required(ErrorMessage = "Введите цену")]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше нуля")]
        public decimal Price { get; set; }
    }
}
