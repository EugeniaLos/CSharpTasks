using System;

class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();
        Console.WriteLine(stack.IsEmpty());
        stack.Push(2);
        stack.Push(1);
        stack.Push(0);
        Stack<int> stackk = new Stack<int>();
        stackk = stack.Reverse();
        Console.ReadLine();
    }
}

