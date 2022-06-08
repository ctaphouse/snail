using MediatR;

namespace snail.shared.Features.ManageStudents.DeleteStudent;

public record DeleteStudentRequest(int StudentId) : IRequest<DeleteStudentRequest.Response>
{
    public const string RouteTemplate = "/api/students/{studentId}";

    public record Response(bool IsSuccess);
}