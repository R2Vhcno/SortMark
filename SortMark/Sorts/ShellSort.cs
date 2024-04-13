using SortMark.CustomControls;
using SortMark.SortJob;

namespace SortMark.Sorts {
    internal class ShellSort : SlowJob<SortResult> {
        private int[] _array;
        private SortVisualizer _sortVisualizer;
        private SortResult _sortResult;

        int _posA = -1;
        int _posB = -1;

        public ShellSort(int[] array, SortVisualizer sortVisualizer) : base(TimeSpan.FromMilliseconds(50)) {
            _array = array;
            _sortVisualizer = sortVisualizer;
            _sortResult = new SortResult();
        }

        public override SortResult GetReturnValue() {
            return _sortResult;
        }

        protected override void Perform() {
            if (_array.Length < 2) return;

            int[] gaps = new int[] { 701, 301, 132, 57, 23, 10, 4, 1 }; // Some magic numbers (By Ciura, 2001)

            foreach (var gap in gaps) {
                for (int i = gap; i < _array.Length; i++) {
                    int temp = _array[i];
                    int j;

                    _posA = i;

                    for (j = i; (j >= gap) && (_array[j - gap].CompareTo(temp) == 1); j -= gap) {
                        _array[j] = _array[j - gap];

                        _sortResult.CompareCount++;
                        _posB = j;
                    }

                    _array[j] = temp;

                    if (j != i) {
                        _sortResult.SwapCount++;
                        QuietSleep(1);
                    }
                }

               
            }
        }

        protected override void Update() {
            _sortVisualizer.SelectedIndexA = _posA;
            _sortVisualizer.SelectedIndexB = _posB;
            _sortVisualizer.UpdateVisualization();
        }
    }
}
