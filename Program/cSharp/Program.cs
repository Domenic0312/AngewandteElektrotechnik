using System;
using KartenDaten;

namespace cSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Kartenobjekt erzeugen
            Karte karte = new Karte();

            //Karte generieren (Karten array fuellen)
            karte.genKarte();


            Console.WriteLine(karte.getDistance(44,65,0));
        }
    }
}
