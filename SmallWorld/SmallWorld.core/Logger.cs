using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.Core
{
    public static class Logger
    {
        public static string Log { get; set; }

        static Logger()
        {
            Log = "";
        }

        public static void addMessage(string message)
        {
            Log += message + "\n";
        }

        public static void empty()
        {
            Log = "";
        }
    }
}
