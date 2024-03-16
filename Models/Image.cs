using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EMG.Models;

public class Image
{
    public int? Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public string? Path { get; set; }

    [NotMapped]
    public IFormFile? File { get; set; }

    public int? CarId { get; set; }
    public virtual Car? Car { get; set; }

}
