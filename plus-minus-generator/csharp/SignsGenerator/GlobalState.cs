using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignsGenerator
{
    public static class GlobalState
    {
        private static long afterMemory;
        private static long beforeMemory;

        public static long AfterMemory { get => afterMemory; set => afterMemory = value; }
        public static long BeforeMemory { get => beforeMemory; set => beforeMemory = value; }
    }
}
