using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Customer
{
    [Required]
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;
}
