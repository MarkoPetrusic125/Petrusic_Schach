using System;

namespace klasse;

public class Board
{
    private Figures[,] board = new Figures[8, 8];

    private Player white = new Player("white");





    public Board()
    {
        SetupBoard();
    }



    public void SetupBoard()
    {
        board[4, 0] = new Figures("King", white.GetColor());
        board[0, 0] = new Figures("Rook", white.GetColor());
        board[7, 0] = new Figures("Rook", white.GetColor());

    }




    public void SetFigure(int x, int y, Figures figure)
    {
        board[x, y] = figure;
    }


    public override string ToString()
    {
        string result = "";

        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (board[x, y] == null)
                {
                    if ((x + y) % 2 == 0)
                    {
                        result += "   ";
                    }
                    else
                    {
                        result += " # ";
                    }
                }
                else
                {
                    result += " " + board[x, y].ToString() + " ";
                }

                if (x < 7)
                {
                    result += "|";
                }
            }

            if (y < 7)
            {
                result += "\n---+---+---+---+---+---+---+---\n";
            }
        }
        return result;
    }

}