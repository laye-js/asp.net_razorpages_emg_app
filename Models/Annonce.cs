using System.ComponentModel.DataAnnotations;

namespace EMG.Models;

public class Annonce
{
    public int Id { get; set; }
    [Required]
    [Display(Name = "Description de l'annonce")]
    public string? Description { get; set; }

    [Required]
    [Display(Name = "Véhicule associé")]
    public int? CarId { get; set; }
    public virtual Car? Car { get; set; }

}
