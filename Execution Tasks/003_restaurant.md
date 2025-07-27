# 003_restaurant.md – Restaurant Service

## API Layer

- [x] Implement endpoints for restaurant registration and profile management
- [x] Implement GET /restaurants for listing and filtering
- [x] Implement health endpoints (/healthz, /readyz)
- [x] Implement gRPC endpoints for internal communication

## Domain Layer

- [x] Design Restaurant entity and filtering logic
- [] Implement event publishing to Kafka for domain events
- [] Implement idempotency keys for event deduplication
- [] Implement saga compensation logic for distributed transactions
- [] Implement timeouts and retries for inter-service calls

## Persistence Layer

- [] Set up Restaurant table schema in SQL Server
- [x] Implement repository for restaurant CRUD operations

## Orphan Cleanup

- [] Implement cron jobs for stale restaurants (if applicable)

## Security

- [] Ensure secrets are managed via Kubernetes Secrets

## Testing

- [] Write unit tests for restaurant profile logic
- [] Write integration tests for restaurant listing/filtering
- [] Write contract tests for restaurant service APIs
