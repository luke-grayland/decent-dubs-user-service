using System.Net;
using DecentDubs.UserService.Models;
using DecentDubs.UserService.Processors.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace DecentDubs.UserService.Endpoints;

public class GetSessionFunction(ILoggerFactory loggerFactory, IGetSessionProcessor getSessionProcessor) : EndpointBase(loggerFactory)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<User>();
    
    [Function("GetSession")]
    public async Task<HttpResponseData> GetSession([HttpTrigger(AuthorizationLevel.Function, "get", Route = "session/{sessionId}")] 
        HttpRequestData req, FunctionContext executionContext, string sessionId)
    {
        try
        {
            _logger.LogInformation("Get Session request received");
            
            if (string.IsNullOrEmpty(sessionId))
                throw new BusinessException("Session ID not found in query parameter");
            
            var getSessionResponse = getSessionProcessor.Process(sessionId);
            
            return await CreateSuccessResponse(req, getSessionResponse);
        }
        catch (BusinessException ex)
        {
            return await CreateErrorResponse(req, LogAndReturnError(ex, "GetSession"), HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            return await CreateErrorResponse(req, LogAndReturnError(ex, "GetSession"), HttpStatusCode.InternalServerError);
        }
    }
}