using DecentDubs.UserService.Processors;
using DecentDubs.UserService.Processors.Interfaces;
using DecentDubs.UserService.Repositories;
using DecentDubs.UserService.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddScoped<ICreateUserProcessor, CreateUserProcessor>();
        services.AddScoped<IGetUserProcessor, GetUserProcessor>();
        services.AddScoped<IUserRepository, UserRepository>();
    })
    .Build();

host.Run();
