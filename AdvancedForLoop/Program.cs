//#define type1
#define type2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedForLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, }, increment = new int[arr.Length], decrement = new int[arr.Length];
#if type1
            int i, j;
            for (i = 0, j = arr.Length - 1; i < arr.Length && j >= 0; i++, j--)
#elif type2
            for (int i = 0, j = arr.Length - 1; i < arr.Length && j >= 0; i++, j--)
#endif
            {
                increment[i] = arr[i];
                decrement[i] = arr[j];
            }

            int k = 0;
            for (; ; )            //infinite loop with for
            {
                if (++k >= 100)
                    break;
            }
        }
    }
}
