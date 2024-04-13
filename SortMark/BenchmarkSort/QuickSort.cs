using System;

namespace SortMark.BenchmarkSort {
  partial class Sort {
    public static void QuickSort<T>(T[] array, bool debug) where T : IComparable {
      QuickSort(array, 0, array.Length - 1, debug);
    }

    public static void QuickSort<T>(T[] array, int start, int end, bool debug) where T : IComparable {
      int i = start;
      int j = end;

      T pivot = array[start];

      while (i <= j) {
        while (array[i].CompareTo(pivot) < 0) {
          i++;

          CompareCount++;
        }

        while (array[j].CompareTo(pivot) > 0) {
          j--;

          CompareCount++;
        }

        if (i <= j) {
          Swap(array, i, j);

          i++;
          j--;
        }
      }

      if (start < j) QuickSort(array, start, j, debug);
      if (i < end) QuickSort(array, i, end, debug);
    }
  }
}
