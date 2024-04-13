using SortMark.CustomControls;
using SortMark.SortJob;

namespace SortMark.Sorts {
    internal class BubbleSort : SlowJob<SortResult> {
        private int[] _array;
        private SortVisualizer _sortVisualizer;
        private SortResult _sortResult;

        int _posA = -1;
        int _posB = -1;

        public BubbleSort(int[] array, SortVisualizer sortVisualizer) : base(TimeSpan.FromMilliseconds(50)) {
            _array = array;
            _sortVisualizer = sortVisualizer;
            _sortResult = new SortResult();
        }

        public override SortResult GetReturnValue() {
            return _sortResult;
        }

        protected override void Perform() {
            if (_array.Length < 2) return;

            int right = _array.Length;

            do {
                for (int i = 0; i < right - 1; i++) {
                    _posA = i;

                    if (_array[i].CompareTo(_array[i + 1]) >= 0) {
                        int tmp = _array[i];
                        _array[i] = _array[i + 1];
                        _array[i + 1] = tmp;

                        _posB = i + 1;

                        _sortResult.SwapCount++;
                    } else _posB = -1;

                    _sortResult.CompareCount++;

                }
                QuietSleep(50);

                right--;
            } while (right > 0);
        }

        protected override void Update() {
            _sortVisualizer.SelectedIndexA = _posA;
            _sortVisualizer.SelectedIndexB = _posB;
            _sortVisualizer.UpdateVisualization();
        }
    }
}
