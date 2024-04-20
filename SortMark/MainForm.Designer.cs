namespace SortMark {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            contentPanel = new Panel();
            mainContainer = new ToolStripContainer();
            toolStrip = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            arrayLengthToolTextBox = new ToolStripTextBox();
            createArrayToolButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            randomizeToolButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            sortMethodToolComboBox = new ToolStripComboBox();
            visualizeTooButton = new ToolStripSplitButton();
            benchmarkMenuItem = new ToolStripMenuItem();
            menuStrip = new MenuStrip();
            fileMenuItem = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            helpMenuItem = new ToolStripMenuItem();
            aboutMenuItem = new ToolStripMenuItem();
            statusStrip.SuspendLayout();
            contentPanel.SuspendLayout();
            mainContainer.TopToolStripPanel.SuspendLayout();
            mainContainer.SuspendLayout();
            toolStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip.Location = new Point(0, 419);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(838, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(39, 17);
            statusLabel.Text = "Status";
            // 
            // contentPanel
            // 
            contentPanel.Controls.Add(mainContainer);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 24);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(838, 395);
            contentPanel.TabIndex = 1;
            // 
            // mainContainer
            // 
            // 
            // mainContainer.ContentPanel
            // 
            mainContainer.ContentPanel.Size = new Size(838, 370);
            mainContainer.Dock = DockStyle.Fill;
            mainContainer.Location = new Point(0, 0);
            mainContainer.Name = "mainContainer";
            mainContainer.Size = new Size(838, 395);
            mainContainer.TabIndex = 0;
            mainContainer.Text = "toolStripContainer1";
            // 
            // mainContainer.TopToolStripPanel
            // 
            mainContainer.TopToolStripPanel.Controls.Add(toolStrip);
            // 
            // toolStrip
            // 
            toolStrip.Dock = DockStyle.None;
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripLabel1, arrayLengthToolTextBox, createArrayToolButton, toolStripSeparator1, randomizeToolButton, toolStripSeparator2, toolStripLabel2, sortMethodToolComboBox, visualizeTooButton });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(838, 25);
            toolStrip.Stretch = true;
            toolStrip.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(60, 22);
            toolStripLabel1.Text = "Array size:";
            // 
            // arrayLengthToolTextBox
            // 
            arrayLengthToolTextBox.Name = "arrayLengthToolTextBox";
            arrayLengthToolTextBox.Size = new Size(100, 25);
            arrayLengthToolTextBox.Text = "1000";
            // 
            // createArrayToolButton
            // 
            createArrayToolButton.Image = Properties.Resources.NewListQuery;
            createArrayToolButton.ImageTransparentColor = Color.Magenta;
            createArrayToolButton.Name = "createArrayToolButton";
            createArrayToolButton.Size = new Size(79, 22);
            createArrayToolButton.Text = "Construct";
            createArrayToolButton.Click += createArrayToolButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // randomizeToolButton
            // 
            randomizeToolButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            randomizeToolButton.ImageTransparentColor = Color.Magenta;
            randomizeToolButton.Name = "randomizeToolButton";
            randomizeToolButton.Size = new Size(48, 22);
            randomizeToolButton.Text = "Shuffle";
            randomizeToolButton.Click += randomizeToolButton_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(76, 22);
            toolStripLabel2.Text = "Sort method:";
            // 
            // sortMethodToolComboBox
            // 
            sortMethodToolComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sortMethodToolComboBox.Items.AddRange(new object[] { "Bubble Sort", "Shell Sort", "Quick Sort" });
            sortMethodToolComboBox.Name = "sortMethodToolComboBox";
            sortMethodToolComboBox.Size = new Size(121, 25);
            // 
            // visualizeTooButton
            // 
            visualizeTooButton.DropDownItems.AddRange(new ToolStripItem[] { benchmarkMenuItem });
            visualizeTooButton.Image = Properties.Resources.SortAscending;
            visualizeTooButton.ImageTransparentColor = Color.Magenta;
            visualizeTooButton.Name = "visualizeTooButton";
            visualizeTooButton.Size = new Size(84, 22);
            visualizeTooButton.Text = "Visualize";
            visualizeTooButton.ButtonClick += visualizeTooButton_ButtonClick;
            // 
            // benchmarkMenuItem
            // 
            benchmarkMenuItem.Image = Properties.Resources.Performance;
            benchmarkMenuItem.Name = "benchmarkMenuItem";
            benchmarkMenuItem.Size = new Size(154, 22);
            benchmarkMenuItem.Text = "Immediate sort";
            benchmarkMenuItem.Click += benchmarkMenuItem_Click;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenuItem, helpMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(838, 24);
            menuStrip.TabIndex = 2;
            menuStrip.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitMenuItem });
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new Size(65, 20);
            fileMenuItem.Text = "&Program";
            // 
            // exitMenuItem
            // 
            exitMenuItem.Image = Properties.Resources.Exit;
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitMenuItem.Size = new Size(139, 22);
            exitMenuItem.Text = "&Quit";
            exitMenuItem.Click += exitMenuItem_Click;
            // 
            // helpMenuItem
            // 
            helpMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutMenuItem });
            helpMenuItem.Name = "helpMenuItem";
            helpMenuItem.Size = new Size(24, 20);
            helpMenuItem.Text = "&?";
            // 
            // aboutMenuItem
            // 
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new Size(116, 22);
            aboutMenuItem.Text = "&About...";
            aboutMenuItem.Click += aboutMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 441);
            Controls.Add(contentPanel);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "SortMark";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            contentPanel.ResumeLayout(false);
            mainContainer.TopToolStripPanel.ResumeLayout(false);
            mainContainer.TopToolStripPanel.PerformLayout();
            mainContainer.ResumeLayout(false);
            mainContainer.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private Panel contentPanel;
        private ToolStripContainer mainContainer;
        private ToolStrip toolStrip;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox arrayLengthToolTextBox;
        private ToolStripButton createArrayToolButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton randomizeToolButton;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripStatusLabel statusLabel;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox sortMethodToolComboBox;
        private ToolStripMenuItem helpMenuItem;
        private ToolStripMenuItem aboutMenuItem;
        private ToolStripSplitButton visualizeTooButton;
        private ToolStripMenuItem benchmarkMenuItem;
    }
}
