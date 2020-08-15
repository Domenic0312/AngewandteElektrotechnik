﻿using System;
using KartenDaten;
using Sensoren;
using System.Collections.Generic;
using RescueRobot;

namespace cSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Karte generieren (Karten array fuellen)
            Karte.genKarte();

            distanceSensor distOne = new distanceSensor("SensorgenNorden", 0, 1, 0);

            //Abstand von der Position  nach Norden abfragen
            int distance = distOne.getDistance(100, 160);

            Console.WriteLine("Abstand ist: {0}", distance);

            Robot robot = new Robot();
            robot.distanceSensoren();
            robot.drive();

            PowerTrain power = new PowerTrain();
            power.getBatteryState();

        }
    }
}