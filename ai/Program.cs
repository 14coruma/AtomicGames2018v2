using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai 
{
    public class Program
    {
        static void Main(string[] args)
        {
            BoardTests bt = new BoardTests();
            bt.testLegalMoves();
            Console.ReadLine();
        }
    }
}
