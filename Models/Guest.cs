using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    [Table("quest")]
    public class Guest
    {
        [Column("id_guest")]
        public int Id { get; set; }

        [Column("full_name")]
        [MaxLength(100, ErrorMessage = "Максимальная длина 100 символов")]
        public string FullName { get; set; }

        [Column("passport_series")]
        [MaxLength(2, ErrorMessage = "Максимальная длина 2 символа")]
        public string PassportSeries { get; set; }

        [Column("passport_number")]
        [MaxLength(9, ErrorMessage = "Максимальная длина 9 символов")]
        public string PassportNumber { get; set; }
    }
}
