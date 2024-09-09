using DecentDubs.UserService.Processors;
using DecentDubs.UserService.Processors.Interfaces;
using DecentDubs.UserService.Repositories;
using DecentDubs.UserService.Repositories.Interfaces;
using DecentDubs.UserService.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddScoped<ICreateUserProcessor, CreateUserProcessor>();
        services.AddScoped<IGetUserProcessor, GetUserProcessor>();
        services.AddScoped<IUserRepository, UserRepository>();
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        services.AddDbContext<DecentDubsDbContext>(options => 
            options.UseSqlServer(connectionString));
        services.Configure<UserServiceSettings>(options =>
        {
            options.Test = Environment.GetEnvironmentVariable("UserServiceSettings:TEST");
        });
        
    })
    .Build();

host.Run();
