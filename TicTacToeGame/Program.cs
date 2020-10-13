using System;
namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToe Game");
            TicTacToeGame game = new TicTacToeGame();
            game.createBoard();
            game.choosePlayerLetter();
        }
    }
}
