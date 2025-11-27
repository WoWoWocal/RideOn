```mermaid
erDiagram
    BENUTZER ||--o{ SPIELRUNDE : "spielt"
    BENUTZER ||--o{ MEDIUM : "lädt hoch"
    BENUTZER ||--o{ BENUTZER_ACHIEVEMENT : "hat"
    ACHIEVEMENT ||--o{ BENUTZER_ACHIEVEMENT : "wird freigeschaltet"
    MEDIUM ||--o{ SONG : "ist Basis für"
    SONG ||--o{ LEVEL : "wird verwendet in"
    LEVEL ||--o{ SPIELRUNDE : "wird gespielt in"

    BENUTZER {
        int benutzer_id PK
        string nutzername
        string email
        string passwort_hash
        date registriert_am
        string anzeige_name
        string avatar_url
        string bevorzugte_schwierigkeit
    }

    MEDIUM {
        int media_id PK
        string typ
        string titel
        string dateipfad
        int hochgeladen_von FK
        date hochgeladen_am
    }

    SONG {
        int song_id PK
        int media_id FK
        int bpm
        int dauer_sekunden
        string genre
    }

    LEVEL {
        int level_id PK
        string name
        string schwierigkeitsgrad
        bool ist_roguelike
        string beschreibung
        int song_id FK
    }

    SPIELRUNDE {
        int runde_id PK
        int benutzer_id FK
        int level_id FK
        datetime startzeit
        datetime endzeit
        int gesamtpunkte
        float treffer_quote
        int max_combo
        int anzahl_miss
    }

    ACHIEVEMENT {
        int achievement_id PK
        string name
        string beschreibung
        string kategorie
        string icon_url
    }

    BENUTZER_ACHIEVEMENT {
        int benutzer_id PK, FK
        int achievement_id PK, FK
        date freigeschaltet_am
    }
