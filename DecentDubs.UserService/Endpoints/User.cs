using System.Net;
using System.Text.Json;
using DecentDubs.UserService.Models;
using DecentDubs.UserService.Processors.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace DecentDubs.UserService;

public class User(ILoggerFactory loggerFactory, ICreateUserProcessor createUserProcessor) : EndpointBase(loggerFactory)
{
    // private readonly ILoggerFactory _loggerFactory;
    // private readonly ICreateUserProcessor _createUserProcessor;
    private readonly ILogger _logger = loggerFactory.CreateLogger<User>();

    // public User(ILoggerFactory loggerFactory, ICreateUserProcessor createUserProcessor) : base(loggerFactory)
    // {
    //     _loggerFactory = loggerFactory;
    //     _createUserProcessor = createUserProcessor;
    //     _logger = _loggerFactory.CreateLogger<User>();
    // }

    [Function("CreateUser")]
    public async Task<HttpResponseData> CreateUser([HttpTrigger(AuthorizationLevel.Function, "post", Route = "user")] 
        HttpRequestData req, FunctionContext executionContext)
    {
        try
        {
            _logger.LogInformation("Create User request received");

            // var walletID = req.Query["walletID"];

            var createUserRequest = JsonSerializer.Deserialize<CreateUserRequest>(await new StreamReader(req.Body).ReadToEndAsync());

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

    // private string LogAndReturnError(Exception ex, string endpoint)
    // {
    //     var errorMessage = $"Error in {endpoint}: {ex.Message} {ex?.InnerException}"; 
    //     _logger.LogError(errorMessage);
    //     return errorMessage;
    // }
    //
    // private static async Task<HttpResponseData> CreateErrorResponse(HttpRequestData req, string errorMessage, HttpStatusCode code)
    // {
    //     var response = req.CreateResponse(code);
    //     response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
    //     await response.WriteStringAsync(errorMessage);
    //     return response;
    // }
    //
    // private static async Task<HttpResponseData> CreateSuccessResponse(HttpRequestData req, object responseContent)
    // {
    //     var response = req.CreateResponse(HttpStatusCode.OK);
    //     response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
    //     await response.WriteAsJsonAsync(responseContent);
    //     return response;
    // }
}