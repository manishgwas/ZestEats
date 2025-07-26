# 006_order.md – Order Service

## API Layer

- [ ] Implement POST /orders for order placement
- [ ] Implement GET /orders/{id} for order status
- [ ] Implement health endpoints (/healthz, /readyz)
- [ ] Implement gRPC endpoints for internal communication

## Domain Layer

- [ ] Design Order entity and lifecycle logic
- [ ] Integrate with Payment and Delivery services via Kafka events
- [ ] Implement event publishing to Kafka for domain events
- [ ] Implement idempotency keys for event deduplication
- [ ] Implement saga compensation logic for distributed transactions
- [ ] Implement timeouts and retries for inter-service calls

## Persistence Layer

- [ ] Set up Order table schema in SQL Server
- [ ] Implement repository for order operations

## Orphan Cleanup

- [ ] Implement cron jobs for stale/unpaid orders

## Security

- [ ] Ensure secrets are managed via Kubernetes Secrets

## Testing

- [ ] Write unit tests for order lifecycle
- [ ] Write integration tests for order placement and status
- [ ] Write contract tests for order service APIs
