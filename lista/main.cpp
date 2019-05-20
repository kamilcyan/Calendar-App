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

int ileRoslin();
Rosliny* dodajWiele(Rosliny *&glowa);
Rosliny* Dodaj(Rosliny *&glowa);
Rosliny* wybierzWyraz(Rosliny *&glowa);
Rosliny* Rysuj(Rosliny *&glowa);
Rosliny* wybierzUsuwanie(Rosliny *&glowa);
Rosliny* Usun(Rosliny *&mUsuwania, Rosliny *&glowa);

int main()
{

    Rosliny *glowa;
    glowa = NULL;

    ileRoslin();
    dodajWiele(glowa);
    Dodaj(glowa);
    wybierzWyraz(glowa);
    wybierzUsuwanie(glowa);

    return 0;
}

int ileRoslin()
{
    int n;
    cout << "Podaj ilosc wyrazow do wczytania: " << endl;
    cin >> n;
    return n;
}

Rosliny* dodajWiele(Rosliny *&glowa)
{
    int n = ileRoslin();
    for(int i=1; i<n; i++){
        glowa = Dodaj(glowa);
    }
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
    cout << ileRoslin();
}

Rosliny* wybierzUsuwanie(Rosliny *&glowa)
{
    string tuUsuwania;
    cout << "Podaj miejsce usuwania:" << endl;
    cin >> tuUsuwania;

    Rosliny *mUsuwania = glowa; //miejsce w ktorym zaczynamy usuwac
    while(mUsuwania != nullptr)
    {
    mUsuwania = mUsuwania -> next;
    if(mUsuwania->nazwa == tuUsuwania)
        {
            Usun(mUsuwania, glowa);
        }
    }
}

Rosliny* Usun(Rosliny *&mUsuwania, Rosliny *&glowa)
{
  /*  Rosliny *kursor = glowa;

    while(kursor -> next != mUsuwania)
    {
        kursor = kursor -> next;
    }
    while(mUsuwania != nullptr)
    {
        if(mUsuwania->wiek > kursor->wiek && parzyste)
        {
            usun ten elelemnt
        }
    }*/
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
*/
}
