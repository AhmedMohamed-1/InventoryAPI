# 🛍️ Inventory Management API

A lightweight and extensible ASP.NET 9 Web API for managing products, categories, and suppliers with full CRUD functionality, validation, and clean architecture.

---

## ✨ Features

- 📦 Complete Product Management
- 🏷️ Category Management
- 🏢 Supplier Management
- ✅ Input Validation with FluentValidation
- 🔄 AutoMapper for clean DTO mapping
- 📚 Swagger/OpenAPI for easy documentation
- 🧪 Ready for testing and extension

---

## 🚀 Getting Started

Follow these steps to run the project locally:

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/InventoryAPI.git
   ```

2. **Navigate into the project directory**

   ```bash
   cd InventoryAPI
   ```

3. **Restore dependencies**

   ```bash
   dotnet restore
   ```

4. **Update the connection string** in `appsettings.json` to point to your local SQL Server instance.
   ```
   "ConnectionStrings": {
    "InventoryAPIconnection": "YOUR_CONNECTION_STRING_HERE"
   }
   ```

6. **Run the project**

   ```bash
   dotnet run
   ```

---

## 🌐 Online Documentation

You can view the live API documentation and test the endpoints online:

* 🔗 [Swagger UI](http://inventoryapitest.runasp.net/swagger/index.html)

> ⚠️ **Note**: Use **HTTP**, not HTTPS, when accessing the live Swagger UI.

---

## 📚 API Endpoints

### Products

* `GET /api/Product` – Get all products
* `GET /api/Product/{id}` – Get a product by ID
* `POST /api/Product` – Create a new product
* `PUT /api/Product/{id}` – Update a product
* `DELETE /api/Product/{id}` – Delete a product

### Categories

* `GET /api/Category` – Get all categories
* `GET /api/Category/{id}` – Get a category by ID
* `GET /api/Category/name/{name}` – Get a category by name
* `POST /api/Category` – Create a new category
* `PUT /api/Category/{id}` – Update a category
* `DELETE /api/Category/{id}` – Delete a category


### Suppliers

* `GET /api/Supplier` – Get all suppliers
* `GET /api/Supplier/{id}` – Get a supplier by ID
* `POST /api/Supplier` – Create a new supplier
* `PUT /api/Supplier/{id}` – Update a supplier
* `DELETE /api/Supplier/{id}` – Delete a supplier

---

## 🛠️ Tech Stack

* .NET 9.0 (ASP.NET Core)
* Entity Framework Core
* SQL Server
* AutoMapper
* FluentValidation
* Swagger / Swashbuckle

---

## 🗂️ Project Structure

```
/Controllers        → API endpoints
/Models             → Entity classes
/DTOs               → Data transfer objects
/Repositories       → Database access logic
/Services           → Business logic layer
/MapperProfiles     → AutoMapper configurations
/ValidatorClasses   → FluentValidation validators
```

## 🗄️ Database Backup

A SQL Server `.bak` file is included in this repository for testing and demonstration purposes.

### 📥 Restore Instructions

1. Open SQL Server Management Studio (SSMS).
2. Right-click on `Databases` → `Restore Database`.
3. Choose **Device** and browse to select the included `.bak` file.
4. Restore the database and update the connection string in `appsettings.json` accordingly.

> ⚠️ Make sure your SQL Server instance has sufficient permissions to restore the database.

### 🧱 Database Design

The database contains well-structured tables for:
- Products
- Categories
- Suppliers
- Relational integrity is maintained via foreign keys
---

## 🔒 Security

* Input data is validated and sanitized using FluentValidation.
* Swagger UI is available for testing, but authentication can be added easily if needed.

---

## 🧾 License

This project is open-source under the [MIT License](LICENSE).

---

## 👤 Author

**Ahmed Mohamed**
.NET Backend Developer
🌐 [ahmedmohameddev.netlify.app](https://ahmedmohameddev.netlify.app)
🔗 [LinkedIn](https://www.linkedin.com/in/ahmedmohameddev/)

---

## 🤝 Contributing

Contributions are welcome! Feel free to fork the project, open issues, or submit pull requests.
