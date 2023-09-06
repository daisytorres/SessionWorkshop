using System.ComponentModel.DataAnnotations;

namespace SessionWorkshop.Models;

public class User 
{
    [Required]
    public string Name {get;set;}
    public int Num {get;set;}
}