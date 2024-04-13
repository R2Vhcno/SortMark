namespace SortMark {
    partial class ShuffleForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            okButton = new Button();
            cancelButton = new Button();
            formContainer = new TableLayoutPanel();
            label1 = new Label();
            label4 = new Label();
            randomizationSelector = new FlowLayoutPanel();
            fullRandomizationRadioButton = new RadioButton();
            repeatingElementRadioButton = new RadioButton();
            semiPresortedRadioButton = new RadioButton();
            outstandingElementsRadioButton = new RadioButton();
            label2 = new Label();
            label3 = new Label();
            mTextBox = new TextBox();
            lTextBox = new TextBox();
            kTextBox = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            formContainer.SuspendLayout();
            randomizationSelector.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Controls.Add(formContainer, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(434, 281);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(okButton);
            flowLayoutPanel1.Controls.Add(cancelButton);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 249);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(428, 29);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // okButton
            // 
            okButton.Location = new Point(350, 3);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 0;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(269, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // formContainer
            // 
            formContainer.Anchor = AnchorStyles.None;
            formContainer.AutoSize = true;
            formContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formContainer.ColumnCount = 2;
            formContainer.ColumnStyles.Add(new ColumnStyle());
            formContainer.ColumnStyles.Add(new ColumnStyle());
            formContainer.Controls.Add(label1, 0, 0);
            formContainer.Controls.Add(label4, 0, 3);
            formContainer.Controls.Add(randomizationSelector, 1, 3);
            formContainer.Controls.Add(label2, 0, 1);
            formContainer.Controls.Add(label3, 0, 2);
            formContainer.Controls.Add(mTextBox, 1, 2);
            formContainer.Controls.Add(lTextBox, 1, 1);
            formContainer.Controls.Add(kTextBox, 1, 0);
            formContainer.Location = new Point(32, 26);
            formContainer.Name = "formContainer";
            formContainer.RowCount = 4;
            formContainer.RowStyles.Add(new RowStyle());
            formContainer.RowStyles.Add(new RowStyle());
            formContainer.RowStyles.Add(new RowStyle());
            formContainer.RowStyles.Add(new RowStyle());
            formContainer.Size = new Size(370, 193);
            formContainer.TabIndex = 10;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(60, 7);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 1;
            label1.Text = "K, %:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(3, 132);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 2;
            label4.Text = "Randomization:";
            // 
            // randomizationSelector
            // 
            randomizationSelector.AutoSize = true;
            randomizationSelector.Controls.Add(fullRandomizationRadioButton);
            randomizationSelector.Controls.Add(repeatingElementRadioButton);
            randomizationSelector.Controls.Add(semiPresortedRadioButton);
            randomizationSelector.Controls.Add(outstandingElementsRadioButton);
            randomizationSelector.FlowDirection = FlowDirection.TopDown;
            randomizationSelector.Location = new Point(99, 90);
            randomizationSelector.Name = "randomizationSelector";
            randomizationSelector.Size = new Size(268, 100);
            randomizationSelector.TabIndex = 6;
            // 
            // fullRandomizationRadioButton
            // 
            fullRandomizationRadioButton.AutoSize = true;
            fullRandomizationRadioButton.Checked = true;
            fullRandomizationRadioButton.Location = new Point(3, 3);
            fullRandomizationRadioButton.Name = "fullRandomizationRadioButton";
            fullRandomizationRadioButton.Size = new Size(44, 19);
            fullRandomizationRadioButton.TabIndex = 0;
            fullRandomizationRadioButton.TabStop = true;
            fullRandomizationRadioButton.Text = "Full";
            fullRandomizationRadioButton.UseVisualStyleBackColor = true;
            // 
            // repeatingElementRadioButton
            // 
            repeatingElementRadioButton.AutoSize = true;
            repeatingElementRadioButton.Location = new Point(3, 28);
            repeatingElementRadioButton.Name = "repeatingElementRadioButton";
            repeatingElementRadioButton.Size = new Size(143, 19);
            repeatingElementRadioButton.TabIndex = 1;
            repeatingElementRadioButton.Text = "With repetitions (K, %)";
            repeatingElementRadioButton.UseVisualStyleBackColor = true;
            // 
            // semiPresortedRadioButton
            // 
            semiPresortedRadioButton.AutoSize = true;
            semiPresortedRadioButton.Location = new Point(3, 53);
            semiPresortedRadioButton.Name = "semiPresortedRadioButton";
            semiPresortedRadioButton.Size = new Size(161, 19);
            semiPresortedRadioButton.TabIndex = 2;
            semiPresortedRadioButton.Text = "With sorted sub-arrays (L)";
            semiPresortedRadioButton.UseVisualStyleBackColor = true;
            // 
            // outstandingElementsRadioButton
            // 
            outstandingElementsRadioButton.AutoSize = true;
            outstandingElementsRadioButton.Location = new Point(3, 78);
            outstandingElementsRadioButton.Name = "outstandingElementsRadioButton";
            outstandingElementsRadioButton.Size = new Size(262, 19);
            outstandingElementsRadioButton.TabIndex = 3;
            outstandingElementsRadioButton.Text = "Without, only some random numbers (M, %)";
            outstandingElementsRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(77, 36);
            label2.Name = "label2";
            label2.Size = new Size(16, 15);
            label2.TabIndex = 2;
            label2.Text = "L:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(56, 65);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 2;
            label3.Text = "M, %:";
            // 
            // mTextBox
            // 
            mTextBox.Dock = DockStyle.Fill;
            mTextBox.Location = new Point(99, 61);
            mTextBox.Name = "mTextBox";
            mTextBox.Size = new Size(268, 23);
            mTextBox.TabIndex = 9;
            mTextBox.Text = "2";
            // 
            // lTextBox
            // 
            lTextBox.Dock = DockStyle.Fill;
            lTextBox.Location = new Point(99, 32);
            lTextBox.Name = "lTextBox";
            lTextBox.Size = new Size(268, 23);
            lTextBox.TabIndex = 8;
            lTextBox.Text = "5";
            // 
            // kTextBox
            // 
            kTextBox.Dock = DockStyle.Fill;
            kTextBox.Location = new Point(99, 3);
            kTextBox.Name = "kTextBox";
            kTextBox.Size = new Size(268, 23);
            kTextBox.TabIndex = 7;
            kTextBox.Text = "45";
            // 
            // ShuffleForm
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(434, 281);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ShuffleForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Shuffle Array";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            formContainer.ResumeLayout(false);
            formContainer.PerformLayout();
            randomizationSelector.ResumeLayout(false);
            randomizationSelector.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button okButton;
        private Button cancelButton;
        private Label label2;
        private FlowLayoutPanel randomizationSelector;
        private RadioButton fullRandomizationRadioButton;
        private RadioButton repeatingElementRadioButton;
        private RadioButton semiPresortedRadioButton;
        private RadioButton outstandingElementsRadioButton;
        private Label label4;
        private Label label3;
        private Label label1;
        private TextBox kTextBox;
        private TextBox lTextBox;
        private TextBox mTextBox;
        private TableLayoutPanel formContainer;
    }
}