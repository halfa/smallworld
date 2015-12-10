#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h>
#include <random>

using namespace std;

void Algo::fillMap(TileType map[], int size)
{
	fillMapByPermutations(map, size);
}

void Algo::fillMapByPermutations(TileType map[], int size)
{
	// fill the map with tiles
	for (int i = 0; i < size; i++)
		map[i] = (TileType)(i % 4);
	// switch each tile with a random one
	for (int i = 0; i < size; i++) {
		TileType tmp = map[i];
		int rd = rand() % size;
		map[i] = map[rd];
		map[rd] = tmp;
	}
}

/** Better map generator
* Use cpp11 Mersenne Twister implementation as random
* and a Perlin noise heightmap.
*/
void Algo::fillMapWithNoise(TileType map[], int size, int seed)
{
	// initialise random generator
	mt19937_64 generator(seed);
	
	// fill up the map with white noise
	// normalization
	// tiles assignation
}

int Algo::suggestMove(int points[], int nbChoice, int suggestions[])
{
	int default = points[0];
	int j = 0;
	for (int i = 0; i < nbChoice; i++) {
		if (points[i] > default) {
			suggestions[j] = i;
			j++;
			if (j == 3)
				break;
		}
	}
	if (j == 0) {
		suggestions[0] = 0;
		return ++j;
	}
	return j;
}