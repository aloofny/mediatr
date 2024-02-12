using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

// Define a request class
public class Ping : IRequest<string> { }

// Define a handler for the request
public class PingHandler : IRequestHandler<Ping, string>
{
    public Task<string> Handle(Ping request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Pong");
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        // Setup MediatR
        var mediator = BuildMediator();

        // Send a request and get the response
        var response = await mediator.Send(new Ping());
        
        // Output the response
        Console.WriteLine(response);
    }

    static IMediator BuildMediator()
    {
        // Create MediatR service collection
        var services = new ServiceCollection();
        
        // Add MediatR
        services.AddMediatR(Assembly.GetExecutingAssembly());

        // Build service provider
        var serviceProvider = services.BuildServiceProvider();

        // Resolve mediator
        return serviceProvider.GetRequiredService<IMediator>();
    }
}
