using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models.ViewModels;

public class LoginViewModel
{
    [Microsoft.Build.Framework.Required]
    public string Username { get; set; }
    
    [Microsoft.Build.Framework.Required]
    [MinLength(6, ErrorMessage = "Password has to be at least 6 characters")]
    public string Password { get; set; }
    
    public string? ReturnUrl { get; set; }
}