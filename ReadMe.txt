To generate EntityFramework model from Database first approach, please run below query

Scaffold-DbContext "Server=tcp:customersample.database.windows.net,1433;Initial Catalog=CustomerDB;Persist Security Info=False;
User ID=adminSQL;Password=Google@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" 
Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -force