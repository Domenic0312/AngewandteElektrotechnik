using System;
using KartenDaten;

namespace cSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kartenobjekt erzeugen
            Karte karte = new Karte();

            //Karte generieren (Karten array fuellen)
            karte.genKarte();
            //Abstand von der Position 44/65 nach Norden abfragen
            int distance = karte.getDistance(66,164,4);
            Console.WriteLine("Abstand ist: {0}",distance);
        }
    }
}