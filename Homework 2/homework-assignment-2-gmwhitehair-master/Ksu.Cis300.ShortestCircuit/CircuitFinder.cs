/* CircuitFinder.cs
 * Author: Gabriel Whitehair
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.ShortestCircuit
{
    /// <summary>
    /// 3.0: Public class CircuitFinder that deals with algorithm of finding shortest circuit
    /// </summary>
    public static class CircuitFinder
    {
        /// <summary>
        /// 3.1: GetDistances returns an array of distances for a list of Points
        /// </summary>
        /// <param name="p">List of points</param>
        /// <returns>Double array with distances between points</returns>
        private static double[,] GetDistances(List<Point> p)
        {
            double[,] n = new double[p.Count, p.Count];
            for (int i = 0; i < p.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int xSide = (p[i].X - p[j].X); // (x1 - x2) ^2
                    int ySide = (p[i].Y - p[j].Y); // (y1 - y2) ^ 2
                    double squareRoot = Math.Sqrt(xSide * xSide + ySide * ySide); // square root of above
                    n[i, j] = n[j,i] = squareRoot;
                }
            }
            return n;
        }
        /// <summary>
        /// 3.2: Restores the original position within a list
        /// </summary>
        /// <param name="cell">Cell to be restored</param>
        private static void Restore(DoublyLinkedListCell<int> cell) 
        {
            cell.Previous.Next = cell; 
            cell.Next.Previous = cell; 
        }

        /// <summary>
        /// 3.3: Builds a list of unused indicies from 1 to n-1
        /// </summary>
        /// <param name="n">number to cells to add</param>
        /// <returns>A linked list cell with the unused cells</returns>
        private static DoublyLinkedListCell<int> GetList(int n) 
        {
            DoublyLinkedListCell<int> header = new DoublyLinkedListCell<int>();
            header.Next = header;
            header.Previous = header;
            for (int i = 1; i < n; i++)
            {
                DoublyLinkedListCell<int> toAdd = new DoublyLinkedListCell<int>();
                toAdd.Data = i;
                toAdd.Previous = header.Previous;
                toAdd.Next = header;
                Restore(toAdd);
            }
            return header;
        }

        /// <summary>
        /// 3.4: Moves a linkedlist cell onto the stack
        /// </summary>
        /// <param name="cell">LinkedList cell</param>
        /// <param name="s"> Stack of doubly linked list cells</param>
        private static void MoveToStack(DoublyLinkedListCell<int> cell, Stack<DoublyLinkedListCell<int>> s)
        {
            cell.Previous.Next = cell.Next;
            cell.Next.Previous = cell.Previous;
            s.Push(cell);
        }

        /// <summary>
        /// 3.5: Finishes permutation by passing in begining
        /// </summary>
        /// <param name="stack">Begining of permutation</param>
        /// <param name="cell">Unused indicies</param>
        /// <param name="distances">Array with distances between points</param>
        /// <param name="limit">Used to compare to length of adding a length</param>
        /// <returns>Double of length of finishing permutation</returns>
        private static double FinishPermutation(Stack<DoublyLinkedListCell<int>> stack, DoublyLinkedListCell<int> cell, double[,] distances, double limit)
        {
            DoublyLinkedListCell<int> n1 = cell.Next;
            double length = 0;
           
            while ((distances[stack.Peek().Data, 0] + length) < limit && (cell != n1))
            {
                length += distances[stack.Peek().Data, n1.Data];
                MoveToStack(n1, stack);
                n1 = n1.Next;
            }

            return length;
        }

        /// <summary>
        /// 3.6: Gets next prefix for permutation
        /// </summary>
        /// <param name="stack">Stack for begining</param>
        /// <param name="header">Unused indexes</param>
        /// <param name="distances">Distances array with distances between points</param>
        /// <returns>Length of prefix of permutation</returns>
        private static double GetNextPrefix(Stack<DoublyLinkedListCell<int>> stack, DoublyLinkedListCell<int> header, double[,] distances)
        {
            double length = 0;
            DoublyLinkedListCell<int> n1 = null;
            do
            {
                n1 = stack.Pop();
                length -= distances[n1.Data, stack.Peek().Data];
                Restore(n1);
            } while (n1.Next == header);
           
            n1 = n1.Next;
            length += distances[stack.Peek().Data, n1.Data];
            MoveToStack(n1, stack);
            return length;
        }

        /// <summary>
        /// 3.7: Gets the ciruit for list of points
        /// </summary>
        /// <param name="stack">Stack of indicies</param>
        /// <param name="points">Points to be added to circuit</param>
        /// <returns>List of points of the circuit</returns>
        private static List<Point> GetCircuit(Stack<DoublyLinkedListCell<int>> stack, List<Point> points)
        {
            List<Point> circuit = new List<Point>();

            circuit.Add(points[0]);
            foreach (DoublyLinkedListCell<int> i in stack)
            {
                circuit.Add(points[i.Data]);
            }

            return circuit;

        }

        /// <summary>
        /// 3.8: Gets the shortest circuit by calling other methods
        /// </summary>
        /// <param name="points">Points list to be passed in</param>
        /// <param name="shortest">Points list to be passed out of shortest circuit</param>
        /// <returns>Double with length of shortest circuit</returns>
        public static double GetShortestCircuit(List<Point> points, out List<Point> shortest)
        {
            double[,] lengths = GetDistances(points);
            Stack<DoublyLinkedListCell<int>> currentPath = new Stack<DoublyLinkedListCell<int>>();
            DoublyLinkedListCell<int> zero = new DoublyLinkedListCell<int> { Data = 0 };
            currentPath.Push(zero);
            DoublyLinkedListCell<int> unusedIndicies = GetList(points.Count);
            double lengthOfCurrentPath = 0;
            double minimumLength = double.PositiveInfinity;
            int firstIndex = 1;
            shortest = null;

            while (firstIndex < (points.Count - 1))
            {
                if (firstIndex < unusedIndicies.Previous.Data)
                {
                    lengthOfCurrentPath += FinishPermutation(currentPath, unusedIndicies, lengths, minimumLength - lengthOfCurrentPath);
                    double fullLength = lengthOfCurrentPath + lengths[currentPath.Peek().Data, 0];
                    if (fullLength < minimumLength)
                    {
                        minimumLength = fullLength;
                        shortest = GetCircuit(currentPath, points);
                    } 
                }
                lengthOfCurrentPath += GetNextPrefix(currentPath, unusedIndicies, lengths);

                if(currentPath.Count == 2)
                {
                    firstIndex = currentPath.Peek().Data;
                }
            }
            return minimumLength;
        }
    }
}
