# EPA Water Permit Manager

A .NET Core application for managing water permits and EPA submissions.

## Technology Stack

- ASP.NET Core 9.0
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI
- FluentValidation
- GitHub Actions for CI/CD

## Project Structure

The solution follows Clean Architecture principles:

- **WaterPermitManager.API**: REST API endpoints and controllers
- **WaterPermitManager.Core**: Domain models and business logic
- **WaterPermitManager.Infrastructure**: Data access and external services
- **WaterPermitManager.Application**: Application services and DTOs
- **WaterPermitManager.UnitTests**: Unit tests
- **WaterPermitManager.IntegrationTests**: Integration tests

## Getting Started

### Prerequisites

- .NET 9.0 SDK
- SQL Server (LocalDB or higher)

### Setup

1. Clone the repository
```bash
git clone https://github.com/Vexatious-777/EPA-Water-Permit.git
```

2. Navigate to the project directory
```bash
cd EPA-Water-Permit
```

3. Restore dependencies
```bash
dotnet restore
```

4. Update database
```bash
cd src/WaterPermitManager.API
dotnet ef database update
```

5. Run the application
```bash
dotnet run
```

The API will be available at:
- HTTPS: https://localhost:7127/swagger
- HTTP: http://localhost:5127/swagger

## API Endpoints

- POST /api/Auth/register - Register page for users
- POST /api/Auth/login - login page for users
- GET /api/WaterPermits - List all permits
- POST /api/WaterPermits - submit a permit to database
- GET /api/WaterPermits/search - search page
- GET /api/WaterPermits/{id} - Get specific permit
- PUT /api/WaterPermits/{id} - to update a permit
- DELETE /api/WaterPermits/{id} - to delete a permit

## Database Schema

The application uses SQL Server with the following main entities:

- LoginRequest
- RegisterRequest
- WaterPermitDto

## Contributing

1. Create a feature branch
2. Commit your changes
3. Push to the branch
4. Create a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.
