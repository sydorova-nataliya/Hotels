//Клиент 
//Ціна 
//Тип замовлення(ресторан,сервіс,бронювання....)
//Дата
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("order")]
    public class Order
    {
        [Key]
        [Column("id_order")]
        public int Id { get; set; }

        [Column("type_order_id")]
        public TypeOrder TypeOrderId {get;set;}

        [Column("type_order")]
        [Display(Name = "Тип ордера")]
        public string TypeOrder { get; set; }

        [Column("client_id")]
        public string Client_id {get;set;}
        public Account Client {get;set;}

        [Column("price")]
        [Display(Name = "Ціна")]
        public decimal Price {get;set;}

        [Column("date_create")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата створення")]
        public DateTime dateCreate{get;set;} = DateTime.Now;
    }
}