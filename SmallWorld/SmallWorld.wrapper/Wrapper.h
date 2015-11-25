#ifndef __WRAPPER__
#define __WRAPPER__
#include "../SmallWorld.lib/Algo.h"

#pragma comment(lib, "../Debug/SmallWorld.lib")
using namespace System;
using namespace System::Collections;
using namespace System::Collections::Generic;
//using namespace model; // use the namespace of the model of your application

namespace Wrapper {

	public ref class WrapperAlgo {
	private:
		Algo* algo;

	public:
		WrapperAlgo(){ 
			algo = Algo_new(); 
		}
		
		~WrapperAlgo(){ 
			Algo_delete(algo); 
		}

		List<int>^ createMap(int size) {
			List<int>^ res = gcnew List<int>(size);
			int* list = Algo_createMap(algo, size);
			for (int i = 0; i < size; i++)
				res[i] = list[i];

			return res;
		}

		/*Map createMap(int size) { 
			int* mapLib = Algo_createMap(algo, size);
			Map map = // convert the int* in a Map object
			return map;
		}*/

		//List<Tile^>^ suggestTilesForMove(Unit unitToMove, Map map) {

		//}
	};
}
#endif
