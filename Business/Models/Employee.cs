using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Employee
{
    [Required]
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;
}
