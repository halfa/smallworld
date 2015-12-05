﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.Core
{
    public class Algo : IDisposable
    {
        bool disposed = false;
        IntPtr nativeAlgo;

        public TileType[] createMap(int nbTiles)
        {
            TileType[] res = new TileType[nbTiles];
            Algo_fillMap(nativeAlgo, res, nbTiles);

            return res;
        }

        public List<int> suggestMove(int[] points, int size)
        {
            List<int> res = new List<int>();
            int[] suggestions = new int[3];
            int i = Algo_suggestMove(nativeAlgo, points, size, suggestions);
            for(int j = 0; j < i; j++)
            {
                res.Add(suggestions[j]);
            }
            return res;
        }

        public Algo()
        {
            nativeAlgo = Algo_new();
        }

        ~Algo()
        {
            Dispose(false);
            Algo_delete(nativeAlgo);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                Algo_delete(nativeAlgo);
            }
            disposed = true;
        }


        [DllImport("SmallWorld.lib.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_fillMap(IntPtr algo, TileType[] tiles, int nbTiles);

        [DllImport("SmallWorld.lib.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("SmallWorld.lib.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algo);

        [DllImport("SmallWorld.lib.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int Algo_suggestMove(IntPtr algo, int[] points, int nbChoice, int[] suggestions);

    }
}
