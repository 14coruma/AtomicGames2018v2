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
        public bool legalMove(int[] pos)
        {
            if (myBoard[pos[0]][pos[1]] > 0) // Already occupied
                return false;
            for (int i = 0; i < 8; i++) // Look at each line around our move
            {
                int j;
                switch (i)
                {
                    case 0: // L to R
                        j = pos[1]+2;
                        if (j > 7 || myBoard[pos[0]][pos[1]+1] != (myPlayersTurn % 2) + 1)
                            break;
                        while (j < 8)
                        {
                            if (myBoard[pos[0]][j] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            j++;
                        }
                        if (myBoard[pos[0]][j] == myPlayersTurn)
                            return true;
                        break;
                    case 1: // R to L
                        j = pos[1]-2;
                        if (j < 0 || myBoard[pos[0]][pos[1]-1] != (myPlayersTurn % 2) + 1)
                            break;
                        while (j > 0)
                        {
                            if (myBoard[pos[0]][j] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            j--;
                        }
                        if (myBoard[pos[0]][j] == myPlayersTurn)
                            return true;
                        break;
                    case 2: // Top to Bot
                        j = pos[0]+2;
                        if (j > 7 || myBoard[pos[0]+1][pos[1]] != (myPlayersTurn % 2) + 1)
                            break;
                        while (j < 8)
                        {
                            if (myBoard[j][pos[1]] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            j++;
                        }
                        if (myBoard[j][pos[1]] == myPlayersTurn)
                            return true;
                        break;
                    case 3: // Bot to Top
                        j = pos[0]-2;
                        if (j < 0 || myBoard[pos[0]-1][pos[1]] != (myPlayersTurn % 2) + 1)
                            break;
                        while (j > 0)
                        {
                            if (myBoard[j][pos[1]] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            j--;
                        }
                        if (myBoard[j][pos[1]] == myPlayersTurn)
                            return true;
                        break;
                }
            }
            return false;
        }

        /// Returns a list of all possible moves
        public List<int> moveSpace()
        {
            List<int> moves = new List<int>();
            return moves;
        }

        /// Makes a move, returns legalMove()
        public bool makeMove(int[] pos)
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
