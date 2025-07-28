
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Polly;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var retryPolicy = Policy<HttpResponseMessage>
    .Handle<HttpRequestException>()
    .OrResult(r => (int)r.StatusCode >= 500)
    .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

var circuitBreakerPolicy = Policy<HttpResponseMessage>
    .Handle<HttpRequestException>()
    .OrResult(r => (int)r.StatusCode >= 500)
    .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));

builder.Services.AddHttpClient("ResilientClient")
    .AddHttpMessageHandler(() => new PollyDelegatingHandler(retryPolicy))
    .AddHttpMessageHandler(() => new PollyDelegatingHandler(circuitBreakerPolicy));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
builder.Services.AddSingleton<OrderService.Persistence.IOrderRepository, OrderService.Persistence.OrderRepository>();
builder.Services.AddSingleton<OrderService.Persistence.IOrderEventPublisher>(sp =>
    new OrderService.Persistence.KafkaOrderEventPublisher("localhost:9092"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGrpcService<OrderService.GrpcImpl.OrderProtoService>();
app.MapGet("/healthz", () => Results.Ok("Healthy"));
app.MapGet("/readyz", () => Results.Ok("Ready"));

// Custom DelegatingHandler for Polly
public class PollyDelegatingHandler : DelegatingHandler
{
    private readonly IAsyncPolicy<HttpResponseMessage> _policy;
    public PollyDelegatingHandler(IAsyncPolicy<HttpResponseMessage> policy)
    {
        _policy = policy;
    }
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return _policy.ExecuteAsync(ct => base.SendAsync(request, ct), cancellationToken);
    }
}
// ...existing code...
