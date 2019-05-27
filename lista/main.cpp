#include <iostream>

using namespace std;

class Rosliny
{
    public:
    string nazwa;
    int wiek;
    double cena;
    Rosliny *next;
};

Rosliny* dodajWiele(Rosliny *&glowa);
Rosliny* Dodaj(Rosliny *&glowa);
Rosliny* wybierzWyraz(Rosliny *&glowa);
Rosliny* Rysuj(Rosliny *&glowa);
Rosliny* wybierzUsuwanie(Rosliny *&glowa);
Rosliny* Usun(Rosliny *&mUsuwania, Rosliny *&glowa);
Rosliny* znajdzNajmniejsza(Rosliny *&glowa);
Rosliny* wstaw(Rosliny *&glowa);

int main()
{
    Rosliny *glowa;
    glowa = NULL;

    dodajWiele(glowa);
    wybierzWyraz(glowa);
    wybierzUsuwanie(glowa);
    Rysuj(glowa);
    znajdzNajmniejsza(glowa);

    return 0;
}

Rosliny* dodajWiele(Rosliny *&glowa)
{
    int n;
    cout << "Podaj ilosc wyrazow do wczytania: " << endl;
    cin >> n;
    for(int i=0; i<n; i++)
    {
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
        cout << "Nazwa:\t" << kursor->nazwa << "\t" << "Wiek:\t" << kursor->wiek << "\t" << "Cena:\t" << kursor->cena << "\t" << endl;
        kursor = kursor->next;
    }

}

Rosliny* wybierzUsuwanie(Rosliny *&glowa)
{
    string tuUsuwania;
    cout << "Podaj miejsce usuwania:" << endl;
    cin >> tuUsuwania;
    int counter = 0;
    Rosliny *mUsuwania = glowa; //miejsce w ktorym zaczynamy usuwac
    int wiekPoprzedniego = -1;
    while(mUsuwania != nullptr)
    {

    if(mUsuwania-> next ->nazwa == tuUsuwania)
        {
        wiekPoprzedniego = mUsuwania -> wiek;
        }
    else if (mUsuwania-> nazwa == tuUsuwania)
    {
    break;
    }
    else
        {
            mUsuwania = mUsuwania -> next;
        }
    }
    while(mUsuwania != nullptr)
    {
    if(mUsuwania -> wiek > wiekPoprzedniego )
    {
        if(counter% 2 == 0)
        {
            Rosliny *tmp = mUsuwania;
            mUsuwania = mUsuwania -> next;
            Usun(tmp, glowa);
        }
        else
        {
            mUsuwania = mUsuwania -> next;
        }
        counter++;
    }
    else
    {
        mUsuwania = mUsuwania -> next;
    }
}
}


Rosliny* Usun(Rosliny *&tmp, Rosliny *&glowa)
{
    if(tmp == glowa)
    {
        glowa = glowa -> next;
    }
    else
    {
        Rosliny *kursor = glowa;

        while(kursor -> next != tmp)
        {
            kursor = kursor -> next;
        }
        kursor -> next = tmp -> next;
    }

    delete(tmp);

    return glowa;
}

Rosliny* znajdzNajmniejsza(Rosliny *&glowa)
{
    Rosliny *kursor = glowa;
    int najmlodsza = 10000;

    while(kursor != nullptr)
    {
        if(kursor->wiek < najmlodsza)
        {
            najmlodsza = kursor->wiek;
        }
        kursor = kursor->next;
    }



    while(glowa != nullptr)
    {
        if(glowa->wiek = najmlodsza)
        {
            wstaw(glowa);
        }
        glowa = glowa->next;
    }
}

Rosliny* wstaw(Rosliny *&glowa)
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

    if(poprzedni == NULL)
    {
        glowa = aktualny;
        return glowa;
    }

    while(poprzedni -> next != NULL)
    {
    poprzedni = poprzedni -> next;
    poprzedni ->next = aktualny;
    }
    Rysuj(glowa);
}
