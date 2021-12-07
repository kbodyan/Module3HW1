using System;
using System.Collections;
using System.Collections.Generic;

namespace OwnCollection
{
    public class ListCollection<T> : ICollection<T>, IEnumerable<T>, IList<T>, ICloneable
    {
        private T[] _array;
        private int _position = 0;

        public ListCollection()
        {
            _array = new T[10];
        }

        public ListCollection(int size)
        {
            _array = new T[size + 10];
        }

        public ListCollection(ICollection<T> collection)
        {
            AddRange(collection);
        }

        public int Capacity
        {
            get
            {
                return _array.Length;
            }
        }

        public int Count
        {
            get
            {
                return _position;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return _array.IsReadOnly;
            }
        }

        public T this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        public object Clone()
        {
            var result = new ListCollection<T>(_array.Length);
            result.AddRange(_array);
            return result;
        }

        public override string ToString()
        {
            var result = string.Empty;
            for (var i = 0; i < _position; i++)
            {
                result += $"{_array[i].ToString()}, ";
            }

            return result;
        }

        public void Add(T item)
        {
            if (_position >= _array.Length)
            {
                Resize(1);
            }

            _array[_position] = item;
            _position++;
        }

        public void Insert(int index, T item)
        {
            if (index <= _position)
            {
                Add(item);
                var temp = _array[_position - 1];
                Array.Copy(_array, index, _array, index + 1, _position - index);
                _array[index] = temp;
            }
        }

        public void AddRange(ICollection<T> collection)
        {
            if (_position + collection.Count >= _array.Length)
            {
                Resize(collection.Count);
            }

            collection.CopyTo(_array, _position);
            _position += collection.Count;
        }

        public void Clear()
        {
            _position = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _position; i++)
            {
                yield return _array[i];
            }
        }

        public bool Remove(T item)
        {
            var mask = new bool[_position];
            var count = 0;
            for (var i = 0; i < _position; i++)
            {
                if (_array[i].GetHashCode() == item.GetHashCode())
                {
                    mask[i] = true;
                    count++;
                }
            }

            if (count > 0)
            {
                Zip(mask, count);
                _position -= count;
                if (_array.Length - _position > 10)
                {
                    Resize(_position - _array.Length + 10);
                }

                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < _position)
            {
                var mask = new bool[_position];
                mask[index] = true;
                Zip(mask, 1);
                _position--;
            }
        }

        public void Sort()
        {
            Array.Sort<T>(_array, 0, _position);
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < _position; i++)
            {
                if (_array[i].GetHashCode() == item.GetHashCode())
                {
                    return i;
                }
            }

            return -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _array.CopyTo(array, arrayIndex);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var i = 0; i < _position; i++)
            {
                yield return _array[i];
            }
        }

        private void Resize(int size)
        {
            var newArray = new T[(_array.Length + size) + 10];
            Array.Copy(_array, newArray, _position);
            _array = newArray;
        }

        private void Zip(bool[] mask, int count)
        {
            var tempPosition = 0;
            for (var i = 0; i < _position; i++, tempPosition++)
            {
                while (mask[i])
                {
                    i++;
                    count--;
                }

                if (i != tempPosition)
                {
                    _array[tempPosition] = _array[i];
                }
            }
        }
    }
}
