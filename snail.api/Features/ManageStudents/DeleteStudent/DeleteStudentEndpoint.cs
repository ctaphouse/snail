using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using snail.api.Persistence;
using snail.shared.Features.ManageStudents.DeleteStudent;

namespace snail.api.Features.ManageStudents.DeleteStudent;

public class DeleteStudentEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<DeleteStudentRequest.Response>
{
    private readonly SnailContext _context;

    public DeleteStudentEndpoint(SnailContext context)
    {
        _context = context;
    }

    [HttpDelete(DeleteStudentRequest.RouteTemplate)]
    public override async Task<ActionResult<DeleteStudentRequest.Response>> HandleAsync(int studentId, CancellationToken cancellationToken = default)
    {
        var student = await _context.Students.SingleOrDefaultAsync(x => x.Id == studentId);

        if(student is null)
        {
            return BadRequest("Student could not be found");
        }

        _context.Students.Remove(student);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(true);
    }
}
