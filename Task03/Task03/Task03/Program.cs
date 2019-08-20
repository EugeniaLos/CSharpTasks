using System;

class Program
{
    static void Main(string[] args)
    {
        Color col = new Color(250, 250, 250);
        Console.WriteLine(col.GetHashCode());
        Console.ReadLine();
    }
}