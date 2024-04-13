namespace SortMark {
    public enum ShuffleType {
        FullRandom,
        RandomRepeatedElement,
        SortedSubArrays,
        OccasionalRandomElements
    }

    public partial class ShuffleForm : Form {
        public int KPercent { get; private set; } = 45;
        public int L { get; private set; } = 5;
        public int MPercent { get; private set; } = 2;

        public ShuffleType ShuffleType { get; private set; } = ShuffleType.FullRandom;

        public ShuffleForm() {
            InitializeComponent();

            ResetKPercent();
            ResetL();
            ResetMPercent();
        }

        private void ResetKPercent(bool focus = false) {
            kTextBox.Text = KPercent.ToString();

            if (focus) {
                kTextBox.Focus();
                kTextBox.SelectAll();
            }
        }

        private void ResetL(bool focus = false) {
            lTextBox.Text = L.ToString();

            if (focus) {
                lTextBox.Focus();
                lTextBox.SelectAll();
            }
        }

        private void ResetMPercent(bool focus = false) {
            mTextBox.Text = MPercent.ToString();

            if (focus) {
                mTextBox.Focus();
                mTextBox.SelectAll();
            }
        }

        private bool ValidateKPercent() {
            int parsedKPercent;

            if (!int.TryParse(kTextBox.Text, out parsedKPercent)) {
                MessageBox.Show("Поле \"K, %\" должно содержать целое число.", "Недопустимое значение", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ResetKPercent(true);
                return false;
            }

            if (parsedKPercent < 0 || parsedKPercent > 100) {
                MessageBox.Show("Число в поле \"K, %\" должно быть в диапазоне [0, 100].", "Недопустимое значение", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ResetKPercent(true);
                return false;
            }

            KPercent = parsedKPercent;
            ResetKPercent();

            return true;
        }

        private bool ValidateL() {
            int parsedL;

            if (!int.TryParse(lTextBox.Text, out parsedL)) {
                MessageBox.Show("Поле \"L\" должно содержать целое число.", "Недопустимое значение", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ResetL(true);
                return false;
            }

            if (parsedL < 0) {
                MessageBox.Show("Число в поле \"L\" должно быть больше 0.", "Недопустимое значение", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ResetL(true);
                return false;
            }

            L = parsedL;
            ResetL();

            return true;
        }

        private bool ValidateMPercent() {
            int parsedMPercent;

            if (!int.TryParse(mTextBox.Text, out parsedMPercent)) {
                MessageBox.Show("Поле \"M, %\" должно содержать целое число.", "Недопустимое значение", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ResetMPercent(true);
                return false;
            }

            if (parsedMPercent < 0 || parsedMPercent > 100) {
                MessageBox.Show("Число в поле \"M, %\" должно быть в диапазоне [0, 100].", "Недопустимое значение", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ResetMPercent(true);
                return false;
            }

            MPercent = parsedMPercent;
            ResetMPercent();

            return true;
        }

        private void okButton_Click(object sender, EventArgs e) {
            if (!ValidateKPercent()) return;
            if (!ValidateL()) return;
            if (!ValidateMPercent()) return;

            if (fullRandomizationRadioButton.Checked)
                ShuffleType = ShuffleType.FullRandom;
            else if (repeatingElementRadioButton.Checked)
                ShuffleType = ShuffleType.RandomRepeatedElement;
            else if (semiPresortedRadioButton.Checked)
                ShuffleType = ShuffleType.SortedSubArrays;
            else
                ShuffleType = ShuffleType.OccasionalRandomElements;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
