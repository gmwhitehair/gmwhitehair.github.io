namespace Ksu.Cis300.ShortestCircuit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterface));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.uxFindCircuit = new System.Windows.Forms.ToolStripButton();
            this.uxClear = new System.Windows.Forms.ToolStripButton();
            this.uxSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uxListBox = new System.Windows.Forms.ListBox();
            this.uxToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.uxDrawingCanvas = new Ksu.Cis300.ShortestCircuit.DrawingCanvas();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxSplitContainer)).BeginInit();
            this.uxSplitContainer.Panel1.SuspendLayout();
            this.uxSplitContainer.Panel2.SuspendLayout();
            this.uxSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxFindCircuit,
            this.uxClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1200, 34);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // uxFindCircuit
            // 
            this.uxFindCircuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uxFindCircuit.Enabled = false;
            this.uxFindCircuit.Image = ((System.Drawing.Image)(resources.GetObject("uxFindCircuit.Image")));
            this.uxFindCircuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxFindCircuit.Name = "uxFindCircuit";
            this.uxFindCircuit.Size = new System.Drawing.Size(104, 29);
            this.uxFindCircuit.Text = "Find Circuit";
            this.uxFindCircuit.Click += new System.EventHandler(this.uxFindCircuit_Click);
            // 
            // uxClear
            // 
            this.uxClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uxClear.Image = ((System.Drawing.Image)(resources.GetObject("uxClear.Image")));
            this.uxClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxClear.Name = "uxClear";
            this.uxClear.Size = new System.Drawing.Size(55, 29);
            this.uxClear.Text = "Clear";
            this.uxClear.Click += new System.EventHandler(this.uxClear_Click);
            // 
            // uxSplitContainer
            // 
            this.uxSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxSplitContainer.Location = new System.Drawing.Point(0, 34);
            this.uxSplitContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxSplitContainer.Name = "uxSplitContainer";
            // 
            // uxSplitContainer.Panel1
            // 
            this.uxSplitContainer.Panel1.Controls.Add(this.uxDrawingCanvas);
            // 
            // uxSplitContainer.Panel2
            // 
            this.uxSplitContainer.Panel2.Controls.Add(this.uxListBox);
            this.uxSplitContainer.Size = new System.Drawing.Size(1200, 658);
            this.uxSplitContainer.SplitterDistance = 885;
            this.uxSplitContainer.SplitterWidth = 6;
            this.uxSplitContainer.TabIndex = 1;
            // 
            // uxListBox
            // 
            this.uxListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxListBox.FormattingEnabled = true;
            this.uxListBox.ItemHeight = 20;
            this.uxListBox.Location = new System.Drawing.Point(0, 0);
            this.uxListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxListBox.Name = "uxListBox";
            this.uxListBox.Size = new System.Drawing.Size(309, 658);
            this.uxListBox.TabIndex = 0;
            // 
            // uxDrawingCanvas
            // 
            this.uxDrawingCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxDrawingCanvas.Location = new System.Drawing.Point(0, 0);
            this.uxDrawingCanvas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxDrawingCanvas.Name = "uxDrawingCanvas";
            this.uxDrawingCanvas.Size = new System.Drawing.Size(885, 658);
            this.uxDrawingCanvas.TabIndex = 0;
            this.uxDrawingCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawingCanvas1_MouseClick);
            this.uxDrawingCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingCanvas1_MouseMove);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.uxSplitContainer);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserInterface";
            this.Text = "Shortest Circuit";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.uxSplitContainer.Panel1.ResumeLayout(false);
            this.uxSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxSplitContainer)).EndInit();
            this.uxSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton uxFindCircuit;
        private System.Windows.Forms.ToolStripButton uxClear;
        private System.Windows.Forms.SplitContainer uxSplitContainer;
        private System.Windows.Forms.ListBox uxListBox;
        private DrawingCanvas uxDrawingCanvas;
        private System.Windows.Forms.ToolTip uxToolTip;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}

