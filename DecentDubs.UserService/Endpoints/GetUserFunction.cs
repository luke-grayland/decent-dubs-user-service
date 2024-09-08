using System.Net;
using System.Text.Json;
using DecentDubs.UserService.Models;
using DecentDubs.UserService.Processors.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace DecentDubs.UserService;

public class GetUserFunction(ILoggerFactory loggerFactory, IGetUserProcessor getUserProcessor) : EndpointBase(loggerFactory)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<User>();
    
    [Function("GetUser")]
    public async Task<HttpResponseData> CreateUser([HttpTrigger(AuthorizationLevel.Function, "get", Route = "user")] 
        HttpRequestData req, FunctionContext executionContext)
    {
        try
        {
            _logger.LogInformation("Get User request received");
            var walletId = req.Query["walletId"];

            if (string.IsNullOrEmpty(walletId))
                throw new BusinessException("Wallet ID not found in query parameter");
                
            var getUserResponse = getUserProcessor.Process(walletId);
            return await CreateSuccessResponse(req, getUserResponse);
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