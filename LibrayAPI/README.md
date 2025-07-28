## 📚 Library Checkout API (.NET 8 + Dapper)

A simple ASP.NET Core Web API that allows members to check out books and view their checked-out books. This project demonstrates:

- Repository Pattern
- CRUD operations for members
- Dapper for SQL data access
- SQL Server database with sample seed data

### 📁 Project Structure

```
LibraryAPI/
├── Controllers/
├── Models/
├── Repositories/
├── SQLScripts/
├── appsettings.json
└── Program.cs
```

### 🔧 Prerequisites

- .NET 8 SDK
- SQL Server (LocalDB or Full Instance)
- Visual Studio or VS Code

### 🛠️ Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-repo/library-api.git
   cd library-api
   ```

2. **Create the database and tables**

   Execute the SQL script at `SQLScripts/init.sql` using SSMS or `sqlcmd`:
 

3. **Configure your connection string**

   In `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

4. **Run the application**

   ```bash
   dotnet run
   ```

5. **Visit Swagger UI (if enabled)**
   ```
   https://localhost:<port>/swagger
   ```

### 🧪 API Endpoints

| Method | Endpoint                 | Description                       |
|--------|--------------------------|-----------------------------------|
| GET    | `/api/member`           | Get all members                   |
| GET    | `/api/member/{id}`      | Get a member by ID                |
| POST   | `/api/member`           | Create a new member               |
| PUT    | `/api/member/{id}`      | Update a member                   |
| DELETE | `/api/member/{id}`      | Delete a member                   |
| GET    | `/api/member/{id}/books`| Get books checked out by member   |

### ✅ Sample Data

See [`SQLScripts/init.sql`](SQLScripts/init.sql) for seed data:
- 2 members
- 2 books
- Each member has checked out one book

### 🙌 Contributing

Feel free to open issues or submit PRs for improvements!