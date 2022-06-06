using MediatR;

namespace snail.shared.Features.ManageStudents.EditStudent;

public record GetStudentRequest(int StudentId) : IRequest<GetStudentRequest.Response>
{
    public const string RouteTemplate = "/api/students/{studentId}";
    public record Student(int Id, string FirstName, string LastName, int DepartmentId);
    public record Response(Student Student);
}