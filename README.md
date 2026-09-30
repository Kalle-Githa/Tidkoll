# Tidkoll

Tidkoll är en enkel app för tidrapportering, byggd i Blazor och .NET 10.
Konsulten rapporterar sin tid snabbt och med så få fält som möjligt.
Ekonomichefen ser hur många debiterbara timmar varje kund har.

**Grupp 5A:** Cazper, Emelie, Juan · IU2 Projektleverans, NET25S

---

## Kom igång

Du behöver **.NET SDK 10**. Kolla vilken version du har med `dotnet --list-sdks`.

```bash
git clone https://github.com/Kalle-Githa/Tidkoll.git
cd Tidkoll
dotnet restore
dotnet build
dotnet test
dotnet run --project src/IU2.Web
```

Öppna sedan <http://localhost:5080>.

Du behöver inga konton, ingen databas och ingen konfiguration.

---

## Vad appen gör

| Sida | Vem använder den | Vad man gör | Story |
|---|---|---|---|
| `/tidrapportering` (startsida) | Konsulten | Rapportera timmar per kund och dag | #2 |
| `/kalender` | Konsulten | Se månaden med timmar per dag och en månadstotal | #3 |
| `/update-report` | Konsulten | Ändra timmarna på en felaktig rapport | #4 |
| `/billable-hours` | Ekonomichefen | Se timmar per kund och månad | #6 |
| `/customers` | Ekonomichefen | Se alla kunder med kundnummer och om de är debiterbara | #7 |

Vilka regler som gäller står i acceptanskriterierna i [`docs/TIDKOLL-BACKLOG.md`](docs/TIDKOLL-BACKLOG.md).

---

## Struktur

```
src/IU2.Core          Domänlogik: modeller, tjänster, validering, kalender
src/IU2.Web           Blazor Web App (interactive server), sidorna ovan
tests/IU2.Core.Tests  xUnit-tester för IU2.Core
.github/workflows     CI: restore, build, test på varje push och PR
docs/                 Backlog, sprintplaner, DoD och projektledningsbilagan
```

Logiken ligger i `IU2.Core` och inte i Razor-sidorna. Då kan vi testa den utan att starta webbappen.

---

## Tekniska beslut och varför

### 1. Varningar stoppar bygget
`TreatWarningsAsErrors` är påslaget i `Directory.Build.props`.
**Varför:** Vår Definition of Done kräver att CI är grön med 0 varningar. Då går raden att bocka av med ett ja eller nej. Varningar som får ligga kvar blir oftast aldrig åtgärdade. Nackdelen är att en liten varning stoppar hela bygget, och det tar vi medvetet.

### 2. Låsta paketversioner
Testprojektet använder exakta versioner (`xunit 2.9.3`, `Microsoft.NET.Test.Sdk 17.14.1`, `xunit.runner.visualstudio 2.8.2`) i stället för `2.*`.
**Varför:** Med flytande versioner kan ett bygge i dag och ett bygge om två veckor hämta olika paket. Då kan CI bli röd utan att vi har ändrat något. Med låsta versioner bygger alla och CI mot exakt samma paket. Vi uppdaterar paketen själva, när vi väljer det.

### 3. Data sparas bara i minnet
Tidrapporterna ligger i en lista i `TimeReportService`, och kundlistan är hårdkodad.
**Varför:** Med endagssprintar ville vi lägga tiden på det konsulten och ekonomichefen faktiskt ser. En databas hade tagit en stor del av en sprint. För demon räcker det att data finns medan appen körs.
**Känd begränsning:** Tjänsten är registrerad som `Scoped`. Därför försvinner data vid omladdning, i en ny flik och vid omstart. En riktig databas (till exempel EF Core) är det första ett mottagande team bör göra, och den krävs för spårbarheten i #11. Se [`docs/OVERLAMNING.md`](docs/OVERLAMNING.md).

### 4. `IClock` i stället för `DateTime.Now`
Kalendern frågar en `IClock` om vad klockan är.
**Varför:** I testerna kan vi då skicka in en `FakeClock` och bestämma datumet, till exempel "mars 2026". Därför går kalendertesterna att köra oavsett vilken dag det är.

### 5. Branching: `feature/*` → `dev` → `main`
Allt arbete görs på korta feature-grenar. De går in i `dev` via pull request, och `dev` går till `main` när sprintens stories fungerar ihop.
**Varför:** Flera stories bygger på samma kod. I `dev` ser vi att de fungerar tillsammans, så att `main` alltid är något som går att visa. Hela motiveringen finns i [`docs/BRANCHING.md`](docs/BRANCHING.md).

### 6. CI på varje push och pull request
GitHub Actions ("Bygg och testa") kör `restore`, `build` och `test` i Release. Både `main` och `dev` kräver att CI är grön innan man får merga.
**Varför:** Då får vi veta direkt om något går sönder, och inte först på demon.

---

## Så jobbar vi

1. Skapa en gren från `dev`: `feature/<kort-beskrivning>`
2. Gör en pull request till `dev` och fyll i PR-mallen
3. Minst en teammedlem granskar koden, och CI måste vara grön
4. Merga och ta bort grenen

En story är klar när den uppfyller vår [Definition of Done](docs/DEFINITION-OF-DONE.md).

---

## Dokumentation

| Dokument | Innehåll |
|---|---|
| [`TIDKOLL-BACKLOG.md`](docs/TIDKOLL-BACKLOG.md) | Vision, roller, user stories med acceptanskriterier |
| [`SPRINTPLAN_1.md`](docs/SPRINTPLAN_1.md) · [`SPRINTPLAN_2.md`](docs/SPRINTPLAN_2.md) | Sprintmål, story points, antaganden |
| [`DEFINITION-OF-DONE.md`](docs/DEFINITION-OF-DONE.md) | Mätbar DoD med ändringslogg |
| [`BRANCHING.md`](docs/BRANCHING.md) | Branching-strategi och motivering |
| [`RETROSPEKTIV_RAPPORT.md`](docs/RETROSPEKTIV_RAPPORT.md) | Retrospektiv med åtgärder och ägare |
| [`INTRESSENTKARTA.md`](docs/INTRESSENTKARTA.md) | Intressentlök, intressentkarta och konflikten beställare/användare |
| [`RISKREGISTER.md`](docs/RISKREGISTER.md) | Risker med ägare och uppföljning |
| [`KRAVFORANDRING-SVAR.pdf`](docs/KRAVFORANDRING-SVAR.pdf) | Svar på kravförändringen (#11) |
| [`STATUSRAPPORT.md`](docs/STATUSRAPPORT.md) | Statusrapport till styrgruppen 30/9 |
| [`OVERLAMNING.md`](docs/OVERLAMNING.md) | Överlämningsnot till nästa team |

---

## Känt och inte åtgärdat

- Ingen inloggning. Rollerna konsult och ekonomichef är bara etiketter (#1)
- Ingen spårbarhet vid ändring och borttagning (#11, 13 SP)
- "Ändra rapport" kontrollerar inte att dagens totala tid är högst 24 h
- Tester saknas för `AddReport`, `UpdateHours` och `GetHoursForCustomer`

Hela listan, och vad som bör göras först, finns i [`docs/OVERLAMNING.md`](docs/OVERLAMNING.md).
