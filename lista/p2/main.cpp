#include <iostream>
#include <fstream>
#include <cstdlib>

using namespace std;

struct Rosliny {
	string gatunek;
	int wiek;
	int cena;
	Rosliny *_wsk;
};

void WczytajListe(Rosliny *&glowa);
void WydrukujListe(Rosliny *glowa);
void UsunListe(Rosliny *&glowa);

int main() {
	Rosliny *glowa;
	glowa=NULL;

	WczytajListe(glowa);
	WydrukujListe(glowa);
	UsunListe(glowa);
	cout << endl << "Ponownie drukuje liste: " << endl;
//	WydrukujListe(glowa);


return 0;
}

void WczytajListe(Rosliny *&glowa) {
	fstream dane;
	dane.open("p2.txt",ios::in);
	if(dane.good()==false)
		cout << "Plik nie istnieje.";
	Rosliny *p;
	while(!dane.eof()) {
		p = new Rosliny;
		string a;
		int b;
		int c;
		dane >> a >> b >> c;
		p->gatunek = a;
		p->cena = b;
		p->wiek = c;
		if(glowa==0)
			glowa = p;
		else {
			Rosliny *temp = glowa;
			while(temp->_wsk) {
				temp = temp->_wsk;
			}
            temp->_wsk = p;
            p->_wsk = 0;
        }

	}

}


void WydrukujListe(Rosliny *glowa)
{
    cout << "LISTA (gatunek, cena, wiek): " << endl;
	Rosliny *p;
    p = glowa;
    while(p) {
        cout << p->gatunek << ", " << p->cena << ", " << p->wiek << endl;
        p = p->_wsk;
    }
    cout << endl;
}

void UsunListe(Rosliny *&glowa)
{

}
