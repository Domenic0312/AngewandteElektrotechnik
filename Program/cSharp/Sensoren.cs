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
            Console.WriteLine(
            "Verbindung aufgebaut") ;               //zu Sensor {0} wurde aufgebaut. Pins: {1},{2}",Name, Pins[0], Pins[1]);
        }
        public void disconnect(){
            Console.WriteLine(
                "Verbindung geschlossen");            //zu Sensor {0} wurde beendet. Pins: {1},{2}", Name, Pins[0], Pins[1]);
        }
    }
    
    class radioSensor:sensor{
        public radioSensor(String _Name, int _pinOne, int _pinTwo){
            Name = _Name;
            Pins = new int[]{_pinOne, _pinTwo};
            connect();
        }
        public List<referenzPunkte> getRefPoint()
        {
            
            return Karte.refPunkte;
        }
    }
    class waterSensor:sensor{
        public waterSensor(String _Name, int _pinOne, int _pinTwo){
            Name = _Name;
            Pins = new int[]{_pinOne, _pinTwo};
            connect();
        }
        public string isWater(int posX, int posY){
            string terrain = Karte.getTerrain(posX, posY);
            return terrain;
        }
    }

    class battery:sensor{
        int wert = 75;

        public battery(String _Name, int pinOne, int pinTwo){
            Name = _Name;
            Pins = new int[]{pinOne, pinTwo};
            connect();
        }
        public int getState(){
            return wert;
        }
    }
    class distanceSensor:sensor{
        public int viewDirection = 0;
        public distanceSensor(String _Name, int _pinOne, int _pinTwo, int _viewDirection){
            Name = _Name;
            Pins = new int[]{_pinOne,_pinTwo};
            viewDirection = _viewDirection;
            connect();
        }

        public distanceSensor(){}
        public int getDistance(int posX, int posY){
            int dist = Karte.getDistance(posX, posY, viewDirection);
            Console.WriteLine("Abstand von Position {0}/{1} in Richtung {2} ist {3}",posX, posY, viewDirection, dist);
            return dist;
        }
    }
}