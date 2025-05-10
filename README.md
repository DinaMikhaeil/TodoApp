# ✅ Todo App (.NET Core Web API + HTML/JS Frontend)

This is a simple Todo application built using **ASP.NET Core Web API** for the backend and plain **HTML + JavaScript** for the frontend.  
It supports full CRUD operations and filters by status.

---

## 📁 Project Structure

- `TodoApp/` — ASP.NET Core Web API backend
- `index.html` — Frontend UI (uses Fetch API + Bootstrap)

---

## 🧰 Requirements

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server (Express or LocalDB)
- Git

---

## 🚀 Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/todo-app-dotnet.git
cd todo-app-dotnet
```

### 2. Configure Database Connection

In `appsettings.json`, set your connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=TodoDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

> ⚠️ Adjust the `Server` and credentials as needed.

---

### 3. Run Migrations and Update the DB

```bash
dotnet ef database update
```

If you haven’t added EF tools yet:

```bash
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

---

### 4. Run the API

```bash
dotnet run
```

API will be served at:

```
https://localhost:PORT/api/todo
```

Replace `PORT` with your actual launch port.

---

### 5. Open Frontend

Just open `index.html` in your browser (double-click or drag).  
Make sure CORS is enabled in `Program.cs`.

---

## 🧪 Example JSON for POST

```json
{
  "title": "Buy groceries",
  "description": "Milk, Eggs, Bread",
  "status": 0,
  "priority": 2,
  "dueDate": "2025-05-15T00:00:00"
}
```

---

## ✨ Features

- Create, update, delete todos
- Filter by status
- Set priority and due date
- Clean UI with Bootstrap

---

## 🧠 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- HTML/CSS/JavaScript
- Bootstrap 5

---

## 📝 License

This project is for learning purposes. You’re free to use and modify it.

---

## 📬 Contact

Built with ❤️ by Dena (دينا)
