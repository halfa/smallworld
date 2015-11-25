#pragma once

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

	// You can change the return type and the parameters according to your needs.
	void fillMap(TileType map[], int size);
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
