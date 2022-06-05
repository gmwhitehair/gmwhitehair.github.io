/* UserInterface.cs
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
    /// UserInterface class for the form, handles alot of event handlers
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// 4.1: List field with points
        /// </summary>
        List<Point> _points = new List<Point>();
        /// <summary>
        /// 4.2: Last known mouse location
        /// </summary>
        Point _lastMouseLocation = new Point(-1, -1);

        /// <summary>
        /// Constructor that initializes component
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Plots a point by drawing two vertical lines
        /// </summary>
        /// <param name="p">Point to be drawn</param>
        private void Plot(Point p)
        {
            Point p1 = new Point(p.X + 1, p.Y + 1);
            Point p2 = new Point(p.X - 1, p.Y - 1);
            Point p3 = new Point(p.X - 1, p.Y + 1);
            Point p4 = new Point(p.X + 1, p.Y - 1);

            uxDrawingCanvas.DrawLine(p1, p2);
            uxDrawingCanvas.DrawLine(p3, p4);

        }
        /// <summary>
        /// When clicking mouse, make a point
        /// </summary>
        /// <param name="sender">On click</param>
        /// <param name="e">Used to find e.Location for point</param>
        private void drawingCanvas1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p1 = e.Location;
            Plot(p1);
            _points.Add(p1);
            if (_points.Count > 2)
            {
                uxFindCircuit.Enabled = true;
            }

            uxListBox.Items.Add(p1);
        }
        /// <summary>
        /// When moving mouse update tool tip
        /// </summary>
        /// <param name="sender">On click</param>
        /// <param name="e">e.Location used to find point</param>
        private void drawingCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            Point p1 = e.Location;
            if (p1 != _lastMouseLocation)
            {
                uxToolTip.SetToolTip(uxDrawingCanvas, p1.ToString());
                _lastMouseLocation = p1;
            }
        }

        /// <summary>
        /// When clicking on find circuit, draw the points
        /// </summary>
        /// <param name="sender">On click</param>
        /// <param name="e">On click</param>
        private void uxFindCircuit_Click(object sender, EventArgs e)
        {
            List<Point> outPoints = new List<Point>();
            double circuitLength = CircuitFinder.GetShortestCircuit(_points, out outPoints);
            uxDrawingCanvas.Clear();
            uxListBox.Items.Clear();
            for (int i = 0; i < outPoints.Count - 1; i++)
            {
                Plot(outPoints[i]);
                uxDrawingCanvas.DrawLine(outPoints[i], outPoints[i+1]);
                uxListBox.Items.Add(outPoints[i]);
            }

            MessageBox.Show("The length of the shortest circuit is: " + circuitLength);
        }
        /// <summary>
        /// When clicking on clear, clear board and points field
        /// </summary>
        /// <param name="sender">On click</param>
        /// <param name="e">On click</param>
        private void uxClear_Click(object sender, EventArgs e)
        {
            uxDrawingCanvas.Clear();
            uxListBox.Items.Clear();
            _points.Clear();
            uxFindCircuit.Enabled = false;
        }
    }
}
 