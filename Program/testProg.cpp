#include <iostream>
#include <fstream>
#include <vector>

using namespace std;



class Karte{
    public:
    vector< vector<int> > Karte;

    int genKarte(){
            
        vector<std::string> lines;
        //Generierte Kartendatei einlesen
        ifstream filein("karteSmall.csv");
        //Gesamte Datei in einen Vector legen
        for (string line; getline(filein, line); ){
            lines.push_back(line);
        }
        //Jeden Eintrag des Vektors Aufsplitten in die einzelnen Werte
        string tmp;

        stringstream linestream(lines[0]);

        getline(linestream, Surname, ',');

        //for (int i = 0; i < lines.size(); i++){
            cout << "Type:"<<typeid(lines[0]).name()<<endl;
            cout<<lines[0]<< endl;
            while(getline(lines[0],tmp, ';')){
                cout<<tmp<<endl;
            }            
        //}


        for (int i = 0; i < lines.size(); i++){
            //cout << lines[i] << endl;
        }
        return 0;
    }
};

int main() {
    Karte kart;
    kart.genKarte();
    
    return 0;
}
