using System;
using Lab04_TicTacToe.Classes;

namespace Lab04_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            Player p1 = new Player
            {
                Name = "Miriam",
                IsTurn = true,
                Marker = "X"
            };
            Player p2 = new Player
            {
                Name = "Joel",
                IsTurn = false,
                Marker = "O"
            };
            // TODO: Setup your game. Create a new method that creates your players and instantiates the game class. Call that method in your Main method.
            // You are requesting a Winner to be returned, Determine who the winner is output the celebratory message to the correct player. If it's a draw, tell them that there is no winner. 
            Game newGame = new Game(p1, p2);
            newGame.Play();

        }


    }
}
