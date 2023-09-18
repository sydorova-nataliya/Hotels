using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelcourseworkV2.Models
{
    public class Account : IdentityUser
    {
        [Display(Name = "Имя")]
        [Column("name")]
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [Column("lastname")]
        [Required(ErrorMessage = "Введите фамилию пользователя")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        [Column("middlename")]
        [Required(ErrorMessage = "Введите отчество пользователя")]
        public string MiddleName { get; set; }
        [Display(Name = "Номер телефона")]
        [Column("phone_number")]
        [Required(ErrorMessage = "Введите номер телефона пользователя")]
        public string Phone { get; set; }

        public int? GuestId { get; set; }
        public Guest Guest { get; set; }

        public IEnumerable<Hotel> Hotels { get; set; }
    }
}
