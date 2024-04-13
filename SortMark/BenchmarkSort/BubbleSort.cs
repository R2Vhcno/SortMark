using System;

namespace SortMark.BenchmarkSort {
    partial class Sort {
        public static void BubbleSort<T>(T[] array) where T : IComparable {
            if (array.Length < 2) return;

            int right = array.Length;

            do {
                for (int i = 0; i < right - 1; i++) {
                    if (array[i].CompareTo(array[i + 1]) >= 0) {
                        Swap(array, i, i + 1);

                    }
                    CompareCount++;
                }

                right--;
            } while (right > 0);
        }
    }
}
