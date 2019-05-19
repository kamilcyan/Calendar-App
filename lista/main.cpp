#include <iostream>

using namespace std;

class Rosliny
{
    public:
    string nazwa;
    Rosliny *next;
};


int rysujMenu()
{
    int wybor;
    cout << "Baza danych roslin:" << endl;
    cout << "Wybierz opcje:" << endl;
    cout << "Dodaj  rosline\t1" << endl;
    cout << "Skasuj  rosline\t2" << endl;
    cout << "Pokaz liste\t3" << endl;
    cout << "Wyjdz\t0" << endl;
    cin >> wybor;
    return wybor;
}

Rosliny* dodajWiele(Rosliny *&glowa)
{
    Rosliny* Dodaj(Rosliny *&glowa);
    int n;
    cout << "Podaj ilosc wyrazow do wczytania: " << endl;
    cin >> n;
    for(int i=0; i<n; i++){
        glowa = Dodaj(glowa);
    }
    return glowa;
}

Rosliny* Dodaj(Rosliny *&glowa)
{
    Rosliny *aktualny, *poprzedni;
    poprzedni = glowa;



    aktualny = new Rosliny();
    string nazwa;
    cout << "Podaj nazwe:" << endl;
    cin >> nazwa;


    aktualny->nazwa = nazwa;
    aktualny->next = NULL;

if(poprzedni == NULL)
{
    glowa = aktualny;
    return glowa;
}
while(poprzedni -> next != NULL)
poprzedni = poprzedni -> next;
poprzedni ->next = aktualny;
return glowa;
}

void Usun(Rosliny *&glowa)
{

}

void Rysuj(Rosliny *&glowa)
{
    Rosliny *adres;
    adres = glowa;

    while(adres != NULL){
        cout << adres->nazwa << endl;
        adres = adres->next;
    }
}

int main()
{

    Rosliny *glowa;

    glowa = NULL;

    int wybor=1;
    while(wybor)
    {
        wybor =rysujMenu();
        switch(wybor)
        {
        case 1:
            dodajWiele(glowa);
            break;
        case 2:
            Usun(glowa);
            break;
        case 3:
            Rysuj(glowa);
            break;
        default:
            return 0;
        }
    }

    return 0;
}
