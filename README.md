# Library Management System

A simple **Library Management System** built with **ASP.NET Core MVC**. This project follows a faculty-style **3-tier architecture** using separate **App**, **BLL**, and **DAL** layers. It uses **Entity Framework Core Database First**, **SQL Server**, **DTOs**, **AutoMapper**, **Repository**, and **Service** pattern.

## Features

- Librarian login and logout using session
- Book create, read, update, delete, details, and search
- Student create, read, update, delete, details, and search
- Borrow book functionality
- Return book functionality
- Automatic available copy update
- Fine calculation for late returns
- Overdue book list
- Report dashboard

## Technologies Used

- ASP.NET Core MVC
- C#
- SQL Server
- Entity Framework Core
- AutoMapper
- Bootstrap
- 3-Tier Architecture

## Project Architecture

```text
App → BLL → DAL
Controller → Service → Repository → DbContext → Database
