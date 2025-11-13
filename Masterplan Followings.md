# Masterplan — Cleaned & Merged

Diese Datei enthält eine bereinigte und strukturierte Version des Masterplans (Vorschlag) gefolgt vom originalen `Projektauftrag.md`.

---

## Masterplan (bereinigt / Vorschlag)

**Mögliche Titel:** RideOn · Da Route · Rat Hot Fuzz Race

Ein Rhythmus-Roguelike-Autospiel in isometrischer Perspektive mit 32-bit-Ästhetik.
Programmiert in Unity.

### Vision

Kurz: Ein schneller, musikalisch getriebener Arcade-Racer, der Roguelike-Elemente
mit rhythmischen Trefferzonen kombiniert. Jeder Durchlauf fühlt sich einzigartig an,
während Musik, Risiko und Belohnung die Spielerentscheidung antreiben.

### Core Loop

1. Spieler wählt eine Kassette (Song) und startet einen Run.
2. Das Spiel zoomt in isometrische Perspektive; Song und Level starten synchron.
3. Spieler fährt automatisch vorwärts, weicht Traffic und Hindernissen aus, sammelt
   rhythmisch platzierte Beats ein und kann Nitro/Upgrades riskant aufnehmen.
4. Punkte, Multiplikator und Fortschritt werden während des Songs gesammelt.
5. Nach Ende des Songs: Zwischenbildschirm (Tankstelle/Raststätte) zum Ausgeben von
   Punkten auf Upgrades und Auswahl der nächsten Kassette. Loop wiederholt sich.

### Mechanics

- Steuerung: Links/Rechts zum Spurwechsel; Gas wird automatisch gegeben. Fokus liegt
  auf Positionsmanagement und Timing.
- Beats: Sammelobjekte, die zur Musik synchron erscheinen — geben Punkte.
- Nitro-Canister: Erhöhen Multiplikator bei riskantem Einsammeln (Close-call-Mechanik).
- Hindernisse: Andere Autos, Ölpfützen, Straßensperren; Collision führt zu Crash-Animation
  und Reset des Multiplikators auf 1x.
- Special-Level-Mechaniken: Police-Pursuit mit Nagelbändern, Straßensperren und einem
  Grappler-Mechanismus gegen Ende des Levels (Boss-Feature).
- Prozedurale Streckengenerierung: Level bauen sich rhythmisch passend zum Song auf,
  sodass jeder Durchlauf sich neu anfühlt.

### Progression

- Ein Run besteht aus mehreren Songs/Level-Abschnitten (Acts).
- Zwischen den Songs kann der Spieler Upgrades kaufen (z. B. bessere Handhabung, längerer
  Nitro-Effekt, höhere Multiplikatorgrenzen).
- Nach Abschluss bestimmter Bedingungen startet ein Boss-/Verfolgungslevel (z. B. Polizeiverfolgung).
- Ziel des Spielerlebnisses: möglichst viele Beats und Punkte in einem Durchlauf zu sammeln
  und das Boss-Level zu überstehen.

### Milestones

1. Prototyp: Basis-Fahrmechanik + Spurwechsel + einfache Beat-Sammlung (Spiel-Loop sichtbar).
2. Audio-Sync: Songs und Beatplatzierung synchronisieren; einfache prozedurale Streckengenerierung.
3. Obstacle & Nitro: Hindernisse, Öl, Nitro-Items, Multiplikator-Logik.
4. Zwischenbildschirm & Upgrades: Tankstelle-Routine, Upgrade-Auswahl, Kassettensystem.
5. Police-Pursuit: Design und Implementierung des Verfolgungslevels mit Boss-Features.
6. Polish & Demo: UI, SFX, VFX, Level-Varianz, Trailer-Video.

### Sprintplan (erste Wochen)

**Sprint-Kadenz**
- 1 Woche pro Sprint, Daily 15 Min, Review/Retro am Freitag.
- Definition of Done (DoD): Läuft im Unity-Editor ohne Errors, spielbar mit Tastatur/Controller, kurze Readme-Notiz zum Status.

**Sprint 0 (Pre-Kickoff, 2–3 Tage)**
- Ziel: Setup & Klarheit schaffen.
- Schritte:
  - Unity-Projekt (LTS) anlegen, Git-Repo einrichten, Branch-/PR-Flow dokumentieren.
  - Ordnerstruktur: `Assets/{Scripts,Art,Audio,UI,Scenes}`, Beispielszene `Main.unity`.
  - Projekt-README mit Vision, Core Loop, Milestones; Audio-Pipeline-Entscheidung anstoßen (Preprocessing vs. On-the-fly).
  - Backlog in Tickets (User Stories + Akzeptanzkriterien) erfassen und priorisieren (TINO).
- DoD: Projekt öffnet, Beispiel-Build erstellt; Backlog priorisiert (P0/P1).

**Woche 1 – Core-Loop Skeleton**
- Ziel: Auto-Vortrieb + Spurwechsel + Punktezähler sichtbar.
- Schritte:
  - Fahrzeug-Controller: Auto-Forward, 3 Spuren, Links/Rechts als diskrete Lane-Changes.
  - Einfache Strecke (endloser, loopender Straßen-Chunk).
  - Basic Score-Manager + On-Screen UI (Text) für Score/Multiplier (BENDRA).
  - Placeholder-Auto + Straße (CALVIN, 32-bit-Look/Low-Poly).
  - Test-Szene „CoreLoop“ mit Start/Restart.
- DoD: 30 Sek. Fahrtest, Spurwechsel flüssig, Score zählt hoch.

**Woche 2 – Audio-Sync & Beats**
- Ziel: Musik synchronisieren und Beat-Objekte im Takt spawnen.
- Schritte:
  - Audio-Pipeline finalisieren: Vorverarbeitete Beat-Marker (JSON) bevorzugt.
  - Import-Tool/Script: BPM + Beat-Offsets einlesen; Conductor/Timeline implementieren.
  - Beat-Spawner: Sammelobjekte auf Spuren gemäß Marker-Timestamps erzeugen.
  - Visuelles/Audio-Feedback bei Einsammeln (Ping + Flash); einfacher Miss-State.
  - Erster Song integrieren (CALVIN liefert Musik + Marker).
- DoD: Beat-Spawn ±20 ms zum Takt; Einsammeln gibt Punkte.

**Woche 3 – Hindernisse & Multiplikator**
- Ziel: Risiko/Belohnung spürbar machen.
- Schritte:
  - Hindernisse: Traffic-Car, Öl, Blockade; Kollision → Crash-Feedback, Reset.
  - Nitro-Canister: erhöht Multiplikator bei „knappem“ Einsammeln (Distance-Check).
  - Multiplier-Logik: skaliert Score; UI-Anzeige (BENDRA).
  - Baseline-Balancing: Spawn-Raten, Lane-Bias, Kollisionsboxen.
  - Effekt-SFX (CALVIN): Crash, Nitro, Collect.
- DoD: 60 Sek. Run mit erkennbarer Risiko-/Belohnungsdynamik; Multiplier stabil.

**Woche 4 – Prozedurale Segmente & Fahrgefühl**
- Ziel: Mehr Varianz, saubereres Handling.
- Schritte:
  - Segment-Generator: Straßensegmente (Gerade, Kurven-Optik via Deko) entlang Beat-Timeline.
  - Spawn-Pools: Beats/Hindernisse/Nitro per „Wave“-Definition (ScriptableObjects).
  - Fahrzeug-Handling: Lateral-Easing, Deadzone, fixe Step-Zeiten pro Lane-Change.
  - Performance: Garbage vermeiden, Object Pooling für Collectibles/Hindernisse.
  - Basic-Pause/Restart-UI (BENDRA).
- DoD: 2–3 Preset-Waves, stabile FPS, kein merklicher GC-Surge.

**Woche 5 – Startmenü, HUD-Polish, Score-Persistenz**
- Ziel: Spielschleife runder + Ergebnis sichtbar.
- Schritte:
  - Startmenü: Kassette/Song wählen (1–2 Einträge), „Play/Exit“ (BENDRA).
  - HUD-Polish: klare Multiplikator-States, Hit/Miss-Feedback, einfache Combo-Anzeige.
  - End-of-Run-Summary: Score, längste Streak, eingesammelte Beats.
  - Lokale Highscores speichern/laden; Name-Input minimal (kein Account nötig).
  - Art-Pass I: UI-Icons, Kassettencover (CALVIN).
- DoD: Start → Run → Summary → Highscore persistiert; UI klar lesbar.

**Woche 6 – Zwischenbildschirm (Tankstelle) & Upgrade-Stubs**
- Ziel: Erste Progression antasten.
- Schritte:
  - Tankstellen-Screen zwischen Songs: 2–3 Dummy-Upgrades (Handling+, Nitro-Dauer, Multiplier-Cap).
  - Punkte-als-Währung verwenden; Auswahl per Tastatur/Controller.
  - Kassettensystem: nächstes Lied wählen (Stub mit 1 weiterem Track/Loop).
  - Technische Vorbereitung für Police-Pursuit: Spike-Strip-Placeholder/Prefab.
  - SFX/UI für Upgrade-Kauf (CALVIN/BENDRA).
- DoD: Upgrade-Auswahl verändert Werte spürbar; Next-Song-Flow funktioniert.

**Offene Fragen (früh klären, Woche 1–2)**
- Zielplattform (PC primär?) → Eingabe-/UI-Fokus.
- Beat-Ermittlung endgültig: Preprocessing-Tooling abgesegnet?
- Umfang Demo: Anzahl Songs (1–2) und Upgrade-Tiefe (3–5).
- Scoring-Formel: Gewichtung Close Calls vs. Sammeln.

**Rollen-Zuordnung (Vorschlag)**
- BENDRA: HUD/Startmenü/Pause/Endscreen, Multiplikator-Anzeige, UI-Polish.
- CALVIN: Musik + Beat-Marker + SFX, 32-bit Art-Pass (Auto, Straße, UI-Icons).
- TINO: Conductor/Beat-Timeline, Spawner/Pooling, Fahrcontroller, Hindernislogik, Backlog/Reviews.

### Backlog (Beispiele / User Stories)

- Start-Menü / Cockpit (UI) // BENDRA
- Models & Art-Assets // CALVIN
- Music & Sounddesign // CALVIN
- Level-Structure / Generator // (offen)
- Level-Design / Wave-Design // (offen)
- Trailer-Video (Schnitt) // (offen)
- Backlog-Management (User Stories, Priorisierung) // TINO

Konkrete User Stories (Beispiele):
- Als Spieler möchte ich mich intuitiv zwischen Spuren bewegen, damit das Spiel flüssig wirkt.
- Als Spieler möchte ich Upgrades kaufen können, um mich auf längere Runs vorzubereiten.
- Als Designer möchte ich einfache Parameter für die Beat-Platzierung, um Level schnell zu testen.

### Open Questions

- Zielplattformen: PC, Mobile, Konsole? (Steuerung & UI-Anpassungen)
- Audio-Pipeline: Werden Songs vorverarbeitet für Beat-Marker oder soll On-the-fly-Analysis verwendet werden?
- Scoring-Formel: Wie stark soll Risiko (Close Calls) gegenüber einfachen Sammlungen belohnt werden?
- Difficulty-Scaling: Wie skaliert die Ballung der Hindernisse und die Aggressivität der Polizei?
- Umfang: Wie viele Songs/Upgrades für eine Demo sinnvoll sind?
- Save/Leaderboards: Lokale Highscores vs. globales Ranking (Datenschutz, Backend-Aufwand)

---

## Original `Projektauftrag.md` (unten angefügt)

# WMC und SYPPRE 2025/26

## Projektname: "RideOn"

## Projekthintergrund

Wir wollen ein Spiel entwickeln, das Musik und Reaktionsfähigkeit verbindet.
Unser Ziel ist es, ein Rhythmusspiel mit einfachen Roguelike-Elementen zu bauen, bei dem die Spieler:innen im Takt zur Musik spielen.
Ein Scoreboard soll zeigen, wer die besten Ergebnisse hat.

---
## Projektergebnis

Am Ende soll eine funktionierende Demo fertig sein:
- Ein Level oder Song, den man spielen kann
- Punktevergabe nach Treffern/Misses
- Einfache Gegner/Level-Struktur (zufällig oder fix)
- Scoreboard mit Highscores

### Kriterien für Projekterfolg

- Funktionalität
- User-Accounts
- Medienintegration
- Usability

---
## Projektziele

- Spielbar machen: Ein Grundlevel mit Rhythmus-Eingaben.
- Spaß machen: Musik + visuelles Feedback (z. B. Treffer-Effekte).
- Motivation: Scoreboard mit Rangliste.
- Roguelike Aspekt: zufällige Gegner oder zufällige Reihenfolge von Abschnitten.

---
## Inhalte und Aufgaben 
- Spielfigur oder Symbol, das auf Eingaben reagiert
- Punkte & Scoreboard
- Roguelike-Elemente
- Grafik & UI

---
## Medienintergration : Uploud von Medien und Texten

- Medienintegration: Upload von Songs und SoundFX
- Progressions- und Belohnungssysteme: Integration von Levels und Achievements
- Datenspeicherung: Sicheres Hinterlegen der Profildaten in einer Datenbank
  
---
## Erfolgsfaktoren 
- Einfaches Gameplay
- Sauberes Feedback (Treffer/Miss klar sichtbar)
- Übersichtliches Scoreboard
  
---
## Termine

- Projektstart: September 2025
- Kick-off-Meeting: 
- Grundgerüst UI: 
- User-Accounts: 
- Achievement-System: 
- Abschluss des Projekts: 

   
---
## Organisation 

**Projektleiter:** Calvin Wohland
**Teammitglieder:** Tino Tomasic, Daniel Bendra

Teamrollen:
- Programmierung (Spiellogik, Punkte, Scoreboard)
- Musik/Sound (Song auswählen oder selbst machen)
- Grafik (Spielfigur, Hintergrund, UI)
- Testen (Spaßfaktor prüfen, Fehler finden)
