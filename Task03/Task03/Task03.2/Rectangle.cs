using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle: Figure
{
    private int _width, _height;

    public int Width
    {
        get { return _width; }
        set
        {
            if (value >= 0)
            {
                _width = value;
            }
            else
            {
                _height = 0;
            }
        }
    }

    public int Height
    {
        get { return _height; }
        set
        {
            if (value >= 0)
            {
                _height = value;
            }
            else
            {
                _height = 0;
            }
        }
    }

    public Rectangle(int width, int height, byte r, byte g, byte b) : base(r, g, b)
    {
        Width = width;
        Height = height;
    }

    public override double Aria()
    {
        return Height * Width;
    }

    public override string ToString()
    {
        return Сol.ToString() + " Width:" + Width + " Height:" + Height;
    }
}

