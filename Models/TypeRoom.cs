using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("type_room")]
    public class TypeRoom
    {
        [Key]
        [Column("id_type_room")]
        public int Id { get; set; }
        [Column("name_type_room")]
        public string Name { get; set; }
    }
}
