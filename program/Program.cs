using System;
using klasse;
namespace program;
class Program
{
    static void Main()
    {
        Board game = new Board();

        while (true)
        {

            // Board anzeigen
            Console.WriteLine(game);

            try
            {
                Console.WriteLine("Welche Figur bewegen? (z.B. King)");
                string name = Console.ReadLine();

                Console.WriteLine("Nach X:");
                int toX = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Nach Y:");
                int toY = Convert.ToInt32(Console.ReadLine());

                game.MoveFigure(name, toX, toY);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Fehler: " + ex.Message);
                Console.WriteLine("Enter drücken...");
                Console.ReadLine();
            }
        }
    }
}