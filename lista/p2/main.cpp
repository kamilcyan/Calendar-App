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

	cout << "Etap 1" << endl;
	WczytajListe(glowa);
	cout << "Etap 2" << endl;
	WydrukujListe(glowa);
	//UsunListe(glowa);
	//cout << endl << "Ponownie drukuje liste: " << endl;
//	WydrukujListe(glowa);


return 0;
}

void WczytajListe(Rosliny *&glowa)
{
	ifstream dane;
	dane.open("p2.txt");
	if(dane.good()==false)
    {
        cout << "Plik nie istnieje.";
    }
    if(dane.good())
    {
        cout << "tak" << endl;
    }
	Rosliny *p = nullptr;
	while(!dane.eof())
    {
		p = new Rosliny;
		string a;
		int b;
		int c;
		dane >> a >> b >> c;
		p->gatunek = a;
		p->cena = b;
		p->wiek = c;
		p->_wsk = nullptr;

		Rosliny *temp = glowa;

		if(glowa==nullptr)
        {
            glowa = p;
            return;
        }

		else
        {
            WydrukujListe(glowa);
			while(temp->_wsk)
            {
				temp = temp->_wsk;
			}
            temp->_wsk = p;
            return;
        }


	}

}


void WydrukujListe(Rosliny *glowa)
{
    cout << "Rosliny (gatunek, cena, wiek): " << endl;
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
