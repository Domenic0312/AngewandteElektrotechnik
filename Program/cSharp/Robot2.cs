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

        public void distanceSensoren()
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
        }


        public void drive() 
        {
            wayPoint p1 = logic.getWay(new int[] { 66, 164 },new int[] { 66, 159}, sensorik ); //Richtung, Entfernung von Logik
            if(p1.reachable){
                //Dahin fahren
            }
            wayPoint p2 = logic.getWay(new int[] { 66, 159 },new int[] { 71, 159}, sensorik );
            if(p2.reachable){
                //Dahin fahren
            }
            wayPoint p3 = logic.getWay(new int[] { 71, 159 },new int[] { 71, 164}, sensorik );
            if(p3.reachable){
                //Dahin fahren
            }
            wayPoint p4 = logic.getWay(new int[] { 71, 164 },new int[] { 66, 164}, sensorik );
            if(p4.reachable){
                //Dahin fahren
            }
        }
    }

    class PowerTrain
    {
        Motor motor = new Motor();
        //ADD Methodenzugriff

        int[] motors;
        int batteryState;

        public int drive(int direction, int distance) 
        {
            Console.WriteLine("Bewege dich in Richtung: {0}{2}", direction, distance);
            motor.rotate(5, 10);
            return 0;
        }
        public int getBatteryState()
        {
            battery battery = new battery("Batteriesensor", 26, 27);
            Console.WriteLine("Batteriestatus:{0} %", battery.getState());
            return battery.getState();
        }
    }
    class Motor
    {
      
        int[] pins;
        public int rotate(int rpm, int revolution)
        {
            
            return 0;
        }

    }
    
}