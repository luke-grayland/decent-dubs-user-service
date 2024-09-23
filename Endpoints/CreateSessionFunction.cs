using System.Net;
using System.Text.Json;
using DecentDubs.UserService.Models;
using DecentDubs.UserService.Processors.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace DecentDubs.UserService.Endpoints;

public class CreateSessionFunction(ILoggerFactory loggerFactory, ICreateSessionProcessor createSessionProcessor) : EndpointBase(loggerFactory)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<User>();
    
    [Function("CreateSession")]
    public async Task<HttpResponseData> CreateSession([HttpTrigger(AuthorizationLevel.Function, "post", Route = "session")] 
        HttpRequestData req, FunctionContext executionContext)
    {
        try
        {
            _logger.LogInformation("Create Session request received");
            
            var createSessionRequest = JsonSerializer.Deserialize<CreateSessionRequest>(await new StreamReader(req.Body).ReadToEndAsync())
                ?? throw new Exception("Unable to deserialize CreateSessionRequest");
                
            var userSession = createSessionProcessor.Process(createSessionRequest); 
            
            return await CreateSuccessResponse(req, userSession);
        }
        catch (BusinessException ex)
        {
            return await CreateErrorResponse(req, LogAndReturnError(ex, "CreateSession"), HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            return await CreateErrorResponse(req, LogAndReturnError(ex, "CreateSession"), HttpStatusCode.InternalServerError);
        }
    }
    
    
}