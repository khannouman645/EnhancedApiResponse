EnhancedApiResponse is a lightweight and flexible .NET package to simplify the handling of API responses. It provides standardized structures for successful and error responses, along with built-in pagination support and global exception handling.

## Features

- Standardized API response structure.
- Pagination metadata for paginated endpoints.
- Middleware for global exception handling.
- Simplifies API response creation with reusable methods.

## Installation

You can install the package via NuGet:

```bash
dotnet add package EnhancedApiResponse
```
## Usage

### 1. API Response Factory

Use the `ApiResponse` class to generate consistent responses for your API endpoints.

#### Example: Successful Response

```csharp
using EnhancedApiResponse;

[HttpGet("{id}")]
public IActionResult GetUser(int id)
{
    var user = _userService.GetUserById(id);
    if (user == null)
    {
        return NotFound(ApiResponse<string>.Error("User not found."));
    }

    return Ok(ApiResponse<object>.Success(user, "User retrieved successfully."));
}
```
### Example: Error Response
```csharp
using EnhancedApiResponse;

[HttpPost]
public IActionResult CreateUser(CreateUserRequest request)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ApiResponse<string>.Error("Invalid request data."));
    }

    return Ok(ApiResponse<object>.Success(newUser, "User created successfully."));
}
```

### 2. Pagination Support

Use the `PaginationHelper` class to add metadata for paginated responses.

```csharp
using EnhancedApiResponse;

[HttpGet]
public IActionResult GetUsers(int page = 1, int pageSize = 10)
{
    var users = _userService.GetUsers(page, pageSize, out var totalRecords);
    var metadata = PaginationHelper.GenerateMetadata(page, pageSize, totalRecords);

    return Ok(ApiResponse<object>.Success(users, "Users retrieved successfully.", metadata));
}

```

### 3. Global Exception Handling
The `ExceptionMiddleware` simplifies error handling by catching unhandled exceptions and returning a standardized error response.

Register Middleware
Add the middleware in Program.cs or Startup.cs:

```csharp
using EnhancedApiResponse;

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
```

## Example Error Response
If an unhandled exception occurs, the middleware returns:
```
{
  "status": "Error",
  "message": "An unexpected error occurred.",
  "data": "Exception details here"
}
```

### API Response Structure
The `ApiResponse<T>` class provides a consistent structure for all responses:

```
{
  "status": "Success",
  "message": "Operation completed successfully.",
  "data": { /* Your data */ },
  "metadata": { /* Optional metadata */ }
}

```

### Properties

| Property  | Type   | Description                           |
|-----------|--------|---------------------------------------|
| `Status`  | string | Response status: `Success` or `Error`|
| `Message` | string | A human-readable message             |
| `Data`    | T      | The response payload                 |
| `Metadata`| object | Optional metadata (e.g., pagination) |


## Development
Prerequisites
* .NET SDK 6.0 or higher
* NuGet CLI for packaging
##Build the Project
Clone the repository and build the solution:

```bash
git clone https://github.com/khannouman645/EnhancedApiResponse.git
cd EnhancedApiResponse
dotnet build
```

### Contributing
Contributions are welcome! Here's how you can contribute:

* Fork the repository on GitHub.
* Create a feature branch: git checkout -b feature-name.
* Commit your changes: git commit -m "Add new feature".
* Push to the branch: git push origin feature-name.
* Submit a pull request.
## License

This project is licensed under the [MIT License](LICENSE).

## Acknowledgments
* Thanks to the .NET community for inspiration and support.
* Special thanks to all contributors who have helped improve this package.
