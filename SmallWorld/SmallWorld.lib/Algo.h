#ifdef WANTDLLEXP
#define DLL _declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif

class DLL Algo {
public:
	Algo() {}
	~Algo() {}

	// You can change the return type and the parameters according to your needs.
	int* createMap(int size);
	int* suggestTilesForMove(int locationUnit, int* locationEnnemyUnits, int typeRace, float movePoints, int* tiles, int mapSize);
	// and you can add other functions.
};

// Not to implement in this header file.
EXTERNC DLL Algo* Algo_new();
EXTERNC DLL void Algo_delete(Algo* algo);
EXTERNC DLL int* Algo_createMap(Algo* algo, int size);
EXTERNC DLL int* Algo_suggestTilesForMove(int locationUnit, int* locationEnnemyUnits, float movePoints, int* tiles, int mapSize);

