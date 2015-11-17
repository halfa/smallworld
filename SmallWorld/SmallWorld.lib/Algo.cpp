#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h> 

using namespace std;


int* Algo_createMap(Algo* algo, int nbTiles) {
	return NULL;
}

int* Algo_suggestTilesForMove(int locationUnit, int* locationEnnemyUnits, float movePoints, int* tiles, int mapSize) {
	return NULL;
}


Algo* Algo_new() {
	return new Algo();
}


void Algo_delete(Algo* algo) {
	if (algo != NULL)
		delete algo;
}