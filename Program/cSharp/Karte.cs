using System;

namespace Karte
{
    class Karte
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Karte karte = new Karte();
            karte.genKarte();


        }
    }
        class Karte{

        private void loadKarte(){
            //Karte zeilenweise einlesen
        }
        private void splitKarte(){
            //Karte auf das Array aufsplitten
        }

        public void genKarte(){
            //Generieren der Karte.

            //Au
        }
        public int[] getStartPos(){
            //Position von der aus der Roboter startet
            return new int[100,100];
        }
        public int[] getEndPos(){
            //Position der verletzten Person
            return new int[200,50];
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