using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("hotel_type_room")]
    public class HotelRoom
    {
        [Key]
        [Column("id_h_t_r")]
        public int Id { get; set; }
        [Column("id_hotel")]
        public int HotelId { get; set; }
        public Hotel hotel { get; set; }
        [Column("id_type_room")]
        public int TypeRoomId { get; set; }
        public TypeRoom typeRoom { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Значення повино бути більше нуля")]
        [Column("price")]
        [Display(Name = "Ціна")]
        public decimal Price { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Значення повино бути більше нуля")]
        [Column("number_room")]
        [Display(Name = "Номер")]
        public int NumberRoom {get; set; }

        [Column("floor_room")]
        [Display(Name = "Поверх")]
        public int FloorRoom { get; set; }
        [Column("amount_room")]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше нуля")]
        [Display(Name = "Кількість кімнат")]
        public int AmountRoom { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше нуля")]
        [Column("amount_place")]
        [Display(Name = "Кількість місць")]
        public int AmountPlace { get; set; }

        [Display(Name = "Статус")]
        [Column("status")]
        public bool ?IsStatus {get;set;}
        


    }
}
