using System.ComponentModel.DataAnnotations;

namespace EMG.Models
{
    public class Repair
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Coût")]
        public decimal? Coût { get; set; }

        [Required]
        [Display(Name = "Date de réparation")]
        public DateTime? DateRéparation { get; set; }

        [Required]
        [Display(Name = "Véhicule associé")]
        public int? CarId { get; set; }
        public virtual Car? Cars { get; set; }
    

}
}
