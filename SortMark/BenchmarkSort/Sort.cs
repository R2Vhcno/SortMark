
namespace SortMark.BenchmarkSort {
  partial class Sort {
    public static int SwapCount = 0;
    public static int CompareCount = 0;

    private static void Swap<T>(T[] array, int indexA, int indexB) {
      T temp = array[indexB];
      array[indexB] = array[indexA];
      array[indexA] = temp;

      SwapCount++;
    }

    public static void ResetCounters() {
      SwapCount = 0;
      CompareCount = 0;
    }
  }
}
