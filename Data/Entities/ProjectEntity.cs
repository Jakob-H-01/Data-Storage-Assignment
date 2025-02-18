using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public string Description { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;

    public int ServiceId { get; set; }
    public ServiceEntity Service { get; set; } = null!;

    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;

    public int EmployeeId { get; set; }
    public EmployeeEntity Employee { get; set; } = null!;
}
