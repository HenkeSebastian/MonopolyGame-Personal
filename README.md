# Monopoly WPF
Monopoly built on WPF


-Persönliches Freizeit Projekt/n
-Aufbau der bekannten Monopoly UI in WPF/XAML.
-Einzelne Fensterinhalte als austauschbare User-Controls.
-Die UI ist durch MVVM von der business logic getrennt.
-Daten werden durch Datenbindung angezeigt.
-Daten wie Spielerliste dürfen nur einzigartig, jedoch nicht statisch, sein.
-In der bisherigen Implementation werden statische Eigenschaften nicht in der UI aktualisiert.
-Somit werden alle wichtigen Klassen nur ein einziges mal instanziert.
-Auf diese Objekte wird über eine Singleton Klasse (WindowContent) zugegriffen.
-Grundlegende Spielregeln von Monopoly implementiert.
-Bisher nur lokaler Mehrspieler / keine computer kontrollierten Gegner.
-Tausch von Spielobjekten noch nicht implementiert.
