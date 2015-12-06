using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is used as a mean to access the C++ dll from the C# project.
    /// It make the use of the C++ methods available from the C#.
    /// </summary>
    public class Algo : IDisposable
    {
        bool disposed = false;
        IntPtr nativeAlgo;

        /// <summary>
        /// Returns a randomly generated array of tiles, which con be converted into a map.
        /// </summary>
        /// <param name="nbTiles"></param>
        /// <returns></returns>
        public TileType[] createMap(int nbTiles)
        {
            TileType[] res = new TileType[nbTiles];
            Algo_fillMap(nativeAlgo, res, nbTiles);

            return res;
        }

        /// <summary>
        /// Returns an array of intersting destinations regarding the specified points array.
        /// </summary>
        /// <param name="points"></param>
        /// <param name="size"></param>
        /// <returns></returns>
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
