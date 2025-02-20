using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ProjectRegistrationForm
{
    public string ProjectName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public int StatusId { get; set; }

    public int ServiceId { get; set; }

    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }
}
