using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSortingAlgorithm
{
    class Program
    {
        static int[] baseArray = new int[] { 4, 8, 7, 1, 3, 0, 5, 9, 6, 2 };

        static void Main(string[] args)
        {
            BubbleSort();
            SelectionSort();
            InsertionSort();
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void BubbleSort()
        {
            int[] arr = new int[baseArray.Length];
            Array.Copy(baseArray, arr, baseArray.Length);

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                        Swap(ref arr[j], ref arr[j + 1]);
                }
            }
        }

        static void SelectionSort()
        {
            int[] arr = new int[baseArray.Length];
            Array.Copy(baseArray, arr, baseArray.Length);

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int indexOfMin = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[indexOfMin])
                        indexOfMin = j;
                }
                if (indexOfMin != i)
                    Swap(ref arr[i], ref arr[indexOfMin]);
            }
        }

        static void InsertionSort()
        {
            int[] arr = new int[baseArray.Length];
            Array.Copy(baseArray, arr, baseArray.Length);

            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                bool hasAnyValidMoves = false;
                int j;
                for (j = i; j > 0 && temp < arr[j - 1]; j--)
                {
                    arr[j] = arr[j - 1];
                    hasAnyValidMoves = true;
                }
                if (hasAnyValidMoves)
                    arr[j] = temp;
            }
        }
    }
}
