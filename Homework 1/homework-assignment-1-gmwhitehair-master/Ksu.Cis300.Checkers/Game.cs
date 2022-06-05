/* Game.cs
 * Authors: Josh Weese and Rod Howell
 * Modified By: Gabriel Whitehair
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ksu.Cis300.Checkers
{
    /// <summary>
    /// This class contains the logic for the game of Checkers
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Checker board
        /// </summary>
        private Checker[,] _board = new Checker[8, 8];
        /// <summary>
        /// Boolean if square is selected
        /// </summary>
        private bool _squareIsSelected;
        /// <summary>
        /// Point of selected square
        /// </summary>
        private Point _selectedSquare;
        /// <summary>
        /// New blacker for black
        /// </summary>
        private Player _blackPlayer = new Player(-1, "Black");
        /// <summary>
        /// New player for white
        /// </summary>
        private Player _whitePlayer = new Player(1, "White");
        /// <summary>
        /// Current player
        /// </summary>
        private Player _currentPlayer;
        /// <summary>
        /// Other player
        /// </summary>
        private Player _otherPlayer;
        /// <summary>
        /// Stack of legal moves
        /// </summary>
        private Stack<Move> _legalMoves = new Stack<Move>();
        /// <summary>
        /// Array of directions for kings
        /// </summary>
        private Point[] _allDirections = new Point[] { new Point(-1, -1), new Point(-1, 1), new Point(1, -1), new Point(1, 1) };
        /// <summary>
        /// Move history stack
        /// </summary>
        private Stack<Move> _moveHistory = new Stack<Move>();
        /// <summary>
        /// Current name property, black is first
        /// </summary>
        public string CurrentName { get; private set; } = "Black";
        /// <summary>
        /// Other name property
        /// </summary>
        public string OtherName { get; private set; } = "White"; 
        /// <summary>
        /// IsOver property boolean, 
        /// </summary>
        public bool IsOver { get; private set; } = false; 
        /// <summary>
        /// Gets the contents of the given square.
        /// </summary>
        /// <param name="square">The square to check.</param>
        /// <returns>The contents of square.</returns>
        public SquareContents GetContents(Point square) 
        {
            int xCord = square.X;
            int yCord = square.Y;
            if (xCord > 7 || xCord < 0 || yCord < 0 || yCord > 7) {
                return SquareContents.Invalid;
            }
            else if (_board[xCord,yCord] == null) {
                return SquareContents.None;
            }
            else {
                if ((_board[xCord,yCord].Owner == _whitePlayer) && _board[xCord, yCord].IsKing) {
                    return SquareContents.WhiteKing;
                }
                else if ((_board[xCord, yCord].Owner == _whitePlayer) && !(_board[xCord, yCord].IsKing)) {
                    return SquareContents.WhitePawn;
                }
                if ((_board[xCord, yCord].Owner == _blackPlayer) && _board[xCord, yCord].IsKing) {
                    return SquareContents.BlackKing;
                }
                else if ((_board[xCord, yCord].Owner == _blackPlayer) && !(_board[xCord, yCord].IsKing)) {
                    return SquareContents.BlackPawn;
                }
                else {
                    return SquareContents.Invalid; // do we need this all paths statement?
                }
            }
        }
        /// <summary>
        /// Returns Point[] of movement directions for a point
        /// </summary>
        /// <param name="isKing">True if a king</param>
        /// <returns>Array of possible movements</returns>
        private Point[] GetValidDirections(bool isKing)
        {
            if (isKing) {
                return _allDirections;
            }
            else {
               return _currentPlayer.PawnDirections;
            }
        }
        /// <summary>
        /// Pushes non moves onto legal moves stack
        /// </summary>
        /// <param name="square">Point starting</param>
        private void GetNonJumpsFrom(Point square)
        {
            Point[] moves = GetValidDirections(_board[square.X, square.Y].IsKing);
            foreach (Point d in moves)
            {
                Point p = new Point(square.X + d.X, square.Y + d.Y);
                if (GetContents(p) == SquareContents.None)
                {
                    Move m1 = new Move(square, p, _board[square.X, square.Y].IsKing, _currentPlayer, _otherPlayer, _legalMoves);
                    _legalMoves.Push(m1);
                }
            }
        }
        /// <summary>
        /// Returns if the starting point can jump or not
        /// </summary>
        /// <param name="square">Starting point</param>
        /// <param name="direction">Adjacent square</param>
        /// <returns></returns>
        private bool CanJump(Point square, Point direction)
        {
            Point adjacentPoint2 = new Point((square.X + direction.X * 2), (square.Y + direction.Y * 2));
            SquareContents adjacentSquare2 = GetContents(adjacentPoint2);
            if (adjacentSquare2 == SquareContents.None)
            {
                Point adjacentPoint = new Point((square.X + direction.X), (square.Y + direction.Y));
                Checker enemyPiece = _board[adjacentPoint.X, adjacentPoint.Y];
                if (enemyPiece != null && enemyPiece.Owner == _otherPlayer)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Pushes jump moves onto legal moves
        /// </summary>
        /// <param name="square">Starting point</param>
        private void GetJumpsFrom(Point square)
        {
            Point[] moves = GetValidDirections(_board[square.X, square.Y].IsKing);
            int movesLength = moves.Length;
            for (int i = 0; i < movesLength; i++)
            {
                if (CanJump(square, moves[i]))
                {
                    Point adjacentPoint2 = new Point((square.X + moves[i].X * 2), (square.Y + moves[i].Y * 2));
                    Point adjacentPoint = new Point(square.X + moves[i].X, square.Y + moves[i].Y);
                    Move m1 = new Move(square, adjacentPoint2, _board[square.X, square.Y].IsKing, _currentPlayer, _otherPlayer, _legalMoves, _board[square.X + moves[i].X, square.Y + moves[i].Y], adjacentPoint);
                    _legalMoves.Push(m1);
                }
            }
        }
        /// <summary>
        /// Gets moves for the piece
        /// </summary>
        /// <param name="isJump">True for jump moves</param>
        private void GetMoves(bool isJump)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Checker piece = _board[i, j];
                    if (piece != null)
                    {
                        if (piece.Owner == _currentPlayer)
                        {
                            Point pointToCheck = new Point(i, j);
                            if (isJump)
                            {
                                GetJumpsFrom(pointToCheck);
                            }
                            else
                            {
                                GetNonJumpsFrom(pointToCheck);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Constructor for game, sets up the board
        /// </summary>
        public Game()
        {
            _currentPlayer = _blackPlayer;
            _otherPlayer = _whitePlayer;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (((i + j) % 2) != 0)
                    {
                        if (j < 3)
                        {
                            _board[i,j] = new Checker(_whitePlayer);
                        }
                        else if (j > 4) 
                        {
                            _board[i,j] = new Checker(_blackPlayer);
                        }
                    }
                }
            }
            GetMoves(false); 
        }
        /// <summary>
        /// Ends the turn for the current player
        /// </summary>
        private void EndTurn()
        {
            Player temporaryPlayer = _currentPlayer;
            _currentPlayer = _otherPlayer;
            _otherPlayer = temporaryPlayer;

            _legalMoves = new Stack<Move>();
            GetMoves(true);
            if (_legalMoves.Count == 0)
            {
                GetMoves(false);
            }

            _squareIsSelected = false;

            string temporaryName = CurrentName;
            CurrentName = OtherName;
            OtherName = temporaryName;
            if(_legalMoves.Count == 0)
            {
                IsOver = true;
            }
        }
        /// <summary>
        /// Trys to get a move from one point to another
        /// </summary>
        /// <param name="square1">Point start</param>
        /// <param name="square2">Point end</param>
        /// <returns></returns>
        private Move TryGetMove(Point square1, Point square2)
        {
            foreach (Move m in _legalMoves)
            {
                if (m.From == square1 && m.To == square2)
                {
                    return m;
                }
            }
            return null;
        }
        /// <summary>
        /// Selection for userinterface
        /// </summary>
        /// <param name="target">Starting point</param>
        /// <returns>Boolean if selected</returns>
        public bool SelectOrMove(Point target)
        {
            if (TrySelectSquare(target))
            {
                return true;
            }
            else if (_squareIsSelected)
            {
                Move m = TryGetMove(_selectedSquare, target);
                if (m == null)
                {
                    return false;
                }
                else
                {
                    DoMove(m);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Does the move for the pieces, assigns new spots
        /// </summary>
        /// <param name="move1">Move being passed in</param>
        private void DoMove(Move move1)
        {
            _moveHistory.Push(move1);

            Point from = move1.From;
            Point to = move1.To;
            bool fromKing = move1.FromKing;
            _currentPlayer = move1.MovingPlayer;
            _otherPlayer = move1.OtherPlayer;
            Checker capturedChecker = move1.CapturedPiece;
            Point capturedPoint = move1.CapturedLocation;

            Checker movingChecker = _board[from.X, from.Y];

            _board[to.X, to.Y] = movingChecker;
            _board[from.X, from.Y] = null;
            
            if(to.Y == _currentPlayer.KingAt)
            {
                _board[to.X, to.Y].IsKing = true;
            }
           

            if (move1.IsJump)
            {
                _board[capturedPoint.X, capturedPoint.Y] = null;

                if (!(movingChecker.IsKing) || move1.FromKing)
                {
                    _legalMoves = new Stack<Move>();
                    GetJumpsFrom(to);
                    if (_legalMoves.Count != 0)
                    {
                        TrySelectSquare(to);
                        return;
                    }
                }
            }
            EndTurn();

        }
        /// <summary>
        /// Sees if the square is selected
        /// </summary>
        /// <param name="square">Starting point</param>
        /// <returns>If square is selected and if it's the same square, boolean</returns>
        public bool IsSelected(Point square)
        {
            if (_squareIsSelected && square == _selectedSquare)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Asks if it is a legal start
        /// </summary>
        /// <param name="square">Starting point</param>
        /// <returns>Returns boolean if found in legalMoves stack</returns>
        private bool IsLegalStart(Point square)
        {
            foreach (Move m in _legalMoves)
            {
                if (m.From == square)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Asks if you can selected square, assigns fields if legal start if yes
        /// </summary>
        /// <param name="square">Starting point</param>
        /// <returns>Boolean for if you can try select</returns>
        private bool TrySelectSquare(Point square)
        {
            if (IsLegalStart(square))
            {
                _squareIsSelected = true;
                _selectedSquare = square;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Undo method
        /// </summary>
        /// <returns>True if we can undo</returns>
        public bool Undo()
        {
            if (_moveHistory.Count != 0)
            {
                Move move1 = _moveHistory.Pop();
                bool jump = move1.IsJump;
                _currentPlayer = move1.MovingPlayer;
                _otherPlayer = move1.OtherPlayer;
                _legalMoves = move1.LegalMoves;
                Point from = move1.From;
                Point to = move1.To;

                Checker localPiece = _board[to.X, to.Y];
                _board[from.X, from.Y] = localPiece;
                _board[to.X, to.Y] = null;
                bool startasKing = move1.FromKing;

                if (!startasKing)
                {
                    _board[from.X, from.Y].IsKing = false;
                }
                
                if (jump)
                {
                    Checker capturedChecker = move1.CapturedPiece;
                    Point capturedPoint = move1.CapturedLocation;
                    _board[capturedPoint.X, capturedPoint.Y] = capturedChecker;
                }

                IsOver = false;
                CurrentName = _currentPlayer.Name;
                OtherName = _otherPlayer.Name;

                TrySelectSquare(from);

                return true;
            }
            return false;
        }
    }
}
