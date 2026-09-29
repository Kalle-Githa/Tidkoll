# Statusrapport till styrgruppen

**Team:** Cazper, Juan, Emelie

**Datum:** 29 september 2026

## Klart enligt Definition of Done

Allt nedan är granskat via pull request och CI "Bygg och testa" är grön på `main` (PR #15, 29/9).

| Vad | Bevis |
|---|---|
| #2 Konsulten rapporterar timmar per kund och dag | PR #4 |
| #3 Kalendervy över månaden med månadstotal | PR #6 · 4 xUnit-tester |
| #4 Konsulten ändrar en felaktig rapport – använder nu samma data som övriga vyer | PR #5, PR #12 |
| #6 Debiterbara timmar per kund och månad | PR #11 |
| #7 Lista över alla kunder med kundnummer och debiterbar ja/nej | PR #11 |
| Paketversioner låsta, backlog och sprintplaner uppdaterade | PR #13, PR #14 |

**Velocity:** sprint 1 = 8 av 8 SP · sprint 2 = 4 av 4 SP, plus tilläggsarbetet på #4 från sprintplanen (3 SP).
Så våran velocity blir 4-7 eftersom första sprinten tog extra tid och vi behöver räkna med marginal.

## Inte klart – återstående arbete

| Vad | Återstår |
|---|---|
| #11 Spårbarhet vid ändring och borttagning (kravförändringen) | Allt – 13 SP: databas, inloggning och ändringslogg |
| Data sparas bara i minnet och försvinner vid omstart | Ingår i databasen i #11 |
| #5 Sök kund (Should) | Allt – 2 SP |
| #1, #8, #9 (Could) | Allt – 15 SP, ej planerade |

## Prognos

Kvar till skarp drift är #11, 13 SP. Med en velocity på 4-7 SP per sprint behövs **2–3 sprintar**. Prognosen bygger på samma team och samma velocity som i sprint 1–2.

## Tre risker just nu

| Risk | Ägare | Vad vi gör |
|---|---|---|
| R1 Fler obligatoriska fält gör att konsulterna rapporterar mer sällan | Cazper | Spårbarheten i #11 byggs utan nya fält för konsulten – vem och när loggas automatiskt. |
| R2 Nya krav tar tid från planerat arbete | Juan | Svarsmall klar i förväg. Kravförändringen besvarades inom 24 h. |
| R4 En teammedlem är frånvarande i kritiskt skede | Emelie | Estimerar med marginal (8 → 4 SP) och planerar om vid behov. |

## Beslut vi behöver – ja eller nej

**Godkänner ni att nästa sprint börjar med databas och inloggning, som grund för spårbarhetskravet (#11), innan nya funktioner byggs?** Ja / Nej
