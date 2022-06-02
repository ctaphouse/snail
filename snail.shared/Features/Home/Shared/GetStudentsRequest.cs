using MediatR;

namespace snail.shared.Features.Home.Shared;

public record GetStudentsRequest: IRequest<GetStudentsRequest.Response>
{
    public const string RouteTemplate = "api/students";
    public record Student(int Id, string FirstName, string LastName, int DepartmentId);
    public record Response(IEnumerable<Student> Students);
}