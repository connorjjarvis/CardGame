using System;
using CardGame;
using CardGame.Interfaces;

public class Game
{
    private IPlayer player;
    private IBoard board;
    private Error error;
    public Game()
    {
        player = new Player();
        board = new Board(player);
    }

    public void Start()
    {
        while (true)
        {
            board.Refresh(error);
            error = null;
            string input = Console.ReadLine();

            if (input == "!quit")
            {
                break;
            } 
            else
            {
                error = board.ValidateAction(input);
                player.CalculateScore();
            }

        }
    }

    
}
