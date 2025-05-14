# .NET 8 Clean Architecture API & Web Project

This project is a personal backend development study built with **.NET 8**, following **Clean Architecture** and **N-Layered Architecture** principles. It aims to demonstrate best practices for building scalable, maintainable, and testable enterprise-level Web API solutions using modern .NET technologies.

## 🧱 Technologies Used

- .NET 8 SDK
- ASP.NET Core Web API
- Entity Framework Core (Code-First)
- SQL Server
- AutoMapper
- FluentValidation
- Swagger / Swashbuckle
- RESTful API Design

## 🧠 Architecture Overview

The solution applies a clean separation of concerns through layered architecture:

- **Presentation Layer (WebAPI)**  
  Handles HTTP requests and responses, contains controllers and validation filters.

- **Application Layer**  
  Contains DTOs, service interfaces, business contracts, and result wrappers.

- **Domain Layer**  
  Holds core business entities and domain rules.

- **Persistence Layer**  
  Implements repository logic and database context using Entity Framework.

- **Infrastructure Layer**  
  Includes cross-cutting concerns like caching strategies.

## 🚀 Features Implemented

- **Repository → Service → Controller** flow for structured logic
- **Functional folder structure**: each domain module (e.g. Products) contains its own services, DTOs, and mappings
- **Guard Clauses and Fail Fast principle** for clean and readable service methods
- **Cyclomatic Complexity** awareness: methods designed to be minimal and focused
- **FluentValidation integration** with custom filter handling model state
- **AutoMapper** for seamless Entity ↔ DTO conversions
- **ServiceResult<T>** used to wrap business responses consistently
- **Cache-Aside Pattern** used for performance-optimized data access
- **Route Constraints** like `[HttpGet("{id:int}")]` to enhance route handling
- **Transaction management** controlled strictly from Service Layer
- **Swagger UI** included for interactive API documentation

## 🧾 HTTP Verbs Used

| Verb      | Purpose                   |
|-----------|---------------------------|
| `GET`     | Retrieve data             |
| `POST`    | Create new record         |
| `PUT`     | Full update               |
| `PATCH`   | Partial update            |
| `DELETE`  | Remove record             |

## 📁 Project Structure

```
NetCoreWEBAPICleanArchitectureNLayer
│
├── Application/
│   ├── DTOs/
│   ├── Interfaces/
│   └── Services/
│
├── Domain/
│   ├── Entities/
│   └── Common/
│
├── Infrastructure/
│   └── Cache/
│
├── Persistence/
│   ├── Repositories/
│   └── DbContext/
│
├── WebAPI/
│   ├── Controllers/
│   ├── Filters/
│   └── Program.cs
│
└── NetCoreWEBAPICleanArchitectureNLayer.sln
```

## 🧪 Setup & Run Locally

1. Clone the repository:

```bash
git clone https://github.com/tbugracelikcode/.NET8-CleanArchitecure-WEB-API.git
```

2. Navigate into the solution folder:

```bash
cd .NET8-CleanArchitecure-WEB-API/NetCoreWEBAPICleanArchitectureNLayer
```

3. Restore and run the project:

```bash
dotnet restore
dotnet build
dotnet run --project WebAPI
```

4. Open browser and test the API via Swagger at:  
`https://localhost:{port}/swagger/index.html`

## 👨‍💻 Author

Developed and maintained by **[@tbugracelikcode](https://github.com/tbugracelikcode)**  
This repository serves as a hands-on implementation of clean backend architecture patterns in .NET.

---
