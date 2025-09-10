# EmployeeManagement

## Setup Instructions

### Backend (ASP.NET Core Web API)
1. Open the solution in Visual Studio.
2. Update `appsettings.json` with your SQL Server connection string.
3. Run the following in Package Manager Console to apply migrations:


##  Project Structure
- **EmployeeManagement.Api** → ASP.NET Core Web API (Startup project)
- **EmployeeManagement.Infrastructure** → Database, EF Core, Repositories, Migrations
- **EmployeeManagement.Core** → Entities & Models
- **EmployeeManagement.Services** → Business Logic
- **EmployeeManagement.React** → React frontend (if included)

---

## Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Node.js (LTS)](https://nodejs.org/)

---

## Setup Instructions

### 1. Clone the repository
```sh
git clone https://github.com/<your-username>/EmployeeManagement.git
cd EmployeeManagement
