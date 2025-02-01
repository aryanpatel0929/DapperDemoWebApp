# DapperDemo Web Application
<img width="1456" alt="Screenshot 2025-02-02 at 1 57 12 AM" src="https://github.com/user-attachments/assets/cac72691-6141-45bd-9a75-118b1668a000" />


This project is a web application built with ASP.NET Core and Dapper for data access. It demonstrates how to use Dapper to interact with a SQL database and display data in a web application.

## Project Structure

- **DapperDemo.Data**: Contains the data access layer, including repositories and models.
  - **DataAccess**: Contains the `ISqlDataAccess` and `SqlDataAccess` classes for database interactions.
  - **Models**: Contains the `PersonModel` class representing the data model.
  - **PersonRepository**: Contains the repository for managing `PersonModel` entities.

- **WebApplication1**: Contains the web application layer, including controllers, views, and static assets.
  - **Controllers**: Contains the MVC controllers.
  - **Models**: Contains the view models.
  - **Views**: Contains the Razor views for displaying data.
  - **wwwroot**: Contains static files like CSS and JavaScript.

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/DapperDemo.git
   cd DapperDemo
