# Product Inventory API

A RESTful ASP.NET Core Web API for managing Products and Items with JWT Authentication, API Versioning, Repository Pattern, FluentValidation, Refresh Tokens, and SQL Server.

---

## Features

- ASP.NET Core (.NET 10)
- Entity Framework Core
- SQL Server
- Repository Pattern
- Service Layer
- JWT Authentication
- Refresh Token Strategy
- API Versioning
- Swagger with JWT Authorization
- FluentValidation
- Global Exception Handling Middleware
- Serilog Structured Logging
- xUnit + Moq Unit Testing
- Docker Support

---

## Technologies

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT
- Swagger
- FluentValidation
- AutoMapper
- Serilog
- xUnit
- Moq
- Docker

---

## Project Structure

```
ProductInventoryAPI
│
├── Authentication
├── Controllers
├── Data
├── DTOs
├── Middleware
├── Models
├── Repository
├── Services
├── Validators
├── Logs
└── Program.cs
```

---

## Authentication

### Login

```
POST /api/Auth/login
```

Returns:

- Access Token
- Refresh Token

Use the Access Token in Swagger Authorization.

```
Bearer your_access_token
```

---

## Product Endpoints

| Method | Endpoint |
|---------|----------|
| GET | /api/v1.0/Product |
| GET | /api/v1.0/Product/{id} |
| POST | /api/v1.0/Product |
| PUT | /api/v1.0/Product/{id} |
| DELETE | /api/v1.0/Product/{id} |

---

## Database

SQL Server

Run EF Core Migration

```bash
dotnet ef database update
```

---

## Run Project

```bash
dotnet restore

dotnet build

dotnet run
```

Swagger

```
https://localhost:7297/swagger
```

---

## Docker

Build

```bash
docker-compose build
```

Run

```bash
docker-compose up
```

---

## Logging

Logs are stored inside

```
Logs/
```

using Serilog.

---

## Testing

Run Unit Tests

```bash
dotnet test
```

---

## Author

Hrushikesh
