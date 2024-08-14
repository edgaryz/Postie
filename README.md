To configure DB we need these shell commands:
  dotnet tool install --global dotnet-ef
  dotnet ef migrations add InitialCreate (Migration Creation - In this case, InitialCreate is the name of the migration)
  dotnet ef database update (Executing the migration on the database)
