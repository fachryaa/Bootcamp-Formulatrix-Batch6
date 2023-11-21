# Day21

## Materi
1. [Entity Framework](./EntityFramework)
1. [Migration](./Migration)

## Entity Framework
- Entity Framework adalah ORM (Object Relational Mapping) untuk aplikasi .NET
- Entity Framework menyediakan API untuk mengakses data dari database
- Entity Framework menyediakan fitur seperti:
    - Querying
    - Change Tracking
    - Caching
    - Migrations
    - Unit Testing
- Entity Framework dapat digunakan untuk mengakses berbagai jenis database seperti SQL Server, MySQL, PostgreSQL, Oracle, dan SQLite
- Terdapat 3 cara untuk menggunakan Entity Framework:
    - Database First
    - Model First
    - Code First
- Entity Framework menyediakan 3 komponen utama:
    - ObjectContext
    - EntityClient
    - Metadata
- 3 cara untuk mapping
    - Naming Convention
    - Data Annotation (Attribute)
    - Fluent API (Recommended)

## Migration
- Migration adalah proses untuk membuat database berdasarkan model yang telah dibuat
- Terdapat 2 cara untuk melakukan migration:
    - CLI (Command Line Interface)
        ```bash
        dotnet ef migrations add <nama-migration>
        dotnet ef database update
        ```
    - Package Manager Console
        ```bash
        Add-Migration <nama-migration>
        Update-Database
        ```
- dotnet ef migration adalah perintah untuk melakukan migration, sedangkan database update adalah perintah untuk mengupdate database berdasarkan migration yang telah dibuat
