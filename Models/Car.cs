namespace EMG.Models;

using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;


public class Car
{
    public int Id { get; set; }

    public string? VIN { get; set; }


    [Range(1990, int.MaxValue, ErrorMessage = "L'année doit être supérieure à 1990.")]
    public int? Année { get; set; }
    [Display(Name = "Marque")]
    public int? MarqueId { get; set; }
    [Display(Name = "Modele")]
    public int? ModeleId { get; set; }
    [Display(Name = "Finition")]
    public int? FinitionId { get; set; }
    public virtual Marque? Marque { get; set; }
    public virtual Modele? Modele { get; set; }
    public virtual Finition? Finition { get; set; }

[Required]
    [Display(Name = "Date d'achat")]
    public DateTime? DateAchat { get; set; }

    [Required]
    [Display(Name = "Prix d'achat")]
    public decimal? PrixAchat { get; set; }

    [Required]
    [Display(Name = "Date de disponibilité")]
    public DateTime? DateDisponibilité { get; set; }

    [Required]
    [Display(Name = "Prix de vente")]
    public decimal? PrixVente { get; set; }

    [Required]
    [Display(Name = "Date de vente")]
    public DateTime? DateVente { get; set; }

    // Navigation property pour les réparations associées
    public virtual ICollection<Repair>? Réparations { get; set; }

    public virtual Image? Image { get; set; }

   

}
