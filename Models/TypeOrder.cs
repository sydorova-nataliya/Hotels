using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("type_order")]
    public class TypeOrder
    {
        [Key]
        [Column("id_type_order")]
        public int Id { get; set; }
        [Column("name_type_order")]
        [Display(Name = "Тип трансакции")]
        public string Name { get; set; }
    }
}
