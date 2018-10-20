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

        /// Bot constructor
        public Bot(int timeLimit)
        {
            myTimeLimit = timeLimit;
            myStopwatch = new Stopwatch();
        }

        /// Find best move given a game Board object and time limit
        public int[] getMove(Board board)
        {
            // For now... just return random legal move
            int[] rmove = new int[] { 0, 0 };
            Random r = new Random();
            while (board.legalMove(rmove).Count == 0)
            {
                rmove = new int[] { r.Next(0, 8), r.Next(0, 8) };
            }
            return rmove;

            // Begin timing
            myStopwatch.Reset();
            myStopwatch.Start();

            // Iterate search depth until out of time...
            // ...or depth too far (meaning bot sees endgame)
            int depth = 0;
            int lastMove = -1;
            int move = -1;
            while (myStopwatch.ElapsedMilliseconds < myTimeLimit && depth <= 100)
            {
                lastMove = move;
                //move = alphabeta(board, depth, int.MinValue, int.MaxValue).Item1;
                depth++;
            }

            //return lastMove; // because move may contain an uneducated decision
        }

        /// Alpha-beta algorithm
         /*
        Tuple<int, int> alphabeta(Board board, int depth, int a, int b)
        {
            int bestMove = -1;
            int v1, v2;

            if (depth == 0 || board.myGameOver)
                return Tuple.Create(-1, evaluate(board));
            if (board.myPlayersTurn == 1) // Maximizing
            {
                v1 = int.MinValue;
                foreach (int move in board.moveSpace())
                {
                    if (myStopwatch.ElapsedMilliseconds > myTimeLimit - 1)
                        break;
                    Board tempBoard = new Board(board);
                    tempBoard.makeMove(move);
                    v2 = alphabeta(tempBoard, depth - 1, a, b).Item2;
                    if (v2 > v1)
                    {
                        v1 = v2;
                        bestMove = move;
                    }
                    a = Math.Max(a, v1);
                    if (a >= b)
                        break;
                }
            } else
            { // Minimizing
                v1 = int.MaxValue;
                foreach (int move in board.moveSpace())
                {
                    if (myStopwatch.ElapsedMilliseconds > myTimeLimit - 1)
                        break;
                    Board tempBoard = new Board(board);
                    tempBoard.makeMove(move);
                    v2 = alphabeta(tempBoard, depth - 1, a, b).Item2;
                    if (v2 < v1)
                    {
                        v1 = v2;
                        bestMove = move;
                    }
                    b = Math.Min(b, v1);
                    if (a >= b)
                        break;
                }
            }
            return Tuple.Create(bestMove, v1);
        }
        */

        /// Board evaluation function
        public int evaluate(Board b)
        {
            // TODO: improve heuristic
            if (b.myWinner == 0)
                return 0;
            else if (b.myWinner == 1)
                return 1;
            else
                return -1;
        }
    }
}
