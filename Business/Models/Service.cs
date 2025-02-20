using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Service
{
    [Required]
    public int Id { get; set; }

    public string ServiceName { get; set; } = null!;

    public decimal Price { get; set; }
}
