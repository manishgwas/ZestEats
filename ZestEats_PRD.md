# Product Requirements Document (PRD)

## Project Title: ZestEats – Food Delivery Platform

---

### 1. Overview

ZestEats is an open-source, cost-effective food delivery platform designed for web users. It supports public APIs, microservices architecture, asynchronous workflows, and modern deployment practices. The MVP focuses on core food delivery features, omitting advanced or deferred functionalities.

---

### 2. User Personas

- **Customers:** Browse restaurants, menus, manage cart, place orders, track order status.
- **Restaurant Owners:** Manage restaurant profile, menu, view orders.
- **Delivery Partners:** View assigned deliveries, update delivery status.

---

### 3. Core Features

- User Registration & Login (JWT, via API Gateway)
- Restaurant Listing & Filtering
- Menu Browsing
- Cart Management (Redis-backed)
- Order Placement (async payment flow)
- Payment Integration (mock/Razorpay test mode)
- Real-time Order Tracking (status changes via WebSocket)
- Automatic Delivery Partner Assignment
- API Documentation (OpenAPI/Swagger for all services)
- Automated Testing (unit, integration, contract)

---

### 4. Excluded/Deferred Features

- Scheduled Orders, Group Orders, Subscriptions
- Loyalty Program, Coupons, Wallet
- Notifications, In-app Chat, Multi-city/country, Recommendations
- Refunds/Disputes
- Centralized Logging/Tracing (can be added later)

---

### 5. Microservices Architecture

- **User Service:** User data, registration, authentication
- **Restaurant Service:** Restaurant profiles, filtering
- **Menu Service:** Menu management (MongoDB)
- **Cart Service:** Cart operations (Redis)
- **Order Service:** Order lifecycle, status
- **Payment Service:** Payment processing, status updates
- **Delivery Service:** Partner assignment, status updates
- **Authentication Service:** JWT issuance/validation
- **API Gateway:** Centralized routing, JWT validation

**Service Boundaries:**  
Each service owns its data. Communication via REST/gRPC for core workflows, Kafka for events (order, payment, delivery).

---

### 6. Data Strategy

- **PostgreSQL:** Users, Orders, Payments
- **MongoDB:** Menus
- **Redis:** Cart, Sessions

---

### 7. Infrastructure

- **Local Development:** Docker Compose
- **Orchestration:** Kubernetes (k3s/kind)
- **CI/CD:** Jenkins (self-hosted), GitHub Actions (optional)
- **Deployment:** Manual or ArgoCD (optional)
- **Open Source Only:** All components free or on free tier

---

### 8. Scalability & Reliability

- **Load Simulation:** 1000 orders/min, 10,000 concurrent users
- **Resilience:** Retry with exponential backoff, health checks (liveness/readiness)
- **Saga Pattern:** Distributed transactions with compensation logic

---

### 9. Security

- **Authentication:** JWT via API Gateway
- **Authorization:** Basic user roles (Customer, Restaurant Owner, Delivery Partner)

---

### 10. Developer Experience

- **API Documentation:** OpenAPI/Swagger for all services
- **Testing:** Unit, integration, contract tests for all services

---
