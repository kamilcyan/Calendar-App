#include <iostream>

using namespace std;

struct Rosliny
{
    string nazwa;
    Rosliny *next;
};
int wybor;

int rysujMenu()
{

    cout << "Baza danych roslin:" << endl;
    cout << "Wybierz opcje:" << endl;
    cout << "Dodaj  rosline\t1" << endl;
    cout << "Skasuj  rosline\t2" << endl;
    cout << "Pokaz liste\t3" << endl;
    cout << "Wyjdz\t0" << endl;
    cin >> wybor;
    return wybor;
}

void Dodaj(Rosliny *&glowa)
{
    Rosliny *aktualny, *poprzedni;
    poprzedni = aktualny;


    aktualny = new Rosliny;
    string nazwa;
    cout << "Podaj nazwe:" << endl;
    cin >> nazwa;


    aktualny->nazwa = nazwa;
    aktualny->next = NULL;
    if (poprzedni != NULL)
        poprzedni->next = aktualny;
    else
        glowa = aktualny;


}

void Usun(Rosliny *&glowa)
{

}

void Rysuj(Rosliny *&glowa)
{
    Rosliny *adres;
    adres = glowa;

    while(adres){
        cout << adres->nazwa << endl;
        adres = adres->next
    }
}

int main()
{

    Rosliny *glowa;

    glowa = NULL;

    int wybor=1;
    while(wybor!=0)
    {
        wybor =rysujMenu();
        switch(wybor)
        {
        case 1:
            Dodaj(glowa);
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
