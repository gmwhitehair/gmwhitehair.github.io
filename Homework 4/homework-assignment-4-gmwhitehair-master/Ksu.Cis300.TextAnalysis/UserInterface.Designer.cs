namespace Ksu.Cis300.TextAnalysis
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterface));
            this.uxButtonBar = new System.Windows.Forms.ToolStrip();
            this.uxOpen = new System.Windows.Forms.ToolStripButton();
            this.uxSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.uxSelectedLabel = new System.Windows.Forms.ToolStripLabel();
            this.uxSelectedFile = new System.Windows.Forms.ToolStripTextBox();
            this.uxTabs = new System.Windows.Forms.TabControl();
            this.uxAllFilesTab = new System.Windows.Forms.TabPage();
            this.uxResults = new System.Windows.Forms.ListView();
            this.uxFileNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxVocabulary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxDifference = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxNumberOfWords = new System.Windows.Forms.NumericUpDown();
            this.uxNumberOfWordsLabel = new System.Windows.Forms.Label();
            this.uxSelectedTab = new System.Windows.Forms.TabPage();
            this.uxThreshold = new System.Windows.Forms.NumericUpDown();
            this.uxThresholdLabel = new System.Windows.Forms.Label();
            this.uxWordFrequencies = new System.Windows.Forms.ListView();
            this.uxWord = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxFrequency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.uxButtonBar.SuspendLayout();
            this.uxTabs.SuspendLayout();
            this.uxAllFilesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfWords)).BeginInit();
            this.uxSelectedTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // uxButtonBar
            // 
            this.uxButtonBar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButtonBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxOpen,
            this.uxSeparator,
            this.uxSelectedLabel,
            this.uxSelectedFile});
            this.uxButtonBar.Location = new System.Drawing.Point(0, 0);
            this.uxButtonBar.Name = "uxButtonBar";
            this.uxButtonBar.Size = new System.Drawing.Size(774, 29);
            this.uxButtonBar.TabIndex = 0;
            this.uxButtonBar.Text = "toolStrip1";
            // 
            // uxOpen
            // 
            this.uxOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uxOpen.Image = ((System.Drawing.Image)(resources.GetObject("uxOpen.Image")));
            this.uxOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxOpen.Name = "uxOpen";
            this.uxOpen.Size = new System.Drawing.Size(52, 26);
            this.uxOpen.Text = "Open";
            this.uxOpen.Click += new System.EventHandler(this.uxOpen_Click);
            // 
            // uxSeparator
            // 
            this.uxSeparator.Name = "uxSeparator";
            this.uxSeparator.Size = new System.Drawing.Size(6, 29);
            // 
            // uxSelectedLabel
            // 
            this.uxSelectedLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSelectedLabel.Name = "uxSelectedLabel";
            this.uxSelectedLabel.Size = new System.Drawing.Size(99, 26);
            this.uxSelectedLabel.Text = "Selected File:";
            // 
            // uxSelectedFile
            // 
            this.uxSelectedFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSelectedFile.Name = "uxSelectedFile";
            this.uxSelectedFile.ReadOnly = true;
            this.uxSelectedFile.Size = new System.Drawing.Size(265, 29);
            // 
            // uxTabs
            // 
            this.uxTabs.Controls.Add(this.uxAllFilesTab);
            this.uxTabs.Controls.Add(this.uxSelectedTab);
            this.uxTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxTabs.Location = new System.Drawing.Point(0, 29);
            this.uxTabs.Name = "uxTabs";
            this.uxTabs.SelectedIndex = 0;
            this.uxTabs.Size = new System.Drawing.Size(774, 663);
            this.uxTabs.TabIndex = 1;
            // 
            // uxAllFilesTab
            // 
            this.uxAllFilesTab.Controls.Add(this.uxResults);
            this.uxAllFilesTab.Controls.Add(this.uxNumberOfWords);
            this.uxAllFilesTab.Controls.Add(this.uxNumberOfWordsLabel);
            this.uxAllFilesTab.Location = new System.Drawing.Point(4, 29);
            this.uxAllFilesTab.Name = "uxAllFilesTab";
            this.uxAllFilesTab.Padding = new System.Windows.Forms.Padding(3);
            this.uxAllFilesTab.Size = new System.Drawing.Size(766, 630);
            this.uxAllFilesTab.TabIndex = 0;
            this.uxAllFilesTab.Text = "All Files";
            this.uxAllFilesTab.UseVisualStyleBackColor = true;
            // 
            // uxResults
            // 
            this.uxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uxFileNameHeader,
            this.uxVocabulary,
            this.uxDifference});
            this.uxResults.GridLines = true;
            this.uxResults.HideSelection = false;
            this.uxResults.Location = new System.Drawing.Point(8, 37);
            this.uxResults.MultiSelect = false;
            this.uxResults.Name = "uxResults";
            this.uxResults.Size = new System.Drawing.Size(750, 587);
            this.uxResults.TabIndex = 2;
            this.uxResults.UseCompatibleStateImageBehavior = false;
            this.uxResults.View = System.Windows.Forms.View.Details;
            this.uxResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.uxResults_ColumnClick);
            this.uxResults.SelectedIndexChanged += new System.EventHandler(this.uxResults_SelectedIndexChanged);
            // 
            // uxFileNameHeader
            // 
            this.uxFileNameHeader.Text = "File Name   ";
            this.uxFileNameHeader.Width = 425;
            // 
            // uxVocabulary
            // 
            this.uxVocabulary.Text = "Vocabulary   ";
            this.uxVocabulary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxVocabulary.Width = 150;
            // 
            // uxDifference
            // 
            this.uxDifference.Text = "Difference   ";
            this.uxDifference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxDifference.Width = 150;
            // 
            // uxNumberOfWords
            // 
            this.uxNumberOfWords.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.uxNumberOfWords.Location = new System.Drawing.Point(194, 5);
            this.uxNumberOfWords.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxNumberOfWords.Name = "uxNumberOfWords";
            this.uxNumberOfWords.Size = new System.Drawing.Size(51, 26);
            this.uxNumberOfWords.TabIndex = 1;
            this.uxNumberOfWords.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxNumberOfWords.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.uxNumberOfWords.ValueChanged += new System.EventHandler(this.uxNumberOfWords_ValueChanged);
            // 
            // uxNumberOfWordsLabel
            // 
            this.uxNumberOfWordsLabel.AutoSize = true;
            this.uxNumberOfWordsLabel.Location = new System.Drawing.Point(9, 7);
            this.uxNumberOfWordsLabel.Name = "uxNumberOfWordsLabel";
            this.uxNumberOfWordsLabel.Size = new System.Drawing.Size(179, 20);
            this.uxNumberOfWordsLabel.TabIndex = 0;
            this.uxNumberOfWordsLabel.Text = "Number of Words Used:";
            this.uxNumberOfWordsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uxSelectedTab
            // 
            this.uxSelectedTab.Controls.Add(this.uxThreshold);
            this.uxSelectedTab.Controls.Add(this.uxThresholdLabel);
            this.uxSelectedTab.Controls.Add(this.uxWordFrequencies);
            this.uxSelectedTab.Location = new System.Drawing.Point(4, 29);
            this.uxSelectedTab.Name = "uxSelectedTab";
            this.uxSelectedTab.Padding = new System.Windows.Forms.Padding(3);
            this.uxSelectedTab.Size = new System.Drawing.Size(766, 630);
            this.uxSelectedTab.TabIndex = 1;
            this.uxSelectedTab.Text = "Selected";
            this.uxSelectedTab.UseVisualStyleBackColor = true;
            // 
            // uxThreshold
            // 
            this.uxThreshold.DecimalPlaces = 5;
            this.uxThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.uxThreshold.Location = new System.Drawing.Point(97, 5);
            this.uxThreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxThreshold.Name = "uxThreshold";
            this.uxThreshold.Size = new System.Drawing.Size(120, 26);
            this.uxThreshold.TabIndex = 2;
            this.uxThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxThreshold.Value = new decimal(new int[] {
            100,
            0,
            0,
            327680});
            this.uxThreshold.ValueChanged += new System.EventHandler(this.uxThreshold_ValueChanged);
            // 
            // uxThresholdLabel
            // 
            this.uxThresholdLabel.AutoSize = true;
            this.uxThresholdLabel.Location = new System.Drawing.Point(8, 7);
            this.uxThresholdLabel.Name = "uxThresholdLabel";
            this.uxThresholdLabel.Size = new System.Drawing.Size(83, 20);
            this.uxThresholdLabel.TabIndex = 1;
            this.uxThresholdLabel.Text = "Threshold:";
            // 
            // uxWordFrequencies
            // 
            this.uxWordFrequencies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxWordFrequencies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uxWord,
            this.uxFrequency});
            this.uxWordFrequencies.GridLines = true;
            this.uxWordFrequencies.HideSelection = false;
            this.uxWordFrequencies.Location = new System.Drawing.Point(8, 34);
            this.uxWordFrequencies.MultiSelect = false;
            this.uxWordFrequencies.Name = "uxWordFrequencies";
            this.uxWordFrequencies.Size = new System.Drawing.Size(750, 588);
            this.uxWordFrequencies.TabIndex = 0;
            this.uxWordFrequencies.UseCompatibleStateImageBehavior = false;
            this.uxWordFrequencies.View = System.Windows.Forms.View.Details;
            this.uxWordFrequencies.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.uxWordFrequencies_ColumnClick);
            // 
            // uxWord
            // 
            this.uxWord.Text = "Word   ";
            this.uxWord.Width = 225;
            // 
            // uxFrequency
            // 
            this.uxFrequency.Text = "Frequency   ";
            this.uxFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxFrequency.Width = 150;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 692);
            this.Controls.Add(this.uxTabs);
            this.Controls.Add(this.uxButtonBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserInterface";
            this.Text = "Text Analyzer";
            this.uxButtonBar.ResumeLayout(false);
            this.uxButtonBar.PerformLayout();
            this.uxTabs.ResumeLayout(false);
            this.uxAllFilesTab.ResumeLayout(false);
            this.uxAllFilesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfWords)).EndInit();
            this.uxSelectedTab.ResumeLayout(false);
            this.uxSelectedTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip uxButtonBar;
        private System.Windows.Forms.ToolStripButton uxOpen;
        private System.Windows.Forms.ToolStripSeparator uxSeparator;
        private System.Windows.Forms.ToolStripLabel uxSelectedLabel;
        private System.Windows.Forms.ToolStripTextBox uxSelectedFile;
        private System.Windows.Forms.TabControl uxTabs;
        private System.Windows.Forms.TabPage uxAllFilesTab;
        private System.Windows.Forms.NumericUpDown uxNumberOfWords;
        private System.Windows.Forms.Label uxNumberOfWordsLabel;
        private System.Windows.Forms.TabPage uxSelectedTab;
        private System.Windows.Forms.ListView uxResults;
        private System.Windows.Forms.NumericUpDown uxThreshold;
        private System.Windows.Forms.Label uxThresholdLabel;
        private System.Windows.Forms.ListView uxWordFrequencies;
        private System.Windows.Forms.ColumnHeader uxWord;
        private System.Windows.Forms.ColumnHeader uxFrequency;
        private System.Windows.Forms.FolderBrowserDialog uxFolderBrowser;
        private System.Windows.Forms.ColumnHeader uxFileNameHeader;
        private System.Windows.Forms.ColumnHeader uxVocabulary;
        private System.Windows.Forms.ColumnHeader uxDifference;
    }
}

