using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ServiceUpdateForm
{
    [Required]
    public int Id { get; set; }

    public string ServiceName { get; set; } = null!;

    public decimal Price { get; set; }
}
