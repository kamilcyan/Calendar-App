#include <iostream>

using namespace std;

class Rosliny
{
    public:
    string nazwa;
    int wiek;
    double cena;
    int id;//liczba porzadkowa
    Rosliny *next;
};

Rosliny* dodajWiele(Rosliny *&glowa);
Rosliny* Dodaj(Rosliny *&glowa, int ile);
Rosliny* wybierzWyraz(Rosliny *&glowa);
Rosliny* Rysuj(Rosliny *&glowa);
Rosliny* wybierzUsuwanie(Rosliny *&glowa);
Rosliny* Usun(Rosliny *&mUsuwania, Rosliny *&glowa);

int main()
{
    Rosliny *glowa;
    glowa = NULL;
    int ile;

    dodajWiele(glowa);
    Dodaj(glowa, ile);
    wybierzWyraz(glowa);
    wybierzUsuwanie(glowa);

    return 0;
}

Rosliny* dodajWiele(Rosliny *&glowa)
{
    int n;
    int ile = 0;
    cout << "Podaj ilosc wyrazow do wczytania: " << endl;
    cin >> n;
    for(int i=1; i<n; i++)
    {
        ile++; //liczy ilosc powtorzen
        glowa = Dodaj(glowa, ile);
    }
    return glowa;
}


Rosliny* Dodaj(Rosliny *&glowa, int ile)
{
    Rosliny *aktualny, *poprzedni;
    poprzedni = glowa;



    aktualny = new Rosliny();
    string nazwa;
    int wiek;
    double cena;
    cout << "Podaj nazwe:" << endl;
    cin >> nazwa;
    cout << "Podaj wiek:" << endl;
    cin >> wiek;
    cout << "Podaj cene:" << endl;
    cin >> cena;



    aktualny->nazwa = nazwa;
    aktualny->cena = cena;
    aktualny->wiek = wiek;
    aktualny->next = NULL;
    aktualny->id = ile;


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



Rosliny* wybierzWyraz(Rosliny *&glowa)
{
    string wyraz;
    cout << "Podaj nazwe wyrazu od ktorego chcesz wydrukowac: " << endl;
    cin >> wyraz;
    Rosliny *tu = glowa;


    while(tu != NULL)
    {

        if(tu->nazwa == wyraz)
        {
            Rysuj(tu);
        }
        tu = tu -> next;
    }
}

Rosliny* Rysuj(Rosliny *&tu)
{
    Rosliny *kursor = tu;


    while(kursor != NULL)
    {
        cout << "Nazwa:\t" << kursor->nazwa << "\t" << "Wiek:\t" << kursor->wiek << "\t" << "Cena:\t" << kursor->cena << "\t" << kursor->id << endl;
        kursor = kursor->next;
    }

}

Rosliny* wybierzUsuwanie(Rosliny *&glowa)
{
    string tuUsuwania;
    cout << "Podaj miejsce usuwania:" << endl;
    cin >> tuUsuwania;

    Rosliny *mUsuwania = glowa; //miejsce w ktorym zaczynamy usuwac
    while(mUsuwania != nullptr)
    {

    if(mUsuwania->nazwa == tuUsuwania)
        {
            Usun(mUsuwania, glowa);
        }
    else
        {
            mUsuwania = mUsuwania -> next;
        }
    }
}

Rosliny* Usun(Rosliny *&mUsuwania, Rosliny *&glowa)
{
    Rosliny *kursor = glowa;
    Rosliny *poprzedni = nullptr;

    Rosliny *tmp = nullptr;

    while(kursor -> next != mUsuwania)
    {
        kursor = kursor -> next;

    while(mUsuwania != nullptr)
    {
        //Rosliny *aktualny = glowa;
        if(mUsuwania->wiek > kursor->wiek && (kursor->id)%2==0)
        {
            if(mUsuwania==glowa)
            {
                glowa = glowa->next;
            }

            else
            {
                poprzedni->next = mUsuwania->next;
                tmp = mUsuwania;
                mUsuwania = mUsuwania->next;
                delete tmp;
            }
          while(mUsuwania != NULL)
            {
                cout << "Nazwa:\t" << mUsuwania->nazwa << "\t" << "Wiek:\t" << mUsuwania->wiek << "\t" << "Cena:\t" << mUsuwania->cena << "\t" << mUsuwania->id << endl;
                mUsuwania = mUsuwania->next;
            }
        }

    }
    }
}


    /*Rosliny* nastepny = kursor->next;
    int licznikStarszych = 0;

    while(kursor != NULL)
    {
        if(kursor->wiek > kursor->next->wiek)
        {
            licznikStarszych++;
            kursor = kursor->next;
        }
    }
    if((kursor->wiek > nastepny->wiek)||licznikStarszych%2==0)
    {

    }

}*/


