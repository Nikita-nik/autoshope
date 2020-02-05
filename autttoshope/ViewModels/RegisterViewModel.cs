using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace autttoshope.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}