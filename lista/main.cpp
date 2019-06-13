#include <iostream>

using namespace std;

class Rosliny
{
    public:
    string gatunek;
    int wiek;
    double cena;
    Rosliny *next;
};

Rosliny* dodajWiele(Rosliny *&glowa);                   //wybiera ile wyrazow dodac
Rosliny* Dodaj(Rosliny *&glowa);                          //dodaje kolejne wyrazy
Rosliny* wybierzWyraz(Rosliny *&glowa);                    //wybiera miejsce drukowania
Rosliny* Rysuj(Rosliny *&glowa);                            //drukuje liste
Rosliny* wybierzUsuwanie(Rosliny *&glowa);                     //wybiera miejsce od ktorego ma zaczac usuwac
Rosliny* Usun(Rosliny *&mUsuwania, Rosliny *&glowa);            //usuwa dane wyrazy
Rosliny* znajdzNajmlodsza(Rosliny *&glowa);                       //znajduje najmlodsza rosline
Rosliny* wstaw(Rosliny *&glowa);                                  //wstawia wyraz na wybrane miejsce
Rosliny* usunListe(Rosliny *&glowa);                            //wybiera miejsce od ktorego nalezy zaczac usuwac liste
Rosliny* deleteTu(Rosliny *&glowa);                            //rozpoczyna usuwanie w wybranym miejscu

int main()
{
    Rosliny *glowa;
    glowa = NULL;

    dodajWiele(glowa);
    wybierzWyraz(glowa);
    wybierzUsuwanie(glowa);
    Rysuj(glowa);
    znajdzNajmlodsza(glowa);
    usunListe(glowa);

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
    string gatunek;
    int wiek;
    double cena;
    cout << "Podaj gatunek:" << endl;
    cin >> gatunek;
    cout << "Podaj wiek:" << endl;
    cin >> wiek;
    cout << "Podaj cene:" << endl;
    cin >> cena;



    aktualny->gatunek = gatunek;
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


    while(tu != nullptr)
    {

        if(tu->gatunek == wyraz)
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
        cout << "Gatunek:\t" << kursor->gatunek << "\t" << "Wiek:\t" << kursor->wiek << "\t" << "Cena:\t" << kursor->cena << "\t" << endl;
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
        if(mUsuwania-> next ->gatunek == tuUsuwania)
            {
            wiekPoprzedniego = mUsuwania -> wiek;
            }
        else if (mUsuwania-> gatunek == tuUsuwania)
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

    return glowa;
}

Rosliny* znajdzNajmlodsza(Rosliny *&glowa)
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
        if(glowa->wiek == najmlodsza)
        {
            wstaw(glowa);
            return 0;
        }
        glowa = glowa->next;
    }
}

Rosliny* wstaw(Rosliny *&glowa)
{
    Rosliny *aktualny;

    aktualny = new Rosliny;

        string gatunek;
        int wiek;
        double cena;
        cout << "Podaj gatunek:" << endl;
        cin >> gatunek;
        cout << "Podaj wiek:" << endl;
        cin >> wiek;
        cout << "Podaj cene:" << endl;
        cin >> cena;

        aktualny->gatunek = gatunek;
        aktualny->cena = cena;
        aktualny->wiek = wiek;
        aktualny->next = glowa;

    Rysuj(aktualny);
}

Rosliny* usunListe(Rosliny *&glowa)
{
    string wyraz;
    cout << "Podaj nazwe wyrazu od ktorego chcesz zaczac usuwac: " << endl;
    cin >> wyraz;
    Rosliny *tu = glowa;

    if(tu->gatunek == wyraz)
    {
        deleteTu(tu);
    }
    tu = tu->next;
}

Rosliny* deleteTu(Rosliny *&glowa)
{
    Rosliny *tu;


    while(glowa)
    {
        tu = glowa;
        glowa = glowa->next;
        delete tu;
    }
}
