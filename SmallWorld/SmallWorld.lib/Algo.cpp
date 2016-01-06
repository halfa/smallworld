#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h>
#include <random>
#include "PerlinNoise.h"

using namespace std;

void Algo::fillMap(TileType map[], int size)
{
	fillMapWithNoise(map, size, 0);
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
	int height = (int) sqrt(size);
	clog << height << endl;
	// initialise random generator
	mt19937_64 generator(seed);
	// generate a mask with random z indexes for Perlin
	vector<float> mask(size);
	for (auto i = 0; i < mask.size(); i++)
		mask[i] = 1/generator();
	// fill the map with tiles
	for (int x = 0; x < height; x++)
		for (int y = 0; y < height; y++)
			map[height*y + x] = (TileType)(determineTileType(x, y, mask[height*y+x]));
}

int Algo::determineTileType(int x, int y, float z)
{
	PerlinNoise pn;
	float tile = pn.noise(x*10, y*10, z*10) * 4;
	return (int) tile;
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