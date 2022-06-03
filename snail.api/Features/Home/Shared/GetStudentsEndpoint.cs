using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using snail.api.Persistence;
using snail.shared.Features.Home.Shared;

namespace snail.api.Features.Home;

public class GetStudentsEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetStudentsRequest.Response>
{
    private readonly SnailContext _context;

    public GetStudentsEndpoint(SnailContext context)
    {
        _context = context;
    }

    [HttpGet(GetStudentsRequest.RouteTemplate)]
    public override async Task<ActionResult<GetStudentsRequest.Response>> HandleAsync(int request, CancellationToken cancellationToken = default)
    {
        var students = await _context.Students.ToListAsync(cancellationToken);

        var response = new GetStudentsRequest.Response(students.Select(student => new GetStudentsRequest.Student(
            student.Id,
            student.FirstName,
            student.LastName,
            student.DepartmentId
        )));

        return Ok(response);
    }
}