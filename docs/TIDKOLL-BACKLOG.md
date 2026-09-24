# Tidkoll – Product Backlog

**Tema A · Tidsrapportering** · Grupp 5: Cazper, Emelie, Juan

> **Beställare:** Ekonomichefen – vill se debiterbara timmar per kund.
> **Användare:** Konsulten – vill rapportera hela veckan på 30 sekunder.
> **Konflikten:** Varje fält ekonomichefen lägger till gör att konsulten rapporterar mer sällan.

## Produktvision

För konsulter som vill lägga minimal tid på tidrapportering är **Tidkoll** en enkel app där veckan rapporteras på 30 sekunder – samtidigt som ekonomichefen får en tydlig överblick över debiterbara timmar per kund.

## Roller

| Roll | Namn | Ansvar |
|---|---|---|
| Product Owner / Beställare | Benny | Prioriterar och fattar beslut |
| Teknisk ansvarig | Juan | Statusrapport, arkitektur, repo, pipeline |
| Scrum Master | Emelie | Riskregister (minst 5 risker), ceremonier |
| Utvecklare | Cazper | Utveckling och tester |

## User Stories



| # | User Story | Acceptanskriterier | SP | Prio |
|---|---|---|---|---|
| 1 | Som **användare** vill jag kunna logga in så att jag ser rätt vy och data för min roll. | • Användarnamn minst 6 tecken och lösenord minst 10 tecken<br>• Rätt uppgifter → inloggad inom 3 sek<br>• Fel uppgifter → meddelandet "Fel användarnamn eller lösenord" <br>• Efter lyckad inloggning dirigeras konsulten till sin egen rapporteringsvy, ekonomichefen till kundöversikten| 5 | Could |
| 2 | Som **konsult** vill jag rapportera timmar per kund och dag så att min tid registreras. | • Välj datum, kund och antal timmar<br>• Timmar > 0 och max 24 per dag, annars felmeddelande<br>• Efter sparning visas "Sparat" och timmarna syns på datumet | 3 | Must |
| 3 | Som **konsult** vill jag se månaden i en kalendervy så att jag ser att allt är rapporterat. | • Aktuell månad med rätt veckodagar och datum<br>• Visar bara inloggad konsults timmar<br>• Datum utan timmar är tomma<br>• Total summa för månaden visas | 3 | Must |
| 4 | Som **konsult** vill jag kunna ändra en felaktig rapport så att underlaget blir rätt. | • Välj en rapport i aktuell månad och ändra timmarna (samma regler som #2)<br>• Nya tiden ersätter den gamla<br>• Meddelandet "Uppdaterat" visas | 2 | Must |
| 5 | Som **ekonomichef** vill jag kunna söka efter en kund så att jag snabbt hittar rätt. | • Sök på namn eller kundnummer<br>• Ingen träff → "Ingen kund hittades" | 2 | Should |
| 6 | Som **ekonomichef** vill jag se debiterbara timmar per kund så att jag kan fakturera rätt. | • Välj kund och månad<br>• Totalt antal timmar för kunden visas<br>• Bara perioder markerade som klara räknas | 3 | Must |
| 7 | Som **ekonomichef** vill jag se en lista över alla kunder så att jag får överblick. | • Varje kund visas med namn och kundnummer<br>• Varje kund är märkt debiterbar eller ej | 1 | Should |
| 8 | Som **konsult** vill jag få en påminnelse så att jag inte glömmer att rapportera. | • Kommer 7 dagar före sista rapporteringsdag<br>• Skickas bara om rapporten inte är klar<br>• Visar datumet då rapporten ska vara klar | 5 | Could |
| 9 | Som **ekonomichef** vill jag få en notis när en rapport är klar så att jag vet när jag kan fakturera. | • Skickas när konsulten markerat perioden som klar<br>• Visar konsult och period<br>• Ekonomichefen ser vilka rapporter som är klara | 5 | Could |
| 10 | Som **ekonomichef** vill jag kunna lägga till fält i rapporten så att jag får mer information. | • Lägg till och ta bort fält från en lista<br>• Rapporten visar valda fält<br>• Valen sparas till nästa gång | 8 | Won't |

> **Om #10:** Storyn *är* konflikten – varje nytt fält gör rapporteringen långsammare för konsulten. Den tas upp med beställaren istället för att byggas nu.

## Sammanfattning

| Prio | Stories | SP totalt |
|---|---|---|
| Must | #2, #3, #4, #6 | 11 |
| Should | #5, #7 | 3 |
| Could | #1, #8, #9 | 15 |
| Won't (just nu) | #10 | 8 |

