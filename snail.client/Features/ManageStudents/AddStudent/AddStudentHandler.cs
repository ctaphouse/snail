using MediatR;
using snail.shared.Features.ManageStudents.AddStudent;
using System.Net.Http.Json;

namespace snail.client.Features.ManageStudents.AddStudent;

public class AddStudentHandler : IRequestHandler<AddStudentRequest, AddStudentRequest.Response>
{
    private readonly HttpClient _httpClient;

    public AddStudentHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AddStudentRequest.Response> Handle(AddStudentRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(AddStudentRequest.RouteTemplate, request, cancellationToken);

        if(response.IsSuccessStatusCode)
        {
            var studentId = await response.Content.ReadFromJsonAsync<int>(cancellationToken: cancellationToken);
            return new AddStudentRequest.Response(studentId);
        }
        else
        {
            return new AddStudentRequest.Response(-1);
        }
    }
}