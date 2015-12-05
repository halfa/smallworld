#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h>
#include "Algo.h"

using namespace std;

void Algo::fillMap(TileType map[], int size)
{
	//TODO : init map tiles with a better algorithm
	for (int i = 0; i < size; i++)
		map[i] = (TileType)(i % 4);
	for (int i = 0; i < size; i++) {
		TileType tmp = map[i];
		int rd = rand() % size;
		map[i] = map[rd];
		map[rd] = tmp;
	}
}

int Algo::suggestMove(int points[], int nbChoice, int suggestions[])
{
	int default = points[0];
	int j = 0;
	for (int i = 0; i < nbChoice; i++) {
		if (points[i] > default) {
			suggestions[j] = points[i];
			j++;
			if (j == 3)
				break;
		}
	}
	if (j == 0) {
		suggestions[0] = default;
		return ++j;
	}
	return j;
}