using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentCRUDProjectAPI.Entity;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? CourseId { get; set; }

    public string Phone { get; set; }

    public string Password { get; set; }

    [JsonIgnore]
    public virtual Subject Course { get; set; }
}
