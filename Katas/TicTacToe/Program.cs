using System;

namespace TicTacToe 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boardSize = 3;
            Game game = new Game(boardSize);
            InputValidator validator = new InputValidator(game);

            Player player1 = new Player("X");
            Player player2 = new Player("O");      


            //start game
            Player currentPlayer = player1;
            game.ShowInConsole();

            while (!game.Finished())
            {
               

                int positionToSetToken = validator.GetInput(currentPlayer);

                game.SetCellValue(positionToSetToken, currentPlayer.Token);

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






