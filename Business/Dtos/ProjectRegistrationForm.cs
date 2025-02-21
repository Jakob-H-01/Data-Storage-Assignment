namespace Business.Dtos;

public class ProjectRegistrationForm
{
    public string ProjectName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public StatusRegistrationForm Status { get; set; } = null!;
    
    public ServiceRegistrationForm Service { get; set; } = null!;

    public EmployeeRegistrationForm Employee { get; set; } = null!;

    public CustomerRegistrationForm Customer { get; set; } = null!;
}
