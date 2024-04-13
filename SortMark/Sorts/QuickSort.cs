using SortMark.CustomControls;
using SortMark.SortJob;

namespace SortMark.Sorts {
    internal class QuickSort : SlowJob<SortResult> {
        private int[] _array;
        private SortVisualizer _sortVisualizer;
        private SortResult _sortResult;

        int _posA = -1;
        int _posB = -1;

        public QuickSort(int[] array, SortVisualizer sortVisualizer) : base(TimeSpan.FromMilliseconds(50)) {
            _array = array;
            _sortVisualizer = sortVisualizer;
            _sortResult = new SortResult();
        }

        public override SortResult GetReturnValue() {
            return _sortResult;
        }

        protected override void Perform() {
            SortQuick(0, _array.Length - 1);
        }

        private void SortQuick(int start, int end) {
            int i = start;
            int j = end;

            int pivot = _array[start];

            while (i <= j) {
                while (_array[i].CompareTo(pivot) < 0) {
                    i++;

                    _sortResult.CompareCount++;

                    _posA = i;
                }

                while (_array[j].CompareTo(pivot) > 0) {
                    j--;

                    _sortResult.CompareCount++;

                    _posB = j;
                }

                if (i <= j) {
                    int tmp = _array[i];
                    _array[i] = _array[j];
                    _array[j] = tmp;

                    _sortResult.SwapCount++;

                    i++;
                    j--;

                    _posA = i;
                    _posB = j;
                }

                QuietSleep(10);
            }

            if (start < j) SortQuick(start, j);
            if (i < end) SortQuick(i, end);
        }

        protected override void Update() {
            _sortVisualizer.SelectedIndexA = _posA;
            _sortVisualizer.SelectedIndexB = _posB;
            _sortVisualizer.UpdateVisualization();
        }
    }
}
