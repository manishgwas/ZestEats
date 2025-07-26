# 000_setup.md – Project Setup & Foundation


## Environment & Tooling

- [x] Initialize Git repository and commit PRD/Technical PRD
- Remote: https://github.com/manishgwas/ZestEats.git
- [x] Create .gitignore file with all necessary exclusions
- [x] Set up solution structure for .NET microservices (one project per service)
- [ ] Create Dockerfiles for each service
- [ ] Create docker-compose.yml for local development
- [ ] Configure .env files for secrets and environment variables
- [ ] Set up basic CI pipeline (Jenkins or GitHub Actions)
- [x] Prepare README with local setup instructions
- [ ] Configure time synchronization (NTP) across all nodes
- [ ] Set up backups for SQL Server and MongoDB (manual/cron-based)
- [ ] Configure Kafka schema registry (Avro/JSON Schema)
- [ ] Ensure secrets are managed via Kubernetes Secrets

## Shared Libraries & Contracts

- [ ] Define shared DTOs and Protobuf contracts for gRPC
- [ ] Set up shared utility library (logging, error handling)
- [ ] Plan contract tests for all service APIs
- [ ] Plan load simulation: 1000 orders/min, 10,000 concurrent users (k6)
