using System;
using System.IO;
using System.Collections.Generic; // Für List
using System.Linq;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Globalization;
using Sensoren;
using System.Runtime.CompilerServices;

namespace RescueRobot
{
    class Logic
    {
        public int[] move;
        public void fahren(int _direction, int _distance)
        {
            move = new int[] { _direction, _distance };
        }
        public int[] getdirection(int[] startpos)
        {

            int[] endpos = new int[] { 200, 50 };
            Console.WriteLine("Endposition bzw. Position des Bergungsobjektes ist:{0}", endpos[0]);

            int[] direction = new int[] { endpos[0] - startpos[0], endpos[1] - startpos[1] };
            Console.WriteLine("Die Richtung ist:{0},{1}", direction[0], direction[1]);
            return direction;

        }
    }
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
            int[] dir = logic.getdirection(new int[] { 66, 164 }); //Richtung, Entfernung von Logik
            power.drive(dir[0], dir[1]);

            //int[] move = new int[] { 0, 1 };
            //power.move(new int[] { 0, 1 });
            //int[] drive = new int[] { 0, 10 }; // Richtung 0, Distanz 10 Blöcke
            //PowerTrain.move(new int 0, 10)            
            
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