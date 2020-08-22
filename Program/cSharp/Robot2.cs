using System;
using System.IO;
using System.Collections.Generic; // Für List
using System.Linq;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Globalization;
using Sensoren;
using System.Runtime.CompilerServices;
using robotLogik;
using KartenDaten;

namespace RescueRobot
{
    
    class Robot
    {
        int gesamtWeg;
        PowerTrain power = new PowerTrain();
        Logic logic = new Logic();
        /*
        7   0   1
        6       2
        5   4   3
        */
        List<distanceSensor> sensorik = new List<distanceSensor>();
        waterSensor water;
        radioSensor radioPlace;
        public void makeSensors()
        {
            Console.WriteLine("---- Sensoren Verbinden ----\n");

            sensorik.Add(new distanceSensor("Nord", 1, 2, 0));
            sensorik.Add(new distanceSensor("Nordost", 3, 4, 1));
            sensorik.Add(new distanceSensor("Ost", 5, 6, 2));
            sensorik.Add(new distanceSensor("Südost", 7, 8, 3));
            sensorik.Add(new distanceSensor("Süd", 9, 10, 4));
            sensorik.Add(new distanceSensor("Südwest", 11, 12, 5));
            sensorik.Add(new distanceSensor("West", 13, 14, 6));
            sensorik.Add(new distanceSensor("Nordwest", 15, 16, 7));

            foreach (distanceSensor sensor in sensorik)
            {
                Console.WriteLine("Sensor:" + sensor.Name + ";" + sensor.Pins[0] + ";" + sensor.Pins[1] + ";" + sensor.viewDirection);
            }
            water = new waterSensor("Wasser Sensor",17,18);
            radioPlace = new radioSensor("Radio Sensor", 19, 20);

            Console.WriteLine("---- Sensoren wurden verbunden ----\n");
        }

        
        public void drive() 
        {
            radioPlace.getRefPoint();
            List<referenzPunkte> refPunkte = radioPlace.getRefPoint();
            Random rnd = new Random();
            int wert = rnd.Next(0, 2);
            
            if(wert == 0)
            {
                Console.WriteLine("---- Fahre den kurzen Weg ----");
                shortWay(refPunkte);
                Console.WriteLine("Person erfolgreich geborgen und am Startpunkt zurück!");
                Console.WriteLine("\n---- Mission erfolgreich beendet ----");
            }
            else
            {
                Console.WriteLine("---- Fahre den langen Weg ----");
                longWay(refPunkte);
                Console.WriteLine("Person erfolgreich geborgen und am Startpunkt zurück!");
                Console.WriteLine("\n---- Mission erfolgreich beendet ----");
            }
        }

        public void shortWay(List<referenzPunkte> refPunkte)
        {            
            Console.WriteLine("");
            fahreVonBis(new int[] { refPunkte[3].x, refPunkte[3].y }, new int[] { refPunkte[2].x, refPunkte[2].y }, sensorik);
            Console.WriteLine("\nBei Person angekommen. Person wurde als Albert identifiziert.\n Steuerung wird an Hauptquartier übergeben (Live Steuerung).");
            fahreVonBis(new int[] { refPunkte[2].x, refPunkte[2].y }, new int[] { refPunkte[3].x, refPunkte[3].y }, sensorik);
            Console.WriteLine("\nFahrweg: {0} Blöcke", gesamtWeg);
        }

        bool fahreVonBis(int[] startpos, int[] endPos, List<distanceSensor> sensorik){
            Console.WriteLine("");
            wayPoint p4 = logic.getWay(startpos, endPos, sensorik); // Rescue Object -> Startposition
            gesamtWeg += p4.distance;
            power.drive(startpos[0], startpos[1], p4.direction, p4.distance, water);
            return true;
        }
        public void longWay(List<referenzPunkte> refPunkte)
        {
            Console.WriteLine("");
            fahreVonBis(new int[] { 72, 157 }, new int[] { refPunkte[0].x, refPunkte[0].y }, sensorik);
            fahreVonBis(new int[] { refPunkte[0].x, refPunkte[0].y }, new int[] { refPunkte[1].x, refPunkte[1].y }, sensorik);
            fahreVonBis(new int[] { refPunkte[1].x, refPunkte[1].y }, new int[] { refPunkte[2].x, refPunkte[2].y }, sensorik);
            Console.WriteLine("\nBei Person angekommen. Person wurde als Heinrich identifiziert.\nSteuerung wird an Hauptquartier übergeben (Live Steuerung).");
            fahreVonBis(new int[] { refPunkte[2].x, refPunkte[2].y }, new int[] { refPunkte[3].x, refPunkte[3].y }, sensorik);
            Console.WriteLine("Fahrweg: {0} Blöcke", gesamtWeg);
        }
    }


    class PowerTrain
    {
        Motor motor = new Motor();
        //ADD Methodenzugriff
        waterJet waterAntrieb = new waterJet();
        int[] motors;
        int batteryState;

        public int drive(int posX, int posY, int direction, int distance, waterSensor water) 
        {
            bool warWasser = false;
            switch(direction){
                case 2:
                    for(int i=posX;i<(posX+distance);i++){
                        //Nach rechts
                        string ter = water.isWater(i, posY);
                        if (ter == "1"){
                            Console.WriteLine("\tHinderniss bei Koordinate {0}/{1} wird entfernt", i, posY);
                        }
                        if(!warWasser && ter == "2"){//Wenn noch kein Wasser war nach wasser suchen
                            Console.WriteLine("\tFahre im Wasser ab Koord: {0}/{1}", i, posY);
                            warWasser = true;
                        }else{
                            if(warWasser && !(ter == "2") && !(ter == "1")){
                                Console.WriteLine("\tLand ab Koord: {0}/{1}",i,posY);
                                warWasser =false;
                            }
                        }
                    }
                    break;
                case 6:
                    for(int i=posX;i>(posX-distance);i--){
                        //Nach rechts
                        string ter = water.isWater(i, posY);
                        if (ter == "1"){
                            Console.WriteLine("\tHinderniss bei Koordinate {0}/{1} wird entfernt", i, posY);
                        }
                        if(!warWasser && ter == "2"){//Wenn noch kein Wasser war nach wasser suchen
                            Console.WriteLine("\tFahre im Wasser ab Koord: {0}/{1}", i, posY);
                            warWasser = true;
                        }else{
                            if(warWasser && !(ter == "2") && !(ter == "1")){
                                Console.WriteLine("\tLand ab Koord: {0}/{1}",i,posY);
                                warWasser =false;
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine("\tFahrzeug ist auf Land unterwegs.");
                    motor.rotate(5, 10);
                    break;
            }
            return 0;
        }
        public int getBatteryState()
        {
            battery battery = new battery("Batteriesensor", 26, 27);
            Console.WriteLine("Batteriestatus:{0} %", battery.getState());
            return battery.getState();
        }
    }
    class waterJet{
 
        int[] pins;
        public int rotate(int dist)
        {
            Console.WriteLine("\tWasserAntrieb treibt an.");
            return 0;
        }
    }


    class Motor
    {
      
        int[] pins;
        public int rotate(int rpm, int revolution)
        {
            Console.WriteLine("\tAntriebsmotor dreht sich.");
            return 0;
        }

    }
    
}