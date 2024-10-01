using System;
using System.Collections.Generic;

namespace Personenverwaltung
{
    class PersonenManager // Klasse zur Verwaltung der Personen
    {
        private List<Person> personen; // Liste zur Speicherung der Personen

        public PersonenManager()
        {
            personen = new List<Person>(); // Initialisieren der Personenliste
        }

        public void Start() // Hauptmenü starten
        {
            while (true)
            {
                ZeigeMenue(); // Menü anzeigen
                string auswahl = Console.ReadLine(); // Benutzerwahl einlesen

                switch (auswahl)
                {
                    case "1":
                        NeuePersonErstellen(); // Neue Person anlegen
                        break;
                    case "2":
                        PersonenNachAlterFiltern(); // Personen nach Alter anzeigen
                        break;
                    case "3":
                        AlleEintraegeAnzeigen(); // Alle Einträge anzeigen
                        break;
                    case "4":
                        Console.WriteLine("Programm wird beendet...");
                        return; // Programm beenden
                    default:
                        Console.WriteLine("Ungültige Option. Bitte erneut wählen."); // Fehlermeldung
                        break;
                }
                Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren...");
                Console.ReadKey(); // Warten auf Benutzereingabe
            }
        }

        private void ZeigeMenue() // Methode zur Anzeige des Menüs
        {
            Console.Clear(); // Bildschirm löschen
            Console.WriteLine("=== Personenverwaltung ===");
            Console.WriteLine("1. Person anlegen");
            Console.WriteLine("2. Personen nach Alter anzeigen");
            Console.WriteLine("3. Alle Einträge anzeigen");
            Console.WriteLine("4. Programm beenden");
            Console.Write("Wähle eine Option: ");
        }

        private void NeuePersonErstellen() // Methode zur Erstellung einer neuen Person
        {
            if (personen.Count >= 10) // Überprüfen, ob die maximale Anzahl erreicht ist
            {
                Console.WriteLine("Maximale Anzahl von 10 Personen erreicht.");
                return; // Frühes Beenden der Methode
            }

            string vorname = EingabeMitValidierung("Vorname: ", false);
            string nachname = EingabeMitValidierung("Nachname: ", false);
            int alter = EingabeMitValidierung("Alter: ");
            string telefonnummer = EingabeMitValidierung("Telefonnummer: ", false);

            personen.Add(new Person(vorname, nachname, alter, telefonnummer)); // Neue Person zur Liste hinzufügen
            Console.WriteLine("Person erfolgreich hinzugefügt."); // Rückmeldung an den Benutzer
        }

        private void PersonenNachAlterFiltern() // Methode zum Anzeigen von Personen nach Alter
        {
            int alter = EingabeMitValidierung("Geben Sie das Alter zum Filtern ein: ", true, eingabe);
            Console.WriteLine($"Personen unter {alter} Jahren:");
            bool gefunden = false; // Flag zur Überprüfung, ob Personen gefunden wurden

            foreach (var person in personen) // Alle Personen durchgehen
            {
                if (person.Alter < alter) // Überprüfen, ob die Person jünger ist
                {
                    Console.WriteLine(person); // Person ausgeben
                    gefunden = true;
                }
            }

            if (!gefunden) // Wenn keine Personen gefunden wurden
            {
                Console.WriteLine("Keine Personen gefunden, die diese Bedingung erfüllen.");
            }
        }

        private void AlleEintraegeAnzeigen() // Methode zum Anzeigen aller Personen
        {
            if (personen.Count == 0) // Überprüfen, ob die Liste leer ist
            {
                Console.WriteLine("Es gibt keine Einträge zu zeigen."); // Rückmeldung an den Benutzer
                return;
            }

            Console.WriteLine("Alle Personen:");
            foreach (var person in personen) // Durch alle Personen iterieren
            {
                Console.WriteLine(person); // Jede Person ausgeben
            }
        }

        private String EingabeMitValidierung(string nachricht, bool istZahl) // Eingabevalidierung für String
        {
            while (true) // Solange wiederholen, bis eine gültige Eingabe erfolgt
            {
                Console.Write(nachricht);
                string eingabe = Console.ReadLine(); // Eingabe lesen

                if (!string.IsNullOrWhiteSpace(eingabe)) // Überprüfen, ob die Eingabe nicht leer ist
                {
                    return eingabe; // Rückgabe der Eingabe
                }
                Console.WriteLine("Bitte geben Sie einen gültigen Wert ein."); // Fehlermeldung
            }
        }
        private int EingabeMitValidierung(string nachricht) // Eingabevalidierung für Zahlen
        {
            while (true) // Solange wiederholen, bis eine gültige Eingabe erfolgt
            {
                Console.Write(nachricht);
                string eingabe = Console.ReadLine(); // Eingabe lesen

                if (int.TryParse(eingabe, out int zahl) && zahl >= 0) // Überprüfen, ob es eine gültige positive Zahl ist
                {
                    return zahl; // Rückgabe der Zahl
                }
                Console.WriteLine("Bitte geben Sie eine gültige positive Zahl ein."); // Fehlermeldung
            }
        }
    }
}
