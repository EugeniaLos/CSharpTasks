using System;
using System.Collections.Generic;
using System.Text;


public struct Key: IComparable
{
    private readonly byte _storage;

    public Octave Octave
    {
        get {return (Octave)(_storage & 7); }
    }
    public Note Note
    {
        get { return (Note)((_storage & 56) >> 3); }
    }
    public Accidental Accidental
    {
        get { return (Accidental)((_storage & 192) >> 6); }
    }




    public Key(Note note, Accidental accidental, Octave octave)
    {
        _storage = (byte) ((byte) accidental << 6);
        _storage += (byte)((byte)note << 3);
        _storage += (byte)octave;
    }

    public override string ToString()
    {
        string key = Enum.GetName(typeof(Note), Note);
        
        switch ((int) Accidental)
        {
            case 2:
                key += '#';
                break;
            case 0:
                key += 'b';
                break;
        }

        switch ((int) Octave)
        {
            case 0:
                key += "(sub-contra octave)";
                break;
            case 1:
                key += "(contra octave)";
                break;
            case 2:
                key += "(great octave)";
                break;
            case 3:
                key += "(small octave)";
                break;
            case 4:
                key += "(one-line octave)";
                break;
            case 5:
                key += "(two-line octave)";
                break;
            case 6:
                key += "(three-line octave)";
                break;
            case 7:
                key += "(four-line octave)";
                break;
            case 8:
                key += "(five-line octave)";
                break;
        }

        return key;
    }

    public bool Equals(Key other)
    {
        return Note == other.Note && Accidental == other.Accidental && Octave == other.Octave;
    }

    public override int GetHashCode()
    {
        return (int) Note * 100 + (int) Accidental + 10 + (int) Octave;
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        return obj is Key other && Equals(other);
    }

    public int CompareTo(object obj)
    {
        if (!(obj is Key other))
        {
            throw new Exception("There is no ability to compare two objects because their types differ");
        }

        if (Accidental == other.Accidental && Note == other.Note && Octave == other.Octave)
        {
            return 0;
        }

        if ((int) Octave < (int) other.Octave)
            return -1;

        if ((int)Octave > (int)other.Octave)
        {
            return 1;
        }

        if ((int)Note < (int)other.Note)
        {
            return -1;
        }

        if ((int)Note > (int)other.Note)
        {
            return 1;
        }

        if ((int)Accidental < (int)other.Accidental)
        {
            return -1;
        }

        return 1;
    }
}
