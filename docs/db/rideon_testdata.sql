--------------------------------------------------------------------
-- Testdaten für RideOn
-- Voraussetzung: Tabellen BENUTZER, SPIELLEVEL, SPIELRUNDE existieren
--------------------------------------------------------------------

-- Optional: vorhandene Daten löschen (nur in Testumgebung machen!)
-- TRUNCATE TABLE spielrunde;
-- TRUNCATE TABLE spiellevel;
-- TRUNCATE TABLE benutzer;

--------------------------------------------------------------------
-- Benutzer anlegen
--------------------------------------------------------------------
INSERT INTO benutzer (nutzername, email, passwort_hash, anzeige_name, bevorzugte_schwierigkeit)
VALUES ('calvin', 'calvin@example.com', 'hash_calvin_123', 'Calvin', 'Normal');

INSERT INTO benutzer (nutzername, email, passwort_hash, anzeige_name, bevorzugte_schwierigkeit)
VALUES ('tino', 'tino@example.com', 'hash_tino_123', 'Tino', 'Hard');

INSERT INTO benutzer (nutzername, email, passwort_hash, anzeige_name, bevorzugte_schwierigkeit)
VALUES ('daniel', 'daniel@example.com', 'hash_daniel_123', 'Daniel', 'Easy');

-- Optional: weiterer Test-User ohne viele Daten
INSERT INTO benutzer (nutzername, email, passwort_hash, anzeige_name)
VALUES ('guest', 'guest@example.com', 'hash_guest_123', 'Guest');

COMMIT;

--------------------------------------------------------------------
-- Spiellevel anlegen
--------------------------------------------------------------------
INSERT INTO spiellevel (
    name, schwierigkeitsgrad, ist_roguelike,
    beschreibung, song_titel, song_dateipfad, bpm, dauer_sekunden
) VALUES (
    'Tutorial Groove', 'Easy', 'N',
    'Erstes Einsteigerlevel zum Testen des Gameplays.',
    'Chill Beat 1', '/media/songs/chill_beat_1.mp3', 100, 120
);

INSERT INTO spiellevel (
    name, schwierigkeitsgrad, ist_roguelike,
    beschreibung, song_titel, song_dateipfad, bpm, dauer_sekunden
) VALUES (
    'Neon Highway', 'Normal', 'N',
    'Rhythmus-Level mit mittlerer Schwierigkeit.',
    'Neon Ride', '/media/songs/neon_ride.mp3', 128, 150
);

INSERT INTO spiellevel (
    name, schwierigkeitsgrad, ist_roguelike,
    beschreibung, song_titel, song_dateipfad, bpm, dauer_sekunden
) VALUES (
    'Chaos Rush', 'Hard', 'J',
    'Roguelike-Level mit zufälligen Abschnitten.',
    'Chaos Beat', '/media/songs/chaos_beat.mp3', 150, 180
);

COMMIT;

--------------------------------------------------------------------
-- Spielrunden anlegen
-- Wir gehen davon aus:
-- benutzer_id: 1 = calvin, 2 = tino, 3 = daniel, 4 = guest
-- level_id:    1 = Tutorial Groove, 2 = Neon Highway, 3 = Chaos Rush
--------------------------------------------------------------------

-- Calvin spielt Tutorial Groove
INSERT INTO spielrunde (
    benutzer_id, level_id, startzeit, endzeit,
    gesamtpunkte, trefferquote, max_combo, anzahl_miss
) VALUES (
    1, 1,
    SYSTIMESTAMP - INTERVAL '2' DAY,
    SYSTIMESTAMP - INTERVAL '2' DAY + INTERVAL '2' MINUTE,
    12345, 95.50, 30, 5
);

-- Calvin spielt Neon Highway
INSERT INTO spielrunde (
    benutzer_id, level_id, startzeit, endzeit,
    gesamtpunkte, trefferquote, max_combo, anzahl_miss
) VALUES (
    1, 2,
    SYSTIMESTAMP - INTERVAL '1' DAY,
    SYSTIMESTAMP - INTERVAL '1' DAY + INTERVAL '3' MINUTE,
    15890, 97.20, 42, 3
);

-- Tino spielt Chaos Rush (Hard, Roguelike)
INSERT INTO spielrunde (
    benutzer_id, level_id, startzeit, endzeit,
    gesamtpunkte, trefferquote, max_combo, anzahl_miss
) VALUES (
    2, 3,
    SYSTIMESTAMP - INTERVAL '3' DAY,
    SYSTIMESTAMP - INTERVAL '3' DAY + INTERVAL '4' MINUTE,
    20100, 92.30, 55, 10
);

-- Tino spielt Neon Highway
INSERT INTO spielrunde (
    benutzer_id, level_id, startzeit, endzeit,
    gesamtpunkte, trefferquote, max_combo, anzahl_miss
) VALUES (
    2, 2,
    SYSTIMESTAMP - INTERVAL '5' HOUR,
    SYSTIMESTAMP - INTERVAL '5' HOUR + INTERVAL '3' MINUTE,
    18750, 96.10, 48, 4
);

-- Daniel spielt Tutorial Groove
INSERT INTO spielrunde (
    benutzer_id, level_id, startzeit, endzeit,
    gesamtpunkte, trefferquote, max_combo, anzahl_miss
) VALUES (
    3, 1,
    SYSTIMESTAMP - INTERVAL '10' HOUR,
    SYSTIMESTAMP - INTERVAL '10' HOUR + INTERVAL '2' MINUTE,
    8900, 88.40, 20, 12
);

-- Guest spielt einmal Chaos Rush, sehr schlecht :)
INSERT INTO spielrunde (
    benutzer_id, level_id, startzeit, endzeit,
    gesamtpunkte, trefferquote, max_combo, anzahl_miss
) VALUES (
    4, 3,
    SYSTIMESTAMP - INTERVAL '30' MINUTE,
    SYSTIMESTAMP - INTERVAL '27' MINUTE,
    4500, 65.00, 8, 25
);

COMMIT;
