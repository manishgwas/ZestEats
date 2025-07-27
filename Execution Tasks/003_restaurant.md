# 003_restaurant.md – Restaurant Service

## API Layer

- [x] Implement endpoints for restaurant registration and profile management
- [x] Implement GET /restaurants for listing and filtering
- [x] Implement health endpoints (/healthz, /readyz)
- [x] Implement gRPC endpoints for internal communication

## Domain Layer

- [x] Design Restaurant entity and filtering logic
- [x] Implement event publishing to Kafka for domain events
- [x] Implement idempotency keys for event deduplication
- [x] Implement saga compensation logic for distributed transactions
- [x] Implement timeouts and retries for inter-service calls

## Persistence Layer

- [x] Set up Restaurant table schema in SQL Server
- [x] Implement repository for restaurant CRUD operations

## Orphan Cleanup

- [x] Implement cron jobs for stale restaurants (if applicable)

## Security

- [x] Ensure secrets are managed via Kubernetes Secrets

## Testing

- [x] Write unit tests for restaurant profile logic
- [x] Write integration tests for restaurant listing/filtering
- [x] Write contract tests for restaurant service APIs
