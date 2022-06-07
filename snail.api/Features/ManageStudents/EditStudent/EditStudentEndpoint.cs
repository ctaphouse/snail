using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using snail.api.Persistence;
using snail.shared.Features.ManageStudents.EditStudent;

namespace snail.api.Features.ManageStudents.EditStudent;

public class EditStudentEndpoint : EndpointBaseAsync.WithRequest<EditStudentRequest>.WithActionResult<bool>
{
    private readonly SnailContext _context;

    public EditStudentEndpoint(SnailContext context)
    {
        _context = context;
    }

    [HttpPut(EditStudentRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditStudentRequest request, CancellationToken cancellationToken = default)
    {
        var student = await _context.Students.SingleOrDefaultAsync(x => x.Id == request.Student.Id, cancellationToken: cancellationToken);
    
        if(student is null)
        {
            return BadRequest("Student could not be found");
        }

        student.FirstName = request.Student.FirstName;
        student.LastName = request.Student.LastName;
        student.DepartmentId = request.Student.DepartmentId;

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(true);
    }
}