using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("type_service")]
    public class Services
    {
        [Key]
        [Column("id_service")]
        public int Id { get; set; }

        [Column("name_service")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column("price")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше нуля")]
        public decimal Price { get; set; }
    }
}
