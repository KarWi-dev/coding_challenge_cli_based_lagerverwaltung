using System;

namespace Lagerverwaltung
{
    class Program
    {
        public struct KistenLager//die struktur für die kisten wird angelegt
        {
            public string KistenID;
            public bool Belegt;
            public int Laenge;
            public int Breite;
            public int Hoehe;
            public void Eingabe(int LagerPlatz)//hier erfolgt die eingabe. "lagerplatz" wird aus main übernommen
            {
                if (Belegt == true)//prüft ob "lagerplatz" bereits belegt ist
                {
                    Fehler();
                }
                else
                {
                    Zeilen();
                    Console.SetCursorPosition(39, 1);//belegt das array auf "lagerplatz" mit den werten
                    KistenID = Console.ReadLine();
                    Console.SetCursorPosition(39, 2);
                    Breite = Convert.ToInt32(Console.ReadLine());
                    Console.SetCursorPosition(39, 3);
                    Laenge = Convert.ToInt32(Console.ReadLine());
                    Console.SetCursorPosition(39, 4);
                    Hoehe = Convert.ToInt32(Console.ReadLine());
                    Belegt = true;
                    Console.Clear();
                }
            }
            public void Anzeige(int LagerPlatz)//hier erfolgt die anzeige. "lagerplatz" wird aus main übernommen
            {
                int Volumen;
                if (Belegt == false)//prüft ob "lagerplatz" belegt ist
                {
                    Console.WriteLine("Dieser Platz ist leer.");
                }
                else
                {
                    Zeilen();
                    Console.SetCursorPosition(39, 1);
                    Console.Write(KistenID);
                    Console.SetCursorPosition(39, 2);
                    Console.Write(Breite);
                    Console.SetCursorPosition(39, 3);
                    Console.Write(Laenge);
                    Console.SetCursorPosition(39, 4);
                    Console.Write(Hoehe);
                    Volumen = (Breite * Laenge * Hoehe);
                    Console.WriteLine($"\nVolumen in mm:                        [{Volumen}");
                }
            } 
            public void Loeschen (int LagerPlatz)
            {
                Belegt = false;
                KistenID = "";
                Breite = 0;
                Laenge = 0;
                Hoehe = 0;                
            }
            public void AutoFill(int LagerPlatz)//füllt alle basierend auf "lagerplatz"
            {
                Belegt = true;
                KistenID = Convert.ToString(LagerPlatz);
                Breite = LagerPlatz;
                Laenge = LagerPlatz;
                Hoehe = LagerPlatz;
            }
            public void ShowAll(int LagerPlatz)
            {
                if (Belegt == true)//prüft ob lagerplatz belegt ist
                {
                    Console.WriteLine($"\nLagerplatz:\t[{LagerPlatz}");
                    Console.WriteLine($"Kisten ID:\t[{KistenID}");//zeigt den eintrag an wenn er belegt ist
                    Console.WriteLine($"Breite:\t\t[{Breite}");
                    Console.WriteLine($"Länge:\t\t[{Laenge}");
                    Console.WriteLine($"Höhe:\t\t[{Hoehe}");
                    int Volumen = (Breite * Laenge * Hoehe);
                    Console.WriteLine($"\nVolumen in mm:\t[{Volumen}");
                    Console.WriteLine("\n+-----------------------------+");
                }
            }
        } //hier mehr zeugs das die struct nutzt hin
        static void Zeilen()//schreibt das gui für die eingabe
        {
            Rahmen();
            Console.SetCursorPosition(0, 1);
            Console.Write("Bitte KistenID eingeben:              [\n");//1. leer auf 40
            Console.Write("Bitte Kisten Breite in mm eingeben:   [\n");
            Console.Write("Bitte Kisten Länge in mm eingeben:    [\n");
            Console.Write("Bitte Kisten Höhe in mm eingeben:     [\n");
        }
        static int Optionen(int Auswahl)//hier wird ausgewählt was der user machen möchte.
        {
            Rahmen();
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Welche Operation möchten sie auführen?\n\nNeuer Eintrag\t\t[1]\nEinträge anzeigen\t[2]\nEintrag Ändern\t\t[3]\nEinträge löschen\t[4]\n\nProgramm beenden\t[5]\nAutoFill\t\t[6]");
            return(Auswahl = Convert.ToInt32(Console.ReadLine()));//einlesen der user eingabe und rückgabe der "auswahl" an main
        }
        static void Rahmen()//zeichnet den hübschen rahmen um alles
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("+---PoorMansSAP--------------------------------------------------------------------+");            
        }
        static void Fehler()//fehlermeldung für platz belegt; ungultige eingaben oder sonstiges
        {
            Console.Clear();
            Rahmen();
            Console.CursorVisible = false;//hübscher
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Fehler '42'");
            Console.ReadLine();
            Console.Clear();
            Console.CursorVisible = true;
        }
        static void Main(string[] args)
        {
            int Auswahl = 0;// menüauswahl des users
            int AuswahlAnzeige = 0;
            int LagerPlatz;//lagerplatz
            bool Stop = false;//stop
            KistenLager[] Kisten = new KistenLager[75];//initialisierung des arrays "kisten" in "kistenlager"
            Rahmen();
            do
            {                
                Auswahl = Optionen(Auswahl);//auswahl der option
                Console.Clear();
                Rahmen();
                switch (Auswahl)//verarbeitung der usereingabe
                {
                    case 1:
                        Console.SetCursorPosition(0, 1);//erstellen
                        Console.Write("Bitte Lagerplatz wählen(0-74):");//muss hier weil in funktion is zu spääääät
                        LagerPlatz = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        if (LagerPlatz < 0 || LagerPlatz > 74)//testet auf ungültige eingaben
                        {
                            Fehler();
                        }
                        else
                        {
                            Kisten[LagerPlatz].Eingabe(LagerPlatz);//ruft eingabe im array "kisten" in position der usereingabe auf
                        }                                          // und übergibt wert "Lagerplatz" an die funktion "eingabe"
                        break;

                    case 2://anzeigen  

                        do
                        {
                            Rahmen();
                            Console.SetCursorPosition(0, 1);
                            Console.Write("Welchen Lagerplatz anzeigen? (0-74)");
                            Console.Write("\n[99] eingeben für alle Einträge\n[88] eingeben um nach ID zu suchen:");
                            LagerPlatz = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (LagerPlatz == 88)//id suche
                            {
                                Console.Clear();
                                Console.WriteLine("Bitte Gesuchte ID eingeben:");
                                string GesID = Console.ReadLine();
                                for (int i = 0; i < 75; i++)
                                {
                                    LagerPlatz = i;
                                    if (Kisten[LagerPlatz].KistenID == GesID)
                                    {
                                        Console.Clear();
                                        Kisten[LagerPlatz].Anzeige(LagerPlatz);
                                        Console.WriteLine("\nBeliebige Taste zum fortfahren.");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                                break;
                            }
                            else if (LagerPlatz == 99)//Alle einträge anzeigen lassen
                            {
                                Rahmen();
                                for (int i = 0; i < 75; i++)//zählt alle eintrage im array "kisten" durch
                                {
                                    LagerPlatz = i;
                                    Kisten[LagerPlatz].ShowAll(LagerPlatz);
                                }
                                Console.WriteLine("\nBeliebige Taste Zum Fortfahren.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else if (LagerPlatz < 0 || LagerPlatz > 74)//alle einträge mit "belegt" TRUE anzeigen lassen
                            {
                                Fehler();
                            }
                            else
                            {
                                Kisten[LagerPlatz].Anzeige(LagerPlatz);
                                Console.Write("\n\nDiesen eintrag ändern:                [1]\n");
                                Console.Write("Neue Suche:                           [2]\n");
                                Console.Write("Zurück zum Hauptmenü:                 [3]\n");
                                AuswahlAnzeige = Convert.ToInt32(Console.ReadLine());
                                switch (AuswahlAnzeige)
                                {
                                    case 1://diesen eintrag ändern
                                        Kisten[LagerPlatz].Belegt = false;
                                        Kisten[LagerPlatz].Eingabe(LagerPlatz);
                                        Console.Clear();
                                        Kisten[LagerPlatz].Anzeige(LagerPlatz);
                                        Console.Write("\n\nNeue Suche:                           [2]\n");
                                        Console.Write("Zurück zum Hauptmenü:                 [3]\n");
                                        AuswahlAnzeige = Convert.ToInt32(Console.ReadLine());
                                        Console.Clear();
                                        break;
                                    case 2://neue suche
                                        Console.Clear();
                                        break;
                                    case 3://Hauptmenü
                                        Console.Clear();
                                        break;
                                    default:
                                        Fehler();
                                        break;
                                }
                            }
                        } while (AuswahlAnzeige != 3);//case 2 und 3 können wegen der abfrage hier das selbe sein. bei 2 geht die schleife weiter
                        break;                        //und bei 3 wird die switch anweisung verlassen
                        
                    case 3://ändern
                        Console.SetCursorPosition(0, 1);
                        Console.Write("Bitte Lagerplatz wählen(0-74):");
                        LagerPlatz = Convert.ToInt32(Console.ReadLine());
                        if (LagerPlatz < 0 || LagerPlatz > 74)//testet auf ungültige eingaben
                        {
                            Fehler();
                        }
                        else
                        {                            
                            Kisten[LagerPlatz].Belegt = false;//ändert "belegt" für den gewählten lagerplatz damit es mit "eingabe" geändert werden kann
                            Kisten[LagerPlatz].Eingabe(LagerPlatz);//Ändern==eingabe :D
                        }
                        break;

                    case 4://löschen
                        Console.SetCursorPosition(0, 1);
                        Console.Write("Bitte Lagerplatz wählen(0-74)\n[99] um alle einträge zu löschen:");
                        LagerPlatz = Convert.ToInt32(Console.ReadLine());
                        if (LagerPlatz == 99)
                        {
                            Console.Clear();
                            Rahmen();
                            Console.WriteLine("\n\nSind sie sicher? J/n");
                            string bla = Console.ReadLine();
                            if (bla == "j" || bla == "J")
                            {
                                for (int i = 0; i < 75; i++)
                                {
                                    LagerPlatz = i;
                                    Kisten[LagerPlatz].Loeschen(LagerPlatz);
                                }
                            }
                            Console.Clear();
                            break;
                        }
                        else if (LagerPlatz < 0 || LagerPlatz > 74)//testet auf ungültige eingaben
                        {
                            Fehler();
                        }
                        else
                        {
                            Kisten[LagerPlatz].Loeschen(LagerPlatz);
                        }
                        break;

                    case 5:
                        Stop = true;//beendet das programm
                        Console.Clear();
                        break;

                    case 6://einfacher autofill auf basis von "lagerplatz" für debugging
                        for (int i = 0; i < 75; i++)
                        {
                            LagerPlatz = i;
                            Kisten[LagerPlatz].AutoFill(LagerPlatz);//übergibt bei jedem durchlauf "lagerplatz" um einen erhöht um so alle stellen zu füllen
                        }
                        break;
                }
            } while (Stop == false);            
        }
    }
}