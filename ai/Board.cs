using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicGames2018
{
    class Board
    {
        public int myPlayersTurn;
        public bool myGameOver;
        public int myWinner;

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

        ///  We probably need some sort of constructor / update function to 
        ///  update our board to the new Atomic Object game state
        public void update(List<int> updates)
        {
        }

        /// Checks and returns if a move is legal
        public bool legalMove(int pos)
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
        public bool makeMove(int pos)
        {
            return false;
        }

        /// Checks for game over conditions,
        /// returns value of the winning player
        public int gameOver()
        {
            return 0;
        }
    }
}
