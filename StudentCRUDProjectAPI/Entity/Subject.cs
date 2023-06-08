using System.Text.Json.Serialization;

namespace StudentCRUDProjectAPI.Entity;

public partial class Subject
{
    public int Id { get; set; }

    public string CourseName { get; set; }

    public string Description { get; set; }

    [JsonIgnore]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
