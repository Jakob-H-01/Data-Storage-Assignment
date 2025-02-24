using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class StatusUpdateForm
{
    [Required]
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;
}
