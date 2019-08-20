using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;


public class Color
{
    private readonly byte R;
    private readonly byte G;
    private readonly byte B;

    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public override string ToString()
    {
        if (R == 255 && G == 0 && B == 0)
        {
            return "Red";
        }
        if (R == 0 && G == 255 && B == 0)
        {
            return "Green";
        }
        if (R == 0 && G == 0 && B == 255)
        {
            return "Blue";
        }

        return "R:" + R + " G:" + G + " B:" + B;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        Color col = obj as Color;
        if (col == null)
        {
            return false;
        }

        return (R == col.R && B == col.B && G == col.G);
    }

    public override int GetHashCode()
    {
        return R + G + B;
    }
}

