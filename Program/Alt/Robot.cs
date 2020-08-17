using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ComponentModel;
using Sensoren;
namespace asdf //Rueckaendern
{

    class Robot
    {


        public int[] getdirection(int[] startpos)
        {

            //int[] endpos = karte.getEndPos(); // Integer anlegen
            //int[] direction = new int[] { endpos[0] - startpos[0], endpos[1] - startpos[1] };
            //Console.WriteLine("Die Richtung ist:{0},{1}", direction[0], direction[1]);
            return {0};

        }
    }
    class Powertrain
    {
        public int move(int direction, int distance)
        {

            return 0;
        }
        public int getBatteryState()
        {
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