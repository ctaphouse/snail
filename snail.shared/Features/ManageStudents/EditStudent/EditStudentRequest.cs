using MediatR;
using snail.shared.Features.ManageStudents.Shared;

namespace snail.shared.Features.ManageStudents.EditStudent;

public record EditStudentRequest(StudentDto Student) : IRequest<EditStudentRequest.Response>
{
    public const string RouteTemplate = "/api/students";

    public record Response(bool IsSuccess);
}