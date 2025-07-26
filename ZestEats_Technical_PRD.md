# ZestEats – Technical Product Requirements Document (Technical PRD)

## 1. Technology Stack

- **Backend Microservices:** .NET (C#), ASP.NET Core, gRPC, REST, Kafka, Redis, SQL Server, MongoDB
- **Frontend:** React (Javascript), WebSocket for real-time updates
- **API Gateway:** .NET-based (Ocelot or YARP), JWT validation, plugin middleware support
- **Containerization & Orchestration:** Docker, Kubernetes (k3s/kind), Helm
- **CI/CD:** Jenkins (self-hosted), GitHub Actions (optional)
- **Messaging/Event Streaming:** Kafka (with open-source schema registry)
- **Testing:** xUnit/NUnit (backend), Jest/React Testing Library (frontend)
- **Documentation:** Swagger/OpenAPI (REST), Protobuf (gRPC)

---

## 2. Microservices Architecture

### Service List & Responsibilities

- **User Service:** Registration, authentication, user profile (SQL Server)
- **Restaurant Service:** Restaurant profiles, filtering (SQL Server)
- **Menu Service:** Menu management (MongoDB)
- **Cart Service:** Cart operations (Redis)
- **Order Service:** Order lifecycle, status (SQL Server)
- **Payment Service:** Payment processing, status updates (Razorpay test mode, SQL Server)
- **Delivery Service:** Partner assignment, status updates (SQL Server)
- **Authentication Service:** JWT issuance/validation (SQL Server)
- **API Gateway:** Centralized routing, JWT validation, plugin middleware

### Service Boundaries

- Each service owns its data store; no direct DB access across services.
- All inter-service communication via REST/gRPC APIs or Kafka events.
- API Gateway/BFF handles cross-service API composition for frontend.

---

## 3. Data Strategy

- **SQL Server:** Users, Orders, Payments, Delivery
- **MongoDB:** Menus
- **Redis:** Cart, Sessions
- **Backups:** Manual/cron-based pg_dump/mongodump; disaster recovery deferred

---

## 4. Inter-Service Communication

- **REST:** External/client-facing APIs (OpenAPI/Swagger)
- **gRPC:** Internal service-to-service APIs (Protobuf)
- **Kafka:** Asynchronous event workflows (OrderPlaced, PaymentSuccess, DeliveryStarted, etc.)
- **Schema Registry:** Centralized, open-source compatible (Avro/JSON Schema)
- **Versioning:** URI versioning for REST, Protobuf evolution for gRPC, schema evolution for events

---

## 5. Event Design & Saga Pattern

- **Events:** Domain events published to Kafka; partitioned by entity ID; idempotency keys for deduplication
- **Saga:** Choreography-based; compensation logic for distributed transactions (order, payment, delivery)
- **State Tracking:** Local DB table or event store per saga; timeouts and retries per step

---

## 6. Payment Workflows

- **Integration:** Razorpay test mode; no PCI scope for MVP
- **Status Tracking:** Payment events (initiated, success, failed) via Kafka
- **Failure Handling:** Retry with exponential backoff; failed payments cancel order
- **Reconciliation:** Manual via admin panel and audit logs

---

## 7. Deployment & Infrastructure

- **Containerization:** Docker for all services
- **Orchestration:** Kubernetes (k3s/kind); Helm for deployments
- **Secrets Management:** Kubernetes Secrets; manual rotation or sealed secrets
- **Local Development:** Docker Compose with `.env` and override files
- **Service Discovery:** K8s DNS; headless services for gRPC

---

## 8. Scaling & Resilience

- **Autoscaling:** K8s HPA (CPU/memory); Kafka consumers scale by partition
- **Health Checks:** `/healthz` and `/readyz` endpoints for all services
- **Circuit Breakers:** Resilience4J/Polly for .NET services
- **Resource Limits:** Defined in k8s manifests
- **Load Testing:** k6 for order and payment flows

---

## 9. Observability & Monitoring

- **Logging:** JSON format; basic logging via Serilog/Winston
- **Tracing:** Deferred; OpenTelemetry ready for future
- **Alerting:** Basic health endpoint monitoring; full stack deferred

---

## 10. Edge Cases & Failure Handling

- **Partial Failures:** Saga compensation; user-facing error messages for critical paths
- **Timeouts:** gRPC (5s default); Kafka retries and DLQ
- **Deduplication:** Idempotency keys; event storage
- **Orphan Cleanup:** Cron jobs for stale carts, unpaid orders
- **Time Sync:** NTP across all nodes

---

## 11. Extensibility & Future-Proofing

- **API Gateway:** Plugin-based middleware for rate-limiting, auth, logging
- **Feature Toggles:** Config-driven (Redis/env vars)
- **Schema Evolution:** Backward-compatible Protobuf; soft delete fields
- **Deprecation:** Versioned APIs/events; deprecated versions flagged before removal
- **Future Features:** Scalable infra for multi-city, offers, notifications, additional payment providers

---

## 12. Developer Experience

- **API Documentation:** OpenAPI/Swagger for REST, Protobuf for gRPC
- **Testing:** Unit, integration, contract tests for all services
- **Frontend:** React SPA, API calls via API Gateway, real-time updates via WebSocket

---

## 13. Security

- **Authentication:** JWT via API Gateway
- **Authorization:** Role-based (Customer, Restaurant Owner, Delivery Partner)
- **Secrets:** Managed via Kubernetes; no sensitive card data stored

---

## 14. Excluded/Deferred Features

- Scheduled/group orders, subscriptions, loyalty/coupons, notifications, chat, multi-city/country, recommendations, refunds/disputes, centralized logging/tracing, disaster recovery, full observability stack

---

This Technical PRD provides a clear blueprint for the MVP implementation of ZestEats. If you need further breakdowns (e.g., service-level specs, API contracts, deployment manifests), let me know!
