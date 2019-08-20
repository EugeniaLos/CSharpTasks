using System;

class Program
{
    static void Main(string[] args)
    {
        Figure[] figures = new Figure[2];
        figures[0] = new Circle(3, 255, 0, 0);
        figures[1] = new Rectangle(3, 2, 34, 77, 0);
        foreach (Figure figure in figures)
        {
            Console.WriteLine(figure.ToString());
            Console.WriteLine(figure.Aria());
        }
        Console.Read();
    }
}