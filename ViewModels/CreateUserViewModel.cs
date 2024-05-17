using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hotelcourseworkV2.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Введіть ім'я користувача")]
        [Display(Name = "Імя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введіть прізвище користувача")]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введіть по-батькові користувача")]
        [Display(Name = "По-батькові")]
        public string MiddleName { get; set; }

        [Display(Name = "Номер телефону")]
        [Required(ErrorMessage = "Введіть номер телефону користувача")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Введіть адресу електронної пошти")]
        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Підтвердіть пароль")]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Виберіть роль")]
        [Display(Name = "Роль")]
        public string RoleName { get; set; }

        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
