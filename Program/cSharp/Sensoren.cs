using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using KartenDaten;

namespace Sensoren
{
    class sensor{
        public int[] Pins;
        public String Name;

        public void connect(){
            Console.WriteLine("Verbindung zu Sensor {0} wurde aufgebaut. Pins: {1},{2}", Name, Pins[0], Pins[1]);
        }
        public void disconnect(){
            Console.WriteLine("Verbindung zu Sensor {0} wurde beendet. Pins: {1},{2}", Name, Pins[0], Pins[1]);
        }
    }
    class radioSensor:sensor{
        public radioSensor(String _Name, int _pinOne, int _pinTwo){
            Name = _Name;
        }
    }
    class battery:sensor{
        int wert;

        public battery(String _Name, int pinOne, int pinTwo){
            Name = _Name;
            Pins _= new int[]{pinOne, pinTwo};

        }
        public int getState(){

            return 75;
        }
    }
    class distanceSensor:sensor{
        int viewDirection = 0;
        public distanceSensor(String _Name, int _pinOne, int _pinTwo, int _viewDirection){
            Name = _Name;
            Pins = new int[]{_pinOne,_pinTwo};
            viewDirection = _viewDirection;
            connect();
        }
        public int getDistance(int posX, int posY){
            return Karte.getDistance(posX, posY, viewDirection);
        }
    }
}