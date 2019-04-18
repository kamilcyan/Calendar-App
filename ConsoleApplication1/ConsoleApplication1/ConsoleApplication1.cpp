#include "pch.h"
#include <iostream>
#include <string>
#include <cstdlib>
#include <time.h>
#include <iomanip>

using namespace std;

const int n = 7, D = 2, G = 20, M = 5;
int arr[n][n];

int main()
{
	// Inicjacja liczb losowych
	srand(time(NULL));

	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			// Losuję liczby z przedziału <D,G>
			arr[i][j] = rand() % (G - D) + D;
		}
	}

	// Print arr
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			cout << setw(5) << arr[i][j];
		}
		cout << endl;
	}

	cout << "____________________________________________________________" << endl;


	// Sprawdzam kolumna po kolumnie liczby podzielne przez stałą M
	int dividualByM_Arr[n];

	for (int j = 0; j < n; j++)
	{
		dividualByM_Arr[j] = 0;

		for (int i = 0; i < n; i++)
		{
			if ((arr[i][j]) % M == 0)
				dividualByM_Arr[j] += 1;
		}
	}

	// Print dividualByM_Arr
	for (int j = 0; j < n; j++)
	{
		cout << setw(5) << dividualByM_Arr[j];
	}

	cout << endl;
	cout << endl;

	// Szukam największej liczby z przekątnej
	int maxDiagonal = arr[0][0];
	int maxDiagonalPosition = 0;

	for (int i = 0; i < n; i++)
	{
		if (arr[i][i] > maxDiagonal) {
			maxDiagonal = arr[i][i];
			maxDiagonalPosition = i;
		}
	}

	// Szukam najmniejszej liczby w 3 ostatnich wierszach
	int minInThreeLastRows = arr[n - 3][0];
	int minInThreeLastRowsI = n - 3;
	int minInThreeLastRowsJ = 0;

	for (int i = n - 3; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (arr[i][j] < minInThreeLastRows) {
				minInThreeLastRows = arr[i][j];
				minInThreeLastRowsI = i;
				minInThreeLastRowsJ = j;
			}
		}
	}

	// Zamieniam miejscami największą z przekątnej z najmniejszą z ostatnich 3 wierszy
	arr[minInThreeLastRowsI][minInThreeLastRowsJ] = maxDiagonal;
	arr[maxDiagonalPosition][maxDiagonalPosition] = minInThreeLastRows;

	// Print arr
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			cout << setw(5) << arr[i][j];
		}
		cout << endl;
	}

	return 0;
}