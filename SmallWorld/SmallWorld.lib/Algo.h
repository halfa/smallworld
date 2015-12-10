#pragma once

// Used to facilitate the creation of the random map tiles. //
enum TileType
{
	Forest = 0,
	Mountain = 1,
	Plain = 2,
	Water = 3
};

class Algo {

public:
	Algo() {}
	~Algo() {}

	// Fill a map with random tiles. //
	void fillMap(TileType map[], int size);
	void fillMapByPermutations(TileType map[], int size);
	void fillMapWithNoise(TileType map[], int size, int seed);

	// Returns the number of choices contained in the suggestions array. //
	int suggestMove(int points[], int nbChoice, int suggestions[]);
};


#define EXPORTCDECL extern "C" __declspec(dllexport)
//
// export all C++ class/methods as friendly C functions to be consumed by external component in a portable way
///

EXPORTCDECL void Algo_fillMap(Algo* algo, TileType map[], int size) {
	return algo->fillMap(map, size);
}

EXPORTCDECL Algo* Algo_new() {
	return new Algo();
}

EXPORTCDECL void Algo_delete(Algo* algo) {
	delete algo;
}

EXPORTCDECL int Algo_suggestMove(Algo* algo, int points[], int nbChoice, int suggestions[]) {
	return algo->suggestMove(points, nbChoice, suggestions);
}