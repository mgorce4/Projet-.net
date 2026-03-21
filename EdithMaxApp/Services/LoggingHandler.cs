using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class LoggingHandler : DelegatingHandler
{
    public LoggingHandler() { }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Debug.WriteLine($"[LOG] Request: {request.Method} {request.RequestUri}");
        if (request.Content != null)
        {
            Debug.WriteLine($"[LOG] Request Content: {await request.Content.ReadAsStringAsync()}");
        }

        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

        Debug.WriteLine($"[LOG] Response: {response.StatusCode}");
        if (response.Content != null)
        {
            Debug.WriteLine($"[LOG] Response Content: {await response.Content.ReadAsStringAsync()}");
        }

        return response;
    }
}
