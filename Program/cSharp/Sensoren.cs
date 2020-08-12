using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Sensoren
{
    class sensor{
        public int[] Pins;
        public String Name;

        void connect(){
            Console.WriteLine("Verbindung zu Sensor {0} wurde aufgebaut. Pins: {1},{2}", Name, Pins[0], Pins[1]);
        }
        void disconnect(){
            Console.WriteLine("Verbindung zu Sensor {0} wurde beendet. Pins: {1},{2}", Name, Pins[0], Pins[1]);
        }
    }
    class radioSensor:sensor{
        public radioSensor(String _Name, int _pinOne, int _pinTwo){
            Name = _Name;
        }
    }
    class battery:sensor{

    }
    class distanceSensors:sensor{

    }
}