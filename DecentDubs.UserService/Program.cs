using DecentDubs.UserService.Processors;
using DecentDubs.UserService.Processors.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddScoped<ICreateUserProcessor, CreateUserProcessor>();
    })
    .Build();

host.Run();
