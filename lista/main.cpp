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
Rosliny* Usun(Rosliny *&glowa);

int main()
{

    Rosliny *glowa;
    glowa = NULL;

    dodajWiele(glowa);
    Dodaj(glowa);
    wybierzWyraz(glowa);
    wybierzUsuwanie(glowa);

    return 0;
}

Rosliny* dodajWiele(Rosliny *&glowa)
{
    Rosliny* Dodaj(Rosliny *&glowa);
    int n;
    cout << "Podaj ilosc wyrazow do wczytania: " << endl;
    cin >> n;
    for(int i=1; i<n; i++){
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


    while(tu != nullptr)
    {
        tu = tu -> next;
        if(tu->nazwa == wyraz)
        {
            Rysuj(tu);
        }
    }
}

Rosliny* Rysuj(Rosliny *&tu)
{
    Rosliny *kursor = tu;


    while(kursor != NULL)
    {
        cout << "Nazwa:\t" << kursor->nazwa << "\t" << "Wiek:\t" << kursor->wiek << "\t" << "Cena:\t" << kursor->cena << endl;
        kursor = kursor->next;
    }

}

Rosliny* wybierzUsuwanie(Rosliny *&glowa)
{
    string tuUsuwania;
    cout << "Podaj miejsce usuwania:" << endl;
    cin >> tuUsuwania;

    Rosliny *mUsuwania = glowa;
    while(mUsuwania != nullptr)
    {
    mUsuwania = mUsuwania -> next;
    if(mUsuwania->nazwa == tuUsuwania)
        {
            Usun(mUsuwania);
        }
    }
}

Rosliny* Usun(Rosliny *&mUsuwania)
{
    Rosliny *kursor = mUsuwania;
    Rosliny* nastepny = kursor->next;
    int licznikStarszych = 0;

    while(kursor != NULL)
    {
        if(kursor->wiek > kursor->next->wiek)
        {
            licznikStarszych++;
        }
    }
    if((kursor->wiek > nastepny->wiek)||licznikStarszych%2==0)
    {

    }

}
