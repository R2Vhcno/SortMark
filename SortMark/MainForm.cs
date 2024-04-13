using SortMark.BenchmarkSort;
using SortMark.CustomControls;
using SortMark.SortJob;
using SortMark.Sorts;
using System.Diagnostics;

namespace SortMark {
    public partial class MainForm : Form {
        private int _selectedArraySize = 100;
        private bool _arrayIsCreated = false;

        private SortVisualizer _sortVisualizer;

        private int[] _array;

        private float _KPercent = 0.45f;
        private int _L = 5;
        private float _MPercent = 0.02f;

        public MainForm() {
            InitializeComponent();

            sortMethodToolComboBox.SelectedIndex = 0;
            arrayLengthToolTextBox.Text = _selectedArraySize.ToString();

            DisableControls();
            createArrayToolButton.Enabled = true;

            _sortVisualizer = new SortVisualizer();
            _sortVisualizer.Dock = DockStyle.Fill;
            mainContainer.ContentPanel.Controls.Add(_sortVisualizer);

            _array = new int[1];

            statusLabel.Text = "Construct an array.";
        }

        private void EnableControls() {
            createArrayToolButton.Enabled = true;
            randomizeToolButton.Enabled = true;
            visualizeTooButton.Enabled = true;
        }

        private void DisableControls() {
            createArrayToolButton.Enabled = false;
            randomizeToolButton.Enabled = false;
            visualizeTooButton.Enabled = false;
        }

        private void exitMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void createArrayToolButton_Click(object sender, EventArgs e) {
            int sizeAsInt = 100;
            bool sizeConvertible = int.TryParse(arrayLengthToolTextBox.Text, out sizeAsInt);

            if (!sizeConvertible) {
                arrayLengthToolTextBox.Text = _selectedArraySize.ToString();
                arrayLengthToolTextBox.Focus();
                arrayLengthToolTextBox.SelectAll();

                MessageBox.Show("Array length must be a whole number.", "Invalid size", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (sizeAsInt <= 0 || sizeAsInt > 10000) {
                arrayLengthToolTextBox.Text = _selectedArraySize.ToString();
                arrayLengthToolTextBox.Focus();
                arrayLengthToolTextBox.SelectAll();

                MessageBox.Show("Array length must be in range [1, 1000].", "Invalid size", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _selectedArraySize = sizeAsInt;

            // Create array
            _array = new int[_selectedArraySize];

            for (int i = 0; i < _array.Length; i++) {
                _array[i] = i;
            }

            _sortVisualizer.SetArray(_array);

            EnableControls();

            statusLabel.Text = "Array has been constructed successfully.";
        }

        private async void randomizeToolButton_Click(object sender, EventArgs e) {
            ShuffleForm dlg = new ShuffleForm();

            if (dlg.ShowDialog() == DialogResult.Cancel) return;

            _KPercent = dlg.KPercent / 100.0f;
            _L = dlg.L;
            _MPercent = dlg.MPercent / 100.0f;

            statusLabel.Text = "Shuffling...";

            DisableControls();
            UseWaitCursor = true;

            SlowLoopFunc<int> shuffler;

            switch (dlg.ShuffleType) {
            case ShuffleType.RandomRepeatedElement:
                shuffler = new RandomElementsShuffle(_array, _KPercent, _sortVisualizer);
                break;
            case ShuffleType.SortedSubArrays:
                shuffler = new SortedSubArraysShuffle(_array, _L, _sortVisualizer);
                break;
            case ShuffleType.OccasionalRandomElements:
                shuffler = new OccasionalRandomElementsShuffle(_array, _MPercent, _sortVisualizer);
                break;
            default: // ShufflerType.FullRandom:
                shuffler = new ShuffleFullRandom(_array, _sortVisualizer);
                break;
            }

            await Task.Run(shuffler.Run);

            _sortVisualizer.SelectedIndexA = -1;
            _sortVisualizer.SelectedIndexB = -1;
            _sortVisualizer.UpdateVisualization();

            statusLabel.Text = "Array is shuffled.";

            EnableControls();
            UseWaitCursor = false;
        }

        // Validation
        private bool ValidateSort() {
            float updatePercentage = 0.01f;
            int updateRate = (int)(_array.Length * updatePercentage);

            if (updateRate < 1) updateRate = 1;

            bool isSortedProperly = true;
            int improperSortedElement = -1;

            int previousElement = int.MinValue;

            for (int i = 0; i < _array.Length; i++) {
                if (_array[i] < previousElement) {
                    isSortedProperly = false;
                    improperSortedElement = i;
                }

                previousElement = _array[i];

                if (i % updateRate == 0) {
                    _sortVisualizer.SelectedIndexA = i;
                    _sortVisualizer.SelectedIndexB = improperSortedElement;
                    _sortVisualizer.UpdateVisualization();

                    Thread.Sleep(50);
                }
            }

            return isSortedProperly;
        }

        private async void visualizeTooButton_ButtonClick(object sender, EventArgs e) {
            SlowJob<SortResult> _method;
            Stopwatch timer = new Stopwatch();

            int[] _arrayDup = new int[_array.Length];
            _array.CopyTo(_arrayDup, 0);

            Sort.ResetCounters();

            switch (sortMethodToolComboBox.SelectedIndex) {
            case 1: // ShellSort:
                _method = new ShellSort(_array, _sortVisualizer);

                // Run Benchmark
                timer.Start();
                Sort.ShellSort(_arrayDup);
                timer.Stop();

                break;
            case 2: // QuickSort:
                _method = new QuickSort(_array, _sortVisualizer);

                // Run Benchmark
                timer.Start();
                Sort.QuickSort(_arrayDup, false);
                timer.Stop();

                break;
            default: // BubbleSort:
                _method = new BubbleSort(_array, _sortVisualizer);

                // Run Benchmark
                timer.Start();
                Sort.BubbleSort(_arrayDup);
                timer.Stop();
                break;
            }

            DisableControls();
            UseWaitCursor = true;

            statusLabel.Text = "Sorting...";

            await _method.RunAsync();

            statusLabel.Text = "Verifying...";

            bool arrayIsValid = await Task.Run(ValidateSort);

            _sortVisualizer.SelectedIndexA = -1;
            _sortVisualizer.SelectedIndexB = -1;
            _sortVisualizer.UpdateVisualization();

            EnableControls();
            UseWaitCursor = false;

            if (arrayIsValid) {
                statusLabel.Text = "Array has been sorted successfully.";

                SortResult rslt = _method.GetReturnValue();

                MessageBox.Show(
                    string.Format("Time spent sorting: {0}mcs*\nComparisons count: {1}\nSwaps count: {2}\n\n* time without any delays of visualization.",
                                    timer.ElapsedTicks / (TimeSpan.TicksPerMillisecond / 1000),
                                    Sort.CompareCount, Sort.SwapCount),
                    "Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );

                return;
            }

            statusLabel.Text = "Internal error while sorting.";
        }

        private void benchmarkMenuItem_Click(object sender, EventArgs e) {
            Stopwatch timer = new Stopwatch();

            Sort.ResetCounters();

            switch (sortMethodToolComboBox.SelectedIndex) {
            case 1: // ShellSort:
                timer.Start();
                Sort.ShellSort(_array);
                timer.Stop();

                break;
            case 3: // QuickSort:
                timer.Start();
                Sort.QuickSort(_array, false);
                timer.Stop();

                break;
            default: // BubbleSort:
                timer.Start();
                Sort.BubbleSort(_array);
                timer.Stop();
                break;
            }

            _sortVisualizer.SelectedIndexA = -1;
            _sortVisualizer.SelectedIndexB = -1;
            _sortVisualizer.UpdateVisualization();

            MessageBox.Show(
                    string.Format("Time spent sorting: {0}mcs*\nComparisons count: {1}\nSwaps count: {2}\n\n* time without any delays of visualization.",
                                    timer.ElapsedTicks / (TimeSpan.TicksPerMillisecond / 1000),
                                    Sort.CompareCount, Sort.SwapCount),
                    "Immediate sort",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
        }

        private void aboutMenuItem_Click(object sender, EventArgs e) {
            new AboutBox().ShowDialog();
        }
    }

    internal class ShuffleFullRandom : SlowLoopFunc<int> {
        private int[] _array;
        private SortVisualizer _arrayVis;
        private Random _rng;
        private int _newPos;

        public ShuffleFullRandom(int[] array, SortVisualizer arrayVis) : base(array.Length, TimeSpan.FromSeconds(2)) {
            _array = array;
            _arrayVis = arrayVis;

            _rng = new Random();
        }

        protected override void Func(int iteration) {
            int tmp = _array[iteration];
            _newPos = _rng.Next(_array.Length - 1);

            _array[iteration] = _array[_newPos];
            _array[_newPos] = tmp;
        }

        public override int GetReturnValue() {
            return 0;
        }

        protected override void SlowUpdate(int iteration) {
            _arrayVis.SelectedIndexA = iteration;
            _arrayVis.SelectedIndexB = _newPos;
            _arrayVis.UpdateVisualization();
        }
    }

    internal class RandomElementsShuffle : SlowLoopFunc<int> {
        private int[] _array;
        private SortVisualizer _arrayVis;

        private Random _rng;
        private int _repeatingElement;
        int _placeStep;
        private int _newPos;

        public RandomElementsShuffle(int[] array, float kPercent, SortVisualizer arrayVis) : base(array.Length, TimeSpan.FromSeconds(2)) {
            _array = array;
            _arrayVis = arrayVis;

            _rng = new Random();

            _repeatingElement = _array[_rng.Next(_array.Length - 1)];
            _placeStep = (int)(1.0f / kPercent);
        }

        protected override void Func(int iteration) {
            _newPos = iteration;

            if (iteration % _placeStep == 0)
                _array[iteration] = _repeatingElement;
            else {
                int tmp = _array[iteration];
                _newPos = _rng.Next(_array.Length - 1);

                _array[iteration] = _array[_newPos];
                _array[_newPos] = tmp;
            }
        }

        public override int GetReturnValue() {
            return 0;
        }

        protected override void SlowUpdate(int iteration) {
            _arrayVis.SelectedIndexA = iteration;
            _arrayVis.SelectedIndexB = _newPos;
            _arrayVis.UpdateVisualization();
        }
    }

    internal class SortedSubArraysShuffle : SlowLoopFunc<int> {
        private int[] _array;
        private SortVisualizer _arrayVis;

        private Random _rng;
        private int _phaseSize;
        private int _phaseStart = 0;
        private bool _shufflePhase = true;
        private int _newPos;

        public SortedSubArraysShuffle(int[] array, int l, SortVisualizer arrayVis) : base(array.Length, TimeSpan.FromSeconds(2)) {
            _array = array;
            _arrayVis = arrayVis;
            _phaseSize = _array.Length / (l * 2);

            _rng = new Random();
        }

        protected override void Func(int iteration) {
            if (iteration > _phaseStart + _phaseSize) {
                _phaseStart += _phaseSize;
                _shufflePhase = !_shufflePhase;
            }

            if (_shufflePhase) {
                int tmp = _array[iteration];
                _newPos = _phaseStart + _rng.Next(_phaseSize - 1);

                _array[iteration] = _array[_newPos];
                _array[_newPos] = tmp;
            }
        }

        public override int GetReturnValue() {
            return 0;
        }

        protected override void SlowUpdate(int iteration) {
            _arrayVis.SelectedIndexA = iteration;
            _arrayVis.SelectedIndexB = _newPos;
            _arrayVis.UpdateVisualization();
        }
    }

    internal class OccasionalRandomElementsShuffle : SlowLoopFunc<int> {
        private int[] _array;
        private SortVisualizer _arrayVis;

        private Random _rng;
        private int _placeStep;

        public OccasionalRandomElementsShuffle(int[] array, float mPercent, SortVisualizer arrayVis) : base(array.Length, TimeSpan.FromSeconds(2)) {
            _array = array;
            _arrayVis = arrayVis;
            _placeStep = (int)(1.0f / mPercent);

            _rng = new Random();
        }

        protected override void Func(int iteration) {
            if (iteration % _placeStep == 0) {
                _array[iteration] = _rng.Next(_array.Length - 1);
            }
        }

        public override int GetReturnValue() {
            return 0;
        }

        protected override void SlowUpdate(int iteration) {
            _arrayVis.SelectedIndexA = iteration;
            _arrayVis.SelectedIndexB = -1;
            _arrayVis.UpdateVisualization();
        }
    }
}
