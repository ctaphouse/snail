using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using snail.api.Persistence;
using snail.api.Persistence.Entities;
using snail.shared.Features.ManageStudents.AddStudent;

namespace snail.api.Features.ManageStudents.AddStudent;

public class AddStudentEndpoint : EndpointBaseAsync.WithRequest<AddStudentRequest>.WithActionResult<int>
{
    private readonly SnailContext _context;

    public AddStudentEndpoint(SnailContext context)
    {
        _context = context;
    }
    
    [HttpPost(AddStudentRequest.RouteTemplate)]
    public override async Task<ActionResult<int>> HandleAsync(AddStudentRequest request, CancellationToken cancellationToken = default)
    {
        var student = new Student
        {
            FirstName = request.Student.FirstName,
            LastName = request.Student.LastName,
            DepartmentId = request.Student.DepartmentId
        };

        await _context.Students.AddAsync(student, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return student.Id;
    }
}