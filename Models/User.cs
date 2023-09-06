using System.ComponentModel.DataAnnotations;

namespace SessionWorkshop.Models;

public class User 
{
    [Required(ErrorMessage = "Name is requried 🤠")]
    public string Name {get;set;}
}