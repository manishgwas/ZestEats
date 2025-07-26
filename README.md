# ZestEats Microservices

This repository contains the source code and setup for ZestEats, a modular .NET-based microservices food delivery platform.

## Solution Structure

- `services/` – Individual microservice projects (auth, gateway, restaurant, menu, cart, order, payment, delivery)
- `shared/` – Shared libraries (DTOs, contracts, utilities)
- `docker/` – Dockerfiles and docker-compose setup
- `.env` – Environment variables
- `.gitignore` – Git exclusions
- `.github/workflows/` – CI/CD pipelines

## Local Development

1. **Clone the repository**
   ```sh
   git clone https://github.com/manishgwas/ZestEats.git
   ```
2. **Install prerequisites**
   - [.NET 8 SDK](https://dotnet.microsoft.com/download)
   - [Docker Desktop](https://www.docker.com/products/docker-desktop)
   - [Node.js](https://nodejs.org/) (for frontend)
   - [MongoDB](https://www.mongodb.com/try/download/community)
   - [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
   - [Kafka](https://kafka.apache.org/quickstart)
3. **Build and run all services**
   ```sh
   docker-compose up --build
   ```
4. **Access services**
   - API Gateway: `http://localhost:5000`
   - Frontend: `http://localhost:3000`

## Deployment

- See CI/CD pipeline in `.github/workflows/`
- Secrets managed via Kubernetes Secrets
- Time sync via NTP
- Backups configured for databases

## Contact

For issues or contributions, open a GitHub issue or pull request.
