using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ServiceRegistrationForm
{
    public string ServiceName { get; set; } = null!;

    public decimal Price { get; set; }
}
