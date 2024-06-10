


- dotnet tool install --global dotnet-ef

nuget:
- Microsoft.EntityFrameworkCore.Design (8.0.6 u mnie)
- Microsoft.EntityFrameworkCore.SqlServer (8.0.6)

commands:
- dotnet ef migrations add Init
- dotnet ef database update

1. utwórz modele - folder Models
2. utwórz ApplicationContext - folder Data

### struktura:
- #### EF:
  - Models - klasy modeli bazodanowych
  - Data - ApplicationContext\ - konfiguracja bazy danych, dodawanie danych do bazy
- #### Logika:
  - Services - zapytania do bazy danych, interface metod + implementacja
  - Controllers - wywołania metod z serwisu