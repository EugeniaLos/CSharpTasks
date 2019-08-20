using System;

namespace Task05._1
{
    public class Matrix<T>
    {
        private readonly T[] _diagonal;

        public int Size => _diagonal.Length;

        public Matrix(params T[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }

            _diagonal = new T[data.Length];
            data.CopyTo(_diagonal, 0);
        }

        public T this[int i, int j]
        {
            get
            {
                if (IsCorrect(i) && IsCorrect(j))
                {
                    return i == j ? _diagonal[i] : default(T);
                }

                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (!IsCorrect(i) || !IsCorrect(j))
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (i == j)
                {
                    if (!value.Equals(_diagonal[i]))
                    {
                        ElementChanged?.Invoke(i, j, _diagonal[i], value);
                        _diagonal[i] = value;
                    }
                }
            } 
        }

        public event Handler<T> ElementChanged;
        private bool IsCorrect(int i) => i >= 0 && i < Size;
    }
}