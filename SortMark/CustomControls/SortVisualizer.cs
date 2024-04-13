namespace SortMark.CustomControls {
    public class SortVisualizer : Control {
        public string ErrorText { get; set; } = "Array is not initialized.";
        public int SelectedIndexA { get; set; } = -1;
        public int SelectedIndexB { get; set; } = -1;

        private int[]? _array = null;
        private int _maxElement = 0;
        private int _arrayLength = 0;

        private float _columnWidth;

        private Brush _foreColorBrush;
        private Brush _selectionABrush = new SolidBrush(Color.Red);
        private Brush _selectionBBrush = new SolidBrush(Color.Yellow);

        public SortVisualizer() {
            DoubleBuffered = true;

            _columnWidth = Width;
            _foreColorBrush = new SolidBrush(ForeColor);
        }

        public void SetArray(int[] array) {
            _array = array;

            int max = int.MinValue;
            for (int i = 0; i < array.Length; i++) {
                if (array[i] > max) {
                    max = array[i];
                }
            }

            _maxElement = max;
            _arrayLength = array.Length;
            _columnWidth = (float)Width / _arrayLength;

            Invalidate();
        }

        public void UpdateVisualization() {
            _columnWidth = (float)Width / _arrayLength;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            if (_array == null) { // Show error
                SizeF stringSize = g.MeasureString(ErrorText, Font);

                g.DrawString(ErrorText, Font, _foreColorBrush,
                    (Width / 2.0f) - (stringSize.Width / 2.0f),
                    (Height / 2.0f) - (stringSize.Height / 2.0f));

                return;
            }

            for (int i = 0; i < _arrayLength; i++) {
                int value = _array?.ElementAt(i) ?? 0;

                if (value == 0) continue;

                float barHeightPercent = (float)value / _maxElement;
                int barHeight = (int)(Height * barHeightPercent);

                Brush brush;
                if (i == SelectedIndexA) { brush = _selectionABrush; } else if (i == SelectedIndexB) { brush = _selectionBBrush; } else { brush = _foreColorBrush; }

                g.FillRectangle(brush,
                    i * _columnWidth, Height - barHeight,
                    _columnWidth, barHeight);
            }
        }

        protected override void OnResize(EventArgs e) {
            UpdateVisualization();
        }
    }
}
