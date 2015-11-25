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

        public int[] createMap(int nbTiles)
        {
            int[] res = new int[nbTiles];
            Algo_fillMap(nativeAlgo, res, nbTiles);

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


        [DllImport("smallWorld.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_fillMap(IntPtr algo, int[] tiles, int nbTiles);

        [DllImport("smallWorld.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("smallWorld.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algo);
    }
}
