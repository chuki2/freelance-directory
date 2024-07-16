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
    git clone https://github.com/chuki2/freelance-directory
    cd freelancer-directory
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
es and interfaces.
-   **Infrastructure**: Handles data access and external services.
-   **API**: The presentation layer, handling HTTP requests and responses.

### CQRS with MediatR

Commands and queries are handled separately to ensure clear separation of read and write operations. MediatR is used to facilitate this pattern, ensuring a clean ## API Endpoints
The following endpoints are available in the API:-   **GET /api/user**: Retrieves a list of users with pagination and optional filters.-   **POST /api/user**: Creates a new user.-   **PUT /api/user/{id}**: Updates an existing user.-   **DELETE /api/user/{id}**: Deletes a user.-   **GET /api/user/{id}**: Retrieves a single user by ID.## Implementation Details### Clean ArchitectureThe project is structured to follow Clean Architecture principles, ensuring separation of concerns and scalability. The main layers are:-   **Application**: Contains use cases and business logic.-   **Domain**: Contains the core entitiand maintainable codebase.

### Fluent Validation

Fluent Validation is used to enforce validation rules for the API requests. This ensures that only valid data is processed by the API, improving robustness and reliability.

### In-Memory Caching

In-memory caching is implemented to optimize performance. The cache keys are generated from query parameters to ensure that unique queries are cached separately. Cached items have a sliding expiration of 5 minutes.

## Demonstrating the Application

To demonstrate the application:

1.  **Run the Application**
    
    bash
    
    Copy code
    
    `dotnet run` 
    
2.  **Access Swagger Documentation**
    
    Navigate to `http://localhost:5000/swagger/index.html` to view and interact with the API endpoints.
    
3.  **Perform CRUD Operations**
    
    Use the Swagger interface to create, update, delete, and retrieve users. The API supports the following operations:
    
    -   **Create User**: Use the `POST /api/user` endpoint to create a new user.
    -   **Update User**: Use the `PUT /api/user/{id}` endpoint to update an existing user.
    -   **Delete User**: Use the `DELETE /api/user/{id}` endpoint to delete a user.
    -   **Get Users**: Use the `GET /api/user` endpoint to retrieve users with pagination and filters.
    -   **Get User by ID**: Use the `GET /api/user/{id}` endpoint to retrieve a single user by ID.

## Project Requirements and Goals

This project was developed to meet the following requirements and goals outlined by ETIQA IT:

### Expected Skillsets:

-   **ASP.Net Core Web API**: The API is built using .NET Core 8.0.301 and follows best practices for building scalable and maintainable web APIs.
-   **Database**: The project uses Entity Framework Core for data access, supporting both LocalDB and SQL Server.
-   **RESTful API**: The API is designed with RESTful principles, ensuring a clean and intuitive interface for clients.

### API Functionality:

-   **User Management**: The API provides endpoints for creating, updating, deleting, and retrieving users, demonstrating CRUD operations with a relational database.
-   **Demonstration**: The project can be hosted on platforms like Heroku or AWS for demonstration purposes, showcasing its functionality and design.

## Contribution

Contributions are welcome! Please open an issue or submit a pull request for any bugs or feature requests.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For more information, please contact [azrizakaria901@gmail.com].

