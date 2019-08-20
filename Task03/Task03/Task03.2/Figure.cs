using System;
using System.Collections.Generic;
using System.Text;


public abstract class Figure
{
    protected Color MyColor { get; }

    public Figure(byte r, byte g, byte b)
    {
        MyColor = new Color(r, g, b);
    }

    public Figure(Color color)
    {
        MyColor = color;
    }

    public abstract double Aria();

}

