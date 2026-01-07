# RideOn – Integration von C#/Unity mit der Oracle-Datenbank

Dieses Dokument beschreibt, wie das Spiel **RideOn** über C# (Unity) mit der Oracle-Datenbank kommuniziert.  
Ziel ist es, Spielstände zu speichern und Highscores aus der Datenbank zu laden.

---

## 1. Voraussetzungen

- Oracle-Datenbank mit angelegtem Schema:
  - `BENUTZER`
  - `SPIELLEVEL`
  - `SPIELRUNDE`
- Die SQL-Skripte zum Schema und zu den Testdaten liegen im Repository, z. B.:
  - `docs/db/rideon_schema.sql`
  - `docs/db/rideon_testdata.sql`
- In C# wird eine Oracle-Client-Bibliothek verwendet, z. B.:
  - `Oracle.ManagedDataAccess` (NuGet-Package)

Der **Connection String** wird im C#-Code konfiguriert, z. B.:

```csharp
string connectionString =
    "User Id=DEIN_USER;Password=DEIN_PASS;Data Source=DEINE_DB;";
