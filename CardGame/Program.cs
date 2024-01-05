using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                Game game = new Game();
                game.Start();
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }
    }
}
