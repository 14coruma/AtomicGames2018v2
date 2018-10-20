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
            Console.WriteLine("\tPassed!");
        }
    }
}
