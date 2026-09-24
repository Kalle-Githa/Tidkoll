# Intressentkarta

## Intressentlöken

| Lager | Vem                          | Vad de behöver av oss                                   | Vad vi behöver av dem                        |
|---|---|---|---|
| Core | Ekonomichefen / beställare    | Debiterbara timmar per kund och tillförlitligt underlag | Tydliga krav och prioriteringar              |
| Core | Teamet (Cazper, Emelie, Juan) | Tydliga beslut från beställaren                         | Leverans enligt Definition of Done           |
| Primary | Konsulter / användare         | Snabb och enkel tidsrapportering                        | Att de rapporterar sin tid korrekt           |
| Primary | Projektledare / teamchefer | Tillgång till relevant tidsunderlag                     | Feedback på behov och användning             |
| Secondary | HR / Löneadministration  | Korrekt tidsdata                                        | Information om eventuella administrativa krav |



## Intressentkartan

| Område      | Intressent            | Intresse i projektet                           | Makt över projektet |
|---|---|---|---|
| Samhälle    | Skatteverket (bokföringslagen) | Korrekt hantering av ekonomisk information     | Låg                 |
| Marknad     | Kunder                | Korrekt fakturering                            | Låg                 |
| Medarbetare | Konsulter             | Enkel och snabb tidsrapportering               | Medel               |
| Investerare | Ekonomichef           | Korrekt underlag för debitering                | Hög                 |
| Investerare | Företagsledning/ägare | Effektiv verksamhet och ekonomisk uppföljning | Medel               |

## Beställaren och användaren

De är inte samma person, och de vill inte samma sak.

- **Beställaren vill:**
Ekonomichefen vill ha tillräckligt mycket information för att kunna se och kontrollera debiterade timmar per kund.

- **Användaren vill:**
Konsulten vill kunna rapportera hela veckans tid på cirka 30 sekunder, med så få fält som möjligt.

- **Där de krockar:**
Ju fler uppgifter ekonomichefen vill samla in, desto längre tid tar det för konsulten att rapportera sin tid.

- **Så hanterar vi krocken:**
Vi prioriterar de minsta antal fält som krävs för att ekonomichefen ska kunna se debiterbara timmar per kund. Extra fält som inte behövs för projektets kärnfunktion väljs bort i denna version. Konkret: "Lägga till fält" (story #10) är satt som Won't, och debiterbar sätts på kunden i stället för på varje rad.

## Kopplingar

- Minst en risk i riskregistret ska komma härifrån. Vilken?
Risk: Ekonomichefens krav på ytterligare rapporteringsfält kan göra tidsrapportering för långsam för konsulterna, vilket leder till att systemet används mindre eller att rapporteringen blir bristfällig.

- Vilken intressent riktar vi demon mot den 30 september?
Vi riktar demon främst mot konsulten som användare, eftersom systemets värde bygger på att tidsrapporteringen faktiskt blir gjord. Vi visar samtidigt hur den rapporterade tiden blir användbar för ekonomichefen.

- Vad valde vi bort, och för vem?
Vi valde bort möjligheten för ekonomichefen att lägga till obegränsat med egna fält i tidsrapporteringen. Detta val görs för konsultens skull, eftersom fler obligatoriska fält gör rapporteringen långsammare.