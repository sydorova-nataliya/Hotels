using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("booking_dish")]
    public class ReserveDish
    {
        [Key]
        [Column("id_booking_dish")]
        public int Id { get; set; }

        [Column("reserve_room_id")]
        [Display(Name = "Кімната")]
        public int reserveRoomId {get;set;}
        public ReserveRoom reserveRoom {get;set;}

        [Column("desc")]
        [Display(Name = "Коментарі")]
        [MaxLength(500, ErrorMessage = "Максимальна кількість символів 500")]
        [DataType(DataType.Text)]
        public string ?Description {get;set;}
    
        [Column("booking_date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Додайде дату")]
        [Display(Name = "Дата замолення")]
        public DateTime BookingDate { get; set; } = DateTime.Now;

        [Column("price")]
        [Display(Name = "Ціна")]
        [Range(1,99999,ErrorMessage = "Укажіть ціну")]
        public decimal Price { get; set; }
        public virtual ICollection<MenuDishReserveDish> menuDishReserveDishes {get;set;}

    }
}
