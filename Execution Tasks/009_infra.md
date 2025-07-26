# 009_infra.md – Infrastructure & Shared Concerns

## Logging & Monitoring

- [ ] Integrate Serilog for .NET services (JSON logging)
- [ ] Set up basic health endpoints (/healthz, /readyz) for all services
- [ ] Prepare hooks for OpenTelemetry integration (tracing, deferred)
- [ ] Implement basic alerting for health endpoint monitoring

## Messaging

- [ ] Set up Kafka broker and schema registry
- [ ] Configure schema registry for Kafka (Avro/JSON Schema)
- [ ] Implement event publishing/subscription for order, payment, delivery events

## Resilience

- [ ] Integrate Polly for circuit breaker/retry logic in .NET services
- [ ] Implement timeouts and retries for inter-service calls (gRPC/Kafka)

## Containerization & Orchestration

- [ ] Create Helm charts for Kubernetes deployment
- [ ] Configure resource limits and autoscaling (HPA)
- [ ] Configure time synchronization (NTP) across all nodes

## Secrets Management

- [ ] Use Kubernetes Secrets for sensitive config

## Database & Backups

- [ ] Set up backups for SQL Server and MongoDB (manual/cron-based)

## Orphan Cleanup

- [ ] Implement cron jobs for stale carts, unpaid orders

## Testing

- [ ] Write load tests using k6 for order and payment flows
- [ ] Implement contract tests for service APIs
- [ ] Simulate load: 1000 orders/min, 10,000 concurrent users (k6)
