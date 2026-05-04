namespace klasse;

public class Figures
{
    private string Name;
    private string Color;

    public string GetName()
    {
        return Name;
    }

    public string GetColor()
    {
        return Color;
    }

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

        if (Name == "Rook1")
        {
            if (Color == "white") return "R¹";
            else return "r¹";
        }

        if (Name == "Rook2")
        {
            if (Color == "white") return "R²";
            else return "r²";
        }
        return "";
    }
}