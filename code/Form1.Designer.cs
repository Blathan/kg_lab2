namespace lab_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            openPicture = new OpenFileDialog();
            filters = new ComboBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openFileToolStripMenuItem = new ToolStripMenuItem();
            saveFilteredToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            savePicture = new SaveFileDialog();
            blockSize = new ComboBox();
            constant = new ComboBox();
            button1 = new Button();
            globalValue = new TrackBar();
            label1 = new Label();
            kernel = new ComboBox();
            kernelPrint = new TextBox();
            histogramBox = new Emgu.CV.UI.HistogramBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)globalValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)histogramBox).BeginInit();
            SuspendLayout();
            // 
            // openPicture
            // 
            openPicture.FileName = "openFileDialog1";
            openPicture.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openPicture.InitialDirectory = "D:\\";
            openPicture.Title = "Please select image file to filter";
            // 
            // filters
            // 
            filters.FormattingEnabled = true;
            filters.Items.AddRange(new object[] { "Global thresholding", "Adaptive thresholding", "High pass filter", "Otsu", "Gradient" });
            filters.Location = new Point(12, 43);
            filters.Margin = new Padding(3, 4, 3, 4);
            filters.Name = "filters";
            filters.Size = new Size(221, 27);
            filters.TabIndex = 3;
            filters.SelectedIndexChanged += Filters_SelectedIndexChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 2, 0, 2);
            menuStrip1.Size = new Size(692, 27);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openFileToolStripMenuItem, saveFilteredToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(47, 23);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(189, 26);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += NewToolStripMenuItem_Click;
            // 
            // openFileToolStripMenuItem
            // 
            openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            openFileToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
            openFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openFileToolStripMenuItem.Size = new Size(189, 26);
            openFileToolStripMenuItem.Text = "Open";
            openFileToolStripMenuItem.Click += OpenFileToolStripMenuItem_Click;
            // 
            // saveFilteredToolStripMenuItem
            // 
            saveFilteredToolStripMenuItem.Name = "saveFilteredToolStripMenuItem";
            saveFilteredToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            saveFilteredToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveFilteredToolStripMenuItem.Size = new Size(189, 26);
            saveFilteredToolStripMenuItem.Text = "Save";
            saveFilteredToolStripMenuItem.Click += SaveFilteredToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+E";
            exitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            exitToolStripMenuItem.Size = new Size(189, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // blockSize
            // 
            blockSize.FormattingEnabled = true;
            blockSize.Items.AddRange(new object[] { "11", "9", "7", "5" });
            blockSize.Location = new Point(12, 181);
            blockSize.Margin = new Padding(3, 4, 3, 4);
            blockSize.Name = "blockSize";
            blockSize.Size = new Size(221, 27);
            blockSize.TabIndex = 6;
            blockSize.Visible = false;
            // 
            // constant
            // 
            constant.FormattingEnabled = true;
            constant.Items.AddRange(new object[] { "1", "2", "3" });
            constant.Location = new Point(12, 216);
            constant.Margin = new Padding(3, 4, 3, 4);
            constant.Name = "constant";
            constant.Size = new Size(221, 27);
            constant.TabIndex = 7;
            constant.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(257, 43);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(400, 28);
            button1.TabIndex = 8;
            button1.Text = "filter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // globalValue
            // 
            globalValue.Location = new Point(12, 119);
            globalValue.Margin = new Padding(3, 4, 3, 4);
            globalValue.Maximum = 255;
            globalValue.Name = "globalValue";
            globalValue.Size = new Size(221, 56);
            globalValue.TabIndex = 9;
            globalValue.Value = 127;
            globalValue.Visible = false;
            globalValue.Scroll += TrackBar1_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 88);
            label1.Name = "label1";
            label1.Size = new Size(124, 19);
            label1.TabIndex = 10;
            label1.Text = "Global value: 127";
            label1.Visible = false;
            // 
            // kernel
            // 
            kernel.FormattingEnabled = true;
            kernel.Items.AddRange(new object[] { "Laplacian kernel", "Unsharp Mask kernel", "Custom kernel" });
            kernel.Location = new Point(12, 250);
            kernel.Margin = new Padding(3, 4, 3, 4);
            kernel.Name = "kernel";
            kernel.Size = new Size(221, 27);
            kernel.TabIndex = 11;
            kernel.Visible = false;
            kernel.SelectedIndexChanged += Kernel_SelectedIndexChanged;
            // 
            // kernelPrint
            // 
            kernelPrint.Location = new Point(12, 302);
            kernelPrint.Margin = new Padding(3, 4, 3, 4);
            kernelPrint.Multiline = true;
            kernelPrint.Name = "kernelPrint";
            kernelPrint.Size = new Size(221, 98);
            kernelPrint.TabIndex = 12;
            kernelPrint.Visible = false;
            // 
            // histogramBox
            // 
            histogramBox.Location = new Point(257, 100);
            histogramBox.Name = "histogramBox";
            histogramBox.Size = new Size(400, 300);
            histogramBox.TabIndex = 2;
            histogramBox.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(692, 446);
            Controls.Add(histogramBox);
            Controls.Add(kernelPrint);
            Controls.Add(kernel);
            Controls.Add(label1);
            Controls.Add(globalValue);
            Controls.Add(button1);
            Controls.Add(constant);
            Controls.Add(blockSize);
            Controls.Add(filters);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)globalValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)histogramBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openPicture;
        private ComboBox filters;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripMenuItem saveFilteredToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private SaveFileDialog savePicture;
        private ComboBox blockSize;
        private ComboBox constant;
        private Button button1;
        private TrackBar globalValue;
        private Label label1;
        private ComboBox kernel;
        private TextBox kernelPrint;
        private Emgu.CV.UI.HistogramBox histogramBox;
    }
}