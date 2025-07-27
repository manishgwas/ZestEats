# 001_auth.md – Authentication & User Management

## API Layer

- [x] Implement User Registration endpoint (POST /users/register)
- [x] Implement User Login endpoint (POST /users/login)
- [x] Issue JWT tokens on successful login
- [x] Implement JWT validation middleware for all APIs
- [x] Implement role-based authorization (Customer, Restaurant Owner, Delivery Partner)
- [x] Implement password reset/forgot password (if in MVP)

## Domain Layer

- [x] Design User entity and roles (Customer, Restaurant Owner, Delivery Partner)
- [x] Store users in SQL Server
- [x] Implement secure password storage (hashing)

## Persistence Layer

- [x] Set up User table schema in SQL Server
- [x] Implement repository for user CRUD operations

## Security

- [x] Ensure secrets are managed via Kubernetes Secrets
- [x] Ensure no sensitive card data is stored (PCI scope avoidance)

## Testing

- [x] Write unit tests for registration and login flows
- [x] Write integration tests for JWT issuance and validation
- [x] Write contract tests for authentication APIs
