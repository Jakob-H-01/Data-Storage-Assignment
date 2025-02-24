using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ProjectUpdateForm
{
    [Required]
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public StatusUpdateForm Status { get; set; } = null!;

    public ServiceUpdateForm Service { get; set; } = null!;

    public EmployeeUpdateForm Employee { get; set; } = null!;

    public CustomerUpdateForm Customer { get; set; } = null!;
}
