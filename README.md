# TecOS - Service Order Management System

Advanced Backend built with **.NET 8** designed for high scalability, observability, and clean code principles. This project is part of a refactoring process from a legacy Laravel/Spring Boot architecture to a modern C# ecosystem.

## Technologies & Architecture

* **.NET 8 Web API**: Leveraging the latest features for high-performance backend services.
* **Clean Architecture**: Focused on separation of concerns, testability (TDD), and maintainability.
* **PostgreSQL 16**: Robust relational database management.
* **Docker & Docker Compose**: Full infrastructure orchestration for local development parity.
* **Observability Stack**: Real-time monitoring with **Prometheus** and **Grafana**.

## 🛠Infrastructure & Monitoring

This project includes a complete monitoring environment to ensure system health and performance:

* **Prometheus**: Scrapes metrics from the API and Database.
* **Grafana**: Pre-configured dashboards for real-time data visualization.
* **Health Checks**: Automated checks to ensure service availability before starting the API.

## How to Run

### Prerequisites
* Docker Desktop (WSL 2 Backend recommended).
* .NET 8 SDK.

### Setup
1. Clone the repository:
   ```bash
   git clone [https://github.com/lucas-baggio/TecOS-backend-.net.git](https://github.com/lucas-baggio/TecOS-backend-.net.git)
2. **Environment Variables**:
   Create a `.env` file in the root directory (where the `.sln` file is located) and add the following variables:
   ```env
   POSTGRES_DB=tecos_db
   POSTGRES_USER=tecos_user
   POSTGRES_PASSWORD=tecos_password
   DB_PORT=5433
3. **Spin up the entire infrastructure:** Open your terminal and run:
    ```bash
   docker-compose up -d
   
## Access Points & Monitoring
Once the containers are running, you can access the following services:
* API Swagger UI: http://localhost:8080/swagger
* Prometheus: http://localhost:9090
* Grafana: http://localhost:3000 (Default login: admin / admin)

## Cloud & CI/CD Plans
The architecture is designed to be Cloud-ready, specifically targeting AWS infrastructure to meet enterprise requirements:
* Amazon RDS: Planned migration for managed PostgreSQÇ instances
* AWS App Runner / ECS: Container orchestration for the .NET API
* GitHub Action: Automated CI/CD pipeline for TDD enforcement and automated deployment

## Developed by Lucas Baggio - Software Engineer.