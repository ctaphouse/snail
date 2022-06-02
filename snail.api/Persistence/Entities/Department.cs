namespace snail.api.Persistence.Entities;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public ICollection<Student> Students { get; set; } = new List<Student>();
}