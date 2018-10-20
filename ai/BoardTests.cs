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
            Console.Write("Testing Board.legalMove()... ");
            GameMessage gm = new GameMessage();
            gm.board = new int[8][];
            for (int i = 0; i < 8; i++)
                gm.board[i] = new int[8];
            gm.player = 1;
            gm.board[0][1] = 2;
            gm.board[0][2] = 1;
            gm.board[0][6] = 2;
            gm.board[0][7] = 1;

            Board b = new Board(gm);
            Debug.Assert(gm.board.Length == 8);
            Debug.Assert(b.legalMove(new int[] {0, 0}));
            Debug.Assert(!b.legalMove(new int[] {0, 1}));
            Debug.Assert(b.legalMove(new int[] {0, 5}));

            b.myPlayersTurn = 2;
            b.myBoard[1][1] = 1;
            Debug.Assert(b.legalMove(new int[] { 0, 3 }));
            Debug.Assert(b.legalMove(new int[] { 2, 1 }));
            b.myBoard[1][2] = 2;
            b.myBoard[2][2] = 2;
            b.myPlayersTurn = 1;
            Debug.Assert(b.legalMove(new int[] { 3, 2 }));

            b.myBoard[1][6] = 2;
            Console.WriteLine(b);
            b.myPlayersTurn = 2;
            Debug.Assert(b.legalMove(new int[] { 0, 0 }));
            Debug.Assert(!b.legalMove(new int[] { 3, 3 }));
            b.myPlayersTurn = 1;
            Debug.Assert(b.legalMove(new int[] { 3, 3 }));
            Debug.Assert(b.legalMove(new int[] { 2, 5 }));

            Console.WriteLine("\tPassed!");
        }
    }
}
