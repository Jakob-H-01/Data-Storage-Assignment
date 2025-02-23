using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.Entities;

public class StatusEntity
{
    [Key]
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<ProjectEntity> Projects { get; set; } = [];
}
