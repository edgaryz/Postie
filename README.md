To configure DB we need these shell commands:
  dotnet tool install --global dotnet-ef
  dotnet ef migrations add InitialCreate
  dotnet ef database update (Migracijos vykdymas duomenų bazėje)

(Migration Creation - In this case, InitialCreate is the name of the migration)
