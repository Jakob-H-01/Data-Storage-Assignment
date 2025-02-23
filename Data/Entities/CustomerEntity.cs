using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<ProjectEntity> Projects { get; set; } = [];
}
