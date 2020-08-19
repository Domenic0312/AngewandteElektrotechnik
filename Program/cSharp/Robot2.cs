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

namespace RescueRobot
{

    class Robot
    {
        PowerTrain power = new PowerTrain();
        Logic logic = new Logic();
        /*
        7   0   1
        6       2
        5   4   3
        */
        List<distanceSensor> sensorik = new List<distanceSensor>();
        waterSensor water;
        public void makeSensors()
        {

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

        }


        public void drive() 
        {
            Console.WriteLine("");
            wayPoint p1 = logic.getWay(new int[] { 66, 164 },new int[] { 66, 159}, sensorik ); //Richtung, Entfernung von Logik
            if(p1.reachable){
                //Dahin fahren
                power.drive(66,164,p1.direction, p1.distance, water);
            }
            Console.WriteLine("");
            wayPoint p2 = logic.getWay(new int[] { 66, 159 },new int[] { 71, 159}, sensorik );
            if(p2.reachable){
                //Dahin fahren
                power.drive(66,159,p2.direction, p2.distance, water);
            }
            Console.WriteLine("");
            wayPoint p3 = logic.getWay(new int[] { 71, 159 },new int[] { 71, 164}, sensorik );
            if(p3.reachable){
                //Dahin fahren
                power.drive(71,159,p3.direction, p3.distance, water);
            }
            Console.WriteLine("");
            wayPoint p4 = logic.getWay(new int[] { 71, 164 },new int[] { 66, 164}, sensorik );
            if(p4.reachable){
                //Dahin fahren
                power.drive(71,164,p4.direction, p4.distance, water);
            }
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
            if(water.isWater(posX, posY, direction) ){
                Console.WriteLine("\tFahrzeug ist in Wasser unterwegs.");
                waterAntrieb.rotate(distance);
            }else{
                Console.WriteLine("\tFahrzeug ist auf Land unterwegs.");
                motor.rotate(5, 10);
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