using System.Net;
using DecentDubs.UserService.Models;
using DecentDubs.UserService.Processors.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace DecentDubs.UserService.Endpoints;

public class GetUserFunction(ILoggerFactory loggerFactory, IGetUserProcessor getUserProcessor) : EndpointBase(loggerFactory)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<GetUserFunction>();

    [Function("GetUser")]
    public async Task<HttpResponseData> GetUser([HttpTrigger(AuthorizationLevel.Function, "get", Route = "user/{walletId}")] 
        HttpRequestData req, FunctionContext executionContext, string walletId)
    {
        try
        {
            _logger.LogInformation("Get User request received");

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