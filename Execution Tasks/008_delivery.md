# 008_delivery.md – Delivery Service

## API Layer

- [ ] Implement endpoints for delivery assignment and status updates
- [ ] Implement GET /deliveries/{id} for delivery status
- [ ] Implement health endpoints (/healthz, /readyz)
- [ ] Implement gRPC endpoints for internal communication

## Domain Layer

- [ ] Design Delivery entity and assignment logic
- [ ] Integrate with Order and Payment services via Kafka events
- [ ] Implement event publishing to Kafka for domain events
- [ ] Implement idempotency keys for event deduplication
- [ ] Implement saga compensation logic for distributed transactions
- [ ] Implement timeouts and retries for inter-service calls

## Persistence Layer

- [ ] Set up Delivery table schema in SQL Server
- [ ] Implement repository for delivery operations

## Orphan Cleanup

- [ ] Implement cron jobs for stale/unassigned deliveries

## Security

- [ ] Ensure secrets are managed via Kubernetes Secrets

## Testing

- [ ] Write unit tests for delivery logic
- [ ] Write integration tests for delivery assignment and status
- [ ] Write contract tests for delivery service APIs
