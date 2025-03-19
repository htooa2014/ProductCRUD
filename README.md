- Install the required NuGet packages:
Install-Package Dapper

Install-Package Microsoft.Data.SqlClient

Install-Package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation

Install-Package Microsoft.EntityFrameworkCore.SqlServer

- Create new database "ProductDB"
- Need to create Product Table

CREATE TABLE Products ( 
Id INT PRIMARY KEY IDENTITY(1,1),
Name NVARCHAR(100) NOT NULL,
Description NVARCHAR(255),
Price DECIMAL(18,2) NOT NULL, 
Created DATETIME DEFAULT GETDATE(),
IsDeleted BIT)

- And need to add sample product data

INSERT [dbo].[Products] ( [Name], [Description], [Price], [Created],[IsDeleted]) VALUES ( N'iPhone11', N'the smartphone', CAST(10000000.00 AS Decimal(18, 2)), CAST(N'2025-03-19T02:48:39.177' AS DateTime),0)

INSERT [dbo].[Products] ( [Name], [Description], [Price], [Created],[IsDeleted]) VALUES ( N'Vivo', N'the smart mobile phone', CAST(6565600.00 AS Decimal(18, 2)), CAST(N'2025-03-19T02:49:32.363' AS DateTime),0)

INSERT [dbo].[Products] ( [Name], [Description], [Price], [Created],[IsDeleted]) VALUES ( N'Oppo', N'the camera phone', CAST(2000000.00 AS Decimal(18, 2)), CAST(N'2025-03-19T02:52:35.217' AS DateTime),0)

INSERT [dbo].[Products] ( [Name], [Description], [Price], [Created],[IsDeleted]) VALUES ( N'Samsung J7', N'its the fastest mobile.', CAST(4500000.00 AS Decimal(18, 2)), CAST(N'2025-03-19T02:53:17.553' AS DateTime),0)

INSERT [dbo].[Products] ( [Name], [Description], [Price], [Created],[IsDeleted]) VALUES ( N'Iphone 12', N'the lastest smartphone', CAST(200000.00 AS Decimal(18, 2)), CAST(N'2025-03-19T02:53:56.013' AS DateTime),0)


- Change Database server Name in DefaultConnection of appsettings.json file.





