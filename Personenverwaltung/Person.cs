namespace Personenverwaltung
{
    class Person // Klasse zur Definition einer Person
    {
        // Keine Setter da die Werte momentan nicht verändert werden sollen
        public string Vorname { get; } // Getter für den Vornamen
        public string Nachname { get; } // Getter für den Nachnamen
        public int Alter { get; } // Getter für das Alter
        public string Telefonnummer { get; } // Getter für die Telefonnummer

        public Person(string vorname, string nachname, int alter, string telefonnummer) // Konstruktor
        {
            Vorname = vorname;
            Nachname = nachname;
            Alter = alter;
            Telefonnummer = telefonnummer;
        }

        public override string ToString() // Überschreiben der ToString-Methode
        {
            return $"{Vorname} {Nachname}, Alter: {Alter}, Telefonnummer: {Telefonnummer}"; // Formatierte Ausgabe
        }
    }
}
