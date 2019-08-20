using System;
using System.Runtime.InteropServices;


class Program
{
    static void Main(string[] args)
    {
        Key key = new Key(Note.A, Accidental.Sharp, Octave.Contra);
        Key keyy = new Key(Note.A, Accidental.Absence, Octave.Contra);
        Console.WriteLine(key);
        Console.WriteLine(Marshal.SizeOf(key));
        Console.ReadLine();
    }
}

