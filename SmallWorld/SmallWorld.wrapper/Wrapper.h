#ifndef __WRAPPER__
#define __WRAPPER__
#include "../libCPP/Algo.h"

#pragma comment(lib, "../Debug/libCPP.lib")
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
