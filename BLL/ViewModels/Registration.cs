using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.ViewModels
{
    public class Registration
    {
        [Required(ErrorMessage = "Будь ласка, введіть ID")]
        [RegularExpression("[0-9]", ErrorMessage = "ID повинно бути числом")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть ім'я")]
        [RegularExpression("^[a-zA-Z]{1,20}$", ErrorMessage = "Ім'я повинно складатись з літер")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть прізвище")]
        [RegularExpression("^[a-zA-Z]{1,20}$", ErrorMessage = "Прізвище повинно складатись з літер")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть дату народження")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть ідентифікаційний номер")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Ідентифікаційний номер повинен складатись з 10 цифер")]
        public int IPN { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть пароль")]
        [RegularExpression(".{6,}", ErrorMessage = "Пароль повинен містити більше 6 симолів")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
