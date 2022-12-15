using System;
using System.Linq;
using TicTacToe;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game(3);

            Player player1 = new Player("X");
            Player player2 = new Player("O");      


            //start game
            Player currentPlayer = player1;
            game.ShowInConsole();

            while (!game.Finished())
            {
               

                int positionToSetToken = int.Parse(currentPlayer.Go());

                game.SetValue(positionToSetToken, player1.Token);

                game.ShowInConsole();

                currentPlayer = currentPlayer == player1? player2 : player1;
            }

            game.ShowWinner();

           /* int position;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out position))
            {
                Console.WriteLine("Invalid position. Try again!");
                input = Console.ReadLine();
            }*/


        }
    }
}






