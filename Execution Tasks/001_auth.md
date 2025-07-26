# 001_auth.md – Authentication & User Management

## API Layer

- [ ] Implement User Registration endpoint (POST /users/register)
- [ ] Implement User Login endpoint (POST /users/login)
- [ ] Issue JWT tokens on successful login
- [ ] Implement JWT validation middleware for all APIs
- [ ] Implement role-based authorization (Customer, Restaurant Owner, Delivery Partner)
- [ ] Implement password reset/forgot password (if in MVP)

## Domain Layer

- [ ] Design User entity and roles (Customer, Restaurant Owner, Delivery Partner)
- [ ] Store users in SQL Server
- [ ] Implement secure password storage (hashing)

## Persistence Layer

- [ ] Set up User table schema in SQL Server
- [ ] Implement repository for user CRUD operations

## Security

- [ ] Ensure secrets are managed via Kubernetes Secrets
- [ ] Ensure no sensitive card data is stored (PCI scope avoidance)

## Testing

- [ ] Write unit tests for registration and login flows
- [ ] Write integration tests for JWT issuance and validation
- [ ] Write contract tests for authentication APIs
