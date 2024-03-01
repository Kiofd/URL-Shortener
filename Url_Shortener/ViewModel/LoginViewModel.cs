using System.ComponentModel.DataAnnotations;

namespace Url_Shortener.ViewModel;

[Serializable]
public class LoginViewModel
{
    [Required] 
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}