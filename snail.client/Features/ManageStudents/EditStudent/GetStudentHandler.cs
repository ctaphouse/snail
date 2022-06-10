using MediatR;
using snail.shared.Features.ManageStudents.EditStudent;
using System.Net.Http.Json;

namespace snail.client.Features.ManageStudents.EditStudent;

public class GetStudentHandler : IRequestHandler<GetStudentRequest, GetStudentRequest.Response>
{
    private readonly HttpClient _httpClient;

    public GetStudentHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetStudentRequest.Response> Handle(GetStudentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<GetStudentRequest.Response>(GetStudentRequest.RouteTemplate.Replace("{studentId}", request.StudentId.ToString()), cancellationToken);
        }
        catch (HttpRequestException)
        {
            return default!;
        }
    }
}