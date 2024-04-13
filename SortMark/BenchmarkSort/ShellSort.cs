using System;

namespace SortMark.BenchmarkSort {
    partial class Sort {
        public static void ShellSort<T>(T[] array) where T : IComparable {
            if (array.Length < 2) return;

            int[] gaps = new int[] { 701, 301, 132, 57, 23, 10, 4, 1 }; // Some magic numbers (By Ciura, 2001)

            foreach (var gap in gaps) {
                for (int i = gap; i < array.Length; i++) {
                    T temp = array[i];
                    int j;

                    for (j = i;
                        (j >= gap) && SmarterComparer(array[j - gap], temp) == 1;
                        j -= gap) {
                        array[j] = array[j - gap];


                    }

                    array[j] = temp;

                    if (i != j) SwapCount++;
                }
            }
        }
        public static int SmarterComparer(IComparable a, IComparable b) {
            CompareCount++;
            return a.CompareTo(b);
        }
    }

}
