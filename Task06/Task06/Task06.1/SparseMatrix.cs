using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Task06._1
{
    class SparseMatrix : IEnumerable<int>
    {
        private int numberOfRows;
        private int numberOfColumns;
        private Dictionary<(int, int), int> notZeroElementStorage = new Dictionary<(int, int), int>();
        private int _version;


        public SparseMatrix(int i, int j)
        {
            if (!ProperIndexes(i, j, 1))
            {
                throw new ArgumentOutOfRangeException();
            }
            numberOfRows = i;
            numberOfColumns = j;
        }

        public int GetCount(int x)
        {
            int counter = 0;
            foreach (int element in this)
            {
                if (element == x)
                {
                    counter++;
                }
            }

            return counter;
        }

        public IEnumerable<(int, int, int)> GetNonzeroElements()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (notZeroElementStorage.ContainsKey((i, j)))
                    {
                        yield return (i, j, notZeroElementStorage[(i, j)]);
                    }
                }
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new SparseMatrixEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class SparseMatrixEnumerator : IEnumerator<int>
        {
            private readonly SparseMatrix _sparseMatrix;
            private readonly int _capturedVersion;
            private int _position = -1;

            public SparseMatrixEnumerator(SparseMatrix sparseMatrix)
            {
                _sparseMatrix = sparseMatrix;
                _capturedVersion = sparseMatrix._version;
            }
            
            public int Current
            {
                get
                {
                    int j;
                    int i = _position / _sparseMatrix.numberOfColumns;
                    j = _position % _sparseMatrix.numberOfColumns;

                    return _sparseMatrix[i, j];
                }
            }
            object IEnumerator.Current => Current;
            public bool MoveNext()
            {
                if (_capturedVersion != _sparseMatrix._version)
                {
                    throw new InvalidOperationException();
                }

                if (_position < (_sparseMatrix.numberOfRows * _sparseMatrix.numberOfColumns) - 1)
                {
                    _position++;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                _position = -1;
            }

            public void Dispose()
            {
                
            }
        }

        public void AddNotZeroElement(int i, int j, int element)
        {
            if (!ProperIndexes(i, j, 0)|| i >= numberOfRows || j >= numberOfColumns)
            {
                throw new ArgumentOutOfRangeException();
            }
            notZeroElementStorage.Add((i, j), element);
            _version++;
        }

        public int this[int i, int j]
        {
            get
            {
                if (!ProperIndexes(i, j, 0) || i >= numberOfRows || j >= numberOfColumns)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return notZeroElementStorage.ContainsKey((i, j)) ? notZeroElementStorage[(i, j)] : 0;
            }
            set
            {
                if (value == 0)
                {
                    if (notZeroElementStorage.ContainsKey((i, j)))
                    {
                        notZeroElementStorage.Remove((i, j));
                        _version++;
                    }
                }
                else
                {
                    AddNotZeroElement(i, j, value);
                    _version++;
                }
            }
        }

        public override string ToString()
        {
            string result = null;
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (notZeroElementStorage.ContainsKey((i, j)))
                    {
                        result += notZeroElementStorage[(i, j)].ToString();
                    }
                    else
                    {
                        result += 0;
                    }

                    result += " ";
                }
            }

            return result;
        }

        private bool ProperIndexes(int i, int j, int delimiter)
        {
            return i >= delimiter && j >= delimiter;
        }

    }
}
