# 009_infra.md – Infrastructure & Shared Concerns

## Logging & Monitoring

- [x] Integrate Serilog for .NET services (JSON logging)
- [x] Set up basic health endpoints (/healthz, /readyz) for all services
- [x] Prepare hooks for OpenTelemetry integration (tracing, deferred)
- [x] Implement basic alerting for health endpoint monitoring

## Messaging

- [x] Set up Kafka broker and schema registry
- [x] Configure schema registry for Kafka (Avro/JSON Schema)
- [x] Implement event publishing/subscription for order, payment, delivery events

## Resilience

- [x] Integrate Polly for circuit breaker/retry logic in .NET services
- [x] Implement timeouts and retries for inter-service calls (gRPC/Kafka)

### Recommended gRPC timeout and retry pattern (.NET)

For gRPC client calls in .NET, use CallOptions with deadlines/cancellation tokens and Polly for retries:

```csharp
using Grpc.Net.Client;
using Polly;
using System;
using System.Threading;
using System.Threading.Tasks;

var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new MyGrpc.MyGrpcClient(channel);

var retryPolicy = Policy
    .Handle<RpcException>(ex => ex.StatusCode == StatusCode.Unavailable)
    .WaitAndRetryAsync(3, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));

var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)); // 5s timeout
var response = await retryPolicy.ExecuteAsync(async () =>
    await client.MyMethodAsync(request, cancellationToken: cts.Token));
```

This ensures all gRPC calls have timeouts and retries, and can be adapted for any gRPC client in the solution.

## Containerization & Orchestration

- [x] Create Helm charts for Kubernetes deployment
- [x] Configure resource limits and autoscaling (HPA)
- [x] Configure time synchronization (NTP) across all nodes

## Secrets Management

- [x] Use Kubernetes Secrets for sensitive config

## Database & Backups

- [x] Set up backups for SQL Server and MongoDB (manual/cron-based)

## Orphan Cleanup

- [x] Implement cron jobs for stale carts, unpaid orders

## Testing

- [x] Write load tests using k6 for order and payment flows
- [x] Implement contract tests for service APIs
- [x] Simulate load: 1000 orders/min, 10,000 concurrent users (k6)
