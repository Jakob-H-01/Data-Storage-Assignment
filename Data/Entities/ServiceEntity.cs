﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.Entities;

public class ServiceEntity
{
    [Key]
    public int Id { get; set; }

    public string ServiceName { get; set; } = null!;

    public decimal Price { get; set; }

    [JsonIgnore]
    public virtual ICollection<ProjectEntity> Projects { get; set; } = [];
}
