# 007_payment.md – Payment Service

## API Layer

- [x] Implement POST /payments for payment initiation
- [x] Implement GET /payments/{orderId} for payment status
- [x] Implement health endpoints (/healthz, /readyz)
- [x] Implement gRPC endpoints for internal communication

## Domain Layer

- [x] Implement manual reconciliation via admin panel and audit logs
- [x] Implement payment failure and order cancellation logic

## Persistence Layer

[x] Implement repository for payment operations

## Orphan Cleanup

- [x] Implement cron jobs for stale/unpaid payments

## Security

- [x] Ensure secrets are managed via Kubernetes Secrets
- [x] Ensure no sensitive card data is stored (PCI scope avoidance)

## Testing

- [x] Write unit tests for payment logic
- [x] Write integration tests for payment flows
- [x] Write contract tests for payment service APIs
