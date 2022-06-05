/* LeftistTree.cs
 * Author: Rod Howell */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.TextAnalysis
{
    /// <summary>
    /// An immutable generic leftist tree node that can draw itself.
    /// </summary>
    /// <typeparam name="T">The type of the elements stored in the tree.</typeparam>
    public class LeftistTree<T> : ITree
    {
        /// <summary>
        /// The null path length of the tree rooted at this node.
        /// </summary>
        private int _nullPathLength;

        /// <summary>
        /// Gets the data stored in this node.
        /// </summary>
        public T Data { get; }

        /// <summary>
        /// Gets this node's left child.
        /// </summary>
        public LeftistTree<T> LeftChild { get; }

        /// <summary>
        /// Gets this node's right child.
        /// </summary>
        public LeftistTree<T> RightChild { get; }

        #region Properties implementing the ITree interface

        /// <summary>
        /// Gets the children of this node.
        /// </summary>
        ITree[] ITree.Children
        {
            get
            {
                ITree[] children = new ITree[2];
                children[0] = LeftChild;
                children[1] = RightChild;
                return children;
            }
        }

        /// <summary>
        /// Gets whether this node is empty. Because empty trees will be represented by
        /// null, it always returns false.
        /// </summary>
        bool ITree.IsEmpty => false;

        /// <summary>
        /// Gets the object to be drawn as the contents of this node.
        /// </summary>
        object ITree.Root => Data;

        #endregion

        /// <summary>
        /// Constructs a BinaryTreeNode with the given data, left child, and right child.
        /// </summary>
        /// <param name="data">The data stored in the node.</param>
        /// <param name="left">The left child.</param>
        /// <param name="right">The right child.</param>
        public LeftistTree(T data, LeftistTree<T> left, LeftistTree<T> right)
        {
            Data = data;
            if (NullPathLength(right) < NullPathLength(left))
            {
                LeftChild = left;
                RightChild = right;
            }
            else
            {
                LeftChild = right;
                RightChild = left;
            }
            _nullPathLength = 1 + NullPathLength(RightChild);
        }

        /// <summary>
        /// Gets the null path length of the given tree.
        /// </summary>
        /// <param name="t">The tree.</param>
        /// <returns>The null path length of t.</returns>
        public static int NullPathLength(LeftistTree<T> t)
        {
            if (t == null)
            {
                return 0;
            }
            else
            {
                return t._nullPathLength;
            }
        }
    }
}
