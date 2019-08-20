using System;


class Program
{
    static void Main(string[] args)
    {
        Training training = new Training();
        training.Description = "C# training";
        Console.WriteLine(training.Description);
        Console.WriteLine(training.IsPractical());
        Practice practice = new Practice("Eugenia's mail", "Alexey's mail", "Task01");
        training.Add(practice);
        Console.WriteLine(training.IsPractical());
        Lecture lecture = new Lecture("Inheritance");
        training.Add(lecture);
        Console.WriteLine(training.IsPractical());
        Console.Read();
    }
}

