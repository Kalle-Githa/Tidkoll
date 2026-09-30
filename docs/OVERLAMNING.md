# Överlämningsnot – Tidkoll

**Team:** Cazper, Emelie, Juan · **Datum:** 29/9 2026

## Var koden finns

**Repo:** https://github.com/Kalle-Githa/Tidkoll
**Gren som gäller:** `main` – alltid deploybar. Nytt arbete görs på `feature/<namn>` → PR till `dev` → PR till `main`. Se `docs/BRANCHING.md`.
**CI:** GitHub Actions "Bygg och testa" körs på varje push och PR. Grön på `main` (PR #15).

## Hur man kör den

```
dotnet restore
dotnet build
dotnet test
dotnet run --project src/IU2.Web
```

Öppna http://localhost:5080

**Förutsättningar:** .NET SDK 10 (`dotnet --list-sdks`). Inga konton, ingen databas eller konfiguration behövs.
**Att veta:** Varningar stoppar bygget (`TreatWarningsAsErrors` i `Directory.Build.props`). Paketversionerna i testprojektet är låsta.

**Sidor:** `/tidrapportering` (startsida) · `/update-report` · `/kalender` · `/customers` · `/billable-hours`

## Vad som är känt men inte åtgärdat

| Vad | Hur allvarligt | Var i koden |
|---|---|---|
| Data sparas bara i minnet. `TimeReportService` är Scoped, så data försvinner vid omladdning, ny flik och omstart. | **Hög** | `Program.cs`, `TimeReportService.cs` |
| Ingen inloggning. Alla ser allt, och rollerna konsult och ekonomichef är bara etiketter. | **Hög** – krävs före skarp drift | – |
| Ändra rapport (#4) kontrollerar 0–24 h per rapport men inte att dagens totala tid håller sig under 24 h. | Medel | `UpdateReportService.UpdateHours`, `TimeReportValidator.cs` |
| "Debiterbar" sätts automatiskt när en kund får rapporterad tid. Ekonomichefen kan inte själv välja det. | Medel | `TimeReportService.AddReport` |
| Tester saknas för `AddReport`, `UpdateHours` och `GetHoursForCustomer`. Bara kalendern och röktesterna är testade. | Medel | `tests/IU2.Core.Tests` |
| Några sidor använder `DateTime.Now` i stället för `IClock`, vilket gör dem svåra att testa. | Låg | `UpdateReportService.cs`, `BillableHours.razor` |
| Kundlistan är hårdkodad. | Låg | `TimeReportService.Customers` |

## Vad ett mottagande team bör ta först

1. **Databas.** Byt minneslistorna mot en riktig lagring, till exempel EF Core. Utan den försvinner all data, och den är grunden för #11.
2. **Inloggning och roller (#1).** Krävs för att veta *vem* som ändrat något, och för att skilja konsultens vy från ekonomichefens.
3. **Spårbarhet (#11, 13 SP).** Beställarens krav för skarp drift. Logga vem, vad och när vid varje ändring och borttagning.

**Snabb vinst före det:** laga 24-timmarsregeln i "Ändra rapport" och skriv tester för den. Det tar under en timme.

## Vad vi skulle göra om vi fick en vecka till

- Databas, inloggning och #11, i den ordningen
- Tester för alla regler i `IU2.Core`
- Låta ekonomichefen själv markera kunder som debiterbara
- #5 Sök kund
- Driftsätta på Azure App Service, så att beställaren kan testa utan att köra koden lokalt
