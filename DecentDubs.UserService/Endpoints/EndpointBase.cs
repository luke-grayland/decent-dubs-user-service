using System.Net;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace DecentDubs.UserService;

public abstract class EndpointBase(ILoggerFactory loggerFactory)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<EndpointBase>();
    
    internal string LogAndReturnError(Exception ex, string endpoint)
    {
        var errorMessage = $"Error in {endpoint}: {ex.Message} {ex?.InnerException}"; 
        _logger.LogError(errorMessage);
        return errorMessage;
    }

    internal static async Task<HttpResponseData> CreateErrorResponse(HttpRequestData req, string errorMessage, HttpStatusCode code)
    {
        var response = req.CreateResponse(code);
        await response.WriteStringAsync(errorMessage);
        return response;
    }

    internal static async Task<HttpResponseData> CreateSuccessResponse(HttpRequestData req, object responseContent)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(responseContent);
        return response;
    }
}