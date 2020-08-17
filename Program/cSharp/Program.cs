using System;
using KartenDaten;
using RescueRobot;
namespace cSharp
{
    class Program
    {
        
        static void Main(string[] args)
        {

            //Karte generieren (Karten array fuellen)
            Karte.genKarte();
            Robot rob = new Robot();
            rob.distanceSensoren();
            rob.drive();
        }
    }
}