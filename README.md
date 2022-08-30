# Clean Architecture API - .NET 7

Enterprise API built with .NET 7 (C# 11), Clean Architecture, CQRS, and MediatR.

## Features

- ✅ Clean Architecture (Domain, Application, Infrastructure, Presentation)
- ✅ CQRS with MediatR
- ✅ Domain-Driven Design (DDD)
- ✅ Entity Framework Core 7
- ✅ FluentValidation
- ✅ AutoMapper
- ✅ JWT Authentication
- ✅ Serilog Logging
- ✅ Swagger/OpenAPI
- ✅ xUnit + Moq Testing

## Technologies

- **.NET 7 / C# 11**
- **ASP.NET Core Web API**
- **Entity Framework Core 7**
- **MediatR** (CQRS)
- **FluentValidation**
- **PostgreSQL**
- **Docker**

## C# 11 Features Used

### Raw String Literals
```csharp
string json = """
    {
        "name": "Product",
        "price": 99.99
    }
    """;
```

### List Patterns
```csharp
if (items is [var first, .., var last])
{
    Console.WriteLine($"First: {first}, Last: {last}");
}
```

### Required Members
```csharp
public class Product
{
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}
```

### File-scoped Types
```csharp
file class InternalHelper
{
    // Only accessible within this file
}
```

## Project Structure

```
CleanArchitecture/
├── src/
│   ├── Domain/
│   │   ├── Entities/
│   │   ├── ValueObjects/
│   │   ├── Events/
│   │   └── Exceptions/
│   ├── Application/
│   │   ├── Commands/
│   │   ├── Queries/
│   │   ├── DTOs/
│   │   ├── Interfaces/
│   │   └── Behaviors/
│   ├── Infrastructure/
│   │   ├── Persistence/
│   │   ├── Identity/
│   │   └── Services/
│   └── API/
│       ├── Controllers/
│       ├── Filters/
│       └── Middleware/
└── tests/
    ├── Domain.Tests/
    ├── Application.Tests/
    └── API.Tests/
```

## Installation

```bash
# Restore packages
dotnet restore

# Run migrations
dotnet ef database update --project src/Infrastructure

# Run application
dotnet run --project src/API
```

## CQRS Examples

### Command
```csharp
public record CreateProductCommand(
    string Name,
    decimal Price,
    int CategoryId
) : IRequest<ProductDto>;

public class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, ProductDto>
{
    // Implementation
}
```

### Query
```csharp
public record GetProductQuery(int Id) : IRequest<ProductDto>;

public class GetProductQueryHandler
    : IRequestHandler<GetProductQuery, ProductDto>
{
    // Implementation
}
```

## API Endpoints

```
POST   /api/products
GET    /api/products
GET    /api/products/{id}
PUT    /api/products/{id}
DELETE /api/products/{id}
```

## Testing

```bash
dotnet test
```

## Docker

```bash
docker-compose up --build
```

## Author

David Badell - 2022

## License

MIT
