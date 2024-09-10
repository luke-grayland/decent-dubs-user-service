using System.Net;
using System.Text.Json;
using DecentDubs.UserService.Models;
using DecentDubs.UserService.Processors.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace DecentDubs.UserService.Endpoints;

public class CreateUserFunction(ILoggerFactory loggerFactory, ICreateUserProcessor createUserProcessor) : EndpointBase(loggerFactory)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<User>();
    
    [Function("CreateUser")]
    public async Task<HttpResponseData> CreateUser([HttpTrigger(AuthorizationLevel.Function, "post", Route = "user")] 
        HttpRequestData req, FunctionContext executionContext)
    {
        try
        {
            _logger.LogInformation("Create User request received");
            
            var createUserRequest = JsonSerializer.Deserialize<CreateUserRequest>(await new StreamReader(req.Body).ReadToEndAsync())
                ?? throw new Exception("Unable to deserialize CreateUserRequest");
                
            var createUserResponse = createUserProcessor.Process(createUserRequest);
            
            return await CreateSuccessResponse(req, createUserResponse);
        }
        catch (BusinessException ex)
        {
            return await CreateErrorResponse(req, LogAndReturnError(ex, "CreateUser"), HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            return await CreateErrorResponse(req, LogAndReturnError(ex, "CreateUser"), HttpStatusCode.InternalServerError);
        }
    }
    
    
}