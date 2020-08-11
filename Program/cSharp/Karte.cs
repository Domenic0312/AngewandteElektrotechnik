using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace KartenDaten
{
    class Karte{
        List<List<String>> kartenArr = new List<List<String>>();
        List<referenzPunkte> refPunkte = new List<referenzPunkte>();

        private void loadKarte(){
            //Karte zeilenweise einlesen
            string line;
            StreamReader file = new StreamReader(@"karteSmall.csv");   

            while((line = file.ReadLine()) != null){ 
                List<String> liste = line.Split(';').ToList();
                kartenArr.Add(liste);
            }

            file.Close();  
            System.Console.WriteLine("Karte wurde eingelesen, Liste wurde angelegt.");  
        }

        private void loadReferenz(){
            //Karte zeilenweise einlesen
            string line;
            StreamReader file = new StreamReader(@"referenz.csv");   

            while((line = file.ReadLine()) != null){ 
                List<String> liste = line.Split(';').ToList();
                referenzPunkte refPoint = new referenzPunkte();
                refPoint.referenzNr = Convert.ToInt32(liste[0]);
                refPoint.x = Convert.ToInt32(liste[1]);
                refPoint.y = Convert.ToInt32(liste[2]);

                refPunkte.Add(refPoint);
            }
            Console.WriteLine(refPunkte[0].x);
            file.Close();  
            System.Console.WriteLine("ReferenzStationen wurde eingelesen, Liste wurde angelegt.");  
        }
        public void genKarte(){
            //Generieren der Karte.
            loadKarte();
            //ReferenzStationen auslesen
            loadReferenz();
        }
        public int[] getStartPos(){
            //Position von der aus der Roboter startet
            return new int[]{66,164};
        }
        public int[] getEndPos(){
            //Position der verletzten Person
            return new int[]{200,50};
        }
        
        public int getDistance(int posX, int posY, int richtung){
            //Distanz in eine definierte Richtung. Richtung 0 = Norden. 
            //Wird im Uhrzeugersinn gedreht
            Console.WriteLine("PosX: {0} ; PosY  {1}",posX, posY);
            switch(richtung){
                case 0://Norden
                    for(int i=posY; i >= 0;i--){
                        Console.WriteLine("Hoehe:{0}",i);
                        if(kartenArr[i][posX] == "1"){
                            return (posY-i);
                        }
                    }
                    break;
                case 1://Nord Osten

                    break;
                case 2://Osten

                    break;
                case 3://SüdOsten

                    break;
                case 4: //Süden

                    break;
                case 5: //Südwesten

                    break;
                case 6: //Westen

                    break;
                case 7: //Nordwesten

                    break;
                default: //Alles andere.......
                    Console.WriteLine("Leider ist diese Richtung noch nicht definiert");
                    break;
            }
            return -1;
        }
    }

    //ein einzelner KartenEintrag
    class referenzPunkte{
        public int referenzNr = -1;
        public int x=0;
        public int y=0;
    }
}