using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("booking")]
    public class ReserveRoom
    {
        [Key]
        [Column("id_booking")]
        public int Id { get; set; }

        [ForeignKey("Quest")]
        [Column("id_quest")]
        public string QuestId { get; set; }
        public Account Quest { get; set; }

        [ForeignKey("HotelTypeRoom")]
        [Column("id_h_t_r")]
        public int HotelTypeRoomId { get; set; }
        public HotelRoom HotelTypeRoom { get; set; }

        [Column("booking_date")]
        public DateTime BookingDate { get; set; } = DateTime.Now;

        [Column("arrival_date")]
        public DateTime ArrivalDate { get; set; } = DateTime.Now;

        [Column("departure_date")]
        [Required]
        public DateTime DepartureDate { get; set; }

        [Column("price")]
        [Required]
        public decimal Price { get; set; }

    }
}
