using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace KartenDaten
{
    class Karte{
        List<List<String>> asd = new List<List<String>>();


        private void loadKarte(){
            //Karte zeilenweise einlesen
            string line;
            StreamReader file = new StreamReader(@"karteSmall.csv");   

            while((line = file.ReadLine()) != null){ 
                List<String> liste = line.Split(';').ToList();
                asd.Add(liste);
            }

            file.Close();  

            foreach (List<String> element in asd)
            {
                Console.WriteLine($"Element {element}");
            }

            Console.WriteLine("Element : "+asd[0][0] );

            System.Console.WriteLine("Datei wurde eingelesen, Liste wurde angelegt.");  
        }
        public void genKarte(){
            //Generieren der Karte.
            loadKarte();
            //Au
        }
        public int[] getStartPos(){
            //Position von der aus der Roboter startet
            return new int[]{100,100};
        }
        public int[] getEndPos(){
            //Position der verletzten Person
            return new int[]{200,50};
        }
        
        public int getDistance(){
            //Distanz in eine definierte Richtung. Richtung 0 = Norden. 
            //Wird im Uhrzeugersinn gedreht

            return 4;
        }
    }

    //ein einzelner KartenEintrag
    class KartenPos{
        bool befahrbar = false;
    }
    class referenzPunkte{
        int referenzNr = -1;
        int x=0;
        int y=0;
    }
}