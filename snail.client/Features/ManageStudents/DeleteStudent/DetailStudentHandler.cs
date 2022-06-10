using MediatR;
using snail.shared.Features.ManageStudents.DeleteStudent;

namespace snail.client.Features.ManageStudents.DeleteStudent;

public class DeleteStudentHandler : IRequestHandler<DeleteStudentRequest, DeleteStudentRequest.Response>
{
    private readonly HttpClient _httpClient;

    public DeleteStudentHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DeleteStudentRequest.Response> Handle(DeleteStudentRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.DeleteAsync(DeleteStudentRequest.RouteTemplate.Replace("{studentId}", request.StudentId.ToString()), cancellationToken);
    
        if(response.IsSuccessStatusCode)
        {
            return new DeleteStudentRequest.Response(true);
        }
        else
        {
            return new DeleteStudentRequest.Response(false);
        }
    }
}