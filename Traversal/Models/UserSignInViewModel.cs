using System.ComponentModel.DataAnnotations;

namespace Traversal.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriiniz")]
        public string password { get; set; }
    }
}
