# Branching-strategi

> Vald i sprint 0 utifrån lärarens förslag (trunk-based), justerad med en
> `dev`-gren. Motivering nedan.

## Vår strategi: korta feature-grenar via `dev`

```
feature/<kort-beskrivning>  →  dev  →  main
```

- `main` är alltid deploybar. Ingen pushar direkt till `main` eller `dev`.
- Nya grenar skapas från `dev`: `feature/<kort-beskrivning>`.
- Ändringar går in i `dev` via pull request med minst en granskare.
- CI måste vara grön innan merge.
- Grenen tas bort efter merge.
- När sprintens stories fungerar ihop i `dev` görs en pull request `dev` → `main`.

## Varför korta grenar i just det här projektet

Sprintarna är endagssprintar. En gren som lever längre än en sprint hinner
aldrig bli granskad inom sprinten, och då syns inte arbetet i demon.

## Varför `dev` före `main`

Flera stories bygger på samma kod (t.ex. kalendern använder
tidrapporteringens `TimeReportService`). I `dev` kan vi se att de fungerar
tillsammans innan de når `main`. Då är `main` alltid ett fungerande
inkrement att visa på demon.

## Skydda main och dev

Settings → Branches → Add rule på `main` och på `dev`:

- Require a pull request before merging
- Require status checks to pass → välj `Bygg och testa`

