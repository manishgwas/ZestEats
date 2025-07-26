# 007_payment.md – Payment Service

## API Layer

- [ ] Implement POST /payments for payment initiation
- [ ] Implement GET /payments/{orderId} for payment status
- [ ] Implement health endpoints (/healthz, /readyz)
- [ ] Implement gRPC endpoints for internal communication

## Domain Layer

- [ ] Integrate Razorpay test mode for payment processing
- [ ] Publish payment events to Kafka (initiated, success, failed)
- [ ] Implement retry logic for failed payments
- [ ] Implement event publishing to Kafka for domain events
- [ ] Implement idempotency keys for event deduplication
- [ ] Implement saga compensation logic for distributed transactions
- [ ] Implement timeouts and retries for inter-service calls
- [ ] Implement manual reconciliation via admin panel and audit logs
- [ ] Implement payment failure and order cancellation logic

## Persistence Layer

- [ ] Set up Payment table schema in SQL Server
- [ ] Implement repository for payment operations

## Orphan Cleanup

- [ ] Implement cron jobs for stale/unpaid payments

## Security

- [ ] Ensure secrets are managed via Kubernetes Secrets
- [ ] Ensure no sensitive card data is stored (PCI scope avoidance)

## Testing

- [ ] Write unit tests for payment logic
- [ ] Write integration tests for payment flows
- [ ] Write contract tests for payment service APIs
