using MediatR;
using snail.shared.Features.Home.Shared;
using System.Net.Http.Json;

namespace snail.client.Features.Home.Shared;

public class GetStudentsHandler : IRequestHandler<GetStudentsRequest, GetStudentsRequest.Response?>
{
    private readonly HttpClient _httpClient;

    public GetStudentsHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetStudentsRequest.Response?> Handle(GetStudentsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<GetStudentsRequest.Response>(GetStudentsRequest.RouteTemplate);
        }
        catch (System.Exception)
        {
            return default!;
        }
    }
}
