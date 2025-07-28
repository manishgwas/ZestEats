# 006_order.md – Order Service

## API Layer

- [x] Implement POST /orders for order placement
- [x] Implement GET /orders/{id} for order status
- [x] Implement health endpoints (/healthz, /readyz)
- [x] Implement gRPC endpoints for internal communication

## Domain Layer

- [x] Design Order entity and lifecycle logic
- [x] Integrate with Payment and Delivery services via Kafka events
- [x] Implement event publishing to Kafka for domain events
- [x] Implement idempotency keys for event deduplication
- [x] Implement saga compensation logic for distributed transactions
- [x] Implement timeouts and retries for inter-service calls

## Persistence Layer

- [x] Set up Order table schema in SQL Server
- [x] Implement repository for order operations

## Orphan Cleanup

- [x] Implement cron jobs for stale/unpaid orders

## Security

- [x] Ensure secrets are managed via Kubernetes Secrets

## Testing

- [x] Write unit tests for order lifecycle
- [x] Write integration tests for order placement and status
- [x] Write contract tests for order service APIs
