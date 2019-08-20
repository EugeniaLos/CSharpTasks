using System;
using System.Collections.Generic;
using System.Text;


public class Circle: Figure
{
    private int _radius;

    public int Radius
    {
        get { return _radius; }
        set
        {
            if (value >= 0)
            {
                _radius = value;
            }
            else
            {
                _radius = 0;
            }
        }
    }

    public Circle(int radius, byte r, byte g, byte b) : base(r, g, b)
    {
        Radius = radius;
    }

    public override double Aria()
    {
        return 3.14 * Radius * Radius;
    }

    public override string ToString()
    {
        return Сol.ToString() + " Radius:" + Radius;
    }
}

