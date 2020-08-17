using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace KartenDaten
{
    class Karte{
        static List<List<String>> kartenArr = new List<List<String>>();
        static List<referenzPunkte> refPunkte = new List<referenzPunkte>();

        private static void loadKarte(){
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

        private static void loadReferenz(){
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
            file.Close();  
            System.Console.WriteLine("ReferenzStationen wurde eingelesen, Liste wurde angelegt.");  
        }
        public static void genKarte(){
            Console.WriteLine("------ Initialisieren der Umgebung ------\n\n");
            //Generieren der Karte.
            loadKarte();
            //ReferenzStationen auslesen
            loadReferenz();
            Console.WriteLine("\n\n------ Initialisieren der Umgebung beendet ------\n");
        }

        public static int getDistance(int posX, int posY, int richtung){
            //Distanz in eine definierte Richtung. Richtung 0 = Norden. 
            //Wird im Uhrzeugersinn gedreht
            Console.WriteLine("Abstand von Position {0}/{1} in Richtung {2} wurde abgefragt",posX, posY, richtung);
            switch(richtung){
                case 0://Norden
                    for(int i=posY; i >= 0;i--){
                        Console.WriteLine("i:{0} : Wert:{1}",i, kartenArr[i][posX]);
                        if(kartenArr[i][posX].Trim() == "1"){
                            int dist = (posY-i);
                            Console.WriteLine("Hoehe: {0}", i);
                            Console.WriteLine("Abstand ist {0}", dist);
                            return dist;
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
                    for(int i=posY; i < kartenArr.Count ; i++){
                        Console.WriteLine("i:{0} : Wert:{1}",i, kartenArr[i][posX]);
                        if(kartenArr[i][posX].Trim() == "1"){
                            int dist = (i-posY);
                            Console.WriteLine("Hoehe: {0}", i);
                            Console.WriteLine("Abstand ist {0}", dist);
                            return dist;
                        }
                    }
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