#include <iostream>

using namespace std;

class Rosliny
{
    public:
    string nazwa;
    Rosliny *next;
};

Rosliny* dodajWiele(Rosliny *&glowa);
Rosliny* Dodaj(Rosliny *&glowa);
Rosliny* wybierzWyraz(Rosliny *&glowa);
Rosliny* Rysuj(Rosliny *&glowa);

int main()
{

    Rosliny *glowa;
    glowa = NULL;

    dodajWiele(glowa);
    Dodaj(glowa);
    wybierzWyraz(glowa);
    Rysuj(glowa);

    return 0;
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

Rosliny* wybierzWyraz(Rosliny *&glowa)
{
    string wyraz;
    cout << "Podaj nazwe wyrazu od ktorego chcesz wydrukowac: " << endl;
    cin >> wyraz;
    Rosliny *gdzie = glowa;
    Rosliny *tu;
    tu = nullptr;
    while(gdzie != nullptr)
    {
    gdzie = gdzie -> next;
    if(gdzie->nazwa == wyraz)
        tu = gdzie;
    Rysuj(tu);
    }

}

Rosliny* Rysuj(Rosliny *&tu)
{
    Rosliny *kursor = tu;


    while(kursor != NULL){
        cout << kursor->nazwa << endl;
        kursor = kursor->next;
    }

}
