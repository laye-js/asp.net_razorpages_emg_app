using System.ComponentModel.DataAnnotations;

namespace EMG.Models;

public class Modele
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Nom")]
    public string Nom { get; set; }

}
