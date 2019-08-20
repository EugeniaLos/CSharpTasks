using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;


public class Stack<T> : IStack<T>
{
    private int index;
    private readonly T[] data = new T[100];

    public Stack()
    {
        index = 0;
    }

    public void Push(T x)
    {
        if (index > 100)
        {
            throw new Exception("The maximum stack capacity is already achieved");
        }
        data[index++] = x;
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new Exception("The stack is empty!");
        }
        return data[--index];
    }

    public bool IsEmpty()
    {
        return index == 0;
    }
}
