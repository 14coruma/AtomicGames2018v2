using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ai
{
    public class BoardTests
    {
        public void testLegalMoves()
        {
            
            GameMessage gm = new GameMessage();
            gm.board = new int[8][];
            for (int i = 0; i < 8; i++)
                gm.board[i] = new int[8];
            gm.player = 2;

            Board b = new Board(gm);
            Debug.Assert(gm.board.Length == 8);

            b.myBoard[3][3] = 1;
            b.myBoard[3][4] = 2;
            b.myBoard[4][3] = 2;
            b.myBoard[4][4] = 1;
            Console.WriteLine(b);

            //Make sure legalMove works as it should.
            Console.Write("Testing Board.legalMove()... ");

            Console.Write( " 0 ");

            // Placing a piece that doesn't touch any other pieces
            /*
            for (int i = 0; i < 8; i++)
            {
                Debug.Assert(!b.legalMove(new int[] { 0, i }));
                Debug.Assert(!b.legalMove(new int[] { 1, i }));
                Debug.Assert(!b.legalMove(new int[] { 6, i }));
                Debug.Assert(!b.legalMove(new int[] { 7, i }));

                Debug.Assert(!b.legalMove(new int[] { i, 0 }));
                Debug.Assert(!b.legalMove(new int[] { i, 1 }));
                Debug.Assert(!b.legalMove(new int[] { i, 6 }));
                Debug.Assert(!b.legalMove(new int[] { i, 7 }));
            }

            Console.Write(" 1 ");

            // Legal moves
            Debug.Assert(b.legalMove(new int[] {2,3}));
            Debug.Assert(b.legalMove(new int[] {3,2}));
            Debug.Assert(b.legalMove(new int[] {4,5}));
            Debug.Assert(b.legalMove(new int[] {5,4}));

            Console.Write(" 2 ");

            // Remaining Illegal Moves
            Debug.Assert(!b.legalMove(new int[] {2,2}));
            Debug.Assert(!b.legalMove(new int[] {2,5}));
            Debug.Assert(!b.legalMove(new int[] {5,2}));
            Debug.Assert(!b.legalMove(new int[] {5,5}));

            Debug.Assert(!b.legalMove(new int[] {4,2}));
            Debug.Assert(!b.legalMove(new int[] {5,3}));
            Debug.Assert(!b.legalMove(new int[] {2,4}));
            Debug.Assert(!b.legalMove(new int[] {3,5}));

            Console.Write(" 3 ");

            */
            Console.WriteLine("Passed!");
        }

        public void testMakeMove()
        {
            GameMessage gm = new GameMessage();
            gm.board = new int[8][];
            for (int i = 0; i < 8; i++)
                gm.board[i] = new int[8];
            gm.player = 2;

            Board b = new Board(gm);
            Debug.Assert(gm.board.Length == 8);

            b.myBoard[3][3] = 1;
            b.myBoard[3][4] = 2;
            b.myBoard[4][3] = 2;
            b.myBoard[4][4] = 1;
            Console.WriteLine(b);

            Console.Write("Testing Board.makeMove()... ");


            // Turn One
            b.myPlayersTurn = 1;
            b.makeMove(new int[] { 3, 5 });
            Debug.Assert(b.myBoard[3][3] == 1);
            Debug.Assert(b.myBoard[3][4] == 1);
            Debug.Assert(b.myBoard[3][5] == 1);
            Debug.Assert(b.myBoard[4][3] == 2);
            Debug.Assert(b.myBoard[4][4] == 1);

            Console.Write(" 1 ");

            // Turn Two
            b.makeMove(new int[] { 2, 5 });
            Debug.Assert(b.myBoard[3][3] == 1);
            Debug.Assert(b.myBoard[3][5] == 1);
            Debug.Assert(b.myBoard[3][4] == 2);
            Debug.Assert(b.myBoard[4][3] == 2);
            Debug.Assert(b.myBoard[2][5] == 2);
            Debug.Assert(b.myBoard[4][4] == 1);

            Console.Write(" 2 ");

            // Turn 3
            b.makeMove(new int[] { 2, 4 });
            Debug.Assert(b.myBoard[3][3] == 1);
            Debug.Assert(b.myBoard[3][4] == 1);
            Debug.Assert(b.myBoard[3][5] == 1);
            Debug.Assert(b.myBoard[2][4] == 1);
            Debug.Assert(b.myBoard[4][4] == 1);
            Debug.Assert(b.myBoard[4][3] == 2);
            Debug.Assert(b.myBoard[2][5] == 2);

            Console.Write(" 3 ");

            // Turn 4
            // From now on only test items that should have changed, no longer checking if others remained the same.
            b.makeMove(new int[] { 2, 3 });
            Debug.Assert(b.myBoard[2][3] == 2);
            Debug.Assert(b.myBoard[2][4] == 2);
            Debug.Assert(b.myBoard[3][3] == 2);

            Console.Write(" 4 ");

            //Turn 5
            b.makeMove(new int[] { 1, 2 });
            Debug.Assert(b.myBoard[1][2] == 1);
            Debug.Assert(b.myBoard[2][3] == 1);

            Console.Write(" 5 ");

            // Turn 6
            b.makeMove(new int[] { 4, 5 });
            Debug.Assert(b.myBoard[4][5] == 2);
            Debug.Assert(b.myBoard[3][5] == 2);
            Debug.Assert(b.myBoard[4][4] == 2);

            Console.Write(" 6 ");

            // Turn 7
            b.makeMove(new int[] { 5, 6 });
            Debug.Assert(b.myBoard[5][6] == 1);
            Debug.Assert(b.myBoard[4][5] == 1);

            Console.Write(" 7 ");

            // Turn 8 (End State)
            b.makeMove(new int[] { 5, 5 });
            Debug.Assert(b.myBoard[5][5] == 2);
            Debug.Assert(b.myBoard[4][5] == 2);

            Debug.Assert(b.myBoard[1][2] == 1);
            Debug.Assert(b.myBoard[2][3] == 1);
            Debug.Assert(b.myBoard[2][4] == 2);
            Debug.Assert(b.myBoard[2][5] == 2);
            Debug.Assert(b.myBoard[3][3] == 2);
            Debug.Assert(b.myBoard[3][4] == 1);
            Debug.Assert(b.myBoard[3][5] == 2);
            Debug.Assert(b.myBoard[4][3] == 2);
            Debug.Assert(b.myBoard[4][4] == 2);
            Debug.Assert(b.myBoard[5][6] == 1);

            Console.Write(" 8 ");

            Console.Write(" Passed! ");

        }
    }
}
