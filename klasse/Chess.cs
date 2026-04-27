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
        board[0, 0] = new Figures("Rook1", white.GetColor());
        board[7, 0] = new Figures("Rook2", white.GetColor());

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


    public void MoveFigure(string name, int toX, int toY)
    {

        if (toX < 0 || toX > 7 || toY < 0 || toY > 7)
        {
            throw new ArgumentException("Ziel ist außerhalb vom Brett");
        }

        int fromX = 0;
        int fromY = 0;
        bool found = false;

        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (board[x, y] != null)
                {
                    if (board[x, y].GetName() == name)
                    {
                        fromX = x;
                        fromY = y;
                        found = true;
                    }
                }
            }
        }

        if (found == false)
            throw new ArgumentException("Figur nicht gefunden");

        if (board[fromX, fromY] == null)
        {
            throw new ArgumentException("Figur existiert nicht");
        }

        if (fromX == toX && fromY == toY)
        {
            throw new ArgumentException("Figur bleibt stehen");
        }

        if (name == "King")
        {
            int dx = Math.Abs(toX - fromX);
            int dy = Math.Abs(toY - fromY);

            if (dx > 1 || dy > 1)
                throw new ArgumentException("King darf nur 1 Feld bewegen");
        }

        if (name == "Rook1" || name == "Rook2")
        {
            if (fromX != toX && fromY != toY)
                throw new ArgumentException("Rook darf nur gerade ziehen");
        }

        board[toX, toY] = board[fromX, fromY];
        board[fromX, fromY] = null;
    }
}