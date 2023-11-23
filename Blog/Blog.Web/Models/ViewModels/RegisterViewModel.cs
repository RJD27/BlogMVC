using System.ComponentModel.DataAnnotations;
using CloudinaryDotNet.Actions;

namespace Blog.Web.Models.ViewModels;

public class RegisterViewModel
{
    [Microsoft.Build.Framework.Required]
    public string Username { get; set; }
    
    [Microsoft.Build.Framework.Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Microsoft.Build.Framework.Required]
    [MinLength(6, ErrorMessage = "Password has to be at least 6 characters")]
    public string Password { get; set; }
}