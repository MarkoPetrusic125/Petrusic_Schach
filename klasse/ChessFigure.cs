namespace klasse;

public class Figures
{
    private string Name;
    private string Color;

    public Figures(string name, string color)
    {
        Name = name;
        Color = color;
    }

public override string ToString()
{
    if (Name == "King")
    {
        if (Color == "white") return "K";
        else return "k";
    }

        if (Name == "Rook")
    {
        if (Color == "white") return "R";
        else return "r";
    }

    return "";
}
}