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
*
* TODO assign tiles with 1st/3rd quartils and mediane
* TODO take seed as imput
*/
void Algo::fillMapWithNoise(TileType map[], int size)
{
	int height = (int) sqrt(size);
	// initialise random generator
    random_device rd;
    int seed = rd();
	
    mt19937 generator(seed);
    uniform_real_distribution<double> dis(0.0, 1.0);
    uniform_real_distribution<double> translate(-100000, 100000);
    
    double zseed = dis(generator);
    int tx = round(translate(generator));
    int ty = round(translate(generator));
    
    // generate a mask for Perlin
    PerlinNoise pn;
	vector<float> mask(size);
    for (int x = 0; x < height; x++)
		for (int y = 0; y < height; y++)
		    mask[height*y+x] =  pn.noise(x+tx, y+ty, zseed);

    /* Normalize mask
     * From [min, max] to [0, 3.99]
     * 0-.99  -> 0
     * 1-1.99 -> 1
     * 2-2.99 -> 2
     * 3-3.99 -> 3
     */
    vector<float>::iterator maxit = max_element(mask.begin(), mask.end());
    vector<float>::iterator minit = min_element(mask.begin(), mask.end());
    float max = *maxit - *minit; // prepare max for normalisation
    float min = *minit;
    
    // normalize the mask vector to [0;4[
    vector<float>::iterator i;
    for(i = mask.begin(); i < mask.end(); i++)
        (*i) = ( ((*i)-min)/max ) * 3.99;

    // fill the map with tiles
	for (int x = 0; x < height; x++)
		for (int y = 0; y < height; y++)
			map[height*y + x] = (TileType)(mask[height*y+x]);
}

int Algo::suggestMove(int points[], int nbChoice, int suggestions[])
{
	int _default = points[0];
	int j = 0;
	for (int i = 0; i < nbChoice; i++) {
		if (points[i] > _default) {
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
