# 000_setup.md – Project Setup & Foundation

## Environment & Tooling

- [x] Initialize Git repository and commit PRD/Technical PRD
- Remote: https://github.com/manishgwas/ZestEats.git
- [x] Create .gitignore file with all necessary exclusions
- [x] Set up solution structure for .NET microservices (one project per service)
- [x] Create Dockerfiles for each service
- [x] Create docker-compose.yml for local development
- [x] Configure .env files for secrets and environment variables
- [x] Set up basic CI pipeline (GitHub Actions)
- [x] Prepare README with local setup instructions
- [x] Configure time synchronization (NTP) across all nodes
- [x] Set up backups for SQL Server and MongoDB (manual/cron-based)
- [x] Configure Kafka schema registry (Avro/JSON Schema)
- [x] Ensure secrets are managed via Kubernetes Secrets

## Shared Libraries & Contracts

- [x] Define shared DTOs and Protobuf contracts for gRPC
- [x] Set up shared utility library (logging, error handling)
- [x] Plan contract tests for all service APIs
- [x] Plan load simulation: 1000 orders/min, 10,000 concurrent users (k6)
