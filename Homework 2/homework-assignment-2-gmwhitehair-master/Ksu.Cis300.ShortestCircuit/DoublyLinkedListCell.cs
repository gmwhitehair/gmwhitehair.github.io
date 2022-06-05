/* DoublyLinkedListCell.cs
 * Author: Gabriel Whitehair
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.ShortestCircuit
{
    /// <summary>
    /// DoublyLinkedListCell<T> class for double linked list
    /// </summary>
    /// <typeparam name="T">Parmater to pass</typeparam>
    public class DoublyLinkedListCell<T> // 1.0
    {
        /// <summary>
        /// Data property
        /// </summary>
        public T Data { get; set; } // 1.1 Data property
        /// <summary>
        /// Next property
        /// </summary>
        public DoublyLinkedListCell<T> Next { get; set; } // 1.2 Next property
        /// <summary>
        /// Previous property
        /// </summary>
        public DoublyLinkedListCell<T> Previous { get; set; } // 1.3 Previous property

    }
}
