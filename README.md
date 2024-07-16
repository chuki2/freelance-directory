# Freelancer Directory API

## Overview

The Freelancer Directory API is built on .NET Core 8.0.301 and uses LocalDB (SQL) for data storage. It follows the principles of Clean Architecture and implements the CQRS pattern with MediatR. The project supports both LocalDB and SQL Server and is designed with RESTful principles. Fluent Validation is used for data validation, and Swagger is included for API documentation. The project also implements in-memory caching to optimize query performance.

## Features

1. **.NET Core 8.0.301**
2. **Clean Architecture and CQRS Pattern with MediatR**
3. **Supports SQL Server (Local or SQL Server)**
4. **RESTful Design with Fluent Validation**
5. **Swagger Documentation** - Access it at `/swagger/index.html`
6. **In-Memory Caching** - Cache keys are generated from the list of query parameters
7. **Code First Approach with EF Core**
8. **Unit Test Samples** - Includes a sample for checking create user validation

## Getting Started

### Prerequisites

- [.NET Core 8.0.301 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Optional)

### Setup

1. **Clone the Repository**

    ```bash
    git clone https://github.com/your-repo/freelancer-directory-api.git
    cd freelancer-directory-api
    ```

2. **Set up the Database**

    By default, the project is configured to use LocalDB. Update the connection strings in `appsettings.json` if you want to use SQL Server.

    ```json
    "ConnectionStrings": {
        "FreelanceDb": "Server=(localdb)\\mssqllocaldb;Database=FreelanceDb;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
    ```

3. **Apply Migrations**

    ```bash
    dotnet ef database update
    ```

4. **Run the Application**

    ```bash
    dotnet run
    ```

    The application will be available at `http://localhost:5000` and the Swagger documentation at `http://localhost:5000/swagger/index.html`.

### Project Structure

The project follows Clean Architecture principles with the following structure:

- **Application**: Contains the business logic and the CQRS handlers.
- **Domain**: Contains the entities, EF Core DbContext, migrations, and interfaces.
- **Infrastructure**: Contains the external services.
- **API**: Contains the ASP.NET Core controllers and startup configuration.

### Key Technologies and Libraries

- **.NET Core 8.0.301**
- **Entity Framework Core** - Code first approach
- **MediatR** - For implementing CQRS
- **Fluent Validation** - For data validation
- **Swagger** - For API documentation
- **In-Memory Caching** - For optimizing query performance

### Caching

The project implements in-memory caching for query results. Cache keys are generated from the list of query parameters to ensure uniqueness. The cache is configured with a sliding expiration time of 5 minutes.

### Unit Tests

The project includes sample unit tests for checking user creation validation. The tests use NUnit and FluentValidation.TestHelper.
	```bash
    dotnet test
    ```

