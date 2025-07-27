# 005_cart.md – Cart Service

## API Layer

- [x] Implement endpoints for cart operations (add, remove, update, view)
- [x] Implement GET /cart for current user
- [x] Implement health endpoints (/healthz, /readyz)
- [x] Implement gRPC endpoints for internal communication

## Domain Layer

- [x] Design Cart entity and item validation
- [x] Implement event publishing to Kafka for domain events
- [x] Implement idempotency keys for event deduplication
- [x] Implement saga compensation logic for distributed transactions
- [x] Implement timeouts and retries for inter-service calls

## Persistence Layer

- [x] Set up Redis for cart storage
- [x] Implement repository for cart operations

## Orphan Cleanup

- [x] Implement cron jobs for stale carts

## Security

- [x] Ensure secrets are managed via Kubernetes Secrets

## Testing

- [x] Write unit tests for cart logic
- [x] Write integration tests for cart endpoints
- [x] Write contract tests for cart service APIs
