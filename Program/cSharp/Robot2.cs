using System;
using System.IO;
using System.Collections.Generic; // Für List
using System.Linq;
using KartenDaten;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Globalization;
using Sensoren;

namespace RescuteRobot
{

    class Robot
    {

        public void distanceSensoren()
        {
            var sensorik = new List<distanceSensor>
            {
                new distanceSensor() { Name="Nord", pin1=1, pin2=2, direction=1},
                new distanceSensor() { Name="Nordost", pin1=3, pin2=4, direction=2},
                new distanceSensor() { Name="Ost", pin1=5, pin2=6, direction=3},
                new distanceSensor() { Name="Ostsüd", pin1=7, pin2=8, direction=4},
                new distanceSensor() { Name="Süd", pin1=9, pin2=10, direction=5},
                new distanceSensor() { Name="Südwest", pin1=11, pin2=12, direction=6},
                new distanceSensor() { Name="West", pin1=13, pin2=14, direction=7},
                new distanceSensor() { Name="Nordwest", pin1=15, pin2=16, direction=8}
            };
            foreach (distanceSensor sensorik in sensorik)
            {
                Console.WriteLine(Sensor: distanceSensor.Name + "" + distanceSensor.pin1 + "" + distanceSensor.pin2 + distanceSensor.direction);
            }
        }
        public class distancesensor
        {
            public string Name { get; set; }
            public int pin1 { get; set; }
            public int pin2 { get; set; }
            public int direction { get; set; }
        }



        public List<distanceSensor> sensorik = new List<distanceSensor>(string name, int pin1, int pin2, int direction)
        {
            new distanceSensor() { Name="Nord", pin1=1, pin2=2, direction=1},
            
        };

      

        public int distanceSensoren(int pin1, int pin2, int direction)
        {
            

            List<distanceSensor> sensorik = new List<distanceSensor>();

            //sensorik.Add(new distanceSensor() { pin1=1, pin2=2, direction=0});

            for (int i = 0; i < 8; i++)
             {
                 sensorik.Append(new distanceSensor("Name...", 0, 1, i));   // 8 Sensoren
             }
            
           


            return 0;
        }

      

        public int[] getdirection(int[] startpos)
        {

            int[] endpos = new int[]{ 200, 50 }; 
            Console.WriteLine("Endposition bzw. Position des Bergungsobjektes ist:{0}", endpos[0]);

            int[] direction = new int[] { endpos[0] - startpos[0], endpos[1] - startpos[1] };
            Console.WriteLine("Die Richtung ist:{0},{1}", direction[0], direction[1]);
            return direction;

        }
    }
    class PowerTrain
    {
        int[] motors;
        int batteryState;
        
        public int move(int direction, int distance)
        {

            return 0;
        }
        public int getBatteryState()
        {
            //int state = battery.getState();
            // float battery = sensor.getBatteryState();
            return 0;
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