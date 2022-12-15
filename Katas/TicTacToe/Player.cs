using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Player
    {
        internal string Token { get; }
        internal Player(string token) => Token = token;


        internal string Go()
        {
            Console.WriteLine();
            Console.WriteLine($"Player {Token} - GO!");

                
            return Console.ReadLine();
        }
    }
}
