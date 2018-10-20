using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai
{
    public class Bot
    {
        Stopwatch myStopwatch; // Used for timing moves
        int myTimeLimit;
        int escapeTime;

        /// Bot constructor
        public Bot(int timeLimit)
        {
            myTimeLimit = timeLimit;
            myStopwatch = new Stopwatch();
            escapeTime = 1000;
        }

        /// Find best move given a game Board object and time limit
        public int[] getMove(Board board)
        {
            // Begin timing
            myStopwatch.Reset();
            myStopwatch.Start();

            // Iterate search depth until out of time...
            // ...or depth too far (meaning bot sees endgame)
            int depth = 0;
            int[] lastMove = new int[] { -1, -1 };
            int[] move = new int[] { -1, -1 };
            while (myStopwatch.ElapsedMilliseconds < myTimeLimit - escapeTime && depth <= 100)
            {
                move.CopyTo(lastMove, 0);
                alphabeta(board, depth, int.MinValue, int.MaxValue).Item1.CopyTo(move, 0);
                depth++;
            }
            if(lastMove[0] == -1)
            {
                board.moveSpace();
                return board.moveSpace()[0];
            }
            Console.WriteLine("depth: " + (depth - 1));
            return lastMove; // because move may contain an uneducated decision
        }

        /// Alpha-beta algorithm
        Tuple<int[], int> alphabeta(Board board, int depth, int a, int b)
        {
            int[] bestMove = new int[] { -1, -1 };
            int v1, v2;

            if (depth == 0 || board.myGameOver)
                return Tuple.Create(new int[] { -1, -1 }, evaluate(board));
            if (board.myPlayersTurn == 1) // Maximizing
            {
                v1 = int.MinValue;
                foreach (int[] move in board.moveSpace())
                {
                    if (myStopwatch.ElapsedMilliseconds > myTimeLimit - escapeTime)
                        break;
                    Board tempBoard = new Board(board);
                    tempBoard.makeMove(move);
                    v2 = alphabeta(tempBoard, depth - 1, a, b).Item2;
                    if (v2 > v1)
                    {
                        v1 = v2;
                        move.CopyTo(bestMove, 0);
                    }
                    a = Math.Max(a, v1);
                    if (a >= b)
                        break;
                }
            } else
            { // Minimizing
                v1 = int.MaxValue;
                foreach (int[] move in board.moveSpace())
                {
                    if (myStopwatch.ElapsedMilliseconds > myTimeLimit - escapeTime)
                        break;
                    Board tempBoard = new Board(board);
                    tempBoard.makeMove(move);
                    v2 = alphabeta(tempBoard, depth - 1, a, b).Item2;
                    if (v2 < v1)
                    {
                        v1 = v2;
                        move.CopyTo(bestMove, 0);
                    }
                    b = Math.Min(b, v1);
                    if (a >= b)
                        break;
                }
            }
            return Tuple.Create(bestMove, v1);
        }
  
        /// Board evaluation function
        public int evaluate(Board b)
        {
            int score = 0;
            int winScore = 1000;
            int cornerScore = 100;
            int edgeScore = 10;
            
            // Score very highly for winning
            if (b.myWinner == 1)
                score += winScore;
            else
                score -= winScore;

            // Score captured tiles (1pt each) REVERSED
            score -= b.myP1Score - b.myP2Score;

            // Score corners (100pt)
            if (b.myBoard[0][0] == 1)
                score += cornerScore;
            else if (b.myBoard[0][0] == 2)
                score -= cornerScore;
            if (b.myBoard[7][0] == 1)
                score += cornerScore;
            else if (b.myBoard[7][0] == 2)
                score -= cornerScore;
            if (b.myBoard[0][7] == 1)
                score += cornerScore;
            else if (b.myBoard[0][7] == 2)
                score -= cornerScore;
            if (b.myBoard[7][7] == 1)
                score += cornerScore;
            else if (b.myBoard[7][7] == 2)
                score -= cornerScore;

            // Score edge pieces
            for (int row = 2; row < 6; row++)
            {
                if (b.myBoard[row][0] == 1)
                    score += edgeScore;
                else if (b.myBoard[row][0] == 2)
                    score -= edgeScore;
                if (b.myBoard[row][7] == 1)
                    score += edgeScore;
                else if (b.myBoard[row][7] == 2)
                    score -= edgeScore;
            }
            for (int col = 2; col < 6; col++)
            {
                if (b.myBoard[0][col] == 1)
                    score += edgeScore;
                else if (b.myBoard[0][col] == 2)
                    score -= edgeScore;
                if (b.myBoard[7][col] == 1)
                    score += edgeScore;
                else if (b.myBoard[7][col] == 2)
                    score -= edgeScore;
            }

            return score;
        }
    }
}
