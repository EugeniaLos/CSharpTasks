using System.Runtime.InteropServices;
using System;

namespace Task05._2
{
    public sealed class Interval
    {
        private int A { get; }
        private int B { get; }

        public Interval(int a, int b)
        {
            if (a < b)
            {
                A = a;
                B = b;
            }
            else
            {
                A = b;
                B = a;
            }
        }

        public uint Length() => (uint)(B - A);

        public override bool Equals(object obj)
        {
            return obj is Interval other && Equals(other);
        }

        public bool Equals(Interval other)
        {
            return this.A == other.A && this.B == other.B;
        }

        public override int GetHashCode()
        {
            int result = A + B;
            return result.GetHashCode();
        }

        public override string ToString()
        {
            return $"A = {A} B = {B}"; ;
        }

        public static Interval operator +(Interval a, Interval b)
        {
            Interval result = new Interval(a.A + b.A, a.B + b.B);
            return result;
        }

        public static explicit operator uint(Interval a) => a.Length();

    }
}