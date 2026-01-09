# simpleAPIGateway

A simple **API Gateway** built in **.NET 8**, with a **UserService** backend, demonstrating:

- JWT authentication and forwarding
- Rate limiting / throttling per user
- Request routing to backend services
- Middleware-based architecture

## Project Structure

UsersGateway/
│
├── Program.cs
├── Middleware/
│ └── RateLimitingMiddleware.cs
├── RateLimiting/
│ ├── RequestCounter.cs
│ └── SimpleRateLimiter.cs
├── Controllers/
│ └── UsersGatewayController.cs (optional)
└── UsersGateway.csproj

UserService/
│
├── Program.cs
├── Controllers/
│ └── UsersController.cs
├── Models/
│ └── User.cs
└── UserService.csproj

## Features

- **API Gateway**:
  - Routes requests to `UserService`
  - JWT validation
  - Per-user / per-IP **rate limiting**
  - Logging and metrics support
  - Request transformation (adds `X-User-Id` header)

- **UserService**:
  - Basic CRUD for users
  - Returns JSON responses
  - Example in-memory data store