using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace KartenDaten
{
    class Karte{
        static List<List<String>> kartenArr = new List<List<String>>();
        public static List<referenzPunkte> refPunkte = new List<referenzPunkte>();

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
        public static bool isWater(int[] startPunkt, int[] endPunkt){
            //Empty like my Brain
            return false;
        }
        public static String getTerrain(int posX, int posY){
            return kartenArr[posY][posX].Trim();;
        }
        public static int getDistance(int posX, int posY, int richtung){
            //Distanz in eine definierte Richtung. Richtung 0 = Norden. 
            //Wird im Uhrzeugersinn gedreht
            
            switch(richtung){
                case 0://Norden
                    for(int i=posY; i >= 0;i--){
                        if(kartenArr[i][posX].Trim() == "1"){
                            int dist = (posY-i);
                            return dist;
                        }
                    }
                    break;
                case 1://Nord Osten

                    break;
                case 2://Osten
                    for(int i=posX;i< kartenArr[posY].Count;i++){
                        if(kartenArr[posY][i].Trim() == "1"){
                            int dist = (i-posX);
                            return dist;
                        }
                    }
                    break;
                case 3://SüdOsten

                    break;
                case 4: //Süden
                    for(int i=posY; i < kartenArr.Count ; i++){
                        if(kartenArr[i][posX].Trim() == "1"){
                            int dist = (i-posY);
                            return dist;
                        }
                    }
                    break;
                case 5: //Südwesten

                    break;
                case 6: //Westen
                    for(int i=posX;i>=0;i--){
                        if(kartenArr[posY][i].Trim() == "1"){
                            int dist = (posX-i);
                            return dist;
                        }
                    }
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