using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace TicTacToeGame
{
    class TicTacToeGame
    {
        char playerLetter, compLetter;
        public const int HEAD = 1;
        public const int TAIL = 0;
        public char[] createBoard()
        {
            char[] board = new char[10];
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
            return board;
        }
        public char choosePlayerLetter()
        {
            Console.WriteLine("Choose either X or O");
            playerLetter = char.ToUpper(Console.ReadLine()[0]);
            if (playerLetter.Equals('X') || playerLetter.Equals('O'))
            {
                if (playerLetter.Equals('X'))
                {
                    compLetter = 'O';
                }
                else if (playerLetter.Equals('O'))
                {
                    compLetter = 'X';
                }
            }
            else
            {
                Console.WriteLine("Please,Choose either X or O");
                choosePlayerLetter();
            }
            return playerLetter;
        }
        public void showBoard(char[] board)
        {
            Console.WriteLine(board[1] + " | " + board[2] + " | " + board[3]);
            Console.WriteLine("---------");
            Console.WriteLine(board[4] + " | " + board[5] + " | " + board[6]);
            Console.WriteLine("---------");
            Console.WriteLine(board[7] + " | " + board[8] + " | " + board[9]);
        }
        public void userMove(char[] board)
        {
            Console.WriteLine("Enter your Move[1-9]");
            int move = Convert.ToInt32(Console.ReadLine());
            if (move < 10 && move > 0 && board[move] ==' ')
            {
                Console.WriteLine("Your Move is Valid");
                board[move] = playerLetter;
                showBoard(board);
                if (isWinner(board, playerLetter))
                    Console.WriteLine("Player Won");
                else
                    Console.WriteLine("Its Computers Turn now");
            }
            else
            {
                Console.WriteLine("Your Move is Not Valid ");
                userMove(board);
            }
        }
        public void toss()
        {
            Random random = new Random();
            int tossWon = random.Next(0,2);
            if (tossWon == HEAD)
            {
                Console.WriteLine("User will play first");
            }
            else
            {
                Console.WriteLine("Computer will play first");
            }
        }
        public bool isWinner(char[] b, char c)
        {
            return (
                (b[1] == c && b[2] == c && b[3] == c) ||
                (b[4] == c && b[5] == c && b[6] == c) ||
                (b[7] == c && b[8] == c && b[9] == c) ||
                (b[7] == c && b[4] == c && b[1] == c) ||
                (b[8] == c && b[5] == c && b[2] == c) ||
                (b[9] == c && b[6] == c && b[3] == c) ||
                (b[1] == c && b[5] == c && b[9] == c) ||
                (b[7] == c && b[5] == c && b[3] == c) 
                    );
        }
    }
}
