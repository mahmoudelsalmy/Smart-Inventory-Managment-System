
<h1 align="center">
  📦 Smart Inventory Management System
  <img src="https://media.giphy.com/media/hvRJCLFzcasrR4ia7z/giphy.gif" width="30px"/>
</h1>

<p align="center">
  <b>A robust Inventory Management System built with ASP.NET Core MVC</b>
</p>

<p align="center">
  <a href="http://smart-inventory-management-system.runasp.net/">
    🌐 Live Demo
  </a>
  •
  <a href="https://github.com/mahmoudelsalmy/Smart-Inventory-Managment-System">
    📌 Repository
  </a>
</p>

---

## 📌 Overview

**Smart Inventory Management System** is a web-based application designed to help businesses manage:

- Categories & Products  
- Stock quantities  
- Orders & invoices  
- Admin & user roles  
- Reports (PDF / Excel)

It is built using **ASP.NET Core MVC**, **Entity Framework Core**, and **SQL Server**, with a clean responsive UI using **Bootstrap**.

---

## ✨ Key Features

- ✅ CRUD for Categories, Products, Orders, and Invoices  
- 📦 Real-time stock tracking  
- 👥 Authentication & Authorization (Identity)  
- 🔐 Role-based access control (Admin / User)  
- 📊 Export Reports (PDF / Excel)
- 🔔 Low-stock alerts   
- 📱 Fully responsive modern UI  

---

## 🛠️ Tech Stack

| Technology | Description |
|----------|-------------|
| C# | Backend logic |
| ASP.NET Core MVC | Web framework |
| Entity Framework Core | ORM |
| SQL Server | Database |
| Bootstrap | UI / Styling |
| Git & GitHub | Version control |

---

## 🚀 Live Demo

🔗 **Project Link:**  
http://smart-inventory-management-system.runasp.net/

---
---

## 🖼️ Screenshots

### 🔐 Login Page
<img width="1442" height="1023" alt="image" src="https://github.com/user-attachments/assets/7863e59f-8e8e-4d8c-877e-70228bbebeeb" />


### 📊 Dashboard
<img width="1264" height="698" alt="image" src="https://github.com/user-attachments/assets/884c4481-536f-4458-8188-6d116bbec2b0" />


### 📦 Products Page
<img width="2526" height="1375" alt="image" src="https://github.com/user-attachments/assets/298917ba-c7b3-4b40-a28a-fdd8b3dc566e" />

## ⚡ Getting Started (Local Setup)

### 1️⃣ Clone the repository

```bash
git clone https://github.com/mahmoudelsalmy/Smart-Inventory-Managment-System.git
2️⃣ Open the project folder
cd Smart-Inventory-Managment-System
3️⃣ Restore dependencies
dotnet restore
4️⃣ Configure the database
Update your connection string inside:

📄 appsettings.json

Example:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
}
5️⃣ Apply migrations (if needed)
dotnet ef database update
6️⃣ Run the project
dotnet run
🧪 Default Roles
Admin

User

Admin users can manage products, categories, and generate reports.

📂 Project Structure
Inventory Managment System Project/
│── Controllers/
│── Models/
│── Views/
│── Migrations/
│── wwwroot/
│── Program.cs
│── appsettings.json
