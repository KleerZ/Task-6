using System.ComponentModel.DataAnnotations;

namespace Task.Mvc.Models;

public class UserViewModel
{
    [Required(ErrorMessage = "Please, enter your name")]
    public string Name { get; set; }
}