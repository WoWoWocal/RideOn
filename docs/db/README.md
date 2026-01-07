# RideOn – Datenbankdokumentation

Dieses Dokument beschreibt die Test-Datenbank für das Spiel **RideOn** sowie die Nutzung der bereitgestellten SQL-Skripte.

## 1. Ziel der Datenbank

Die Datenbank dient aktuell vor allem zu **Testzwecken**:

- Benutzerkonten verwalten
- Spiellevel mit Song-Informationen speichern
- Gespielte Runden (Scores) speichern
- Highscores und Statistiken auswerten

Produktive Features wie Medien-Upload oder Achievements sind in dieser Version noch **nicht** umgesetzt.

---

## 2. Tabellenübersicht

### 2.1 BENUTZER

| Spalte                  | Typ             | Beschreibung                            |
|-------------------------|-----------------|-----------------------------------------|
| `benutzer_id`           | NUMBER (PK)     | Eindeutige ID (Identity)                |
| `nutzername`            | VARCHAR2(50)    | Benutzername (eindeutig)                |
| `email`                 | VARCHAR2(255)   | E-Mail-Adresse (eindeutig)              |
| `passwort_hash`         | VARCHAR2(255)   | Passwort-Hash                           |
| `registriert_am`        | DATE            | Registrierungsdatum                     |
| `anzeige_name`          | VARCHAR2(100)   | Name, der im Spiel angezeigt wird       |
| `avatar_url`            | VARCHAR2(4000)  | Optionaler Link zu einem Avatar         |
| `bevorzugte_schwierigkeit` | VARCHAR2(20) | z. B. Easy, Normal, Hard                |

### 2.2 SPIELLEVEL

| Spalte              | Typ             | Beschreibung                                  |
|---------------------|-----------------|-----------------------------------------------|
| `level_id`          | NUMBER (PK)     | Eindeutige ID (Identity)                      |
| `name`              | VARCHAR2(100)   | Name des Levels                               |
| `schwierigkeitsgrad`| VARCHAR2(20)    | z. B. Easy / Normal / Hard                    |
| `ist_roguelike`     | CHAR(1)         | 'J' = ja, 'N' = nein                          |
| `beschreibung`      | VARCHAR2(1000)  | Kurze Beschreibung                            |
| `song_titel`        | VARCHAR2(200)   | Anzeigename des Songs                         |
| `song_dateipfad`    | VARCHAR2(4000)  | Pfad/URL zur Songdatei                        |
| `bpm`               | NUMBER(4)       | Beats per Minute                              |
| `dauer_sekunden`    | NUMBER(6)       | Songdauer in Sekunden                         |

### 2.3 SPIELRUNDE

| Spalte         | Typ             | Beschreibung                                         |
|----------------|-----------------|------------------------------------------------------|
| `runde_id`     | NUMBER (PK)     | Eindeutige ID (Identity)                             |
| `benutzer_id`  | NUMBER (FK)     | Referenz auf `BENUTZER.benutzer_id`                  |
| `level_id`     | NUMBER (FK)     | Referenz auf `SPIELLEVEL.level_id`                   |
| `startzeit`    | TIMESTAMP       | Start der Runde                                      |
| `endzeit`      | TIMESTAMP       | Ende der Runde                                       |
| `gesamtpunkte` | NUMBER(10)      | Erreichte Punkte                                     |
| `trefferquote` | NUMBER(5,2)     | Prozentuale Genauigkeit (z. B. 97.50)                |
| `max_combo`    | NUMBER(5)       | Höchste Treffer-Serie am Stück                       |
| `anzahl_miss`  | NUMBER(5)       | Anzahl verfehlter Eingaben                           |

---

## 3. Skripte

### 3.1 Schema-Script

**Datei:** `docs/db/rideon_schema.sql`

- Legt die Tabellen **BENUTZER**, **SPIELLEVEL** und **SPIELRUNDE** an.
- Enthält Primär- und Fremdschlüssel sowie einfache Constraints.

**Ausführung (z. B. in SQL Developer):**

1. Mit der gewünschten Oracle-Datenbank verbinden.
2. Script öffnen: `rideon_schema.sql`.
3. Komplett ausführen oder Abschnitt für Abschnitt.

### 3.2 Testdaten-Script

**Datei:** `docs/db/rideon_testdata.sql`

- Legt mehrere Beispiel-Benutzer an (Calvin, Tino, Daniel, Guest).
- Legt drei Beispiel-Levels an (Tutorial, Normal, Hard/Roguelike).
- Fügt mehrere Spielrunden hinzu, damit Highscores und Statistiken getestet werden können.

**Ausführung:**

1. Sicherstellen, dass das Schema bereits existiert.
2. Script `rideon_testdata.sql` ausführen.
3. Mit `SELECT`-Abfragen überprüfen, ob Daten vorhanden sind.

---

## 4. Beispielabfragen (SELECT)

### 4.1 Top 10 Highscores (global)

```sql
SELECT
    b.nutzername,
    l.name       AS level_name,
    s.gesamtpunkte,
    s.trefferquote,
    s.startzeit
FROM spielrunde s
JOIN benutzer b   ON s.benutzer_id = b.benutzer_id
JOIN spiellevel l ON s.level_id    = l.level_id
ORDER BY s.gesamtpunkte DESC
FETCH FIRST 10 ROWS ONLY;
