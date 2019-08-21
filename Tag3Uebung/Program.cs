using System;


namespace Tag3Uebung
{
    class Program
    {
        static void Main(string[] args)
        {
            String eingabeZahl = "";
            Int16 zahl1 = 0;
            Int16 zahl2 = 0;
            Int16 ergebnis = 0;
            Int16 zahl3 = 0;
            Double zahl4 = 0.0;
            Boolean ersteZahlOK = false;
            Boolean zweiteZahlOK = false;
            Boolean dritteZahlOK = false;
            Boolean vierteZahlOK = false;

            // 32767 ist die groesste Zahl die eingegeben werden kann bei Int16

            Console.WriteLine("Programmspielerein mit try catch");
            Console.WriteLine();

            // Lass den User solange ne Zahl eingeben, bis eine "korrekte" Zahl eingegeben wird
            while (ersteZahlOK == false)
            {
                Console.Write("\nGib die erste Zahl ein: ");
                eingabeZahl = Console.ReadLine();

                try
                {
                    zahl1 = Int16.Parse(eingabeZahl);
                    ersteZahlOK = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n Ups, da hat etwas nicht geklappt...");
                    Console.WriteLine("{0},  {1}", ex.GetType(), ex.Message);
                    Console.WriteLine("\nVersuche es erneut...");
                    ersteZahlOK = false;
                }
            }


            // Lass den User solange ne Zahl eingeben, bis eine "korrekte" Zahl  eingegeben wird
            while (zweiteZahlOK == false)
            {
                Console.Write("\nGib die zweite Zahl ein: ");
                eingabeZahl = Console.ReadLine();


                try
                {
                    zahl2 = Int16.Parse(eingabeZahl);

                    // Prüfe wie groß die zweite Zahl maxinal sein kann,
                    // weil wegen Overflow bei der Addition

                    Int16 tempZahl = (Int16) (Int16.MaxValue - zahl1);

                    if(zahl2 > tempZahl)
                    {
                        Console.WriteLine("\nDie groesste Zahl die du eingeben kannst ist {0} ", tempZahl);
                        zweiteZahlOK = false;
                    }
                    else
                    {
                        zweiteZahlOK = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nUps, da hat etwas nicht geklappt...");
                    Console.WriteLine("{0},  {1}", ex.GetType(), ex.Message);
                    Console.WriteLine("\nVersuche es erneut...");
                    zweiteZahlOK = false;
                }
            }


            try
            {
                // Prüfe ob ein Überlauf stattgefunden hat und wenn ja => Fehlerbehandlung
                checked
                {
                    ergebnis = (Int16)(zahl1 + zahl2);
                    Console.WriteLine("\nDie Summe von {0} und {1} ist {2}", zahl1, zahl2, ergebnis);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("\nUps, da hat etwas nicht geklappt...");
                Console.WriteLine("{0},  {1}", ex.GetType(), ex.Message);
            }


            while (!dritteZahlOK)
            {
                Console.Write("\nGib mal ne Zahl ein: ");
                eingabeZahl = Console.ReadLine();
                dritteZahlOK = Int16.TryParse(eingabeZahl, out zahl3);

                if (dritteZahlOK)
                {
                    Console.WriteLine("Dritte Zahl war OK");
                    Console.WriteLine("Die Eingabe war {0}", eingabeZahl);
                }
                else
                {
                    Console.WriteLine("Dritte Zahl war NICHT OK");
                    Console.WriteLine("Die Eingabe war {0}", eingabeZahl);
                }
            }



            while (!vierteZahlOK)
            {
                Console.Write("\nGib mal Komma-Zahl ein Achtung zb 3,3: ");
                eingabeZahl = Console.ReadLine();
                //eingabeZahl = "3,3";
                vierteZahlOK = Double.TryParse(eingabeZahl, out zahl4);

                if (vierteZahlOK)
                {
                    Console.WriteLine("Komma-Zahl war OK");
                    Console.WriteLine("Die Eingabe war {0}", eingabeZahl);
                }
                else
                {
                    Console.WriteLine("Komma-Zahl war NICHT OK");
                    Console.WriteLine("Die Eingabe war {0}", eingabeZahl);
                }
            }



            double dErgbnis = zahl4 + 2.1;

            Console.WriteLine("Rechne deine zahl + 2,1: {0}", dErgbnis);


            Console.WriteLine("Drücke eine beliebige Taste zum Beenden....");
            Console.ReadKey();
        }
    }
}
