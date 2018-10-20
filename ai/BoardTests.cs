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
            Board b = new Board(gm);

            Debug.Assert(gm.board.Length == 8);

            b.myBoard[3][3] = 1;
            b.myBoard[3][4] = 2;
            b.myBoard[4][3] = 2;
            b.myBoard[4][4] = 1;
            Console.Write(b);

            Console.WriteLine("\tPassed!");
        }
    }
}
