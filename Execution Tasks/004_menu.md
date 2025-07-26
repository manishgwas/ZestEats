# 004_menu.md – Menu Service

## API Layer

- [ ] Implement endpoints for menu CRUD (add, update, delete, list)
- [ ] Implement GET /menus/{restaurantId}
- [ ] Implement health endpoints (/healthz, /readyz)
- [ ] Implement gRPC endpoints for internal communication

## Domain Layer

- [ ] Design Menu entity and validation logic
- [ ] Implement event publishing to Kafka for domain events
- [ ] Implement idempotency keys for event deduplication
- [ ] Implement saga compensation logic for distributed transactions
- [ ] Implement timeouts and retries for inter-service calls

## Persistence Layer

- [ ] Set up MongoDB collections for menus
- [ ] Implement repository for menu operations

## Orphan Cleanup

- [ ] Implement cron jobs for stale menus (if applicable)

## Security

- [ ] Ensure secrets are managed via Kubernetes Secrets

## Testing

- [ ] Write unit tests for menu logic
- [ ] Write integration tests for menu endpoints
- [ ] Write contract tests for menu service APIs
