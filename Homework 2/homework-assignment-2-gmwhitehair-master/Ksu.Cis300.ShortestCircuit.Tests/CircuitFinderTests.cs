/* CircuitFinderTests.cs
 * Author: Rod Howell
 */
using NUnit.Framework;
using System;
using System.Drawing;
using System.Collections.Generic;

namespace Ksu.Cis300.ShortestCircuit.Tests
{
    /// <summary>
    /// Unit tests for the CircuitFinder class.
    /// </summary>
    [TestFixture]
    public class CircuitFinderTests
    {
        /// <summary>
        /// The points used in each of the tests.
        /// </summary>
        Point[][] _testCasePoints = new Point[][]
        {
            new Point[] { new Point(100, 100), new Point(400, 100), new Point(400, 500) }, // ShortTest(0)
            new Point[]
            {
                new Point(200, 200), new Point(700, 200), new Point(200, 600),             // ShortTest(1)
                new Point(400, 600)
            },
            new Point[]
            {
                new Point(200, 200), new Point(400, 600), new Point(700, 200),             // ShortTest(2)
                new Point(200, 600)                                                        //
            },
            new Point[]
            {
                new Point(100, 100), new Point(156, 100), new Point(120, 115),             // ShortTest(3)
                new Point(156, 135), new Point(100, 135)                                   //
            },
            new Point[]
            {
                new Point(229, 71), new Point(165, 149), new Point(301, 152),              // ShortTest(4)
                new Point(227, 220)                                                        // 
            },
            new Point[]
            {
                new Point(100, 500), new Point(100, 100), new Point(105, 100),             // LongTest(5)
                new Point(110, 100), new Point(115, 100), new Point(120, 100),             //
                new Point(125, 100), new Point(125, 900), new Point(120, 900),             //
                new Point(115, 900), new Point(110, 900), new Point(105, 900),             //
                new Point(100, 900)                                                        //
            },
            new Point[]
            {
                new Point(442, 302), new Point(358, 229), new Point(538, 230),             // LongTest(6)
                new Point(359, 374), new Point(551, 372), new Point(441, 158),             //
                new Point(452, 415), new Point(284, 289), new Point(598, 280),             //
                new Point(299, 154), new Point(567, 158), new Point(580, 423),             //
                new Point(292, 409)                                                        //
            }
        };

        /// <summary>
        /// The expected length of the shortest circuit for each of the tests. The length found
        /// must be within 0.001 of the expected length.
        /// </summary>
        double[] _testCaseLengths = new double[]
        {
            1200,             // ShortTest(0)
            1600,             // ShortTest(1)
            1600,             // ShortTest(2)
            190,              // ShortTest(3)
            404.029371419559, // ShortTest(4)
            1650,             // LongTest(5)
            1323.87782779161  // LongTest(6)
        };

        /// <summary>
        /// The expected circuit for each of the tests. The circuit found may be the reverse of the expected
        /// circuit.
        /// </summary>
        Point[][] _testCaseResults = new Point[][]
        {
            new Point[]
            {
                new Point(100, 100), new Point(400, 500), new Point(400, 100), // ShortTest(0)
                new Point(100, 100)                                            //
            },
            new Point[]
            {
                new Point(200, 200), new Point(200, 600), new Point(400, 600), // ShortTest(1)
                new Point(700, 200), new Point(200, 200)
            },
            new Point[]
            {
                new Point(200, 200), new Point(200, 600), new Point(400, 600), // ShortTest(2)
                new Point(700, 200), new Point(200, 200)
            },
            new Point[]
            {
                new Point(100, 100), new Point(100, 135), new Point(156, 135), // ShortTest(3)
                new Point(156, 100), new Point(120, 115), new Point(100, 100)  //
            },
            new Point[]
            {
                new Point(229, 71), new Point(301, 152), new Point(227, 220),  // ShortTest(4)
                new Point(165, 149), new Point(229, 71)
            },
            new Point[]
            {
                new Point(100, 500), new Point(100, 900), new Point(105, 900), // LongTest(5)
                new Point(110, 900), new Point(115, 900), new Point(120, 900), //
                new Point(125, 900), new Point(125, 100), new Point(120, 100), //
                new Point(115, 100), new Point(110, 100), new Point(105, 100), //
                new Point(100, 100), new Point(100, 500)                       //
            },
            new Point[]
            {
                new Point(442, 302), new Point(452, 415), new Point(580, 423), // LongTest(6)
                new Point(551, 372), new Point(598, 280), new Point(538, 230), //
                new Point(567, 158), new Point(441, 158), new Point(299, 154), //
                new Point(358, 229), new Point(284, 289), new Point(292, 409), //
                new Point(359, 374), new Point(442, 302)                       //
            }
        };

        /// <summary>
        /// Runs the test case provided at the given index within the above fields.
        /// </summary>
        /// <param name="index">The index for the test case.</param>
        public void TestGetShortestCircuit(int index)
        {
            List<Point> pointsList = new List<Point>(_testCasePoints[index]);
            double len = CircuitFinder.GetShortestCircuit(pointsList, out List<Point> result);
            Assert.Multiple(() =>
            {
                Assert.That(Math.Abs(len - _testCaseLengths[index]), Is.LessThan(0.000001));
                Assert.That(_testCaseResults[index], Is.EqualTo(result));
            });
        }

        /// <summary>
        /// Runs the test case provided at the given index with a timeout of 1 second.
        /// </summary>
        /// <param name="index">The index for the test case.</param>
        [Test, Category("A: Short Tests")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [Timeout(1000)]
        public void ShortTest(int index)
        {
            TestGetShortestCircuit(index);
        }

        /// <summary>
        /// Runs the test case provided at the given index with a timeout of 10 seconds.
        /// </summary>
        /// <param name="index">The index for the test case.</param>
        [Test, Category("B: Long Tests")]
        [TestCase(5)]
        [TestCase(6)]
        [Timeout(10000)]
        public void LongTest(int index)
        {
            TestGetShortestCircuit(index);
        }
    }
}
