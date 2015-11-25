#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h> 

using namespace std;

void Algo::fillMap(int map[], int size)
{
	//TODO : init map tiles with a better algorithm
	for (int i = 0; i < size; i++)
		map[i] = (i % 4);
	for (int i = 0; i < size; i++) {
		int tmp = map[i];
		int rd = rand() % size;
		map[i] = map[rd];
		map[rd] = tmp;
	}
}