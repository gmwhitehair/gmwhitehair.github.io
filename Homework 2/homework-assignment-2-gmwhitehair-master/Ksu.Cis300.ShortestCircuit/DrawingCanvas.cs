/* DrawingCanvas.cs
 * Author: Gabriel Whitehair
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.ShortestCircuit
{
    /// <summary>
    /// DrawingCanvas class for drawing
    /// </summary>
    public partial class DrawingCanvas : UserControl 
    {
        /// <summary>
        /// Field of list of point pairs to be connected
        /// </summary>
        private List<Point[]> _lines = new List<Point[]>(); // 2.3
        /// <summary>
        /// Constructor that initializes component
        /// </summary>
        public DrawingCanvas()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Draws lines when drawing canvas is reinitialized
        /// </summary>
        /// <param name="e">On click, used for OnPaint method</param>
        protected override void OnPaint(PaintEventArgs e) // 2.4
        {
            base.OnPaint(e);
            Pen pen = new Pen(ForeColor); // 2.5 makes a new pen
            foreach (Point[] i in _lines) // 2.6 looping through lines list
            {
                e.Graphics.DrawLine(pen, i[0], i[1]); // Drawing the line
            }
        }

        /// <summary>
        /// Draws line between two points
        /// </summary>
        /// <param name="p1"> Point 1</param>
        /// <param name="p2"> Point 2</param>
        public void DrawLine(Point p1, Point p2) // 2.7 takes two points as paramaters and draws new line segment
        {
            Point[] pointArray = new Point[] { p1, p2 };
            _lines.Add(pointArray); // adding point array to lines field
            Invalidate(); // 2.2: invalidate method to indicate that control needs to be redrawn at next opportunnity
        }
        /// <summary>
        /// Clear method that clears _lines field and invalidates 
        /// </summary>
        public void Clear() // 2.8: clear method to clear the a lot of it
        {
            _lines.Clear();
            Invalidate();
        }
        /// <summary>
        /// Irelevant, ignore, not used. I don't know how to delete these once double clicked without causing issues and it is getting close to the deadline.
        /// </summary>
        /// <param name="sender">On click</param>
        /// <param name="e">On click</param>
        private void DrawingCanvas_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
