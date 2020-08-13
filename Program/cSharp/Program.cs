using System;
using KartenDaten;
using Sensoren;

namespace cSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Karte generieren (Karten array fuellen)
            Karte.genKarte();

            distanceSensor distOne = new distanceSensor("SensorgenNorden",0,1,0);

            //Abstand von der Position 44/65 nach Norden abfragen
            int distance = distOne.getDistance(66,164);
            Console.WriteLine("Abstand ist: {0}",distance);
        }
    }
}