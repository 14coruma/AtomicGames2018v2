using System;
using System.Collections.Generic;
using System.Collections;
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
        public int myP1Score = 0;
        public int myP2Score = 0;

        /// Empty constructor - creates a new game board
        public Board()
        {
            myPlayersTurn = 1;
            myGameOver = false;
            myWinner = 0;
            myP1Score = 2;
            myP2Score = 2;
        }

        /// Copy constructor - creates a copy of a game board
        public Board(Board b)
        {
            myPlayersTurn = b.myPlayersTurn;
            myGameOver = b.myGameOver;
            myWinner = b.myWinner;
            myBoard = new int[8][];
            myP1Score = 0;
            myP2Score = 0;
            for (int row = 0; row < 8; row++)
            {
                myBoard[row] = new int[8];
                for (int col = 0; col < 8; col++)
                {
                    myBoard[row][col] = b.myBoard[row][col];
                    if (b.myBoard[row][col] == 1)
                        myP1Score++;
                    else if (b.myBoard[row][col] == 2)
                        myP2Score++;
                }
            }
        }

        /// Board constructor from gameMessage
        public Board(GameMessage gm)
        {
            myPlayersTurn = gm.player;
            myGameOver = false;
            myBoard = gm.board.Select(a => a.ToArray()).ToArray();
            updateScores();
        }

        /// Checks and returns list of cases that are legal
        public ArrayList legalMove(int[] pos)
        {
            if (myBoard[pos[0]][pos[1]] > 0) // Already occupied
                return new ArrayList();

            ArrayList legalCases = new ArrayList();
            for (int i = 0; i < 8; i++) // Look at each line around our move
            {
                int j;
                int k;
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
                        if (j >= 8)
                            break;
                        if (myBoard[pos[0]][j] == myPlayersTurn)
                            legalCases.Add(i);
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
                        if (j <= 0)
                            break;
                        if (myBoard[pos[0]][j] == myPlayersTurn)
                            legalCases.Add(i);
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
                        if (j >= 8)
                            break;
                        if (myBoard[j][pos[1]] == myPlayersTurn)
                            legalCases.Add(i);
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
                        if (j <= 0)
                            break;
                        if (myBoard[j][pos[1]] == myPlayersTurn)
                            legalCases.Add(i);
                        break;
                    case 4: // TopL to BotR
                        j = pos[0]+2;
                        k = pos[1]+2;
                        if (j > 7 || k > 7 || myBoard[pos[0]+1][pos[1]+1] != (myPlayersTurn % 2) + 1)
                            break;
                        while (j < 7 && k < 7)
                        {
                            if (myBoard[j][k] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            j++;
                            k++;
                        }
                        if (j >= 8)
                            break;
                        if (myBoard[j][k] == myPlayersTurn)
                            legalCases.Add(i);
                        break;
                    case 5: // BotR to TopL
                        j = pos[0]-2;
                        k = pos[1]-2;
                        if (j < 0 || k < 0 || myBoard[pos[0]-1][pos[1]-1] != (myPlayersTurn % 2) + 1)
                            break;
                        while (j > 0 && k > 0)
                        {
                            if (myBoard[j][k] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            j--;
                            k--;
                        }
                        if (j <= 0 || k <= 0)
                            break;
                        if (myBoard[j][k] == myPlayersTurn)
                            legalCases.Add(i);
                        break;
                    case 6: // TopR to BotL
                        j = pos[0]+2;
                        k = pos[1]-2;
                        if (j > 7 || k < 0 || myBoard[pos[0]+1][pos[1]-1] != (myPlayersTurn % 2) + 1)
                            break;
                        while (j < 7 && k > 0)
                        {
                            if (myBoard[j][k] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            j++;
                            k--;
                        }
                        if (j >= 8 || k <= 0)
                            break;
                        if (myBoard[j][k] == myPlayersTurn)
                            legalCases.Add(i);
                        break;
                    case 7: // BotL to TopR
                        j = pos[0]-2;
                        k = pos[1]+2;
                        if (j < 0 || k > 7 || myBoard[pos[0]-1][pos[1]+1] != (myPlayersTurn % 2) + 1)
                            break;
                        while (j > 0 && k < 7)
                        {
                            if (myBoard[j][k] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            j--;
                            k++;
                        }
                        if (j <= 0 || k >= 8)
                            break;
                        if (myBoard[j][k] == myPlayersTurn)
                            legalCases.Add(i);
                        break;
                }
            }
            return legalCases;
        }

        /// Returns a list of all possible moves
        public List<int[]> moveSpace()
        {
            List<int[]> moves = new List<int[]>();
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                   if (legalMove(new int[] { row, col }).Count > 0)
                        moves.Add(new int[] { row, col });
                }
            }
            return moves;
        }

        /// Makes a move, returns legalMove()
        public bool makeMove(int[] pos)
        {
            ArrayList legalCases = legalMove(pos);
            if (legalCases.Count == 0)
                return false;
            myBoard[pos[0]][pos[1]] = myPlayersTurn;
            foreach (int i in legalCases) // Look at each line around our move that will have captures
            {
                int j;
                int k;
                switch (i)
                {
                    case 0: // L to R
                        j = pos[1] + 1;
                        while (j < 8)
                        {
                            if (myBoard[pos[0]][j] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            myBoard[pos[0]][j] = myPlayersTurn;
                            j++;
                        }
                        break;
                    case 1: // R to L
                        j = pos[1] - 1;
                        while (j > 0)
                        {
                            if (myBoard[pos[0]][j] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            myBoard[pos[0]][j] = myPlayersTurn;
                            j--;
                        }
                        break;
                    case 2: // Top to Bot
                        j = pos[0] + 1;
                        while (j < 8)
                        {
                            if (myBoard[j][pos[1]] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            myBoard[j][pos[1]] = myPlayersTurn;
                            j++;
                        }
                        break;
                    case 3: // Bot to Top
                        j = pos[0] - 1;
                        while (j > 0)
                        {
                            if (myBoard[j][pos[1]] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            myBoard[j][pos[1]] = myPlayersTurn;
                            j--;
                        }
                        break;
                    case 4: // TopL to BotR
                        j = pos[0] + 1;
                        k = pos[1] + 1;
                        while (j < 7 && k < 7)
                        {
                            if (myBoard[j][k] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            myBoard[j][k] = myPlayersTurn;
                            j++;
                            k++;
                        }
                        break;
                    case 5: // BotR to TopL
                        j = pos[0] - 1;
                        k = pos[1] - 1;
                        while (j > 0 && k > 0)
                        {
                            if (myBoard[j][k] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            myBoard[j][k] = myPlayersTurn;
                            j--;
                            k--;
                        }
                        break;
                    case 6: // TopR to BotL
                        j = pos[0] + 1;
                        k = pos[1] - 1;
                        while (j < 7 && k > 0)
                        {
                            if (myBoard[j][k] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            myBoard[j][k] = myPlayersTurn;
                            j++;
                            k--;
                        }
                        break;
                    case 7: // BotL to TopR
                        j = pos[0] - 1;
                        k = pos[1] + 1;
                        while (j > 0 && k < 7)
                        {
                            if (myBoard[j][k] != (myPlayersTurn % 2) + 1)
                            {
                                break;
                            }
                            myBoard[j][k] = myPlayersTurn;
                            j--;
                            k++;
                        }
                        break;
                }
            }

            myPlayersTurn = (myPlayersTurn % 2) + 1; // update players turn
            if (moveSpace().Count == 0)              // revert players turn if they don't have moves
                myPlayersTurn = (myPlayersTurn % 2) + 1;


            gameOver();     // Check for gameOver
            updateScores(); // Update scores
            return true;
        }

        /// Checks for game over conditions,
        /// returns value of the winning player
        public int gameOver()
        {
            myP1Score = 0;
            myP2Score = 0;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (myBoard[row][col] == 0)
                        return 0;
                    else if (myBoard[row][col] == 1)
                        myP1Score++;
                    else if (myBoard[row][col] == 2)
                        myP2Score++;
                }
            }
            if (myP1Score > myP2Score)
                return 1;
            else
                return 2;
        }

        public void updateScores()
        {
            myP1Score = 0;
            myP2Score = 0;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (myBoard[row][col] == 1)
                        myP1Score++;
                    if (myBoard[row][col] == 2)
                        myP2Score++;
                }
            }
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
