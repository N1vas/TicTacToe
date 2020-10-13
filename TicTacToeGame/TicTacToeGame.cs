using System;
using System.Collections.Generic;
using System.Text;
namespace TicTacToeGame
{
    class TicTacToeGame
    {
        public char[] createBoard()
        {
            char[] board = new char[10];
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
            return board;
        }
        public void choosePlayerLetter()
        {
            Console.WriteLine("Choose either X or O");
            string playerLetter = Console.ReadLine();
        }
    }
}
