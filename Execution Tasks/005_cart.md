# 005_cart.md – Cart Service

## API Layer

- [ ] Implement endpoints for cart operations (add, remove, update, view)
- [ ] Implement GET /cart for current user
- [ ] Implement health endpoints (/healthz, /readyz)
- [ ] Implement gRPC endpoints for internal communication

## Domain Layer

- [ ] Design Cart entity and item validation
- [ ] Implement event publishing to Kafka for domain events
- [ ] Implement idempotency keys for event deduplication
- [ ] Implement saga compensation logic for distributed transactions
- [ ] Implement timeouts and retries for inter-service calls

## Persistence Layer

- [ ] Set up Redis for cart storage
- [ ] Implement repository for cart operations

## Orphan Cleanup

- [ ] Implement cron jobs for stale carts

## Security

- [ ] Ensure secrets are managed via Kubernetes Secrets

## Testing

- [ ] Write unit tests for cart logic
- [ ] Write integration tests for cart endpoints
- [ ] Write contract tests for cart service APIs
