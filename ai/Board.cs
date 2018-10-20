using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai 
{
    public class Board
    {
        public int myPlayersTurn;
        public bool myGameOver;
        public int myWinner;
        public int[][] myBoard;

        /// Empty constructor - creates a new game board
        public Board()
        {
            myPlayersTurn = 1;
            myGameOver = false;
            myWinner = 0;
        }

        /// Copy constructor - creates a copy of a game board
        public Board(Board b)
        {
            myPlayersTurn = b.myPlayersTurn;
            myGameOver = b.myGameOver;
            myWinner = b.myWinner;
        }

        /// Board constructor from gameMessage
        public Board(GameMessage gm)
        {
            myPlayersTurn = gm.player;
            myGameOver = false;
            myBoard = gm.board.Select(a => a.ToArray()).ToArray();
        }

        ///  We probably need some sort of constructor / update function to 
        ///  update our board to the new Atomic Object game state
        public void update(List<int> updates)
        {
        }

        /// Checks and returns if a move is legal
        public bool legalMove(int[] move)
        {
            return false;
        }

        /// Returns a list of all possible moves
        public List<int> moveSpace()
        {
            List<int> moves = new List<int>();
            return moves;
        }

        /// Makes a move, returns legalMove()
        public bool makeMove(int move)
        {
            return false;
        }

        /// Checks for game over conditions,
        /// returns value of the winning player
        public int gameOver()
        {
            return 0;
        }

        /// write board
        public override string ToString()
        {
            string boardString;
            boardString = "\n";
            
            for(int i=0; i < 8; i++)
            {
                for(int j=0; j < 8; j++)
                {
                    boardString = boardString + myBoard[i][j] + " ";
                    if (j == 7)
                    {
                        boardString = boardString + '\n';
                    }
                }
            }

            return boardString;
        }
    }
}
