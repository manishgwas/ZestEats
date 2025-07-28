# 008_delivery.md – Delivery Service

## API Layer

- [x] Implement endpoints for delivery assignment and status updates
- [x] Implement GET /deliveries/{id} for delivery status
- [x] Implement health endpoints (/healthz, /readyz)
- [x] Implement gRPC endpoints for internal communication

## Domain Layer

- [x] Design Delivery entity and assignment logic
- [x] Integrate with Order and Payment services via Kafka events
- [x] Implement event publishing to Kafka for domain events
- [x] Implement idempotency keys for event deduplication
- [x] Implement saga compensation logic for distributed transactions
- [x] Implement timeouts and retries for inter-service calls

## Persistence Layer

- [x] Set up Delivery table schema in SQL Server
- [x] Implement repository for delivery operations

## Orphan Cleanup

- [x] Implement cron jobs for stale/unassigned deliveries

## Security

- [x] Ensure secrets are managed via Kubernetes Secrets

## Testing

- [x] Write unit tests for delivery logic
- [x] Write integration tests for delivery assignment and status
- [x] Write contract tests for delivery service APIs
