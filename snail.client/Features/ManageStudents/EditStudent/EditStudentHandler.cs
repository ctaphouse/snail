using MediatR;
using snail.shared.Features.ManageStudents.EditStudent;
using System.Net.Http.Json;

namespace snail.client.Features.ManageStudents.EditStudent;

public class EditStudentHandler : IRequestHandler<EditStudentRequest, EditStudentRequest.Response>
{
    private readonly HttpClient _httpClient;

    public EditStudentHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<EditStudentRequest.Response> Handle(EditStudentRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PutAsJsonAsync(EditStudentRequest.RouteTemplate, request, cancellationToken);

        if(response.IsSuccessStatusCode)
        {
            return new EditStudentRequest.Response(true);
        }
        else
        {
            return new EditStudentRequest.Response(false);
        }
    }
}
