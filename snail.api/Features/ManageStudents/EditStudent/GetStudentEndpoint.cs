using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using snail.api.Persistence;
using snail.shared.Features.ManageStudents.EditStudent;

namespace snail.api.Features.ManageStudents.EditStudent;

public class GetStudentEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetStudentRequest.Response>
{
    private readonly SnailContext _context;

    public GetStudentEndpoint(SnailContext context)
    {
        _context = context;
    }
    [HttpGet(GetStudentRequest.RouteTemplate)]
    public override async Task<ActionResult<GetStudentRequest.Response>> HandleAsync(int studentId, CancellationToken cancellationToken = default)
    {
        var student = await _context.Students.SingleOrDefaultAsync(student => student.Id == studentId);

        if(student is null)
        {
            return BadRequest("Student could not be found");
        }
        
        var response = new GetStudentRequest.Response(new GetStudentRequest.Student(
            student.Id,
            student.FirstName,
            student.LastName,
            student.DepartmentId  
        ));

        return Ok(response);
    }
}
