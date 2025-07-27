# 004_menu.md – Menu Service

## API Layer

- [x] Implement endpoints for menu CRUD (add, update, delete, list)
- [x] Implement GET /menus/{restaurantId}
- [x] Implement health endpoints (/healthz, /readyz)
- [x] Implement gRPC endpoints for internal communication

## Domain Layer

- [x] Design Menu entity and validation logic
- [x] Implement event publishing to Kafka for domain events
- [x] Implement idempotency keys for event deduplication
- [x] Implement saga compensation logic for distributed transactions
- [x] Implement timeouts and retries for inter-service calls

## Persistence Layer

- [x] Set up MongoDB collections for menus
- [x] Implement repository for menu operations

## Orphan Cleanup

- [x] Implement cron jobs for stale menus (if applicable)

## Security

- [x] Ensure secrets are managed via Kubernetes Secrets

## Testing

- [x] Write unit tests for menu logic
- [x] Write integration tests for menu endpoints
- [x] Write contract tests for menu service APIs
