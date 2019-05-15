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
    cout << "Wyjdz\t0" << endl;
    cin >> wybor;
    return wybor;
}

int main()
{

    Rosliny *glowa, *aktualny, *poprzedni, *tmp;

    string nazwa;

    rysujMenu();

    while(wybor==1){
        poprzedni = aktualny;
        cout << "Podaj nazwe:" << endl;
        cin >> nazwa;
        aktualny = new Rosliny;
        aktualny->nazwa = nazwa;
        aktualny->next = NULL;
        if (poprzedni != NULL)
	      poprzedni->next = aktualny;
	    else
	      glowa = aktualny;
        rysujMenu();
    }


    return 0;
}
