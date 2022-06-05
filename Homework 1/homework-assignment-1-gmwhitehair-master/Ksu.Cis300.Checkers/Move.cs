/* Move.cs
 * Authors: Josh Weese and Rod Howell
 * Commented By: Gabriel Whitehair
 * This was shown as modified because I deleted a bunch of comments for readability, I recommented them in
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.Checkers
{
    /// <summary>
    /// Represents a move, either a single jump or a non-jump.
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Gets boolean true if jump
        /// </summary>
        public bool IsJump { get; }
        /// <summary>
        /// Gets moving player
        /// </summary>
        public Player MovingPlayer { get; }
        /// <summary>
        /// Gets other player
        /// </summary>
        public Player OtherPlayer { get; }
        /// <summary>
        /// Gets point from
        /// </summary>
        public Point From { get; }
        /// <summary>
        /// Gets point to
        /// </summary>
        public Point To { get; }
        /// <summary>
        /// Returns true if from king
        /// </summary>
        public bool FromKing { get; }
        /// <summary>
        /// Captured checker
        /// </summary>
        public Checker CapturedPiece { get; }
        /// <summary>
        /// Captured location
        /// </summary>
        public Point CapturedLocation { get; }
        /// <summary>
        /// Stack of legal moves
        /// </summary>
        public Stack<Move> LegalMoves { get; }

        /// <summary>
        /// Constructs a non-jump move.
        /// </summary>
        /// <param name="from">The square where the move starts.</param>
        /// <param name="to">The square where the move ends.</param>
        /// <param name="fromKing">Indicates whether the moving piece start the move as a king.</param>
        /// <param name="moving">The moving player.</param>
        /// <param name="other">The other player.</param>
        /// <param name="moves">The legal moves at the time this move is made.</param>
        public Move(Point from, Point to, bool fromKing, Player moving, Player other, Stack<Move> moves)
        {
            From = from;
            To = to;
            FromKing = fromKing;
            MovingPlayer = moving;
            OtherPlayer = other;
            LegalMoves = moves;
            IsJump = false;
        }

        /// <summary>
        /// Constructs a jump move.
        /// </summary>
        /// <param name="from">The square where the move starts.</param>
        /// <param name="to">The square where the move ends.</param>
        /// <param name="fromKing">Indicates whether the moving piece start the move as a king.</param>
        /// <param name="moving">The moving player.</param>
        /// <param name="other">The other player.</param>
        /// <param name="moves">The legal moves at the time this move is made.</param>
        /// <param name="cap">The captured piece.</param>
        /// <param name="capLoc">The location of the captured piece.</param>
        public Move(Point from, Point to, bool fromKing, Player moving, Player other, Stack<Move> moves, 
            Checker cap, Point capLoc)
        {
            From = from;
            To = to;
            FromKing = fromKing;
            MovingPlayer = moving;
            OtherPlayer = other;
            LegalMoves = moves;
            CapturedPiece = cap;
            CapturedLocation = capLoc;
            IsJump = true;
        }
        /// <summary>
        /// Gets a string representation of this move.
        /// </summary>
        /// <returns>The string representation of this move.</returns>
        public override string ToString()
        {
            string move = MovingPlayer.Name + "-" + From.X +"," + From.Y + " to " + To.X + "," + To.Y;
            if (!IsJump)
            {
                return move;
            }
            else
            {
                StringBuilder sb = new StringBuilder(MovingPlayer.Name + " Jump--");
                sb.Append(move);
                sb.Append("(capt: ");
                sb.Append(CapturedLocation.X + "," + CapturedLocation.Y);
                return sb.ToString();
            }
        }

    }
}
