using System;
using System.IO;
using System.Collections.Generic; // Für List
using Sensoren;


namespace robotLogik
{
     class Logic
    {

        public int[] move;
        
       
        public void fahren(int _direction, int _distance)
        {
            move = new int[] { _direction, _distance };
        }
        
        public wayPoint getWay(int[] startpos, int[] endPos, List<distanceSensor> sensorik) 
        {
            wayPoint point = calcDirDist(startpos,endPos,sensorik);
            Console.WriteLine("Frage Abstandssensoren in Richtung {0} ab.", point.direction);
            int dist = sensorik[point.direction].getDistance(startpos[0],startpos[1]);


            if(point.distance>0){
                Console.WriteLine("Der Weg vom Startpunkt {0}/{1} zum Endpunkt {2}/{3} ist in Richtung {4} mit der Entfernung {5}", startpos[0], startpos[1], endPos[0], endPos[1], point.direction, point.distance);
                point.reachable = true;            
            }else{
                Console.WriteLine("Der Wegpunkt ist leider nicht erreichbar");
            }
            return point;
        }

        wayPoint calcDirDist(int[] startpos, int[] endPos, List<distanceSensor> sensorik) {
            wayPoint point = new wayPoint();

            int deltaX = startpos[0] - endPos[0];
            int deltaY = startpos[1] - endPos[1];
            int direction = -1;
            int distance = -1;
         

                //X
                if (deltaX > 5)
                {
                    direction = 6;
                    distance = deltaX;
                }
                else if (deltaX < -5)
                {
                    direction = 2;
                    distance = deltaX * -1;
                }
           
           
                //y
                if (deltaY > 5) {
                    direction = 0;
                    distance = deltaY;
                } else if (deltaY < -5) {
                    direction = 4;
                    distance = deltaY * -1;
                } 
           
            point.direction = direction;
            point.distance = distance;

            return point;
        }
    }
    class wayPoint{
        public int direction;
        public int distance;
        public bool reachable = false;
        public int hindernis;
        public wayPoint(int _dir, int _dist){
            direction = _dir;
            distance = _dist;
        }
        public wayPoint(){}
    }
 }