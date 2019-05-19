using System.ComponentModel.DataAnnotations;

namespace BLL.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = "Будь ласка, введіть логін")]
        public string UserLogin { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
