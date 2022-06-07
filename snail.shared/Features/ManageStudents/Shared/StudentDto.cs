namespace snail.shared.Features.ManageStudents.Shared;

public class StudentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int DepartmentId { get; set; }
}