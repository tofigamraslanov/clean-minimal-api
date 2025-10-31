# Clean Minimal API - Products Service

A clean architecture implementation of a minimal API for managing products, built with .NET 6 and FastEndpoints. This project demonstrates modern API development practices with clean architecture principles, comprehensive validation, and automated documentation.

## 🚀 Features

- **CRUD Operations** - Complete product management (Create, Read, Update, Delete)
- **Clean Architecture** - Separation of concerns with organized layers
- **FastEndpoints** - Fast, lightweight alternative to MVC controllers
- **Data Validation** - FluentValidation for request validation
- **Auto-mapping** - AutoMapper for object-to-object mapping
- **API Documentation** - Swagger/OpenAPI documentation
- **Error Handling** - Global exception handling and logging
- **Entity Framework** - Code-first approach with migrations

## 🏗️ Architecture

The project follows clean architecture principles with the following structure:

```
├── Contracts/          # API contracts and DTOs
│   ├── Dtos/          # Data Transfer Objects
│   ├── Requests/      # Request models
│   └── Responses/     # Response models
├── Database/          # Data access layer
│   ├── Contexts/      # EF Core DbContext
│   └── Migrations/    # Database migrations
├── Endpoints/         # FastEndpoints definitions
├── Entities/          # Domain entities
├── Repositories/      # Data access repositories
├── Services/          # Business logic services
├── Validators/        # FluentValidation validators
├── Profiles/          # AutoMapper profiles
└── Logger/           # Custom logging components
```

## 🛠️ Tech Stack

- **Framework**: .NET 6.0
- **API Framework**: ASP.NET Core with FastEndpoints 5.1.0
- **Database**: SQL Server with Entity Framework Core 6.0.8
- **Validation**: FluentValidation
- **Mapping**: AutoMapper 11.0.1
- **Documentation**: Swagger/OpenAPI with Swashbuckle
- **Logging**: Built-in ASP.NET Core logging

## 📋 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/products` | Get all products |
| GET | `/products/{id}` | Get product by ID |
| POST | `/products` | Create new product |
| PUT | `/products/{id}` | Update existing product |
| DELETE | `/products/{id}` | Delete product |

## 📊 Product Model

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "name": "Product Name",
  "description": "Product Description",
  "price": 99.99,
  "rate": 4.5
}
```

## 🚀 Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- SQL Server (LocalDB, Express, or full version)
- Visual Studio 2022 or Visual Studio Code

### Installation & Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/tofigamraslanov/clean-minimal-api.git
   cd clean-minimal-api
   ```

2. **Configure Database Connection**
   
   Update the connection string in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.\\SQLEXPRESS;Database=ProductsDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Run Database Migrations**
   ```bash
   cd Products.Api
   dotnet ef database update
   ```

4. **Run the Application**
   ```bash
   dotnet run
   ```

5. **Access the API**
   - API: `https://localhost:7039` or `http://localhost:5039`
   - Swagger UI: `https://localhost:7039/swagger`

## 🧪 Example Usage

### Create a Product
```bash
curl -X POST "https://localhost:7039/products" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Laptop",
    "description": "High-performance laptop",
    "price": 1299.99,
    "rate": 4.5
  }'
```

### Get All Products
```bash
curl -X GET "https://localhost:7039/products"
```

### Get Product by ID
```bash
curl -X GET "https://localhost:7039/products/{product-id}"
```

## 🔧 Development

### Adding New Features

1. **Add Entity** - Define your domain model in `Entities/`
2. **Create Contracts** - Add request/response models in `Contracts/`
3. **Add Repository** - Implement data access in `Repositories/`
4. **Create Service** - Add business logic in `Services/`
5. **Define Endpoint** - Create FastEndpoint in `Endpoints/`
6. **Add Validation** - Create validators in `Validators/`
7. **Configure Mapping** - Update AutoMapper profiles

### Database Migrations

Create new migration:
```bash
dotnet ef migrations add MigrationName
```

Update database:
```bash
dotnet ef database update
```

## 📝 Key Features Explained

### FastEndpoints
This project uses FastEndpoints instead of traditional MVC controllers for better performance and cleaner code organization. Each endpoint is a separate class with clear responsibilities.

### Clean Architecture
- **Separation of Concerns**: Each layer has a specific responsibility
- **Dependency Inversion**: Dependencies point inward toward the domain
- **Testability**: Clean boundaries make unit testing easier

### Validation
FluentValidation provides powerful, composable validation rules that are easy to test and maintain.

### Error Handling
Global exception handling ensures consistent error responses across all endpoints.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Tofig Amraslanov**
- GitHub: [@tofigamraslanov](https://github.com/tofigamraslanov)
