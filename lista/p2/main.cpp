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
void WyswietlElement(Rosliny *p)
{
    cout << p->gatunek << ", " << p->cena << ", " << p->wiek << endl;
}


void WczytajListe(Rosliny *&glowa, string plik);
void WydrukujListe(Rosliny *glowa);
void UsunListe(Rosliny *&glowa);
void WstawElementy(Rosliny *&glowa);
bool WstawCoElement(Rosliny *&zaElement, int index, int ile, int warunek, int wartosc);
void WstawIPrzesunKursor(Rosliny *&zaElement, Rosliny *el);

Rosliny* ZrobElement();

void Wyczysc(Rosliny *&kursor)
{

    while(kursor != NULL)
    {
        Rosliny *tmp = kursor->_wsk;
        delete(kursor);
        kursor = tmp->_wsk;
    }
}


int main()
{
    Rosliny *glowa;
    glowa=NULL;

    WczytajListe(glowa, "p2.txt");
    WydrukujListe(glowa);
    WstawElementy(glowa);
    WydrukujListe(glowa);

    UsunListe(glowa);
    WydrukujListe(glowa);
    Wyczysc(glowa);
    WydrukujListe(glowa);

    return 0;
}

void WczytajListe(Rosliny *&glowa, string plik) {
    ifstream dane;
    dane.open(plik,ios::in);
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
            while(temp->_wsk)
            {
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
    while(p)
    {
        WyswietlElement(p);
        p = p->_wsk;
    }
    cout << endl;
}

bool WstawCoElement(Rosliny *&zaElement, int index, int ile, int warunek, int wartosc)
{
    if(index % ile == 0 &&((warunek == 0 && zaElement->wiek < wartosc) ||(warunek == 1 && zaElement->wiek > wartosc)))
    {

        Rosliny *nowy = ZrobElement(); // robimy element
        cout << "wstawiam element\r\n";
        WyswietlElement(nowy);

        cout << "za element\r\n";
        WyswietlElement(zaElement);
        cout<< "index = "<<index << " warunek "<<warunek<<endl;
        WstawIPrzesunKursor(zaElement, nowy);
        return 1;
    }
    return 0;
}
static int liczb = 0;
void WstawIPrzesunKursor(Rosliny *&zaElement, Rosliny *el)
{
    cout<<liczb<<endl;
    liczb++;
    Rosliny *temp = zaElement->_wsk;
    zaElement->_wsk = el;
    el->_wsk = temp;
    zaElement = el;
}

Rosliny* ZrobElement()
{
    Rosliny * nowy = new Rosliny();
    nowy -> gatunek = "wygenerowany";
    nowy -> wiek = liczb;
    return nowy;
}

int WiekPrzedostatniego(Rosliny * glowa)
{
    Rosliny *kursor = glowa;
    while(kursor->_wsk !=nullptr)
    {
        kursor = kursor->_wsk;
    }
    return kursor->wiek;

}

int Srednia(Rosliny * glowa)
{
    int counter = 0;
    int suma = 0;
    Rosliny * kursor = glowa;

    while(kursor != nullptr)
    {
        counter++;
        suma+=kursor->wiek;
        kursor = kursor->_wsk;
    }

    return (int)(suma/counter);
}

void WstawElementy(Rosliny *&glowa)
{
    int i=0;
    Rosliny *kursor = glowa;
    int wiekPrzedostatniego = WiekPrzedostatniego(glowa);
    int srednia = Srednia(glowa);
    while(kursor !=nullptr)
    {
        WstawCoElement(kursor, i, 2, 0, wiekPrzedostatniego);
        WstawCoElement(kursor, i, 4, 1, srednia);
        i++;
        kursor = kursor -> _wsk;
    }

}

void WylistujWiekszeOd(Rosliny *kursor, int wiek, int &sredniWiek, int &sredniaCena)
{
    int counter = 0;
    int sumaWiek = 0;
    int sumaCena = 0;

    while(kursor != nullptr)
    {
        if(kursor->wiek>wiek)
        {
        cout<<"element do usuniecia\r\n";
        WyswietlElement(kursor);
        counter++;
        sumaWiek+=kursor->wiek;
        sumaCena+=kursor->cena;
        }
        kursor = kursor->_wsk;
    }
    int tmp = sumaWiek/counter;
    int tmp2 = sumaCena / counter;

    sredniWiek = tmp;
    sredniaCena = tmp2;
}

void ZastapWiekszeOd(Rosliny *kursor, int wiek, int sredniWiek, int sredniaCena)
{
    while(kursor->_wsk != nullptr)
    {
        if(kursor->_wsk->wiek>wiek)
        {
            Rosliny *tmp = new Rosliny();
            tmp->gatunek = "zastapione";
            tmp -> wiek = sredniWiek;
            tmp -> cena = sredniaCena;
            tmp ->_wsk = kursor->_wsk->_wsk;
            cout<<"Wstawiam element"<<endl;
            WyswietlElement(tmp);
            cout<<"zamiast elementu"<<endl;
            WyswietlElement(kursor->_wsk);
            delete(kursor->_wsk);
            kursor ->_wsk = tmp;
        }
    kursor = kursor->_wsk;
    }
}


void UsunListe(Rosliny *&glowa)
{
    Rosliny *kursor = glowa ->_wsk; //za pierwszym, olewamy pierwszy
    int podanePrzezUzytkownika = 4;
    int sredniWiek = 0;
    int sredniaCena = 0;
    WylistujWiekszeOd(kursor, podanePrzezUzytkownika, sredniWiek, sredniaCena);
    cout<<"Srednia cena = "<<sredniaCena<<" sredni wiek = "<<sredniWiek<<endl;
    kursor = glowa;
    ZastapWiekszeOd(kursor, podanePrzezUzytkownika, sredniWiek, sredniaCena);
}
