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

            List<distanceSensor> sensorik = new List<distanceSensor>();

            for(int i=0;i<8;i++){
                sensorik.append(new distanceSensor("Name...",0 ,1 , i));
            }


            distanceSensor distOne = new distanceSensor("SensorgenNorden",0,1,0);

            //Abstand von der Position  nach Norden abfragen
            int distance = distOne.getDistance(100,160);

            Console.WriteLine("Abstand ist: {0}",distance);
        }
    }
}