# Architekturübersicht – RideOn

## 1. Systemüberblick
RideOn ist ein 2D/3D-Rennspiel, bei dem …  
*(Kurz beschreiben, was euer Spiel macht: Perspektive, Plattform, Singleplayer/Multiplayer etc.)*

## 2. Hauptkomponenten
- **Client / Spiel-Engine:** (z. B. Unity, Godot, MonoGame …)
- **Game Logic:** Spiellogik, Regeln, Rundenablauf
- **UI:** Menüs, HUD, Einstellungen
- **Datenhaltung:** Speicherung von Spielständen, Highscores, Profilen
- **Sonstiges:** z. B. Audio-System, Input-Handling

## 3. Datenmodell
- Welche wichtigen „Datenobjekte“ gibt es? (z. B. Spieler, Fahrzeug, Strecke, Rennen …)
- Wie hängen diese zusammen?
- Verweis auf das ER-Diagramm (sobald vorhanden), z. B.:
  - Siehe `docs/er/rideon_er_diagram.png`

## 4. Schichten / Architektur-Stil
- Kurze Beschreibung, wie ihr den Code trennt:
  - z. B. Präsentation (UI) – Logik – Datenzugriff
  - oder Entity Component System, oder ein typisches Spiele-Pattern
- Wie kommunizieren diese Teile miteinander?

## 5. Wichtige Designentscheidungen
- Welche Engine/Frameworks verwendet ihr und warum?
- Besondere Entscheidungen (z. B. „Wir speichern keine Datenbank, sondern lokale Dateien“, „Wir nutzen ScriptableObjects“, …)

## 6. Offene Punkte / Risiken
- Welche Teile sind noch nicht umgesetzt?
- Wo seht ihr technische Risiken (Performance, Multiplayer, Physics etc.)?
