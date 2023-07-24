using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Name is Required" )]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        //Login ekranından sonra kaldııekrana gidebilsin
        private string? _returnUrl;

        public string ReturnUrl
        {
            get
            {
                if (_returnUrl == null)
                {
                    return "/";
                }
                else
                {
                    return _returnUrl;
                }
            }
            set
            {
                _returnUrl = value;
            }
        }
    }
}
